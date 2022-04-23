package com.example.mobilprog_oxoobf;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.res.Resources;
import android.database.Cursor;
import android.os.Bundle;
import android.os.Handler;
import android.os.RemoteException;
import android.speech.tts.TextToSpeech;
import android.util.Log;
import android.view.View;
import android.view.ViewDebug;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

import com.opencsv.CSVParser;
import com.opencsv.CSVParserBuilder;
import com.opencsv.CSVReader;
import com.opencsv.CSVReaderBuilder;
import com.opencsv.ICSVParser;

import java.io.IOException;
import java.io.FileReader;
import java.util.Random;
import java.util.function.Function;

public class Kerdesek extends AppCompatActivity {

    private TextView NevTextView;
    TextToSpeech tts_UK;
    TextToSpeech tts_GER;
    private TextView KerdesSzam;
    private TextView OsszKerdes;
    private TextView PontszamLbl;
    private Button KovetkezoBn;
    private Button VegeBn;
    private ImageView image;
    private RadioGroup RadioGr;
    private RadioButton rb1;
    private RadioButton rb2;
    private RadioButton rb3;
    private ImageButton LejatszBn;
    Locale mLangEng;
    Locale mLangDe;
    private Map<String, String> myMap;
    DataBaseSeged db;
    int COLOR_RED = android.graphics.Color.rgb(255, 0, 0);
    int COLOR_GREEN = android.graphics.Color.rgb(0, 255, 0);
    int COLOR_WHITE = android.graphics.Color.rgb(0, 0, 0);
    int COLOR_TRANSPARENT = android.graphics.Color.argb(0, 0, 0, 0);

    @Override
    public void onBackPressed() {
        return;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_kerdesek);

        //Toast.makeText(this, TaroloSeged.Username+"\n"+TaroloSeged.KerdesSzamlalo+"\n"+TaroloSeged.OsszKerdes+"\n"+TaroloSeged.Level+"\n"+
                //TaroloSeged.Language, Toast.LENGTH_LONG).show();

        // adatbazis
        db = new DataBaseSeged(this);

        tts_UK = new TextToSpeech(getApplicationContext(), new TextToSpeech.OnInitListener() {
            @Override
            public void onInit(int status) {
                if (status != TextToSpeech.ERROR) {
                    int result = tts_UK.setLanguage(mLangEng);
                    if (result == TextToSpeech.LANG_MISSING_DATA || result == TextToSpeech.LANG_NOT_SUPPORTED) {
                        Log.e("Text2SpeechWidget", result + " is not supported");
                        showMessage("Hiba", result + " is not supported");
                    }
                }

            }
        });

        tts_GER = new TextToSpeech(getApplicationContext(), new TextToSpeech.OnInitListener() {
            @Override
            public void onInit(int status) {
                if (status != TextToSpeech.ERROR) {
                    int result = tts_GER.setLanguage(mLangDe);
                    if (result == TextToSpeech.LANG_MISSING_DATA || result == TextToSpeech.LANG_NOT_SUPPORTED) {
                        Log.e("Text2SpeechWidget", result + " is not supported");
                        showMessage("Hiba", result + " is not supported");
                    }
                }
            }
        });

        LejatszBn = (ImageButton) findViewById(R.id.Lejatszas);
        mLangEng = new Locale("en");
        mLangDe = new Locale("de");
        NevTextView = (TextView) findViewById(R.id.NevText);
        KerdesSzam = (TextView) findViewById(R.id.kerdesTV);
        OsszKerdes = (TextView) findViewById(R.id.osszkerdesTV);
        PontszamLbl = (TextView) findViewById(R.id.PontszamLbl);
        KovetkezoBn = (Button) findViewById(R.id.koviKerdesBttn);
        VegeBn = (Button) findViewById(R.id.VegeBttn);
        image = (ImageView) findViewById(R.id.imageView);
        rb1 = (RadioButton) findViewById(R.id.FirstoptionRb);
        rb2 = (RadioButton) findViewById(R.id.SecondoptionRb);
        rb3 = (RadioButton) findViewById(R.id.ThirdoptionRb);
        myMap = new HashMap<>();
        RadioGr = (RadioGroup) findViewById(R.id.RadioGr);

        Feltolt();
        Map_Feltolt();
        Feladat_Frissit();

