using System.Threading.Tasks;
using MassTransit;
using TestTemplate1.Core.Events;

namespace TestTemplate1.WorkerServices.FooService
{
    public class FooConsumer : IConsumer<IFooEvent>
    {
        public Task Consume(ConsumeContext<IFooEvent> context) =>
            Task.CompletedTask;
    }
}
