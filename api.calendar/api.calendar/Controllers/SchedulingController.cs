using api.calendar.Bll.Interfaces;
using api.calendar.DTO.Scheduling;
using api.calendar.Info.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : Controller
    {
        private ISchedulingBll _schedulingBll;
        private readonly IMapper _mapper;

        public SchedulingController(IMapper mapper, ISchedulingBll schedulingBll)
        {
            _schedulingBll = schedulingBll;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> create(SchedulingCreateDTO schedulingCreateDTO)
        {
            return Ok(await _schedulingBll.AddRoomScheduling(_mapper.Map<Scheduling>(schedulingCreateDTO)));
        }
    }
}
