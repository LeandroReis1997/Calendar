using api.calendar.Bll.Interfaces;
using api.calendar.DTO.Scheduling;
using api.calendar.Info.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
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
        [Route("getbyschedulingroomidentity/{roomidentity}")]
        [Produces(typeof(IEnumerable<SchedulingListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(SchedulingListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetBySchedulingRoomIdentity(Guid roomIdentity)
        {
            if (_schedulingBll.GetBySchedulingRoomIdentity(roomIdentity) == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<SchedulingListDTO>>(_schedulingBll.GetBySchedulingRoomIdentity(roomIdentity)));
        }

        [HttpGet]
        [Route("{schedulingidentity}")]
        [Produces(typeof(IEnumerable<SchedulingListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(SchedulingListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetByRoom(Guid schedulingIdentity)
        {
            if (_schedulingBll.GetByschedulingIdentity(schedulingIdentity) == null)
                return NotFound();

            return Ok(_mapper.Map<SchedulingListDTO>(_schedulingBll.GetByschedulingIdentity(schedulingIdentity)));
        }

        [HttpPost]
        [Route("create")]
        [Produces(typeof(IEnumerable<SchedulingDTO>))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(SchedulingDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> AddRoomScheduling([FromBody] SchedulingDTO schedulingCreateDTO)
        {
            return Ok(await _schedulingBll.AddRoomScheduling(_mapper.Map<Scheduling>(schedulingCreateDTO)));
        }

        [HttpPut]
        [Route("update/{schedulingidentity}")]
        [Produces(typeof(IEnumerable<SchedulingDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Alterado com sucesso", Type = typeof(SchedulingDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> EditRoomScheduling(Guid schedulingIdentity, [FromBody] SchedulingDTO schedulingCreateDTO)
        {
            if (schedulingCreateDTO == null)
                return BadRequest();

            return Accepted(_mapper.Map<SchedulingListDTO>(await _schedulingBll.EditRoomScheduling(schedulingIdentity, _mapper.Map<Scheduling>(schedulingCreateDTO))));
        }

        [HttpDelete]
        [Route("delete/{schedulingidentity}")]
        [Produces(typeof(OkResult))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Removido com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Delete(Guid schedulingIdentity)
        {
            if (_schedulingBll.GetByschedulingIdentity(schedulingIdentity) == null)
                return NotFound();

            _schedulingBll.DeleteRoomScheduling(schedulingIdentity);
            return NoContent();
        }
    }
}
