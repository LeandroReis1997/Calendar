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
    public class SchedulingTest
    {
        private ISchedulingBll _schedulingBll;
        private Mock<ISchedulingDal> _schedulingDal;

        [SetUp]
        public void SetUp()
        {
            _schedulingDal = new Mock<ISchedulingDal>();
            _schedulingBll = new SchedulingBll(_schedulingDal.Object);
        }

        [Test]
        public void ListarTodasAgendas()
        {

            var agenda = new Scheduling
            {
                SchedulingIdentity = Guid.NewGuid(),
                Title = "Sala de reunião",
                RoomIdentity = Guid.NewGuid(),
                DateStartTime = DateTime.Today,
                DateEndTime = DateTime.Today
            };

            _schedulingDal.Setup(x => x.GetAllScheduling()).Returns(new List<Scheduling> { agenda });

            var result = _schedulingBll.GetAllScheduling();

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void ListarAgendapelaSalaId()
        {
            var agenda = new Scheduling
            {
                SchedulingIdentity = Guid.NewGuid(),
                Title = "Sala de reunião",
                RoomIdentity = Guid.NewGuid(),
                DateStartTime = DateTime.Today,
                DateEndTime = DateTime.Today
            };

            _schedulingDal.Setup(x => x.GetBySchedulingRoomIdentity(agenda.RoomIdentity)).Returns(new List<Scheduling> { agenda });

            var result = _schedulingBll.GetBySchedulingRoomIdentity(agenda.RoomIdentity);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ListarAgendasPeloId()
        {

            var agenda = new Scheduling
            {
                SchedulingIdentity = Guid.NewGuid(),
                Title = "Sala de reunião",
                RoomIdentity = Guid.NewGuid(),
                DateStartTime = DateTime.Today,
                DateEndTime = DateTime.Today
            };

            _schedulingDal.Setup(x => x.GetByschedulingIdentity(agenda.SchedulingIdentity)).Returns(agenda);

            var result = _schedulingBll.GetByschedulingIdentity(agenda.SchedulingIdentity);

            Assert.IsNotNull(result);
        }

        [Test]
        public void IncluirAgendamento()
        {

            var agenda = new Scheduling
            {
                SchedulingIdentity = Guid.NewGuid(),
                Title = "Sala de reunião",
                RoomIdentity = Guid.NewGuid(),
                DateStartTime = DateTime.Today,
                DateEndTime = DateTime.Today
            };

            _schedulingDal.Setup(x => x.AddRoomScheduling(It.IsAny<Scheduling>())).ReturnsAsync(agenda);

            var result = _schedulingBll.AddRoomScheduling(agenda);

            Assert.IsNotNull(result);
        }

        [Test]
        public void EditarAgendamento()
        {
            var agenda = new Scheduling
            {
                SchedulingIdentity = Guid.NewGuid(),
                Title = "Sala de reunião",
                RoomIdentity = Guid.NewGuid(),
                DateStartTime = DateTime.Today,
                DateEndTime = DateTime.Today
            };

            _schedulingDal.Setup(x => x.EditRoomScheduling(It.IsAny<Scheduling>())).ReturnsAsync(agenda);

            var result = _schedulingBll.EditRoomScheduling(agenda.SchedulingIdentity, agenda);

            Assert.IsNotNull(result);
        }

        [Test]
        public void DeletarSala()
        {
            var agenda = new Scheduling
            {
                SchedulingIdentity = Guid.NewGuid(),
                Title = "Sala de reunião",
                RoomIdentity = Guid.NewGuid(),
                DateStartTime = DateTime.Today,
                DateEndTime = DateTime.Today
            };

            _schedulingDal.Setup(x => x.DeleteRoomScheduling(agenda.SchedulingIdentity)).Returns(agenda.SchedulingIdentity);

            var result = _schedulingBll.DeleteRoomScheduling(agenda.SchedulingIdentity);

            Assert.IsNotNull(result);
        }
    }
}
