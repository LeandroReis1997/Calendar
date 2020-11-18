

ALTER TABLE Scheduling
ADD FOREIGN KEY (RoomIdentity) REFERENCES Room(RoomIdentity);