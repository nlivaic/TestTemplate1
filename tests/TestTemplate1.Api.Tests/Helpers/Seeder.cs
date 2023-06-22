using System.Collections.Generic;
using TestTemplate1.Core.Entities;
using TestTemplate1.Data;

namespace TestTemplate1.Api.Tests.Helpers
{
    public static class Seeder
    {
        public static void Seed(this TestTemplate1DbContext ctx)
        {
            ctx.Foos.AddRange(
                new List<Foo>
                {
                    new ("Text 1"),
                    new ("Text 2"),
                    new ("Text 3")
                });
            ctx.SaveChanges();
        }
    }
}
