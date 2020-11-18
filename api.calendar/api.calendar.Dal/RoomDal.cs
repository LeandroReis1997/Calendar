using api.calendar.Dal.Interfaces;
using api.calendar.Info.Entities;
using api.calendar.Info.SqlDbContext;
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

        public int DeleteRoom(int roomIdentity)
        {
            var entity = _sqlDbContext.Room.FirstOrDefault(x => x.RoomIdentity.Equals(roomIdentity));
            _sqlDbContext.Remove(entity);
            _sqlDbContext.SaveChanges();
            return roomIdentity;
        }

        public async Task<Room> EditRoom(int roomIdentity, Room room)
        {
            _sqlDbContext.Room.Update(room);
            await _sqlDbContext.SaveChangesAsync();
            return room;
        }

        public List<Room> GetAllRoom() =>
            _sqlDbContext.Room.ToList();

        public Room GetByRoom(string numberRoom) =>
            _sqlDbContext.Room.FirstOrDefault(x => x.RoomName == numberRoom);

        public Room GetByRoomIdentity(int roomIdentity) =>
            _sqlDbContext.Room.FirstOrDefault(x => x.RoomIdentity == roomIdentity);
    }
}
