

create table Scheduling
(
	SchedulingIdentity int identity primary key not null,
	Title varchar(50) not null,
	Room int not null,
	DateStartTime datetime,
	DateEndTime datetime
)