using Azure.Messaging.ServiceBus;
using System.Threading.Tasks;

namespace DDDCqrsEs.WebJob.Services
{
    public interface IServiceBusQueueHandler
    {
        public Task HandleMessage(ProcessMessageEventArgs message);
        public Task HandleError(ProcessErrorEventArgs message);
        public Task ReceiveMessages();
    }
}
