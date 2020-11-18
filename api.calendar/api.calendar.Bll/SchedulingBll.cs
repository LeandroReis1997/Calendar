using api.calendar.Bll.Interfaces;
using api.calendar.Dal.Interfaces;
using api.calendar.Info.Entities;
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

        public int DeleteRoomScheduling(int SchedulingIdentity) =>
            _schedulingDal.DeleteRoomScheduling(SchedulingIdentity);

        public async Task<Scheduling> EditRoomScheduling(Scheduling scheduling)
        {
            return await _schedulingDal.EditRoomScheduling(scheduling);
        }

        public List<Scheduling> GetAllScheduling() =>
            _schedulingDal.GetAllScheduling();

        public Scheduling GetByRoom(int numberRoom) =>
            _schedulingDal.GetByRoom(numberRoom);
    }
}
