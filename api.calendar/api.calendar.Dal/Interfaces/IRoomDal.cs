using api.calendar.Info.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.calendar.Dal.Interfaces
{
    public interface IRoomDal
    {
        IEnumerable<Room> GetAllRoom();
        Room GetByRoomIdentity(Guid roomIdentity);
        IEnumerable<Room> GetByRoom(string numberRoom);
        Task<Room> AddRoom(Room room);
        Task<Room> EditRoom(Room room);
        Guid DeleteRoom(Guid roomIdentity);
    }
}
