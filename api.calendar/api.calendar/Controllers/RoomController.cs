using api.calendar.Bll.Interfaces;
using api.calendar.DTO.Room;
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
    [Route("webapi/room")]
    [ApiController]
    public class RoomController : Controller
    {
        private IRoomBll _roomBll;
        private readonly IMapper _mapper;

        public RoomController(IMapper mapper, IRoomBll roomBll)
        {
            _roomBll = roomBll;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getall")]
        [Produces(typeof(IEnumerable<RoomListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(IEnumerable<RoomListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(RoomListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetAllRoom()
        {
            return Ok(_mapper.Map<List<RoomListDTO>>(_roomBll.GetAllRoom()));
        }

        [HttpGet]
        [Route("getbyroom/{nameroom}")]
        [Produces(typeof(IEnumerable<RoomListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(RoomListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetByRoom(string nameRoom)
        {
            if (_roomBll.GetByRoom(nameRoom) == null)
                return NotFound();

            return Ok(_mapper.Map<RoomListDTO>(_roomBll.GetByRoom(nameRoom)));
        }

        [HttpGet]
        [Route("getbyroomidentity/{roomidentity}")]
        [Produces(typeof(IEnumerable<RoomListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(RoomListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetByroomidentity(Guid roomIdentity)
        {
            if (_roomBll.GetByRoomIdentity(roomIdentity) == null)
                return NotFound();

            return Ok(_mapper.Map<RoomListDTO>(_roomBll.GetByRoomIdentity(roomIdentity)));
        }

        [HttpPost]
        [Route("create")]
        [Produces(typeof(IEnumerable<RoomDTO>))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(RoomDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> AddRoomRoom([FromBody] RoomDTO RoomDTO)
        {
            return Ok(await _roomBll.AddRoom(_mapper.Map<Room>(RoomDTO)));
        }

        [HttpPut]
        [Route("update/{roomidentity}")]
        [Produces(typeof(IEnumerable<RoomDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Alterado com sucesso", Type = typeof(RoomDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> EditRoomRoom(Guid roomIdentity, [FromBody] RoomDTO RoomDTO)
        {
            if (RoomDTO == null)
                return BadRequest();

            return Accepted(_mapper.Map<RoomListDTO>(await _roomBll.EditRoom(roomIdentity, _mapper.Map<Room>(RoomDTO))));
        }

        [HttpDelete]
        [Route("delete/{roomidentity}")]
        [Produces(typeof(OkResult))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Removido com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Delete(Guid roomIdentity)
        {
            if (_roomBll.GetByRoomIdentity(roomIdentity) == null)
                return NotFound();

            _roomBll.DeleteRoom(roomIdentity);
            return NoContent();
        }
    }
}
