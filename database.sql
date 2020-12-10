USE MASTER
GO
IF EXISTS (SELECT * FROM SYSDATABASES WHERE NAME = 'TIKI')
DROP DATABASE TIKI
GO 
CREATE DATABASE TIKI
GO 
USE TIKI
GO
CREATE TABLE COMPANY(
  com_id int identity primary key,
  com_name nvarchar(50) not null,
)
GO
CREATE TABLE PUBLISHER(
  pub_id int identity primary key,
  pub_name nvarchar(50) not null
)
GO
CREATE TABLE CATEGORY(
  cat_id int identity primary key,
  cat_name nvarchar(50) not null
)
GO
CREATE TABLE BOOK(
  book_id int identity(1000,1) primary key,
  book_name nvarchar(100) not null,
  book_img_small nvarchar(100),
  book_img_large nvarchar(100),
  book_price int,
  book_sale int,
  public_date date,
  width int,
  height int,
  page_number int,
  article nvarchar,
  com_id int foreign key references COMPANY(com_id)
  pub_id int foreign key references PUBLISHER(pub_id),
  cat_id int foreign key references CATEGORY(cat_id),
)
GO
CREATE TABLE CUSTOMER(
  cus_usr varchar(12) primary key,
  cus_pwd varchar(20) not null,
  cus_name nvarchar(100) not null,
  cus_phone char(10),
  cus_address nvarchar(100),
)

GO
CREATE TABLE EMPLOYEE(
  emp_usr varchar(12) primary key,
  emp_pwd varchar(20) not null,
  emp_name nvarchar(100) not null,
  emp_phone char(10) not null,
  emp_address nvarchar(100),
  emp_role int not null
)
GO
CREATE TABLE ORDERS(
  ord_id int identity(100000,1) primary key,
  cus_urs varchar(12) foreign key references CUSTOMER(cus_usr),
  ord_timeup datetime,
  ord_timedown datetime,
  ord_address nvarchar(100) not null,
  ord_phone char(10) not null,
  ord_require nvarchar(100)
)
GO 
CREATE TABLE ORDER_DETAIL(
  ord_id int foreign key references ORDERS(ord_id),
  book_id int foreign key references BOOK(book_id),
  ord_quantity int not null,
  ord_price int not null,
  primary key(ord_id,book_id)
)
GO
CREATE TABLE EVALUATE(
  eva_id int identity primary key,
  cus_usr varchar(12) foreign key references CUSTOMER(cus_usr),
  book_id int foreign key references BOOK(book_id),
  eva_date datetime not null,
  eva_content nvarchar not null,
  eva_rate int not null
)
GO
