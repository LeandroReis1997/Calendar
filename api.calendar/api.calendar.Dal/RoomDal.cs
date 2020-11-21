using api.calendar.Dal.Interfaces;
using api.calendar.Info.Entities;
using api.calendar.Info.SqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.calendar.Dal
{
    public class RoomDal : IRoomDal
    {
        private SqlDbContext _sqlDbContext;

        public RoomDal(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }

        public async Task<Room> AddRoom(Room room)
        {
            _sqlDbContext.Add(room);
            await _sqlDbContext.SaveChangesAsync();
            return room;
        }

        public Guid DeleteRoom(Guid roomIdentity)
        {
            var entity = _sqlDbContext.Room.FirstOrDefault(x => x.RoomIdentity.Equals(roomIdentity));
            _sqlDbContext.Remove(entity);
            _sqlDbContext.SaveChanges();
            return roomIdentity;
        }

        public async Task<Room> EditRoom(Room room)
        {
            _sqlDbContext.Room.Update(room);
            await _sqlDbContext.SaveChangesAsync();
            return room;
        }

        public IEnumerable<Room> GetAllRoom() =>
            _sqlDbContext.Room.ToList();

        public IEnumerable<Room> GetByRoom(string numberRoom) =>
            _sqlDbContext.Room.Where(x => x.RoomName.Contains(numberRoom));

        public Room GetByRoomIdentity(Guid roomIdentity) =>
            _sqlDbContext.Room.FirstOrDefault(x => x.RoomIdentity == roomIdentity);
    }
}
