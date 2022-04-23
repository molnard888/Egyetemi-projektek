package com.example.mobilprog_oxoobf;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import com.jakewharton.processphoenix.ProcessPhoenix;

import java.util.ArrayList;
import java.util.List;

public class Eredmenyek extends AppCompatActivity {


    DataBaseSeged db;
    List<String> EredmenyList;
    ListView LV;
    Button UjraBn;

    @Override
    public void onBackPressed() {
        return;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_eredmenyek);

        LV = (ListView) findViewById(R.id.EredmenyLV);
        UjraBn = (Button) findViewById(R.id.ujraBttn);


        UjraBn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                TaroloSeged.Nullaz();
                //ProcessPhoenix.triggerRebirth(getApplicationContext());
                Intent restartIntent = new Intent(getApplicationContext(), Nevvalaszto.class);
                restartIntent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP); //Set this flag
                startActivity(restartIntent);
                finish();
            }
        });

        EredmenyList = new ArrayList<String>();

        db = new DataBaseSeged(this);
        getEredmenyekString();
        ArrayAdapter<String> arrayAd = new ArrayAdapter<String>(this, R.layout.activity_list_view, R.id.LVtv, EredmenyList);
        LV.setAdapter(arrayAd);


    }



    public void getEredmenyekString(){
        try
        {
            Cursor res = db.EredmenyListaz();

            if(res.getCount() == 0){
                showMessage("ERROR", "No Data!");
            }

            while(res.moveToNext()){
                if(Integer.parseInt(res.getString(2)) < 10){
                    EredmenyList.add(res.getString(0) + " | " + res.getString(1) + " |   " + res.getString(2));
                }
                else {
                    EredmenyList.add(res.getString(0) + " | " + res.getString(1) + " | " + res.getString(2));
                }

            }
        }
        catch (Exception e) {
            Toast.makeText(this, e.toString(), Toast.LENGTH_LONG).show();
            System.out.println(e.toString());
        }
    }

    public void showMessage(String title, String Message){
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setCancelable(true);
        builder.setTitle(title);
        builder.setMessage(Message);
        builder.show();
    }
}