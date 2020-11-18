using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.calendar.Info.Entities
{
    public class Scheduling
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchedulingIdentity { get; set; }
        public string Title { get; set; }
        public int RoomIdentity { get; set; }
        [ForeignKey("RoomIdentity")]
        public virtual Room Rooms { get; set; }
        public DateTime DateStartTime { get; set; }
        public DateTime DateEndTime { get; set; }
    }
}
