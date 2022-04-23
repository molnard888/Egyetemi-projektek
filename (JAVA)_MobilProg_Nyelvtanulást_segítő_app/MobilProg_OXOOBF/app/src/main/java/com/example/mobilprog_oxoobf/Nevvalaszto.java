package com.example.mobilprog_oxoobf;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class Nevvalaszto extends AppCompatActivity {

    private EditText Name;
    private String NameString;
    private Button Button1;
    DataBaseSeged db;

    @Override
    public void onBackPressed() {
        return;
    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_nevvalaszto);

        db = new DataBaseSeged(this);
        Button1 = (Button) findViewById(R.id.NevOkBttn);
        Name = (EditText) findViewById(R.id.NevText);
        Name.setSelection(0);

        Button1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                validate(Name.getText().toString());
            }
        });
        /*try{
            getEredmenyekString();
        }
        catch (Exception e){
            Toast.makeText(this, e.toString(), Toast.LENGTH_SHORT).show();
        }*/

    }

    private void validate(String username){

        if(TextUtils.isEmpty(username.replaceAll("\\s",""))  || username.replaceAll("\\s","") == null ||
                username.replaceAll("\\s","").isEmpty() || username.replaceAll("\\s","").equals("null")) {
            Toast.makeText(this, "Adj meg egy nevet.", Toast.LENGTH_SHORT).show();
            return;
        }
        else{
            TaroloSeged.Username = username;
            Intent nyelvvalaszto = new Intent(Nevvalaszto.this, Nyelvvalaszto.class);
            startActivity(nyelvvalaszto);
        }

    }

    public void getEredmenyekString(){
        try
        {
            Cursor res = db.EredmenyListaz();

            if(res.getCount() == 0){
                Toast.makeText(this, "No Data!", Toast.LENGTH_SHORT).show();
            }

            StringBuffer buffer = new StringBuffer();
            while(res.moveToNext()){
                buffer.append(res.getString(0) + " | ");
                buffer.append(res.getString(1) + " | ");
                buffer.append(res.getString(2) + "\n");
            }
            showMessage("Data", buffer.toString());
        }
        catch (Exception e) {
            Toast.makeText(this, e.toString(), Toast.LENGTH_SHORT).show();
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