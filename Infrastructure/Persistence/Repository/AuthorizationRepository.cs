using System;
using Domain;
using Domain.Entities;
using Domain.ValueObject;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository;

namespace Infrastructure.Persistence.Repository
{
    public class AuthorizationRepository : IAuthorizationRepository, IDisposable
    {
        private readonly LibraryDbContext _dbContext;

        public AuthorizationRepository(LibraryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task Add(Authorization entity)
        {
            await _dbContext.Authorizations.AddAsync(entity);
        }

        public async Task Delete(AuthorizationGuid id)
        {
            Authorization entity = await _dbContext.Authorizations.FindAsync(id);
            _dbContext.Authorizations.Remove(entity);
        }

        public async Task<bool> Exists(AuthorizationGuid id)
        {
            Authorization b = await _dbContext.Authorizations.FindAsync(id);
            if (b == null)
                return false;
            return true;
        }

        public async Task<Authorization> Load(AuthorizationGuid id)
        {
            return await _dbContext.Authorizations.FindAsync(id.Value);
        }

        public void Update(Authorization entity)
        {
            _dbContext.Authorizations.Update(entity);
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
        // ~AuthorizationsRepository()
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