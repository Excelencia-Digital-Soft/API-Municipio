using Microsoft.EntityFrameworkCore.Storage;
using Models.MomentoApp;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concreter
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecetasAppContext _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(RecetasAppContext context)
        {
            _context = context;
        }


        // Iniciar una transacción
        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
        }

        // Confirmar la transacción
        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
        }

        // Revertir los cambios si hay un error
        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            _transaction?.Dispose();
        }
    }
}