        VegeBn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                db.InsertIntoEredmenyek();
                Intent eredmeny = new Intent(Kerdesek.this, Eredmenyek.class);
                startActivity(eredmeny);
                //showMessage("Pontszam: ", String.valueOf(TaroloSeged.Pontszam) +" / "+ String.valueOf(TaroloSeged.OsszKerdes));
            }
        });

        KovetkezoBn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(TaroloSeged.KerdesSzamlalo == TaroloSeged.OsszKerdes){
                    db.InsertIntoEredmenyek();
                    Intent eredmeny = new Intent(Kerdesek.this, Eredmenyek.class);
                    startActivity(eredmeny);
                }
                else {
                    if(rb1.isChecked() || rb2.isChecked() || rb3.isChecked()){
                        if(rb1.isChecked() && rb1.getText().equals(TaroloSeged.HelyesValasz)){
                            TaroloSeged.Pontszam += 1;
                            rb1.setBackgroundColor(COLOR_GREEN);
                        }
                        else if(rb2.isChecked() && rb2.getText().equals(TaroloSeged.HelyesValasz)){
                            TaroloSeged.Pontszam += 1;
                            rb2.setBackgroundColor(COLOR_GREEN);
                        }
                        else if(rb3.isChecked() && rb3.getText().equals(TaroloSeged.HelyesValasz)){
                            TaroloSeged.Pontszam += 1;
                            rb3.setBackgroundColor(COLOR_GREEN);
                        }
                        else{

                            if(rb1.isChecked() && !rb1.getText().equals(TaroloSeged.HelyesValasz))
                            {
                                rb1.setBackgroundColor(COLOR_RED);
                                if(rb2.getText().equals(TaroloSeged.HelyesValasz)){
                                    rb2.setBackgroundColor(COLOR_GREEN);
                                }
                                if(rb3.getText().equals(TaroloSeged.HelyesValasz)){
                                    rb3.setBackgroundColor(COLOR_GREEN);
                                }
                            }
                            else if(rb2.isChecked() && !rb2.getText().equals(TaroloSeged.HelyesValasz))
                            {
                                rb2.setBackgroundColor(COLOR_RED);
                                if(rb1.getText().equals(TaroloSeged.HelyesValasz)){
                                    rb1.setBackgroundColor(COLOR_GREEN);
                                }
                                if(rb3.getText().equals(TaroloSeged.HelyesValasz)){
                                    rb3.setBackgroundColor(COLOR_GREEN);
                                }
                            }
                            else if(rb3.isChecked() && !rb3.getText().equals(TaroloSeged.HelyesValasz))
                            {
                                rb3.setBackgroundColor(COLOR_RED);
                                if(rb1.getText().equals(TaroloSeged.HelyesValasz)){
                                    rb1.setBackgroundColor(COLOR_GREEN);
                                }
                                if(rb2.getText().equals(TaroloSeged.HelyesValasz)){
                                    rb2.setBackgroundColor(COLOR_GREEN);
                                }
                            }
                        }
                         DelayFrissit();
                    }
                    else{
                        showMessage("Hiba", "Jelölj be egy választ!");
                    }

                }

            }
        });



        LejatszBn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Runnable r = new Runnable(){
                    @Override
                    public void run(){
                        try{
                            if(TaroloSeged.Language.equals("Angol")){
                                tts_UK.speak(TaroloSeged.HelyesValasz,TextToSpeech.QUEUE_FLUSH,null);
                            }
                            else if(TaroloSeged.Language.equals("Nemet")){
                                tts_GER.speak(TaroloSeged.HelyesValasz,TextToSpeech.QUEUE_FLUSH,null);
                            }
                        }
                        catch (Exception e){
                            showMessage("Hiba", e.toString());
                        }

                    }
                };
                TaroloSeged.thread1 = new Thread(r);
                TaroloSeged.thread1.start();
            }
        });


    }



    private void Feltolt(){
        NevTextView.setText(TaroloSeged.Username);
        OsszKerdes.setText("/ "+String.valueOf(TaroloSeged.OsszKerdes));
    }

    private void DelayFrissit(){
        Handler handler = new Handler();
        handler.postDelayed(new Runnable() {
            public void run() {
                Feladat_Frissit();
            }
        }, 1500);   //1,5 seconds
    }


    private void Map_Feltolt(){

        try
        {
            //kurzor feldolgozása soronként, amíg nem értünk a végére
            /*while(!c.isAfterLast()){
                c.getString(0);
                myMap.put(c.getString(0), c.getString(1));
                TaroloSeged.Szavak.add(c.getString(0));
                System.out.println(c.getString(0) +" ; "+ c.getString(1));
            }*/

            Cursor res = db.SzavakKepekListazas(TaroloSeged.Language, TaroloSeged.Category);

            if(res.getCount() == 0){
                showMessage("ERROR", "No Data!");
            }

            StringBuffer buffer = new StringBuffer();
            while(res.moveToNext()){
                myMap.put(res.getString(0), res.getString(1));
                TaroloSeged.Szavak.add(res.getString(0));
                buffer.append("Szo: " + res.getString(0) + "\n");
                buffer.append("Kep: " + res.getString(1) + "\n");
            }
            //showMessage("Data", buffer.toString());



        }
        catch (Exception e) {
            Toast.makeText(this, e.toString(), Toast.LENGTH_SHORT).show();
            System.out.println(e.toString());
        }

    }

    /*public void viewAll(){
        Cursor res = db.getAllData();

        if(res.getCount() == 0){
            showMessage("ERROR", "No Data!");
        }
        StringBuffer buffer = new StringBuffer();
        while(res.moveToNext()){
            buffer.append("Szo: " + res.getString(0) + "\n");
            buffer.append("Szo: " + res.getString(1) + "\n");
        }
        showMessage("Data", buffer.toString());

    }*/

    public void showMessage(String title, String Message){
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setCancelable(true);
        builder.setTitle(title);
        builder.setMessage(Message);
        builder.show();
    }

    private void Feladat_Frissit(){
        TaroloSeged.KerdesSzamlalo+=1;
        KerdesSzam.setText(String.valueOf(TaroloSeged.KerdesSzamlalo));
        RadioGr.clearCheck();
        PontszamLbl.setText("Pontszám: "+String.valueOf(TaroloSeged.Pontszam));

        int random = new Random().nextInt(TaroloSeged.Szavak.size());

        while (TaroloSeged.VoltMar.contains(random)){
            random = new Random().nextInt(TaroloSeged.Szavak.size());
        }
        TaroloSeged.VoltMar.add(random);

        TaroloSeged.HelyesValasz = TaroloSeged.Szavak.get(random);


        try{
            Resources res = getResources();
            String mDrawableName = myMap.get(TaroloSeged.HelyesValasz); // a Map tárolóból kulcs alapján
            int resID = res.getIdentifier( mDrawableName.substring(0, mDrawableName.lastIndexOf('.')) , "drawable", getPackageName());
            //Toast.makeText(this, mDrawableName.substring(0, mDrawableName.lastIndexOf('.')), Toast.LENGTH_SHORT).show();
            image.setImageResource(resID);
        }
        catch (Exception e) {
            Toast.makeText(this, e.toString(), Toast.LENGTH_SHORT).show();
            System.out.println(e.toString());
        }


        int random_Helyes = new Random().nextInt(3);
        if(random_Helyes == 0){
            rb1.setText(TaroloSeged.HelyesValasz);
        }
        else if(random_Helyes == 1){
            rb2.setText(TaroloSeged.HelyesValasz);
        }
        else{
            rb3.setText(TaroloSeged.HelyesValasz);
        }

        int randomFillOne = new Random().nextInt(TaroloSeged.Szavak.size());
        while(TaroloSeged.Szavak.get(randomFillOne).equals(TaroloSeged.HelyesValasz)){
            randomFillOne = new Random().nextInt(TaroloSeged.Szavak.size());
        }
        String OtherOptionOne = TaroloSeged.Szavak.get(randomFillOne);

        int randomFillTwo = new Random().nextInt(TaroloSeged.Szavak.size());
        while(TaroloSeged.Szavak.get(randomFillTwo).equals(TaroloSeged.HelyesValasz) || TaroloSeged.Szavak.get(randomFillTwo).equals(OtherOptionOne)){
            randomFillTwo = new Random().nextInt(TaroloSeged.Szavak.size());
        }
        String OtherOptionTwo = TaroloSeged.Szavak.get(randomFillTwo);

        if(random_Helyes == 0){
            rb2.setText(OtherOptionOne);
            rb3.setText(OtherOptionTwo);
        }
        else if(random_Helyes == 1){
            rb1.setText(OtherOptionOne);
            rb3.setText(OtherOptionTwo);
        }
        else{
            rb1.setText(OtherOptionOne);
            rb2.setText(OtherOptionTwo);
        }

        rb1.setBackgroundColor(COLOR_TRANSPARENT);
        rb2.setBackgroundColor(COLOR_TRANSPARENT);
        rb3.setBackgroundColor(COLOR_TRANSPARENT);

    }



}