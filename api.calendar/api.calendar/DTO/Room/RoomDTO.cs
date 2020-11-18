using System.ComponentModel.DataAnnotations;

namespace api.calendar.DTO.Room
{
    public class RoomDTO
    {
        [Required(ErrorMessage = "Nome da sala é obrigatório")]
        public string RoomName { get; set; }
    }
}
