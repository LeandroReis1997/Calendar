using api.calendar.Bll.Interfaces;
using api.calendar.DTO.Scheduling;
using api.calendar.Info.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace api.calendar.Controllers
{
    [Route("webapi/scheduling")]
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
        [Route("getall")]
        [Produces(typeof(IEnumerable<SchedulingListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(IEnumerable<SchedulingListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(SchedulingListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetAllScheduling()
        {
            return Ok(_mapper.Map<List<SchedulingListDTO>>(_schedulingBll.GetAllScheduling()));
        }

        [HttpGet]
        [Route("getbyroom/{numberroom}")]
        [Produces(typeof(IEnumerable<SchedulingListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(SchedulingListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetByRoom(int numberRoom)
        {
            if (_schedulingBll.GetByRoom(numberRoom) == null)
                return NotFound();

            return Ok(_mapper.Map<SchedulingListDTO>(_schedulingBll.GetByRoom(numberRoom)));
        }

        [HttpPost]
        [Produces(typeof(IEnumerable<SchedulingCreateDTO>))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(SchedulingCreateDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> AddRoomScheduling([FromBody] SchedulingCreateDTO schedulingCreateDTO)
        {
            return Ok(await _schedulingBll.AddRoomScheduling(_mapper.Map<Scheduling>(schedulingCreateDTO)));
        }

        [HttpPut]
        [Route("update/{numberroom}")]
        [Produces(typeof(IEnumerable<SchedulingCreateDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Alterado com sucesso", Type = typeof(SchedulingCreateDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> EditRoomScheduling(int numberRoom, [FromBody] SchedulingCreateDTO schedulingCreateDTO)
        {
            if (schedulingCreateDTO == null || schedulingCreateDTO.Room != numberRoom)
                return BadRequest();

            return Accepted(_mapper.Map<SchedulingListDTO>(await _schedulingBll.EditRoomScheduling(_mapper.Map<Scheduling>(schedulingCreateDTO))));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [Produces(typeof(OkResult))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Removido com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Delete(int numberRoom)
        {
            if (_schedulingBll.GetByRoom(numberRoom) == null)
                return NotFound();

            _schedulingBll.DeleteRoomScheduling(numberRoom);
            return NoContent();
        }
    }
}
