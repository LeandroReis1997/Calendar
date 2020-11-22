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
    public class RoomTest
    {
        private IRoomBll _roomBll;
        private Mock<IRoomDal> _roomDal;

        [SetUp]
        public void SetUp()
        {
            _roomDal = new Mock<IRoomDal>();
            _roomBll = new RoomBll(_roomDal.Object);
        }

        [Test]
        public void ListarTodasSalas()
        {

            var sala1 = new Room
            {
                RoomIdentity = Guid.NewGuid(),
                RoomName = "Sala de reunião"
            };

            _roomDal.Setup(x => x.GetAllRoom()).Returns(new List<Room> { sala1 });

            var result = _roomBll.GetAllRoom(null);

            Assert.IsNotNull(result);
        }     
        
        [Test]
        public void ListarSalasPeloNome()
        {

            var sala1 = new Room
            {
                RoomIdentity = Guid.NewGuid(),
                RoomName = "Sala de reunião"
            };

            _roomDal.Setup(x => x.GetByRoom(sala1.RoomName)).Returns(new List<Room> { sala1 });

            var result = _roomBll.GetByRoom(sala1.RoomName);

            Assert.IsNotNull(result);
        } 
        
        [Test]
        public void ListarSalasPeloId()
        {

            var sala1 = new Room
            {
                RoomIdentity = Guid.NewGuid(),
                RoomName = "Sala de reunião"
            };

            _roomDal.Setup(x => x.GetByRoomIdentity(sala1.RoomIdentity)).Returns(sala1);

            var result = _roomBll.GetByRoomIdentity(sala1.RoomIdentity);

            Assert.IsNotNull(result);
        }

        [Test]
        public void IncluirSala()
        {

            var sala = new Room
            {
                RoomIdentity = Guid.NewGuid(),
                RoomName = "Sala de reunião"
            };

            _roomDal.Setup(x => x.AddRoom(It.IsAny<Room>())).ReturnsAsync(sala);

            var result = _roomBll.AddRoom(sala).Result;

            Assert.NotNull(result);
        }

        [Test]
        public void EditarSala()
        {

            var sala = new Room
            {
                RoomIdentity = Guid.NewGuid(),
                RoomName = "Sala de reunião"
            };

            _roomDal.Setup(x => x.EditRoom(It.IsAny<Room>())).ReturnsAsync(sala);

            var result = _roomBll.EditRoom(sala.RoomIdentity, sala).Result;

            Assert.NotNull(result);
        }

        [Test]
        public void DeletarSala()
        {

            var sala = new Room
            {
                RoomIdentity = Guid.NewGuid(),
                RoomName = "Sala de reunião"
            };

            _roomDal.Setup(x => x.DeleteRoom(It.IsAny<Guid>())).Returns(sala.RoomIdentity);

            var result = _roomBll.DeleteRoom(sala.RoomIdentity);

            Assert.NotNull(result);
        }
    }
}
