using api.calendar.Dal.Interfaces;
using api.calendar.Info.Entities;
using api.calendar.Info.SqlDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.calendar.Dal
{
    public class SchedulingDal : ISchedulingDal
    {
        private SqlDbContext _sqlDbContext;

        public SchedulingDal(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }

        public async Task<Scheduling> AddRoomScheduling(Scheduling scheduling)
        {
            _sqlDbContext.Add(scheduling);
            await _sqlDbContext.SaveChangesAsync();
            return scheduling;
        }

        public Guid DeleteRoomScheduling(Guid SchedulingIdentity)
        {
            var entity = _sqlDbContext.Scheduling.FirstOrDefault(x => x.SchedulingIdentity.Equals(SchedulingIdentity));
            _sqlDbContext.Remove(entity);
            _sqlDbContext.SaveChanges();

            return SchedulingIdentity;
        }

        public async Task<Scheduling> EditRoomScheduling(Scheduling scheduling)
        {
            _sqlDbContext.Scheduling.Update(scheduling);
            await _sqlDbContext.SaveChangesAsync();
            return scheduling;
        }

        public List<Scheduling> GetAllScheduling() =>
            _sqlDbContext.Scheduling.Include(x => x.Rooms).ToList();

        public Scheduling GetByRoomScheduling(string nameRoom) =>
            _sqlDbContext.Scheduling.Include(x => x.Rooms).FirstOrDefault(x => x.Rooms.RoomName == nameRoom);

        public Scheduling GetByschedulingIdentity(Guid schedulingIdentity) =>
            _sqlDbContext.Scheduling.Include(x => x.Rooms).FirstOrDefault(x => x.SchedulingIdentity == schedulingIdentity);
    }
}
