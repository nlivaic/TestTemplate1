using System;
using AutoMapper;
using TestTemplate1.Core.Entities;

namespace TestTemplate1.Application.Questions.Queries
{
    public class FooGetModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public class FooGetModelProfile : Profile
        {
            public FooGetModelProfile()
            {
                CreateMap<Foo, FooGetModel>();
            }
        }
    }
}
