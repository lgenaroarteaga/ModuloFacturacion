using Framework;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class EFCoreInvoiceUnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _dbContext;

        public EFCoreInvoiceUnitOfWork(LibraryDbContext dbContext)
            => _dbContext = dbContext;

        public Task Commit() => _dbContext.SaveChangesAsync();
    }
}
