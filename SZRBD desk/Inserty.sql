﻿INSERT INTO "DZIAL" ("NAZWA_DZIALU") VALUES ('FRONTEND');
INSERT INTO "DZIAL" ("NAZWA_DZIALU") VALUES ('BACKEND');

INSERT INTO "STANOWISKO" ("ID_DZIALU","NAZWA_STANOWISKA") VALUES ('1','Programista 1');
INSERT INTO "STANOWISKO" ("ID_DZIALU","NAZWA_STANOWISKA") VALUES ('1','Programista 2');
INSERT INTO "STANOWISKO" ("ID_DZIALU","NAZWA_STANOWISKA") VALUES ('2','Programista 3');
INSERT INTO "STANOWISKO" ("ID_DZIALU","NAZWA_STANOWISKA") VALUES ('2','Programista 4');

INSERT INTO "PRACOWNIK" ("ID_DZIALU","ID_STANOWISKA","IMIE","NAZWISKO") VALUES ('1','1','Joanna','Szulc');
INSERT INTO "PRACOWNIK" ("ID_DZIALU","ID_STANOWISKA","IMIE","NAZWISKO") VALUES ('1','2','Konrad','Gajewski');
INSERT INTO "PRACOWNIK" ("ID_DZIALU","ID_STANOWISKA","IMIE","NAZWISKO") VALUES ('1','3','Jakub','Przybysz');
INSERT INTO "PRACOWNIK" ("ID_DZIALU","ID_STANOWISKA","IMIE","NAZWISKO") VALUES ('1','4','Gabriela','Olejniczak');
INSERT INTO "PRACOWNIK" ("ID_DZIALU","ID_STANOWISKA","IMIE","NAZWISKO") VALUES ('1','1','Wiktoria','Ostrowska');
INSERT INTO "PRACOWNIK" ("ID_DZIALU","ID_STANOWISKA","IMIE","NAZWISKO") VALUES ('2','2','Jakub','Żak');
INSERT INTO "PRACOWNIK" ("ID_DZIALU","ID_STANOWISKA","IMIE","NAZWISKO") VALUES ('2','3','Marek','Żak');
INSERT INTO "PRACOWNIK" ("ID_DZIALU","ID_STANOWISKA","IMIE","NAZWISKO") VALUES ('2','4','Marek','Zieliński');
INSERT INTO "PRACOWNIK" ("ID_DZIALU","ID_STANOWISKA","IMIE","NAZWISKO") VALUES ('2','1','Julia','Szymańska');
INSERT INTO "PRACOWNIK" ("ID_DZIALU","ID_STANOWISKA","IMIE","NAZWISKO") VALUES ('2','2','Przemysław','Ostrowski');

INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('1','Prac1','true');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('1','Prac2','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('1','Prac3','true');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('1','Prac4','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('2','Prac5','true');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('2','Prac6','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('2','Prac7','true');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('2','Prac8','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('3','Prac9','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('3','Prac10','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('4','Prac11','true');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('4','Prac12','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('5','Prac13','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('5','Prac14','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('5','Prac15','true');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('6','Prac16','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('6','Prac17','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('7','Prac18','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('7','Prac19','true');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('8','Prac20','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('8','Prac21','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('9','Prac22','true');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('10','Prac23','false');
INSERT INTO "ZADANIA" ("ID_PRACOWNIKA","NAZWA_ZADANIA","CZY_WYKONANE") VALUES ('10','Prac24','true');