package com.example.mobilprog_oxoobf;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;

public class ListViewActivit extends AppCompatActivity {

    @Override
    public void onBackPressed() {
        return;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_list_view);
    }
}