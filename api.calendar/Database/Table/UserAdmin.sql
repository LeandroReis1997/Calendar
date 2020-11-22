

create table UserAdmin
 (
    UserIdentity UNIQUEIDENTIFIER DEFAULT NEWID(),
    Name varchar(50) not null, 
    Email varchar(50) not null,
    Password varchar(12) not null,
    Role varchar(50)
 )
