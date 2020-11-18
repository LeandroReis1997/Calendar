

create table Scheduling
(
	SchedulingIdentity int identity not null,
	Title varchar(50) not null,
	RoomIdentity int not null,
	DateStartTime datetime,
	DateEndTime datetime
)
