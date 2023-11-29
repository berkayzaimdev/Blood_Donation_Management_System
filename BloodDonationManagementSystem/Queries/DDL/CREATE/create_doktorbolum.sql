CREATE TABLE DoktorBolum(
   DoktorId int,
   BolumId int,
   FOREIGN KEY(DoktorId) REFERENCES Uye(Id),
   FOREIGN KEY(BolumId) REFERENCES Bolum(Id)
);