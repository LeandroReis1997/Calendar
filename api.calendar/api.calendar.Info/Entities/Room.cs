using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.calendar.Info.Entities
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RoomIdentity")]
        public Guid RoomIdentity { get; set; }
        public string RoomName { get; set; }
    }
}
