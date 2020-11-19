using api.calendar.Bll.Interfaces;
using api.calendar.Dal.Interfaces;
using api.calendar.Info.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.calendar.Bll
{
    public class SchedulingBll : ISchedulingBll
    {
        private ISchedulingDal _schedulingDal;

        public SchedulingBll(ISchedulingDal schedulingDal)
        {
            _schedulingDal = schedulingDal;
        }

        public async Task<Scheduling> AddRoomScheduling(Scheduling scheduling)
        {
            return await _schedulingDal.AddRoomScheduling(scheduling);
        }

        public Guid DeleteRoomScheduling(Guid schedulingIdentity) =>
            _schedulingDal.DeleteRoomScheduling(schedulingIdentity);

        public async Task<Scheduling> EditRoomScheduling(Guid schedulingIdentity, Scheduling scheduling)
        {
            return await _schedulingDal.EditRoomScheduling(scheduling);
        }

        public List<Scheduling> GetAllScheduling() =>
            _schedulingDal.GetAllScheduling();

        public Scheduling GetByRoomScheduling(string nameRoom) =>
            _schedulingDal.GetByRoomScheduling(nameRoom);

        public Scheduling GetByschedulingIdentity(Guid schedulingIdentity) =>
            _schedulingDal.GetByschedulingIdentity(schedulingIdentity);
    }
}
