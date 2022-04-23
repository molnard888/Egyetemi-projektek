package com.example.mobilprog_oxoobf;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.RadioButton;

public class Nyelvvalaszto extends AppCompatActivity {

    //private TextView NevLbl;
    private RadioButton angolBn;
    private RadioButton nemetBn;
    private Button Button2;

    @Override
    public void onBackPressed() {
        return;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_nyelvvalaszto);

        //NevLbl = (TextView) findViewById(R.id.NevLbl);
        //NevLbl.setText(TaroloSeged.Username);

        angolBn = (RadioButton) findViewById(R.id.angolRb);
        nemetBn = (RadioButton) findViewById(R.id.nemetRb);
        Button2 = (Button) findViewById(R.id.szintOkBttn);

        Button2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                NyelvBtt_Clicked();
            }
        });

    }

    private void NyelvBtt_Clicked() {
        if(angolBn.isChecked()){
            TaroloSeged.Language="Angol";
        }
        else{
            TaroloSeged.Language="Nemet";
        }

        Intent szintvalaszto = new Intent(Nyelvvalaszto.this, Szintvalaszto.class);
        startActivity(szintvalaszto);
    }
}