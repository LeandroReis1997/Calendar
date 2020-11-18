using api.calendar.Info.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.calendar.Dal.Interfaces
{
    public interface IRoomDal
    {
        List<Room> GetAllRoom();
        Room GetByRoomIdentity(int roomIdentity);
        Room GetByRoom(string nameRoom);
        Task<Room> AddRoom(Room room);
        Task<Room> EditRoom(int roomIdentity,Room room);
        int DeleteRoom(int roomIdentity);
    }
}
