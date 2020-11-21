using api.calendar.Info.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.calendar.Bll.Interfaces
{
    public interface IRoomBll
    {
        IEnumerable<Room> GetAllRoom(string nameRoom);
        Room GetByRoomIdentity(Guid roomIdentity);
        IEnumerable<Room> GetByRoom(string numberRoom);
        Task<Room> AddRoom(Room room);
        Task<Room> EditRoom(Guid roomIdentity, Room room);
        Guid DeleteRoom(Guid roomIdentity);
    }
}
