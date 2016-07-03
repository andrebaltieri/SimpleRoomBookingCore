using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Domain.ReservationContext.Repositories;
using RoomBooking.Infra.Transaction;

namespace RoomBooking.Api.Controllers
{
    [Route("api/rooms")]
    public class RoomsController : Controller
    {
        private IRoomRepository _repository;
        private IUnitOfWork _uow;

        public RoomsController(IRoomRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        [HttpGet]
        public IList<Domain.ReservationContext.Entities.Room> Get()
        {
            return _repository.Get();
        }

        [HttpPost]
        public Domain.ReservationContext.Entities.Room Post([FromBody]Domain.ReservationContext.Entities.Room room)
        {
            _repository.Create(room);
            _uow.Commit();
            return room;
        }
    }
}
