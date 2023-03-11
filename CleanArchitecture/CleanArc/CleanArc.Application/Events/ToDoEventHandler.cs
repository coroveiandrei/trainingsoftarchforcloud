using MediatR;
using CleanArc.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Events
{
    public class ToDoEventHandler : INotificationHandler<ToDoAdded>
    {
        
        public ToDoEventHandler()
        {
            
        }

        public async Task Handle(ToDoAdded todoAdded, CancellationToken cancellationToken)
        {
            // handle the event here
        }
    }
}
