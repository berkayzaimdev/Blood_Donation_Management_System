CREATE TABLE Uye(
   Id int IDENTITY(1,1) PRIMARY KEY,
   TcKimlikNo varchar(11) CHECK(TcKimlikNo='___________') UNIQUE,
   Isim varchar(50),
   Soyisim varchar(50),
   Yas varchar(3),
   Sifre varchar(100),
   Telefon varchar(9) CHECK(Telefon='__________')  UNIQUE
);