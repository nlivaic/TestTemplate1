using TestTemplate1.Common.Interfaces;
using TestTemplate1.Core.Entities;

namespace TestTemplate1.Core.Interfaces
{
    public interface IFooRepository : IRepository<Foo>
    {
    }
}
