using System;

namespace api.calendar.DTO.Scheduling
{
    public class SchedulingListDTO
    {
        public int SchedulingIdentity { get; set; }
        public string Title { get; set; }
        public int Room { get; set; }
        public DateTime DateStartTime { get; set; }
        public DateTime DateEndTime { get; set; }
    }
}
