CREATE TABLE Istek(
   Id int IDENTITY(1,1) PRIMARY KEY,
   HastaId int,
   DoktorId int,
   IstekNedeni nvarchar(MAX),
   IstekTarihi datetime
)
