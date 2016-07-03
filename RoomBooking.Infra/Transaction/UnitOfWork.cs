using System;
using System.Data;
using Npgsql;

namespace RoomBooking.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public UnitOfWork()
        {
            _connection = new NpgsqlConnection("User ID=postgres;Host=localhost;Port=5432;Database=roombooking;");
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IDbConnection GetCurrentConnection()
        {
            return _connection;
        }
        
        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }
}