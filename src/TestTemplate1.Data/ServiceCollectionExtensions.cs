﻿using Microsoft.Extensions.DependencyInjection;
using TestTemplate1.Common.Interfaces;
using TestTemplate1.Core.Interfaces;
using TestTemplate1.Data.Repositories;

namespace TestTemplate1.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSpecificRepositories(this IServiceCollection services) =>
            services.AddScoped<IFooRepository, FooRepository>();

        public static void AddGenericRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
