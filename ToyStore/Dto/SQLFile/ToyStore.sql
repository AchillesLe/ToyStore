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
MANV int identity(3114100,1) not null,
TENNV nvarchar(50) not null,
NGAYSINH date not null,
SDT nvarchar(11)not null,
QUEQUAN nvarchar(60),
PHAI nvarchar(4),
CMT nvarchar(9) ,
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
MAKH int ,
MANV int not null,
TRIGIA float ,
constraint pk_HOADON primary key(MAHD)
)
go
create table CTHD(
MAHD int not null,
MADC int not null,
SL int,
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

insert into CHUCVU values
('AD',N'Quản lí'),
('NVBH',N'Nhân viên bán hàng'),
('NVTV',N'Nhân viên thời vụ')

insert into NHANVIEN values
(N'Lê Văn Bảo','8/11/1996','0165650078',N'Thanh Hóa hahh',N'Nam','174660321','11/15/1996','AD'),
(N'Trần Phúc Hậu','9/4/1996','0157862714',N'Thành phố HCM ha',N'Nam','16557946','11/20/1996','NVBH'),
(N'Trần văn Luân','4/16/1996','0122644971',N'Nha Trang hahha',N'Nam','19634724','11/30/1996','NVBH')


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
(3114101,N'ShinHou',N'Hau'),
(3114102,N'LuanTran',N'LuanTran')
go
alter table NHANVIEN add foreign key(MACV) references CHUCVU(MACV)
alter table ACCOUNT add foreign key(ID) references NHANVIEN(MANV)
alter table CTHD add foreign key (MAHD) references HOADON(MAHD)
alter table CTHD add foreign key (MADC) references DOCHOI(MADC)
alter table HOADON add foreign key (MANV) references NHANVIEN(MANV)