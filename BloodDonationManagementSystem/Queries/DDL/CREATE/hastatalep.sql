CREATE TABLE HastaTalep(
   Id int IDENTITY(1,1) PRIMARY KEY,
   HastaId int,
   DoktorId int,
   TalepTarihi datetime,
   TalepNedeni nvarchar(max)
)
