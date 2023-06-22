using System.Threading.Tasks;
using TestTemplate1.Common.Interfaces;

namespace TestTemplate1.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestTemplate1DbContext _dbContext;

        public UnitOfWork(TestTemplate1DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveAsync()
        {
            if (_dbContext.ChangeTracker.HasChanges())
            {
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}