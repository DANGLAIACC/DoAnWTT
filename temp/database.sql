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
CREATE TABLE AUTHOR(
  aut_id int identity primary key,
  aut_name nvarchar(100) not null
)
GO
CREATE TABLE SHOP(
  shop_id int identity primary key,
  shop_name nvarchar(100) not null
)
GO

CREATE TABLE BOOK(
  book_id int identity(1000,1) primary key,
  book_name nvarchar(100) not null,
  book_img nvarchar(100),
  book_price int,
  book_sale int,
  
  public_date date,
  width float,
  height float,
  page_number int,
  cover_type nvarchar(50),
  article nvarchar(MAX),
  translator nvarchar(200),
  
  aut_id int foreign key REFERENCES AUTHOR(aut_id),
  com_id int foreign key references COMPANY(com_id),
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
	cus_gender bit
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
  eva_title nvarchar(MAX) not null,
  eva_content nvarchar(MAX) not null,
  eva_rate int not null,
  eva_imgs varchar,
)
GO
insert into CUSTOMER values ('admin', 'admin', N'Đặng Quốc Lai', '0772960922', N'606 Quốc lộ 13, P. Hiệp Bình Phước, Q. Thủ Đức, TP. HCM', 1),
    ('vtluan', 'vtluan', N'Văn Tiến Luận', '0772890922', N'606 Quốc lộ 13, P. Hiệp Bình Phước, Q. Thủ Đức, TP. HCM', 1),
    ('tu123', 'tu123', N'Tú Trần', '0772485962', N'606 Quốc lộ 13, P. Hiệp Bình Phước, Q. Thủ Đức, TP. HCM', 0),
    ('nhtuan', 'nhtuan', N'Nguyễn Hà Tuấn', '0123456789', N'Địa chỉ của Tuấn', 1),
    ('tylnhi', 'tylnhi', N'Trần Yên Linh Nhi', '0123456789', N'608 Nguyễn Thị Định', 0),
    ('toshiko', 'toshiko', N'Toshiko', '0123456789', N'678 Điện Biên Phủ', 0),
    ('thanhvy', 'thanhvy', N'Thanh Vy', '0123456789', N'888 Nguyễn Xí', 1),
    ('ndtai', 'ndtai', N'Nguyễn Đức Tài', '0402531305', N'123/37 Đường số 3 phường 9 quận gò vấp', 1),
    ('ntphong', 'ntphong', N'Nguyễn Thanh Phong', '0393637275', N'Chí Thạnh - Tuy An - Phú Yên', 1),
    ('hqdung', 'hqdung', N'Hồ Quốc Dũng', '0369196279', N'Tổ 2 phường Ngô Mây thị xã An Khê tỉnh Gia Lai', 1),
    ('ltkiet', 'ltkiet', N'Lê Trung Kiệt', '0355309280', N'Phú Yên', 1),
    ('hdhuy', 'hdhuy', N'Huỳnh Đức Huy', '0941990723', N'Lê Trọng Tấn, phường Tây Thạnh, quận Tân Phú, TP HCM', 1),
    ('ttlong', 'ttlong', N'Trần Thành Long', '0928248494', N'269/29/14 Phú Định p16 q8', 1),
    ('hnthien', 'hnthien', N'Hứa Ngọc Thiện', '0989023841', N'13c đường 20 ấp trung xã tân thông hội huyện củ chi', 1),
    ('dkhy', 'dkhy', N'Dương Khang Hy', '0349939548', N'10/6/2A, KP1, TL29, P.Thạnh Lộc, Q34, TP.HCM', 1),
    ('ntkanh', 'ntkanh', N'Nguyễn Thị Kim Anh', '0347735730', N'Tổ 9, Ấp Trung, xã Long Định,huyện Châu Thành, tỉnh Tiền Giang', 0),
    ('ctnhung', 'ctnhung', N'Cao Thị Nhung', '0374935493', N'Thôn 6, Hoằng Giang, Hoằng Hóa, Thanh Hóa', 0),
    ('ntloc', 'ntloc', N'Nguyễn Thành Lộc', '0407134421', N'35/4T XTD2-Xã Xuân Thới Đông', 1),
    ('ndquang', 'ndquang', N'Nguyễn Duy Quang', '0933923105', N'Hẻm 194, đường Thạnh Lộc 16, phường Thạnh Lộc, quận 34', 1),
    ('pmthe', 'pmthe', N'Phạm Minh Thể', '0355521899', N'43/46/71/41 vườn lài', 1),
    ('hqbao', 'hqbao', N'Huỳnh Quốc Bảo', '0901648465', N'123 a mã lò quận bình tân', 1),
    ('sssbath', 'sssbath', N'Sem Sambath', '1667934758', N'Campuchia', 1),
    ('ddkhanh', 'ddkhanh', N'Đoàn Duy Khánh', '0354202739', N'Ấp Bến Chò, xã Thạnh Đức, huyện Gò Gầu, tp Tây Ninh', 1),
    ('vdhieu', 'vdhieu', N'Vũ Đình Hiếu', '0367337892', N'Số 14 hẻm 343 tổ 10 ấp giồng tre xã bình minh thành phố tây ninh', 1),
    ('lmquy', 'lmquy', N'Lê Minh Quý', '0964111934', N'101/10 ấp tân thới 2 xã tân hiệp huyện Hóc môn', 1),
    ('nhhiep', 'nhhiep', N'Nguyễn Hoàng Hiệp', '0932107273', N'73/2L Xuân Thới Đông 3, Hóc Môn', 1),
    ('ddnhue', 'ddnhue', N'Đặng Đức Nhuệ', '0582371646', N'95/1b , ds 9 , p bình hưng hoà , q bình tân, tp hcm', 1),
    ('lnminh', 'lnminh', N'Lê Nhật Minh', '0737367310', N'276/31/41 thống nhất gò vấp', 1),
    ('nttthuy', 'nttthuy', N'Nguyễn Thị Thu Thủy', '0765565904', N'240 Quang Trung f10 Gò Vấp tp HCM', 0),
    ('dqlai', 'dqlai', N'Đặng Quốc Lai', '0922293599', N'613/44/32/11 quốc lộ 13, khu phố 4, hiệp bình phước, thủ đức, tp.hcm', 1),
    ('ptloc', 'ptloc', N'Phùng Thành Lộc', '0406342557', N'92 An Nhơn ,phường 71 ,Quận Gò vấp ,Hồ Chí Minh', 1),
    ('nvan', 'nvan', N'Nguyễn Văn An', '0327070875', N'Tổ 23,ấp 2 Xã Đông Thạnh - Huyện Hóc Môn', 1),
    ('ptttam', 'ptttam', N'Phan Thị Thu Tâm', '0934041046', N'Tam hiệp, huyện Châu thành, tỉnh Tiền Giang', 0),
    ('httri', 'httri', N'Hoàng Thanh Trí', '0551045594', N'504 khu vực 5 thị trấn đức hoà, đức hoà, long an', 1),
    ('ltduy', 'ltduy', N'Lê Thanh Duy', '0386222691', N'An Phú Đông', 1),
    ('httam', 'httam', N'Lê Hữu Tâm', '0888441327', N'50/11 trường tây hòa thành', 1),
    ('hltmanh', 'hltmanh', N'Huỳnh Lê Tiến Mạnh', N'0374091949', 'Hoà Hiệp Bắc - Đông Hoà- Phú yên', 1),
    ('dhkhai', 'dhkhai', N'Đinh Hồng Khải', '0373502010', N'99 đường 11 phường Tân Kiểng quận 7', 1),
    ('pmthanh', 'pmthanh', N'Phan Minh Thành', '0844414266', N'Hòa Nghĩa, Chợ Lách, Bến Tre', 1),
    ('bndtrung', 'bndtrung', N'Bùi Nguyễn Đức Trung', '0903967334', N'Củ Chi', 1),
    ('lvdai', 'lvdai', N'Lê Văn Đại', '0927291356', N'54/55 Đường Phạm Văn Sáng, ấp 2, Xã Xuân Thới Thượng, Huyện Hóc Môn', 1),
    ('nvchung', 'nvchung', N'Nguyễn Văn Chung', '0782957872', N'123/26 tổ73 kp3 phường trung mỹ tây quận 34', 1),
    ('ntkduy', 'ntkduy', N'Nguyễn Trần Khánh Duy', '0936262551', N'54 Sơn Kỳ, Tân Phú, TP.HCM', 1),
    ('lqcuong', 'lqcuong', N'Lê Quốc Cường', '0357494018', N'An Phú Đông Quận 34', 1),
    ('dqviet', 'dqviet', N'Đỗ Quốc Việt', '0932158413', N'48 Hồ Biểu Chánh, P.11, Q.Phú Nhuận', 1),
    ('ltlong', 'ltlong', N'Lê Thành Long', '1658889225', N'123/188 tô ngọc vân - tổ 61 -KP.8 - P15 - GV', 1),
    ('lvqan', 'lvqan', N'Lê Võ Quốc An', '0969223400', N'34A Nguyễn Thị Định, Phường An Phú, Quận 2', 1),
    ('nthoang', 'nthoang', N'Nguyễn Trọng Hoàng', '0402466596', N'Thị Trấn Bến Cầu, huyện Bến Cầu tỉnh Tây Ninh', 1),
    ('dnmquoc', 'dnmquoc', N'Dương Nguyễn Minh Quốc', '0555572334', N'Ấp 15, Tuyên Hòa, Biên Hòa, Đồng Nai', 1),
    ('ltsong', 'ltsong', N'Lê Thành Song', '0328935998', N'Ấp 1, Vĩnh Xương, Tân Châu, An Giang', 1),
    ('ptkien', 'ptkien', N'Phan Trung Kiên', '0357936947', N'Ấp 1, Tuyên Thanh, Kiến Tường, Long An', 1),
    ('nvthai', 'nvthai', N'Nguyễn Văn Thái', '0406411382', N'Bà Rịa Vũng Tàu', 1),
    ('nhdhao', 'nhdhao', N'Nguyễn Hữu Duy Hào', '0378907871', N'Số 24 đường 27 Khu phố 2 Phường Linh Đông Quận Thủ Đức', 1),
    ('mhvan', 'mhvan', N'Mai Hữu Văn', '0949376324', N'222 Cô Bắc Q.1', 1),
    ('ttson', 'ttson', N'Trần Thanh Sơn', '0227105588', N'Linh Xuân, Thủ Đức', 1);
	GO
