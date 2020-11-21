using api.calendar.Info.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.calendar.Bll.Interfaces
{
    public interface ISchedulingBll
    {
        List<Scheduling> GetAllScheduling();
        Scheduling GetByschedulingIdentity(Guid schedulingIdentity);
        IEnumerable<Scheduling> GetBySchedulingRoomIdentity(Guid roomIdentity);
        Task<Scheduling> AddRoomScheduling(Scheduling scheduling);
        Task<Scheduling> EditRoomScheduling(Guid schedulingIdentity, Scheduling scheduling);
        Guid DeleteRoomScheduling(Guid schedulingIdentity);
    }
}
