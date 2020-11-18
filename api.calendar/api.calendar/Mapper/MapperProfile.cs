using api.calendar.DTO.Room;
using api.calendar.DTO.Scheduling;
using api.calendar.Info.Entities;
using AutoMapper;

namespace api.calendar.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SchedulingDTO, Scheduling>();

            CreateMap<SchedulingListDTO, Scheduling>();

            CreateMap<RoomDTO, Room>();

            CreateMap<RoomListDTO, Room>().ReverseMap();
        }
    }
}
