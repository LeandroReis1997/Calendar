using System;
using System.ComponentModel.DataAnnotations;

namespace api.calendar.DTO.Scheduling
{
    public class SchedulingDTO
    {
        public string Title { get; set; }
        [Required(ErrorMessage = "Id da sala obri")]
        public int Room { get; set; }

        [Required(ErrorMessage = "data")]
        public DateTime DateStartTime { get; set; }

        [Required(ErrorMessage = "data")]
        public DateTime DateEndTime { get; set; }
    }
}
