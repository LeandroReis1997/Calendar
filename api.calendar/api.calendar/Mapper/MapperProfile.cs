using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }
    }
}
