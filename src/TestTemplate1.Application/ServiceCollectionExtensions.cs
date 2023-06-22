using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestTemplate1.Application.Pipelines;

namespace TestTemplate1.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTestTemplate1ApplicationHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
            services.AddPipelines();

            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        }
    }
}
