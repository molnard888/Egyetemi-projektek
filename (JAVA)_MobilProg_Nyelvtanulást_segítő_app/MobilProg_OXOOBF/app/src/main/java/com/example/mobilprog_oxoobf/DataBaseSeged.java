package com.example.mobilprog_oxoobf;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;

public class DataBaseSeged extends SQLiteOpenHelper {

    public static String DB_NAME = "beadando.db";

    public static final String TABLE_NAME_ALLATOK = "allatok";
    public static final String TABLE_NAME_ETELEK = "etelek";
    public static final String TABLE_NAME_TARGYAK = "targyak";



    public static final String COLUMN_NAME_ANGOL = "Angol";
    public static final String COLUMN_NAME_NEMET = "Nemet";
    public static final String COLUMN_NAME_KEPEK = "Kepek";

    public static final String TABLE_NAME_EREDMENYEK = "eredmenyek";
    public static final String COLUMN_NAME_NEV = "Nev";
    public static final String COLUMN_NAME_IDO = "Idopont";
    public static final String COLUMN_NAME_PONT = "Pontszam";
    public static final String COLUMN_NAME_NYELV = "Nyelv";
    public static final String COLUMN_NAME_KATEGORIA = "Kategoria";


    private static final String SQL_CREATE_TABLE_ALLATOK =
            "CREATE TABLE IF NOT EXISTS " + TABLE_NAME_ALLATOK + " (" +
                    COLUMN_NAME_ANGOL + " TEXT PRIMARY KEY, " +
                    COLUMN_NAME_NEMET + " TEXT, " +
                    COLUMN_NAME_KEPEK + " TEXT)";

    private static final String SQL_CREATE_TABLE_ETELEK =
            "CREATE TABLE IF NOT EXISTS " + TABLE_NAME_ETELEK + " (" +
                    COLUMN_NAME_ANGOL + " TEXT PRIMARY KEY, " +
                    COLUMN_NAME_NEMET + " TEXT, " +
                    COLUMN_NAME_KEPEK + " TEXT)";

    private static final String SQL_CREATE_TABLE_TARGYAK =
            "CREATE TABLE IF NOT EXISTS " + TABLE_NAME_TARGYAK + " (" +
                    COLUMN_NAME_ANGOL + " TEXT PRIMARY KEY, " +
                    COLUMN_NAME_NEMET + " TEXT, " +
                    COLUMN_NAME_KEPEK + " TEXT)";


    private static final String SQL_CREATE_TABLE_EREDMENYEK =
            "CREATE TABLE IF NOT EXISTS " + TABLE_NAME_EREDMENYEK + " (" +
                    COLUMN_NAME_NEV + " TEXT, " +
                    COLUMN_NAME_IDO + " TEXT PRIMARY KEY, " +
                    COLUMN_NAME_PONT + " TEXT, " +
                    COLUMN_NAME_NYELV + " TEXT, " +
                    COLUMN_NAME_KATEGORIA+ " TEXT)";


    public DataBaseSeged(Context context) {
        super(context, DB_NAME, null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(SQL_CREATE_TABLE_ALLATOK);
        db.execSQL(SQL_CREATE_TABLE_ETELEK);
        db.execSQL(SQL_CREATE_TABLE_TARGYAK);

        db.execSQL(SQL_CREATE_TABLE_EREDMENYEK);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {

    }

    /*public Cursor getAllData()
    {
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor res = db.rawQuery("SELECT Angol, Kepek FROM allatok", null);
        return res;
    }*/

    public Cursor SzavakKepekListazas(String nyelv, String kategoria){
        SQLiteDatabase db = this.getWritableDatabase();

        //adatok lekérése a táblából egy lekérdezéssel
        Cursor c = db.rawQuery("SELECT "+nyelv+", Kepek FROM "+kategoria, null);

        //ha a lekérdezés adott vissza rekordot - adathalmaz elejére tudunk-e állni, számláló != 0
        if(c.moveToFirst() || c.getCount() != 0){
            //kurzormutató az 1. rekordra áll
            c.moveToFirst();
        }
        else { //ha üres a rekordhalmaz - kurzor bezárása
            c.close();
            return null;
        }
        //visszatérés a kurzorral

        return c;
    }

    public Cursor EredmenyListaz(){
        SQLiteDatabase db = this.getWritableDatabase();

        //adatok lekérése a táblából egy lekérdezéssel
        Cursor c = db.rawQuery("SELECT * FROM "+TABLE_NAME_EREDMENYEK + " WHERE " + COLUMN_NAME_NYELV + "=?  AND "
                + COLUMN_NAME_KATEGORIA + "=? ORDER BY " +COLUMN_NAME_IDO+ " DESC ", new String[] {TaroloSeged.Language, TaroloSeged.Category});

        return c;
    }

    public void InsertIntoEredmenyek(){
            SQLiteDatabase db = this.getWritableDatabase();
            ContentValues cV = new ContentValues();

            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.getDefault());
            String currentDateandTime = sdf.format(new Date());

            cV.put(COLUMN_NAME_NEV, TaroloSeged.Username);
            cV.put(COLUMN_NAME_IDO, currentDateandTime);
            cV.put(COLUMN_NAME_PONT, TaroloSeged.Pontszam);
            cV.put(COLUMN_NAME_NYELV, TaroloSeged.Language);
            cV.put(COLUMN_NAME_KATEGORIA, TaroloSeged.Category);

            db.insert(TABLE_NAME_EREDMENYEK, null, cV);
    }
}
