﻿using Domain.ValueObject;
using Domain.Entities;
using System;
using System.Threading.Tasks;
using Domain.Repository;


namespace Infrastructure.Persistence.Repository
{
    public class InvoiceRepository : IInvoiceRepository, IDisposable
    {
        private readonly LibraryDbContext _dbContext;

        public InvoiceRepository(LibraryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task Add(Invoice entity)
        {
            await _dbContext.Invoices.AddAsync(entity);
        }

        public async Task Delete(InvoiceGuid id)
        {
            Invoice entity = await _dbContext.Invoices.FindAsync(id);
            _dbContext.Invoices.Remove(entity);
        }

        public async Task<bool> Exists(InvoiceGuid id)
        {
            Invoice b = await _dbContext.Invoices.FindAsync(id);
            if (b == null)
                return false;
            return true;
        }

        public async Task<Invoice> Load(InvoiceGuid id)
        {
            return await _dbContext.Invoices.FindAsync(id.Value);
        }

        public void Update(Invoice entity)
        {
            _dbContext.Invoices.Update(entity);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~InvoicesRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
