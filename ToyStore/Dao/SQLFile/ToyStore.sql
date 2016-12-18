create database ToyStore
go
use ToyStore	
go
create table ACCOUNT
(
ID int not null ,
USERNAME Nvarchar(20) not null,
PASS Nvarchar(20) not null,
constraint pk_Account primary key (ID)
)
go
create table DOCHOI
(
	MADC int  not null,
	TENDC nvarchar(200),
	SL int,
	NUOCSX nvarchar(15),
	LOAI nvarchar(30),
	GIA float
	constraint	pk_DOCHOI primary key(MADC)
)
go
create table NHANVIEN(
MANV int not null,
TENNV nvarchar(50) not null,
SDT nvarchar(11)not null,
QUEQUAN nvarchar(60),
PHAI nvarchar(4),
CMT nvarchar(9) ,
NGAYSINH date not null,
NGAYVAOLAM date not null,
MACV Nvarchar(4) not null,
constraint pk_NHANVIEN primary key (MANV)
)
create table CHUCVU(
MACV Nvarchar(4) not null,
TENCV Nvarchar(30) not null,
constraint pk_CHUCVU primary key (MACV)
)
go

create table HOADON(
MAHD int identity(3144100,1) not null,
NGAYHD date not null,
MANV int not null,
TRIGIA float ,
constraint pk_HOADON primary key(MAHD)
)
go
create table CTHD(
MAHD int not null,
MADC int not null,
SL int,
GIA float,
constraint pk_CTHD primary key(MAHD,MADC)
)
go

create table BAOCAO
(
MABC int identity(66800,1) not null,
NGAYBAOCAO date,
TONGGIATRI float,
constraint pk_BAOCAO primary key(MABC)
)
go

create table NHAPKHO
(
	MANV int not null,
	MADC int not null,
	NGAYNHAP date not null,
	SL int,
	GIA float,
	constraint pk_NHAPKHO primary key(MADC)
)
go

insert into CHUCVU values
('AD',N'Quản lí'),
('NVBH',N'Nhân viên bán hàng'),
('NVTV',N'Nhân viên thời vụ')

insert into NHANVIEN values
(3114100,N'Lê Văn Bảo','0165650078',N'Thanh Hóa hahh',N'Nam','174660321','8/11/1996','11/15/2016','AD'),
(3114101,N'Trần Phúc Hậu','0157862714',N'Thành phố HCM ha',N'Nam','16557946','9/4/1996','11/20/2016','NVBH'),
(3114102,N'Trần văn Luân','0122644971',N'Nha Trang hahha',N'Nam','19634724','4/16/1996','11/30/2016','NVBH')


insert into DOCHOI values(600000,N'Xe HotWheels',150,N'Mỹ',N'Xe mô hình',350000),
(600001,N'Xe lửa Thomas',200,N'Philipines',N'Xe mô hình',400000),
(600002,N'Xe điền khiển lamborghini',90,N'Anh',N'Xe mô hình',250000),
(600003,N'Xe điền khiển BMW i8',100,N'Đức',N'Xe mô hình',250000),
(600004,N'Xe điền khiển Ferrari Laferrari',110,N'Mỹ',N'Xe mô hình',260000),
(600005,N'Xe điều khiển từ xa Reventon Roadster 42300',110,N'Mỹ',N'Xe mô hình',290000),
(600006,N'Xe điền khiển Ferrari Laferrari',110,N'Mỹ',N'Xe mô hình',300000),
(600007,N'Xe điền khiển vô lăng tròn 6703',110,N'Việt Nam',N'Xe mô hình',340000)
insert into ACCOUNT values
(3114100,N'AchillesLe',N'haithanhf'),
(3114101,N'ShinHaou',N'Hau'),
(3114102,N'LuanTran',N'LuanTran')
go
alter table NHANVIEN add foreign key(MACV) references CHUCVU(MACV)
alter table ACCOUNT add foreign key(ID) references NHANVIEN(MANV)
alter table CTHD add foreign key (MAHD) references HOADON(MAHD)
alter table CTHD add foreign key (MADC) references DOCHOI(MADC)
alter table HOADON add foreign key (MANV) references NHANVIEN(MANV)
alter table NHAPKHO add foreign key (MANV) references NHANVIEN(MANV)
alter table NHAPKHO add foreign key (MADC) references DOCHOI(MADC)
