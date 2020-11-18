using api.calendar.Bll.Interfaces;
using api.calendar.Dal.Interfaces;
using api.calendar.Info.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.calendar.Bll
{
    public class RoomBll : IRoomBll
    {
        private IRoomDal _roomDal;
        public RoomBll(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public async Task<Room> AddRoom(Room room)
        {
            return await _roomDal.AddRoom(room);
        }

        public int DeleteRoom(int roomIdentity)
        {
            return _roomDal.DeleteRoom(roomIdentity);
        }

        public async Task<Room> EditRoom(int roomIdentity, Room room)
        {
            return await _roomDal.EditRoom(roomIdentity, room);
        }

        public List<Room> GetAllRoom() =>
            _roomDal.GetAllRoom();

        public Room GetByRoom(string nameRoom) =>
            _roomDal.GetByRoom(nameRoom);

        public Room GetByRoomIdentity(int roomIdentity) =>
            _roomDal.GetByRoomIdentity(roomIdentity);
    }
}
