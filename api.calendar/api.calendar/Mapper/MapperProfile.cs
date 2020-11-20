using api.calendar.DTO.Room;
using api.calendar.DTO.Scheduling;
using api.calendar.DTO.UserAdmin;
using api.calendar.Info.Entities;
using AutoMapper;

namespace api.calendar.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Scheduling

            CreateMap<SchedulingDTO, Scheduling>();

            CreateMap<SchedulingListDTO, Scheduling>();

            #endregion

            #region Room

            CreateMap<RoomDTO, Room>();

            CreateMap<RoomListDTO, Room>().ReverseMap();

            #endregion

            #region UserAdmin

            CreateMap<UserAdminDTO, UserAdmin>();

            CreateMap<UserAdminListDTO, UserAdmin>().ReverseMap();

            #endregion
        }
    }
}
