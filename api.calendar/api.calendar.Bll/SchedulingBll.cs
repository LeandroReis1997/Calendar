using api.calendar.Bll.Interfaces;
using api.calendar.Dal.Interfaces;
using api.calendar.Info.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;

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

            var rooms = _schedulingDal.GetBySchedulingRoomIdentity(scheduling.RoomIdentity);

            foreach (var item in rooms)
            {
                if (scheduling.DateStartTime == item.DateStartTime && scheduling.DateEndTime == item.DateEndTime)
                    throw new BusinessException("Data de agendamento já constam, escolha outra data.");
            }
            return await _schedulingDal.AddRoomScheduling(scheduling);
        }

        public Guid DeleteRoomScheduling(Guid schedulingIdentity) =>
            _schedulingDal.DeleteRoomScheduling(schedulingIdentity);

        public async Task<Scheduling> EditRoomScheduling(Guid schedulingIdentity, Scheduling scheduling)
        {
            return await _schedulingDal.EditRoomScheduling(new Scheduling
            {
                SchedulingIdentity = schedulingIdentity,
                Title = scheduling.Title,
                RoomIdentity = scheduling.RoomIdentity,
                DateStartTime = scheduling.DateStartTime,
                DateEndTime = scheduling.DateEndTime
            });
        }

        public List<Scheduling> GetAllScheduling() =>
            _schedulingDal.GetAllScheduling();

        public Scheduling GetByschedulingIdentity(Guid schedulingIdentity) =>
            _schedulingDal.GetByschedulingIdentity(schedulingIdentity);

        public IEnumerable<Scheduling> GetBySchedulingRoomIdentity(Guid roomIdentity) =>
            _schedulingDal.GetBySchedulingRoomIdentity(roomIdentity);
    }
}
