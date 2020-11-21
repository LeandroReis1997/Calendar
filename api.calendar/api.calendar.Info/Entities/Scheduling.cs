using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.calendar.Info.Entities
{
    public class Scheduling
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SchedulingIdentity { get; set; }
        public string Title { get; set; }        
        public Guid RoomIdentity { get; set; }
        public DateTime DateStartTime { get; set; }
        public DateTime DateEndTime { get; set; }
    }
}
