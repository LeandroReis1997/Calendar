using api.calendar.Bll.Interfaces;
using api.calendar.Dal.Interfaces;
using api.calendar.Info.Entities;
using System;
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

        public Guid DeleteRoom(Guid roomIdentity)
        {
            return _roomDal.DeleteRoom(roomIdentity);
        }

        public async Task<Room> EditRoom(Guid roomIdentity, Room room)
        {
            return await _roomDal.EditRoom(room);
        }

        public List<Room> GetAllRoom() =>
            _roomDal.GetAllRoom();

        public Room GetByRoom(string nameRoom) =>
            _roomDal.GetByRoom(nameRoom);

        public Room GetByRoomIdentity(Guid roomIdentity) =>
            _roomDal.GetByRoomIdentity(roomIdentity);
    }
}
