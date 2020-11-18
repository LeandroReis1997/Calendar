using api.calendar.Info.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.calendar.Bll.Interfaces
{
    public interface IRoomBll
    {
        List<Room> GetAllRoom();
        Room GetByRoomIdentity(Guid roomIdentity);
        Room GetByRoom(string nameRoom);
        Task<Room> AddRoom(Room room);
        Task<Room> EditRoom(Guid roomIdentity, Room room);
        Guid DeleteRoom(Guid roomIdentity);
    }
}
