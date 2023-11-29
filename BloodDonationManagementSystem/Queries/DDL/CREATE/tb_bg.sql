CREATE TABLE BloodGroups(
   Id int IDENTITY(1,1) PRIMARY KEY,
   GroupName varchar(2) CHECK(GroupName IN ('A','B','AB','0')),
   Rh char(1) CHECK(Rh IN('+','-'))
);