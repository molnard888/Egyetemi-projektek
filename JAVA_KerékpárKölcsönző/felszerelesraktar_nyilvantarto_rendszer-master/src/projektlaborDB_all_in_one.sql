-- MySQL dump 10.13  Distrib 8.0.24, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: raktardb
-- ------------------------------------------------------
-- Server version	8.0.24

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `alkategoriatbl`
--

DROP TABLE IF EXISTS `alkategoriatbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alkategoriatbl` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Alkategoria` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alkategoriatbl`
--

LOCK TABLES `alkategoriatbl` WRITE;
/*!40000 ALTER TABLE `alkategoriatbl` DISABLE KEYS */;
INSERT INTO `alkategoriatbl` VALUES (1,'MTB'),(2,'Országúti'),(3,'E-bike'),(4,'BMX'),(5,'Enduro'),(6,'Trekking'),(7,'Bukósisak'),(8,'Térdvédő'),(9,'Könyökvédő'),(10,'Gerincvédő'),(11,'Utánfutó'),(12,'Gyerekülés');
/*!40000 ALTER TABLE `alkategoriatbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `allapottbl`
--

DROP TABLE IF EXISTS `allapottbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `allapottbl` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Allapot` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=102 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `allapottbl`
--

LOCK TABLES `allapottbl` WRITE;
/*!40000 ALTER TABLE `allapottbl` DISABLE KEYS */;
INSERT INTO `allapottbl` VALUES (1,'1%'),(2,'2%'),(3,'3%'),(4,'4%'),(5,'5%'),(6,'6%'),(7,'7%'),(8,'8%'),(9,'9%'),(10,'10%'),(11,'11%'),(12,'12%'),(13,'13%'),(14,'14%'),(15,'15%'),(16,'16%'),(17,'17%'),(18,'18%'),(19,'19%'),(20,'20%'),(21,'21%'),(22,'22%'),(23,'23%'),(24,'24%'),(25,'25%'),(26,'26%'),(27,'27%'),(28,'28%'),(29,'29%'),(30,'30%'),(31,'31%'),(32,'32%'),(33,'33%'),(34,'34%'),(35,'35%'),(36,'36%'),(37,'37%'),(38,'38%'),(39,'39%'),(40,'40%'),(41,'41%'),(42,'42%'),(43,'43%'),(44,'44%'),(45,'45%'),(46,'46%'),(47,'47%'),(48,'48%'),(49,'49%'),(50,'50%'),(51,'51%'),(52,'52%'),(53,'53%'),(54,'54%'),(55,'55%'),(56,'56%'),(57,'57%'),(58,'58%'),(59,'59%'),(60,'60%'),(61,'61%'),(62,'62%'),(63,'63%'),(64,'64%'),(65,'65%'),(66,'66%'),(67,'67%'),(68,'68%'),(69,'69%'),(70,'70%'),(71,'71%'),(72,'72%'),(73,'73%'),(74,'74%'),(75,'75%'),(76,'76%'),(77,'77%'),(78,'78%'),(79,'79%'),(80,'80%'),(81,'81%'),(82,'82%'),(83,'83%'),(84,'84%'),(85,'85%'),(86,'86%'),(87,'87%'),(88,'88%'),(89,'89%'),(90,'90%'),(91,'91%'),(92,'92%'),(93,'93%'),(94,'94%'),(95,'95%'),(96,'96%'),(97,'97%'),(98,'98%'),(99,'99%'),(100,'100%'),(101,'Selejt');
/*!40000 ALTER TABLE `allapottbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `felhasznaloktbl`
--

DROP TABLE IF EXISTS `felhasznaloktbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `felhasznaloktbl` (
  `Felhasznalonev` varchar(50) NOT NULL,
  `Jelszo` varchar(50) NOT NULL,
  PRIMARY KEY (`Felhasznalonev`),
  UNIQUE KEY `Felhasznalonev_UNIQUE` (`Felhasznalonev`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `felhasznaloktbl`
--

LOCK TABLES `felhasznaloktbl` WRITE;
/*!40000 ALTER TABLE `felhasznaloktbl` DISABLE KEYS */;
INSERT INTO `felhasznaloktbl` VALUES ('admin','21232f297a57a5a743894a0e4a801fc3'),('anita','83349cbdac695f3943635a4fd1aaa7d0'),('bence','f2034283eae41d2d2f45d92ec7208a93'),('dani','55b7e8b895d047537e672250dd781555');
/*!40000 ALTER TABLE `felhasznaloktbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gyartoktbl`
--

DROP TABLE IF EXISTS `gyartoktbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gyartoktbl` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Gyarto` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gyartoktbl`
--

LOCK TABLES `gyartoktbl` WRITE;
/*!40000 ALTER TABLE `gyartoktbl` DISABLE KEYS */;
INSERT INTO `gyartoktbl` VALUES (1,'Specialized'),(2,'Scott'),(3,'KTM'),(4,'Cross'),(5,'Haibike'),(6,'Hauser'),(7,'Kross'),(8,'Merida'),(9,'UMF'),(10,'Total Bikes'),(11,'Haro'),(12,'Force'),(13,'TSG'),(14,'Thule'),(15,'wkjer'),(16,'DSfdsfsfs'),(17,'Caprine');
/*!40000 ALTER TABLE `gyartoktbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kategoriatbl`
--

DROP TABLE IF EXISTS `kategoriatbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kategoriatbl` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Kategoria` varchar(255) NOT NULL,
  `AlkategoriaID` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `raktarTbl_fk5` (`AlkategoriaID`),
  CONSTRAINT `raktarTbl_fk5` FOREIGN KEY (`AlkategoriaID`) REFERENCES `alkategoriatbl` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kategoriatbl`
--

LOCK TABLES `kategoriatbl` WRITE;
/*!40000 ALTER TABLE `kategoriatbl` DISABLE KEYS */;
INSERT INTO `kategoriatbl` VALUES (1,'Kerékpár',1),(2,'Kerékpár',2),(3,'Kerékpár',3),(4,'Kerékpár',4),(5,'Kerékpár',5),(6,'Kerékpár',6),(7,'Védőfelszerelés',7),(8,'Védőfelszerelés',8),(9,'Védőfelszerelés',9),(10,'Védőfelszerelés',10),(11,'Kiegészítő',11),(12,'Kiegészítő',12);
/*!40000 ALTER TABLE `kategoriatbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kolcsonzesektbl`
--

DROP TABLE IF EXISTS `kolcsonzesektbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kolcsonzesektbl` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `SzNev` varchar(255) NOT NULL,
  `Telefon` varchar(255) NOT NULL,
  `QRKod` varchar(255) NOT NULL,
  `KolcsDateFrom` datetime NOT NULL,
  `KolcsDateTo` datetime NOT NULL,
  `TelepFrom` varchar(255) NOT NULL,
  `TelepTo` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kolcsonzesektbl`
--

LOCK TABLES `kolcsonzesektbl` WRITE;
/*!40000 ALTER TABLE `kolcsonzesektbl` DISABLE KEYS */;
INSERT INTO `kolcsonzesektbl` VALUES (1,'Példa József','+36309999999','3o5gVZjFlrl8ATtY','2021-05-12 21:38:40','2021-05-12 21:42:14','Balatonfüred','Balatonfüred');
/*!40000 ALTER TABLE `kolcsonzesektbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `raktartbl`
--

DROP TABLE IF EXISTS `raktartbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `raktartbl` (
  `Gyarto` int NOT NULL,
  `Tipus` int NOT NULL,
  `Kategoria` int NOT NULL,
  `Evjarat` int NOT NULL,
  `BeszAr` int NOT NULL,
  `Telephely` int NOT NULL,
  `Allapot` int NOT NULL,
  `BeszHely` varchar(255) NOT NULL,
  `Gyariszam` varchar(255) NOT NULL,
  `QRKod` varchar(255) NOT NULL,
  PRIMARY KEY (`QRKod`),
  KEY `raktarTbl_fk0` (`Gyarto`),
  KEY `raktarTbl_fk1` (`Tipus`),
  KEY `raktarTbl_fk2` (`Telephely`),
  KEY `raktarTbl_fk3` (`Allapot`),
  KEY `raktarTbl_fk4` (`Kategoria`),
  CONSTRAINT `raktarTbl_fk0` FOREIGN KEY (`Gyarto`) REFERENCES `gyartoktbl` (`ID`),
  CONSTRAINT `raktarTbl_fk1` FOREIGN KEY (`Tipus`) REFERENCES `tipustbl` (`ID`),
  CONSTRAINT `raktarTbl_fk2` FOREIGN KEY (`Telephely`) REFERENCES `telephelyektbl` (`ID`),
  CONSTRAINT `raktarTbl_fk3` FOREIGN KEY (`Allapot`) REFERENCES `allapottbl` (`ID`),
  CONSTRAINT `raktarTbl_fk4` FOREIGN KEY (`Kategoria`) REFERENCES `kategoriatbl` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `raktartbl`
--

LOCK TABLES `raktartbl` WRITE;
/*!40000 ALTER TABLE `raktartbl` DISABLE KEYS */;
INSERT INTO `raktartbl` VALUES (17,18,1,2002,55000,1,48,'Balatonfüred','158225-22222222222222','3o5gVZjFlrl8ATtY'),(13,21,10,2016,13190,1,68,'Store13 Kft.','TSG-1495623-FNHDE','9EWWVWN2MRRAQdjs'),(13,22,9,2018,8990,2,96,'Store13 Kft.','TSG-15688746-ETFH','Cv6cRhVAtivqAj0N'),(8,16,1,2009,190000,1,101,'Budapest','2342357832','hjdbsfkjsfs'),(12,19,7,2017,17990,2,78,'Force CZ Distr.','856245-89568-1526','kzBVV09aHw0oT0Ur'),(1,4,3,2020,3199000,2,100,'Specialized Hungary Kft.','DSDF4335GD4FGF5','qrkodhelyettesitotext'),(1,1,1,2018,240000,1,97,'Kuszi Kerékpár','38756347543543fds','sdfjhfsf'),(8,15,4,2021,342423,2,101,'gsdfjsdf','jfdhsjflsdf','sdfjsfsdf'),(14,20,11,2011,149825,1,91,'Kerekparshop.hu','1111111123356666','YDDjQtrwK3Z5YJRw');
/*!40000 ALTER TABLE `raktartbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `telephelyektbl`
--

DROP TABLE IF EXISTS `telephelyektbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `telephelyektbl` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Telephely` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `telephelyektbl`
--

LOCK TABLES `telephelyektbl` WRITE;
/*!40000 ALTER TABLE `telephelyektbl` DISABLE KEYS */;
INSERT INTO `telephelyektbl` VALUES (1,'Balatonfüred'),(2,'Siófok');
/*!40000 ALTER TABLE `telephelyektbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipustbl`
--

DROP TABLE IF EXISTS `tipustbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipustbl` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Tipus` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipustbl`
--

LOCK TABLES `tipustbl` WRITE;
/*!40000 ALTER TABLE `tipustbl` DISABLE KEYS */;
INSERT INTO `tipustbl` VALUES (1,'Rockhopper Comp'),(2,'Fusion 10'),(3,'Tarmac SL7'),(4,'Turbo Levo SL'),(5,'Downtown 18'),(6,'Moon 3.0'),(7,'Crossway Urban 100'),(8,'Status'),(9,'Scope'),(10,'Tahoe Resist'),(11,'Dermis'),(12,'Backbone Vest'),(13,'Chariot Sport'),(14,'RideAlong Lite'),(15,'sdkjfns'),(16,'Kalahari'),(17,'bike'),(18,'Cherokee'),(19,'Speed mk2'),(20,'Carry plus'),(21,'Backbone west'),(22,'Scope XL');
/*!40000 ALTER TABLE `tipustbl` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-12 22:11:16
