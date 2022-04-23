use h03_OXOOBF

EXEC [db1]..[sp_CreateTables]


-----1_a_feladat
select rendszam, YEAR(visszadat) as Év, MONTH(visszadat) as Hónap, sum(kolcsdij+potdij) as Bevétel from kolcsonzes
    GROUP BY rendszam, YEAR(visszadat), MONTH(visszadat)
    order by YEAR(visszadat), MONTH(visszadat) asc, Bevétel desc

/* Eredmény:
Rendsz.  Év    Hó   Bevétel
LRR154	2015	1	6930,0
CBS832	2015	1	4680,0
KKT352	2015	1	4400,0
KKL299	2015	2	37200,0
JJJ673	2015	2	9600,0
GHV199	2015	3	29700,0
JJJ673	2015	3	14400,0
KBL152	2015	3	12600,0
LTT532	2015	4	33000,0
CBS832	2015	4	20800,0
JJJ673	2015	4	19200,0
GKP729	2015	5	33500,0
JJJ673	2015	5	24000,0
GJK663	2015	5	23000,0
LLK312	2015	6	69600,0
GHL793	2015	6	49000,0
KBL152	2015	7	29400,0
GJK663	2015	8	73600,0
GHL793	2015	8	68600,0
LFZ952	2015	8	67200,0
LRR154	2015	8	55440,0
KKT352	2015	8	35200,0
NNN724	2015	10	108000,0
GHJ923	2015	10	98000,0
LFZ412	2015	10	67000,0
KKL299	2015	10	56000,0
NNN724	2015	11	132000,0
GKP729	2015	11	73700,0
FKN783	2015	11	67000,0
GJK663	2015	12	136400,0
CBS832	2015	12	83200,0
LLK312	2015	12	61600,0
NNN724	2016	1	12000,0
JJJ673	2016	1	4800,0
GJK663	2016	1	4600,0
LFZ412	2016	2	26800,0
NNK346	2016	2	18400,0
HLI190	2016	2	11200,0
NNN724	2016	3	36000,0
FKN783	2016	3	20100,0
KKL556	2016	4	35600,0
KKL299	2016	4	22400,0
HLI190	2016	4	20160,0
JJJ673	2016	4	19200,0
LFZ412	2016	5	26800,0
GJK663	2016	5	23000,0
HGL712	2016	6	49500,0
FKN783	2016	6	40200,0
LFZ412	2016	7	82900,0
GHV199	2016	7	69300,0
GKP729	2016	7	46900,0
CBS832	2016	7	36400,0
GKP729	2016	8	53600,0
HJP377	2016	8	53600,0
JJJ123	2016	9	45000,0
KKL556	2016	10	89000,0
GKP729	2016	10	67000,0
LLK312	2016	10	56000,0
LFZ412	2016	10	54270,0
KKL299	2016	10	50400,0
JGB783	2016	11	209000,0
NNN724	2016	11	120000,0
FKN783	2016	11	99700,0
CBS832	2016	11	52000,0
KKT352	2016	11	43560,0
GHV199	2016	12	227700,0
LFZ952	2016	12	118400,0
LRR154	2016	12	84700,0
LFZ412	2017	1	116400,0
*/


-----1_pivot

/* select Rendszam, [1], [2], [3], Bevétel 
from (
    select rendszam, YEAR(visszadat) as Év, MONTH(visszadat) as Hónap, sum(kolcsdij+potdij) as Bevétel from kolcsonzes
    GROUP BY rendszam, YEAR(visszadat), MONTH(visszadat)
    order by YEAR(visszadat), MONTH(visszadat) asc, Bevétel desc
) a
pivot ( Év in ([2015], [2016], [2017])) as pt  */




-----2_a_feladat
DROP FUNCTION IF EXISTS func_masodik_feladat
GO

CREATE FUNCTION func_masodik_feladat(@felszAzonosito int)
RETURNS INT
AS
BEGIN
  DECLARE @rendelkAutoMax int, @nemRendelkAutoMax int;
    --rendelkezik
    select @rendelkAutoMax=max(sz.ar) from szgk sz 
        INNER join szgk_felsz szf on sz.rendszam=szf.rendszam
        where felszID=@felszAzonosito
        DECLARE @autodarab int

    --nem rendelkezik
    set @nemRendelkAutoMax=0
    select @autodarab= count(distinct sz.rendszam) from szgk sz 
        INNER join szgk_felsz szf on sz.rendszam=szf.rendszam

    while (@autodarab > 0)BEGIN
        declare @rendszamVar VARCHAR(max)
        SELECT TOP (@autodarab) @rendszamVar=rendszam from szgk_felsz
        declare @rendDarabByRendszam INT
        select @rendDarabByRendszam=count(*) from szgk_felsz
            WHERE felszID=@felszAzonosito and rendszam=@rendszamVar
        if(@rendDarabByRendszam = 0) BEGIN
            DECLARE @nemRendAutoAr INT
            select @nemRendAutoAr=sz.ar from szgk sz 
                INNER join szgk_felsz szf on sz.rendszam=szf.rendszam
                where szf.rendszam=@rendszamVar
            if(@nemRendelkAutoMax < @nemRendAutoAr)BEGIN
                set @nemRendelkAutoMax=@nemRendAutoAr
            END
        END
        set @autodarab = @autodarab-1 

    END 

    if(@rendelkAutoMax is null)BEGIN
        RETURN 5000
    END
    if(@nemRendelkAutoMax is null)BEGIN
        RETURN 5000
    END
    else BEGIN
        DECLARE @ArAtlag INT
        set @ArAtlag=(@rendelkAutoMax+@nemRendelkAutoMax)/2
        return @ArAtlag
    END
    RETURN 5000
