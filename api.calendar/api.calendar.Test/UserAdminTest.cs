using api.calendar.Bll;
using api.calendar.Bll.Interfaces;
using api.calendar.Dal.Interfaces;
using api.calendar.Info.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace api.calendar.Test
{
    public class UserAdminTest
    {
        private IUserAdminBll _userAdminBll;
        private Mock<IUserAdminDal> _userAdminDal;

        [SetUp]
        public void SetUp()
        {
            _userAdminDal = new Mock<IUserAdminDal>();
            _userAdminBll = new UserAdminBll(_userAdminDal.Object);
        }

        [Test]
        public void ListarTodosUsuarios()
        {

            var usuario = new UserAdmin()
            {
                UserIdentity = Guid.NewGuid(),
                Name = "Leandro",
                Email = "leandro@hotmail.com",
                Password = "123456"
            };

            _userAdminDal.Setup(x => x.GetAllUsers()).Returns(new List<UserAdmin> { usuario });

            var result = _userAdminBll.GetAllUsers();

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void ListarUsuariosPeloEmail()
        {
            var usuario = new UserAdmin()
            {
                UserIdentity = Guid.NewGuid(),
                Name = "Leandro",
                Email = "leandro@hotmail.com",
                Password = "123456"
            };

            _userAdminDal.Setup(x => x.GetByEmail(usuario.Email)).Returns(usuario);

            var result = _userAdminBll.GetByEmail(usuario.Email);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ListarUsuariosPeloId()
        {

            var usuario = new UserAdmin()
            {
                UserIdentity = Guid.NewGuid(),
                Name = "Leandro",
                Email = "leandro@hotmail.com",
                Password = "123456"
            };

            _userAdminDal.Setup(x => x.GetByUsersIdentity(usuario.UserIdentity)).Returns(usuario);

            var result = _userAdminBll.GetByUsersIdentity(usuario.UserIdentity);

            Assert.IsNotNull(result);
        }

        [Test]
        public void IncluirUsuario()
        {

            var usuario = new UserAdmin()
            {
                UserIdentity = Guid.NewGuid(),
                Name = "Leandro",
                Email = "leandro@hotmail.com",
                Password = "123456"
            };

            _userAdminDal.Setup(x => x.AddUsers(It.IsAny<UserAdmin>())).ReturnsAsync(usuario);

            var result = _userAdminBll.AddUsers(usuario).Result;

            Assert.NotNull(result);
        }

        [Test]
        public void EditarUsuario()
        {
            var usuario = new UserAdmin()
            {
                UserIdentity = Guid.NewGuid(),
                Name = "Leandro",
                Email = "leandro@hotmail.com",
                Password = "123456"
            };

            _userAdminDal.Setup(x => x.EditUsers(It.IsAny<UserAdmin>())).ReturnsAsync(usuario);

            var result = _userAdminBll.EditUsers(usuario.UserIdentity, usuario).Result;

            Assert.NotNull(result);
        }

        [Test]
        public void DeletarSala()
        {

            var usuario = new UserAdmin()
            {
                UserIdentity = Guid.NewGuid(),
                Name = "Leandro",
                Email = "leandro@hotmail.com",
                Password = "123456"
            };

            _userAdminDal.Setup(x => x.DeleteUsers(It.IsAny<Guid>())).Returns(usuario.UserIdentity);

            var result = _userAdminBll.DeleteUsers(usuario.UserIdentity);

            Assert.NotNull(result);
        }
    }
}
