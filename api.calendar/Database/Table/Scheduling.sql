

create table Scheduling
(
	SchedulingIdentity UNIQUEIDENTIFIER DEFAULT NEWID(),
	Title varchar(50) not null,
	RoomIdentity uniqueidentifier not null,
	DateStartTime datetime,
	DateEndTime datetime
)