END
GO

SELECT dbo.func_masodik_feladat(1);



-----3_feladat

DROP PROCEDURE IF EXISTS proc_harmadik_feladat
GO

CREATE PROCEDURE proc_harmadik_feladat @rendszamParam VARCHAR(max), @felszereltsegParam VARCHAR(max) as
BEGIN
  BEGIN TRY
    BEGIN TRAN
        DECLARE @felszLetezik int
        select @felszLetezik=count(*) from felszereltseg where felsz like @felszereltsegParam
        if(@felszLetezik <> 0) BEGIN
            DECLARE @autoFelszerelesLetezik INT
            SELECT  @autoFelszerelesLetezik=count(*) from szgk_felsz szf 
                INNER join felszereltseg f on szf.felszID=f.felszID
                where rendszam=@rendszamParam and f.felsz like @felszereltsegParam
            if(@autoFelszerelesLetezik <> 0) BEGIN
                PRINT 'Az autó rendelkezik a felszereléssel!'
                ROLLBACK TRAN
                RETURN
            END
            else BEGIN
                DECLARE @tempFelszID INT, @autoAr INT
                select @autoAr=ar from szgk where rendszam=@rendszamParam
                select @tempFelszID=felszID from felszereltseg where felsz like @felszereltsegParam
                --select @tempFelszID=felszID from felszereltseg where felsz=@felszereltsegParam --hiba: catch blokk
                insert into szgk_felsz (rendszam, felszID) VALUES (@rendszamParam, @tempFelszID) 
                DECLARE @ujKolcsDij INT
                select @ujKolcsDij=dbo.func_masodik_feladat(@tempFelszID)
                print 'Az autó ára '+cast(@autoAr as varchar(max))+'-ról '+cast(@ujKolcsDij as varchar(max))+'-ra módosult.'
                commit TRAN
            END                 
        END
        else BEGIN
            PRINT 'Nem létezik a felszerelés!'
            ROLLBACK TRAN
            RETURN
        END
    end try
    begin catch
        print 'EGYÉB HIBA: '+ ERROR_MESSAGE() + ' (' + cast(ERROR_NUMBER() as varchar(20)) + ')'
        ROLLBACK TRAN
  END CATCH
END
GO

execute proc_harmadik_feladat 'CBS832', 'Tolatoradar'

--  (3.feladat) Teszt:
execute proc_harmadik_feladat 'HJP377', 'fffsfasfas'  --Nem létezik a felszerelés!
execute proc_harmadik_feladat 'HJP377', 'GPS'         --Az autó rendelkezik a felszereléssel!
execute proc_harmadik_feladat 'CBS832', 'GPS'         --Az autó ára 5200-ról 10950-ra módosult.

--Visszaállítás:
EXEC [db1]..[sp_CreateTables]

--select * from szgk_felsz
select * from felszereltseg

-----4_a_feladat
DROP TRIGGER IF EXISTS trigger_negyedik_feladat
GO

CREATE TRIGGER trigger_negyedik_feladat ON szgk_felsz
AFTER INSERT 
AS
BEGIN
    DECLARE @tr_rendszam varchar(max), @tr_felszID int, @tr_felszereltseg varchar(max), @tr_gyarto varchar(max), @tr_tipus varchar(max)
    select @tr_rendszam=rendszam, @tr_felszID=felszID from inserted
    select @tr_felszereltseg=felsz from felszereltseg where felszID=@tr_felszID;
    select @tr_gyarto=gyarto, @tr_tipus=tipus from szgk where rendszam=@tr_rendszam;
    print 'A <'+@tr_felszereltseg+'> beszerelésre került a következő autóba: <' +@tr_rendszam+ '> - <' 
    +@tr_gyarto+'> <'+ @tr_tipus +'>.'; 
END
GO

--trigger teszt:

execute proc_harmadik_feladat 'CBS832', 'Tolatoradar'