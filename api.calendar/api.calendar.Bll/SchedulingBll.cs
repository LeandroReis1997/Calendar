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

        public Task<Scheduling> AddRoomScheduling(Scheduling scheduling)
        {
            return _schedulingDal.AddRoomScheduling(scheduling);
        }

        public int DeleteRoomScheduling(int SchedulingIdentity) =>
            _schedulingDal.DeleteRoomScheduling(SchedulingIdentity);

        public Task<Scheduling> EditRoomScheduling(Scheduling scheduling)
        {
            return _schedulingDal.EditRoomScheduling(scheduling);
        }

        public List<Scheduling> GetAllScheduling() =>
            _schedulingDal.GetAllScheduling();

        public Scheduling GetByRoom(int numberRoom) =>
            _schedulingDal.GetByRoom(numberRoom);
    }
}
