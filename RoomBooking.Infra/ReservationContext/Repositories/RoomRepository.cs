using System.Collections.Generic;
using System.Linq;
using Dapper;
using RoomBooking.Domain.ReservationContext.Entities;
using RoomBooking.Domain.ReservationContext.Repositories;
using RoomBooking.Infra.Transaction;

namespace RoomBooking.Infra.ReservationContext.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        const string SELECT_QUERY = "SELECT * FROM public.\"Room\"";
        const string INSERT_QUERY = "INSERT INTO public.\"Room\" values(@Id, @Title)";
        
        private IUnitOfWork _uow;

        public RoomRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IList<Room> Get()
        {
            return _uow
                .GetCurrentConnection()
                .Query<Room>(SELECT_QUERY)
                .ToList();
        }

        public Room Create(Room room){
            _uow
                .GetCurrentConnection()
                .Execute(INSERT_QUERY, room);

            return room;
        }
    }
}