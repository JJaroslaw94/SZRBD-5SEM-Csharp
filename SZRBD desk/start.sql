/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     10.02.2019 14:36:21                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRACOWNIK') and o.name = 'FK_PRACOWNI_RE2_STANOWIS')
alter table PRACOWNIK
   drop constraint FK_PRACOWNI_RE2_STANOWIS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRACOWNIK') and o.name = 'FK_PRACOWNI_RE3_DZIAL')
alter table PRACOWNIK
   drop constraint FK_PRACOWNI_RE3_DZIAL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('STANOWISKO') and o.name = 'FK_STANOWIS_RE1_DZIAL')
alter table STANOWISKO
   drop constraint FK_STANOWIS_RE1_DZIAL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ZADANIA') and o.name = 'FK_ZADANIA_RE4_PRACOWNI')
alter table ZADANIA
   drop constraint FK_ZADANIA_RE4_PRACOWNI
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DZIAL')
            and   type = 'U')
   drop table DZIAL
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRACOWNIK')
            and   name  = 'RE3_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRACOWNIK.RE3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRACOWNIK')
            and   name  = 'RE2_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRACOWNIK.RE2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRACOWNIK')
            and   type = 'U')
   drop table PRACOWNIK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('STANOWISKO')
            and   name  = 'RE1_FK'
            and   indid > 0
            and   indid < 255)
   drop index STANOWISKO.RE1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('STANOWISKO')
            and   type = 'U')
   drop table STANOWISKO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ZADANIA')
            and   name  = 'RE4_FK'
            and   indid > 0
            and   indid < 255)
   drop index ZADANIA.RE4_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ZADANIA')
            and   type = 'U')
   drop table ZADANIA
go

/*==============================================================*/
/* Table: DZIAL                                                 */
/*==============================================================*/
create table DZIAL (
   ID_DZIALU            int                  IDENTITY (1, 1) NOT NULL,
   NAZWA_DZIALU         varchar(50)          null,
   constraint PK_DZIAL primary key nonclustered (ID_DZIALU)
)
go

/*==============================================================*/
/* Table: PRACOWNIK                                             */
/*==============================================================*/
create table PRACOWNIK (
   ID_PRACOWNIKA        int                  IDENTITY (1, 1) NOT NULL,
   ID_DZIALU            int                  not null,
   ID_STANOWISKA        int                  not null,
   IMIE                 varchar(50)          null,
   NAZWISKO             varchar(50)          null,
   constraint PK_PRACOWNIK primary key nonclustered (ID_PRACOWNIKA)
)
go

/*==============================================================*/
/* Index: RE2_FK                                                */
/*==============================================================*/
create index RE2_FK on PRACOWNIK (
ID_STANOWISKA ASC
)
go

/*==============================================================*/
/* Index: RE3_FK                                                */
/*==============================================================*/
create index RE3_FK on PRACOWNIK (
ID_DZIALU ASC
)
go

/*==============================================================*/
/* Table: STANOWISKO                                            */
/*==============================================================*/
create table STANOWISKO (
   ID_STANOWISKA        int                  IDENTITY (1, 1) NOT NULL,
   ID_DZIALU            int                  not null,
   NAZWA_STANOWISKA     varchar(50)          null,
   constraint PK_STANOWISKO primary key nonclustered (ID_STANOWISKA)
)
go

/*==============================================================*/
/* Index: RE1_FK                                                */
/*==============================================================*/
create index RE1_FK on STANOWISKO (
ID_DZIALU ASC
)
go

/*==============================================================*/
/* Table: ZADANIA                                               */
/*==============================================================*/
create table ZADANIA (
   ID_ZADANIA           int                  IDENTITY (1, 1) NOT NULL,
   ID_PRACOWNIKA        int                  not null,
   NAZWA_ZADANIA        varchar(50)          null,
   CZY_WYKONANE         bit                  null,
   constraint PK_ZADANIA primary key nonclustered (ID_ZADANIA)
)
go

/*==============================================================*/
/* Index: RE4_FK                                                */
/*==============================================================*/
create index RE4_FK on ZADANIA (
ID_PRACOWNIKA ASC
)
go

alter table PRACOWNIK
   add constraint FK_PRACOWNI_RE2_STANOWIS foreign key (ID_STANOWISKA)
      references STANOWISKO (ID_STANOWISKA)
go

alter table PRACOWNIK
   add constraint FK_PRACOWNI_RE3_DZIAL foreign key (ID_DZIALU)
      references DZIAL (ID_DZIALU)
go

alter table STANOWISKO
   add constraint FK_STANOWIS_RE1_DZIAL foreign key (ID_DZIALU)
      references DZIAL (ID_DZIALU)
go

alter table ZADANIA
   add constraint FK_ZADANIA_RE4_PRACOWNI foreign key (ID_PRACOWNIKA)
      references PRACOWNIK (ID_PRACOWNIKA)
go

