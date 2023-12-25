CREATE TABLE HastaTalep(
   Id int IDENTITY(1,1) PRIMARY KEY,
   HastaId int,
   DoktorId int,
   TalepNedeni nvarchar(MAX),
   TalepTarihi datetime
)
