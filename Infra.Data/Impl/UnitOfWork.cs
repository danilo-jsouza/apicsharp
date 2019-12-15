using Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.Data.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        private UnitOfWorkTransaction CurrentTransaction { get; set; }

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
        public async Task<ITransaction> BeginTransactionAsync(CancellationToken ct)
        {
            try
            {
                if (CurrentTransaction == null || CurrentTransaction.IsCommited)
                {
                    var efTransaction = _context.Database.CurrentTransaction ?? await _context.Database.BeginTransactionAsync(ct);
                    CurrentTransaction = new UnitOfWorkTransaction(efTransaction);
                }
                return CurrentTransaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> CommitAsync(CancellationToken ct)
        {
            try
            {
                return _context.SaveChangesAsync(ct);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private class UnitOfWorkTransaction : ITransaction
        {
            public bool IsCommited { get; private set; }
            public IDbContextTransaction DbContextTransaction { get; }
            public UnitOfWorkTransaction(IDbContextTransaction dbContextTransaction)
            {
                DbContextTransaction = dbContextTransaction;
            }

            public Task CommitAsync(CancellationToken ct)
            {
                try
                {
                    DbContextTransaction.Commit();
                    IsCommited = true;
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Dispose()
            {
                if (!IsCommited)
                {
                    DbContextTransaction.Rollback();
                }
            }
        }
    }
}