# Rendszerfejlesztés korszerű módszerei - 33.csapat 👨‍💻
A rendszerfejlesztés korszerű módszerei tárgy 33. csapatának github repository-ja.


## Szerver-Kliens Architektúra
| Név | Választott technológia/programozási nyelv |
| ------ | ------ |
| Szerver | Python, Socket, Sqlite |
| Kliens | React, TypeScript |


## Mérföldkövek
### 1. Mérföldkő
- [x] A rendszer adatmodelljének megtervezése és előállítása [✳️](https://github.com/holiczab/rendf-33.csapat/blob/main/Readme%20K%C3%A9pek/adatmodell.PNG)
> - [x] Adatbázis szerkezetének kiépítése sqlite-ban
- [x] A rendszer architektúrájának megtervezése [✳️](https://github.com/holiczab/rendf-33.csapat/blob/main/Readme%20K%C3%A9pek/architektura.PNG)
> - [x] Python Szerver , React Kliens előállítása
- [x] Felhasználók beléptetése (regisztráció nincs, adminisztrátor adja hozzá az embereket)
> - [x] Szerver jelszóellenőrzés kezelése
> - [x] Kliens-Szerver felhasználó név-jelszó ellenőrzés kezelése socket kommunikációval
> - [x] Kliens- 3 felhasználó típus (Eszközfelelős, Operátor, Karbantartó) külön oldalának kiépítése
- [x] Eszköz kategóriák felvétele, hierarchiába rendezése [✳️](https://github.com/holiczab/rendf-33.csapat/blob/main/Readme%20K%C3%A9pek/kat-veg.jpg)
> - [x] Eszközfelelős tudjon kategóriákat felvenni/törölni     (TODO: adatbevitelnél inkább lenyíló menü szerverről lekérve, törlésnél checkboxos kijelölés)
> - [x] Szerver sql műveletek, klienstől adatok fogadásának kezelése
- [x] Eszközök rögzítése (azonosító, név, helyszín, kategóriába sorolás)
> - [x] Eszközfelelős tudjon eszközt felvenni és törölni       (TODO: adatbevitelnél inkább lenyíló menü szerverről lekérve, törlésnél checkboxos kijelölés)
> - [x] Szerver sql műveletek, klienstől adatok fogadásának kezelése
- [x] Végzettségek felvétele és eszköz kategóriákhoz rendelése [✳️](https://github.com/holiczab/rendf-33.csapat/blob/main/Readme%20K%C3%A9pek/kat-veg.jpg)
### 2. Mérföldkő
- [x] Eszköz kategóriához normaidők és karbantartási periódus rögzítése
> - [x] Meglévőkhöz normaidők és karbantartási periódus rendelés 
> - [x] Legyen lehetőség a kliensben felvenni ezeket
> > - [x] Módosítani, törölni
> - [x] Ha valami nincs megadva a kategóriánál, a hierarchia miatt meg kell kapja a felette lévő kategória értékeit (pl.: normaidők és karbantartási periódus)
- [x] Eszköz kategóriához a karbantartásra vonatkozó instrukciók rögzítése
> - [x] Meglévőkhöz instrukciók rendelés 
> - [x] Legyen lehetőség a kliensben felvenni ezeket
> >- [x] Módosítani, törölni
- [x] Karbantartók felvétele a rendszerbe (adatbázis)
- [x] Végzettségek karbantartóhoz rendelése (adatbázis)
- [x] Rendkívüli karbantartási feladatok rögzítése a rendszerbe (eszköz, időpont, hiba leírása) (kliens)
- [x] Időszakos karbantartási feladatok automatikus generálása (utolsó karbantartás és karbantartási periódus alapján)
- [x] Feladatok listázása, állapotok megjelenítése
> - [x] SQL utasítás
> - [x] Kliens
- [x] *ID-k átírása Auto Incrementre*
- [x] *Adatbevitelnél inkább lenyíló menü szerverről lekérve, törlésnél checkboxos kijelölés az eszközöknél és a kategóriáknál*
### 3. Mérföldkő
- [X] Időszakos karbantartási feladatok hozzáadása az adatbázishoz
- [x] Feladatok kiosztása karbantartók számára (manuális hozzárendelés a végzettség egyeztetésével, automatikus megvalósítás opcionális)
> - [x] Kliens - Operator - Feladatoknál kijelöli az elérhető karbantartók közül valamelyiket (Végzettséget figyelve!)
> - [x] SQL - Log táblába feladat mentés
- [x] Az adott karbantartóhoz rendelt feladatok listázása
> - [x] Kliens - Listázás
> - [x] SQL - SELECT Név alapján
- [x] Állapotok beállításának lehetősége (Elfogadva, Elutasítva, Megkezdve, Befejezve) 
> - [x] Elfogadva -> ApprovedBy, Status frissítés
> - [x] Elutasítva -> DeniedBy, Status frissítés
> - [x] Megkezdve -> Start frissítés
> - [x] Befejezve -> Status, End frissítés
- [x] Megkezdve állapotban az instrukciók megjelenítése (2.b)
> - [x] Kliens - Az instrukciok legyenek barmikor megtekinthetoek felugro ablakban
> - [x] Kliens - Ha a karbantartó megkezdi a feladatot (állapot váltás), akkor utána egy felugró ablakban megjelennek az utasítások
> - [x] SQL - ID/Név alapján instrukció lekérése
