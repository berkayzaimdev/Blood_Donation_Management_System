CREATE TABLE HastaTalepSonucu(
   Id int IDENTITY(1,1) PRIMARY KEY,
   TalepId int,
   TahlilId int,
   DoktorId int,
   SonucTarihi datetime,
   Uygunluk bit
)
