CREATE TABLE HastaKanGrubu(
   HastaId int,
   KanGrubuId int,
   FOREIGN KEY(HastaId) REFERENCES Uye(Id),
   FOREIGN KEY(KanGrubuId) REFERENCES KanGrubu(Id)
);