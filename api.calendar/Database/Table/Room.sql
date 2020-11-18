

create table Room
(
	RoomIdentity UNIQUEIDENTIFIER DEFAULT NEWID(),
	RoomName varchar(50) not null
)
