using System;

namespace api.calendar.DTO.Scheduling
{
    public class SchedulingListDTO
    {
        public Guid SchedulingIdentity { get; set; }
        public string Title { get; set; }
        public Guid RoomIdentity { get; set; }
        public DateTime DateStartTime { get; set; }
        public DateTime DateEndTime { get; set; }
    }
}