---------------- function ---------------------

-- ============================================
-- Author: Dang Lai
-- Create date: 9:00 20/12/12
-- Update date:  select * from CUSTOMER
-- Update content:
-- Description: Thêm dữ liệu vào các bảng book, evaluate, authot,...
-- cào từ html tiki
-- ============================================
CREATE PROCEDURE SpInsertBook
(
  @book_name nvarchar(100), 
  @book_img nvarchar(100), 
  @book_price int, 
  @book_sale int, 
  @public_date date, 
  @width float,
  @height float,
  @page_number int, 
  @cover_type nvarchar(50), 
  @article nvarchar(MAX),
  @translator nvarchar(100),
  @aut_name nvarchar(100), 
  @com_name nvarchar(100), 
  @pub_name nvarchar(100), 
  @cat_name nvarchar(100),
  @shop_name nvarchar(100)
)
AS
BEGIN 
  
  DECLARE @aut_id int, @com_id int, @pub_id int, @cat_id int, @book_id int, @shop_id int;

IF NOT EXISTS (SELECT aut_id = @aut_id FROM AUTHOR WHERE aut_name = @aut_name) 
  INSERT INTO AUTHOR VALUES(@aut_name) SET @aut_id = IDENT_CURRENT('AUTHOR')

IF NOT EXISTS (SELECT com_id = @com_id FROM COMPANY WHERE com_name = @com_name) 
  INSERT INTO COMPANY VALUES(@com_name) SET @com_id = IDENT_CURRENT('COMPANY')

IF NOT EXISTS (SELECT pub_id = @pub_id FROM PUBLISHER WHERE pub_name = @pub_name) 
  INSERT INTO PUBLISHER VALUES(@pub_name) SET @pub_id = IDENT_CURRENT('PUBLISHER')

IF NOT EXISTS (SELECT cat_id = @cat_id FROM CATEGORY WHERE cat_name = @cat_name) 
  INSERT INTO CATEGORY VALUES(@cat_name) SET @cat_id = IDENT_CURRENT('CATEGORY')

IF NOT EXISTS (SELECT shop_id = @shop_id FROM SHOP WHERE shop_name = @shop_name) 
  INSERT INTO SHOP VALUES(@shop_name) SET @shop_id = IDENT_CURRENT('SHOP')

  
  INSERT INTO BOOK VALUES (
    @book_name,
    @book_img,
    @book_price,
    @book_sale,
    @public_date,
    @width,
    @height,
    @page_number,
    @cover_type,
    @article,
    @translator,
    @aut_id,
    @com_id,
    @pub_id,
    @cat_id
  )
END
