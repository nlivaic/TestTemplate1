using System.Threading.Tasks;

namespace TestTemplate1.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}