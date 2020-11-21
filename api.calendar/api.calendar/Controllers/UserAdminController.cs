using api.calendar.Bll.Interfaces;
using api.calendar.DTO.UserAdmin;
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
    [Route("webapi/useradmin")]
    [ApiController]
    public class UserAdminController : Controller
    {
        private IUserAdminBll _userAdminBll;
        private readonly IMapper _mapper;

        public UserAdminController(IMapper mapper, IUserAdminBll userAdminBll)
        {
            _userAdminBll = userAdminBll;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<UserAdminListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(IEnumerable<UserAdminListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(UserAdminListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetAllUsers()
        {
            return Ok(_mapper.Map<List<UserAdminListDTO>>(_userAdminBll.GetAllUsers()));
        }

        [HttpGet]
        [Route("getbyemail/{email}")]
        [Produces(typeof(IEnumerable<UserAdminListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(UserAdminListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetByEmail(string email)
        {
            if (_userAdminBll.GetByEmail(email) == null)
                return NotFound();

            return Ok(_mapper.Map<UserAdminListDTO>(_userAdminBll.GetByEmail(email)));
        }
                
        [HttpGet]
        [Route("login/{email}/{senha}")]
        [Produces(typeof(IEnumerable<UserAdminListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(UserAdminListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Login(string email, string senha)
        {
            return Ok(_mapper.Map<UserAdminListDTO>(_userAdminBll.Login(email,senha)));
        }

        [HttpGet]
        [Route("{usersidentity}")]
        [Produces(typeof(IEnumerable<UserAdminListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(UserAdminListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetByUsersIdentity(Guid usersIdentity)
        {
            if (_userAdminBll.GetByUsersIdentity(usersIdentity) == null)
                return NotFound();

            return Ok(_mapper.Map<UserAdminListDTO>(_userAdminBll.GetByUsersIdentity(usersIdentity)));
        }

        [HttpPost]
        [Route("create")]
        [Produces(typeof(IEnumerable<UserAdminDTO>))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(UserAdminDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> AddUsers([FromBody] UserAdminDTO UserAdminDTO)
        {
            return Ok(await _userAdminBll.AddUsers(_mapper.Map<UserAdmin>(UserAdminDTO)));
        }

        [HttpPut]
        [Route("update/{usersidentity}")]
        [Produces(typeof(IEnumerable<UserAdminDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Alterado com sucesso", Type = typeof(UserAdminDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> EditRoomRoom(Guid usersIdentity, [FromBody] UserAdminDTO UserAdminDTO)
        {
            if (UserAdminDTO == null)
                return BadRequest();

            return Accepted(_mapper.Map<UserAdminListDTO>(await _userAdminBll.EditUsers(usersIdentity, _mapper.Map<UserAdmin>(UserAdminDTO))));
        }

        [HttpDelete]
        [Route("delete/{usersidentity}")]
        [Produces(typeof(OkResult))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Removido com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Delete(Guid usersIdentity)
        {
            if (_userAdminBll.GetByUsersIdentity(usersIdentity) == null)
                return NotFound();

            _userAdminBll.DeleteUsers(usersIdentity);
            return NoContent();
        }
    }
}