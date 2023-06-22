using TestTemplate1.Core.Entities;
using TestTemplate1.Core.Interfaces;

namespace TestTemplate1.Data.Repositories
{
    public class FooRepository : Repository<Foo>, IFooRepository
    {
        public FooRepository(TestTemplate1DbContext context)
            : base(context)
        {
        }
    }
}
