using api.calendar.Info.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.calendar.Dal.Interfaces
{
    public interface IRoomDal
    {
        List<Room> GetAllRoom();
        Room GetByRoomIdentity(Guid roomIdentity);
        Room GetByRoom(string nameRoom);
        Task<Room> AddRoom(Room room);
        Task<Room> EditRoom(Room room);
        Guid DeleteRoom(Guid roomIdentity);
    }
}
