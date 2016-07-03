using System.Data;

namespace RoomBooking.Infra.Transaction
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        IDbConnection GetCurrentConnection();
    }
}