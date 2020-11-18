using api.calendar.Info.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.calendar.Bll.Interfaces
{
    public interface ISchedulingBll
    {
        List<Scheduling> GetAllScheduling();
        Scheduling GetByschedulingIdentity(int schedulingIdentity);
        Scheduling GetByRoom(string nameRoom);
        Task<Scheduling> AddRoomScheduling(Scheduling scheduling);
        Task<Scheduling> EditRoomScheduling(int schedulingIdentity, Scheduling scheduling);
        int DeleteRoomScheduling(int schedulingIdentity);
    }
}
