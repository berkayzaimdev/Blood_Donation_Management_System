CREATE TABLE KanDegerleri(
 Id int IDENTITY(1,1) PRIMARY KEY,
 CRP DECIMAL(5,2) CHECK (CRP >= 0 AND CRP <= 5),
 Alanin_Aminotransferaz DECIMAL(5,2) CHECK (Alanin_Aminotransferaz >= 0 AND
Alanin_Aminotransferaz <= 35),
Aspartat_Aminotransferaz DECIMAL(5,2) CHECK (Aspartat_Aminotransferaz >= 0 AND
Aspartat_Aminotransferaz <= 40),
Glukoz DECIMAL(5,2) CHECK (Glukoz >= 74 AND Glukoz <= 106),
Kreatinin DECIMAL(5,2) CHECK (Kreatinin >= 0.5 AND Kreatinin <= 0.9),
KreatininKinaz DECIMAL(5,2) CHECK (KreatininKinaz >= 0 AND KreatininKinaz <=
170)
);