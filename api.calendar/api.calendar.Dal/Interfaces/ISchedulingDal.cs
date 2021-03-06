﻿using api.calendar.Info.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.calendar.Dal.Interfaces
{
    public interface ISchedulingDal
    {
        List<Scheduling> GetAllScheduling();
        Scheduling GetByschedulingIdentity(Guid schedulingIdentity);
        IEnumerable<Scheduling> GetBySchedulingRoomIdentity(Guid roomIdentity);
        Task<Scheduling> AddRoomScheduling(Scheduling scheduling);
        Task<Scheduling> EditRoomScheduling(Scheduling scheduling);
        Guid DeleteRoomScheduling(Guid schedulingIdentity);
    }
}
