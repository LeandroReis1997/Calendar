﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.calendar.DTO.Scheduling
{
    public class SchedulingCreateDTO
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
