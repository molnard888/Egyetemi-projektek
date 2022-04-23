package com.example.mobilprog_oxoobf;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.RadioButton;
import android.widget.Toast;

public class Szintvalaszto extends AppCompatActivity {

    private RadioButton allatokBn;
    private RadioButton etelekBn;
    private RadioButton targyakBn;
    private Button Button3;

    @Override
    public void onBackPressed() {
        return;
    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_szintvalaszto);

        allatokBn = (RadioButton) findViewById(R.id.allatokRb);
        etelekBn = (RadioButton) findViewById(R.id.etelekRb);
        targyakBn = (RadioButton) findViewById(R.id.targyakRb);
        Button3 = (Button) findViewById(R.id.szintOkBttn);

        Button3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                SzintBtt_Clicked();
            }
        });
    }



    private void SzintBtt_Clicked() {

        try {
            if(allatokBn.isChecked()){
                TaroloSeged.Category="allatok";
            }
            else if(etelekBn.isChecked()){
                TaroloSeged.Category="etelek";
            }
            else if(targyakBn.isChecked()){
                TaroloSeged.Category="targyak";
            }

            Intent kerdesek = new Intent(Szintvalaszto.this, Kerdesek.class);
            startActivity(kerdesek);
        }
        catch (Exception e){
            Toast.makeText(this, e.toString(), Toast.LENGTH_SHORT).show();
        }

    }
}