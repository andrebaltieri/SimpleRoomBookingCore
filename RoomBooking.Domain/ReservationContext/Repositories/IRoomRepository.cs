using System.Collections.Generic;
using RoomBooking.Domain.ReservationContext.Entities;

namespace RoomBooking.Domain.ReservationContext.Repositories
{
    public interface IRoomRepository
    {
        IList<Room> Get();
        Room Create(Room room);
    }
}