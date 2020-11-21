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
            room.RoomIdentity = roomIdentity;
            return await _roomDal.EditRoom(room);
        }

        public IEnumerable<Room> GetAllRoom(string nameRoom)
        {

            IEnumerable<Room> rooms = nameRoom  != null ? _roomDal.GetByRoom(nameRoom) : _roomDal.GetAllRoom();

            return rooms;
        }

        public IEnumerable<Room> GetByRoom(string numberRoom) =>
            _roomDal.GetByRoom(numberRoom);

        public Room GetByRoomIdentity(Guid roomIdentity) =>
            _roomDal.GetByRoomIdentity(roomIdentity);
    }
}
