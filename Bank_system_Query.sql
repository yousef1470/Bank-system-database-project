/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     5/23/2023 6:25:56 AM                         */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ACCOUNT') and o.name = 'FK_ACCOUNT_FK_CUSTOM_CUSTOMER')
alter table ACCOUNT
   drop constraint FK_ACCOUNT_FK_CUSTOM_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BRANCH') and o.name = 'FK_BRANCH_FK_BRANCH_BANK')
alter table BRANCH
   drop constraint FK_BRANCH_FK_BRANCH_BANK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CUSTOMER') and o.name = 'FK_CUSTOMER_FK_BRANCH_BRANCH')
alter table CUSTOMER
   drop constraint FK_CUSTOMER_FK_BRANCH_BRANCH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPLOYEE') and o.name = 'FK_EMPLOYEE_FK_BRANCH_BRANCH')
alter table EMPLOYEE
   drop constraint FK_EMPLOYEE_FK_BRANCH_BRANCH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LOAN') and o.name = 'FK_LOAN_FK_BRANCH_BRANCH')
alter table LOAN
   drop constraint FK_LOAN_FK_BRANCH_BRANCH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LOAN') and o.name = 'FK_LOAN_FK_CUSTOM_CUSTOMER')
alter table LOAN
   drop constraint FK_LOAN_FK_CUSTOM_CUSTOMER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ACCOUNT')
            and   type = 'U')
   drop table ACCOUNT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BANK')
            and   type = 'U')
   drop table BANK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BRANCH')
            and   type = 'U')
   drop table BRANCH
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CUSTOMER')
            and   type = 'U')
   drop table CUSTOMER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMPLOYEE')
            and   type = 'U')
   drop table EMPLOYEE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LOAN')
            and   type = 'U')
   drop table LOAN
go

/*==============================================================*/
/* Table: ACCOUNT                                               */
/*==============================================================*/
create table ACCOUNT (
   ACC_NO               int                  not null,
   SSN                  int                  null,
   BALANCE              int                  not null,
   ATYPE                varchar(255)         not null,
   constraint PK_ACCOUNT primary key (ACC_NO)
)
go

/*==============================================================*/
/* Table: BANK                                                  */
/*==============================================================*/
create table BANK (
   CODE                 int                  not null,
   BNAME                varchar(255)         not null,
   BANK_ADDRESS         varchar(255)         not null,
   constraint PK_BANK primary key (CODE)
)
go

/*==============================================================*/
/* Table: BRANCH                                                */
/*==============================================================*/
create table BRANCH (
   BRANCH_NO            int                  not null,
   CODE                 int                  null,
   BRANCH_ADDRESS       varchar(255)         not null,
   constraint PK_BRANCH primary key (BRANCH_NO)
)
go

/*==============================================================*/
/* Table: CUSTOMER                                              */
/*==============================================================*/
create table CUSTOMER (
   SSN                  int                  not null,
   BRANCH_NO            int                  null,
   CNAME                varchar(255)         not null,
   CUSTOMER_ADDRESS     varchar(255)         not null,
   PHONE                varchar(255)         not null,
   constraint PK_CUSTOMER primary key (SSN)
)
go

/*==============================================================*/
/* Table: EMPLOYEE                                              */
/*==============================================================*/
create table EMPLOYEE (
   EMPLOYEE_ID          int                  not null,
   BRANCH_NO            int                  null,
   PHONE                varchar(255)         not null,
   ENAME                varchar(255)         not null,
   EADDRESS             varchar(255)         not null,
   constraint PK_EMPLOYEE primary key (EMPLOYEE_ID)
)
go

/*==============================================================*/
/* Table: LOAN                                                  */
/*==============================================================*/
create table LOAN (
   LOAN_NO              int                  identity,
   SSN                  int                  not null,
   BRANCH_NO            int                  not null,
   AMOUNT               int                  not null,
   LTYPE                varchar(255)         not null,
   STATUS               varchar(255)         null default 'Waiting',
   constraint PK_LOAN primary key (LOAN_NO)
)
go

alter table ACCOUNT
   add constraint FK_ACCOUNT_FK_CUSTOM_CUSTOMER foreign key (SSN)
      references CUSTOMER (SSN)
go

alter table BRANCH
   add constraint FK_BRANCH_FK_BRANCH_BANK foreign key (CODE)
      references BANK (CODE)
go

alter table CUSTOMER
   add constraint FK_CUSTOMER_FK_BRANCH_BRANCH foreign key (BRANCH_NO)
      references BRANCH (BRANCH_NO)
go

alter table EMPLOYEE
   add constraint FK_EMPLOYEE_FK_BRANCH_BRANCH foreign key (BRANCH_NO)
      references BRANCH (BRANCH_NO)
go

alter table LOAN
   add constraint FK_LOAN_FK_BRANCH_BRANCH foreign key (BRANCH_NO)
      references BRANCH (BRANCH_NO)
go

alter table LOAN
   add constraint FK_LOAN_FK_CUSTOM_CUSTOMER foreign key (SSN)
      references CUSTOMER (SSN)
go

