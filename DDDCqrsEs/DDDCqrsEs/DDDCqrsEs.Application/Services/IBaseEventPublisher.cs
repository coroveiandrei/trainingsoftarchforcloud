using DDDCqrsEs.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDCqrsEs.Application.Services
{
    public interface IBaseEventPublisher
    {
        public Task PublishEvent(BaseEvent _event);
    }
}
