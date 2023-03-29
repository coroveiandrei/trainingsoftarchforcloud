using DDDCqrsEs.Domain.Events;
using System;
using System.Collections.Generic;

namespace DDDCqrsEs.Domain.Aggregates
{
    public class AggregateRoot : IAggregateRoot
    {
        public Guid Id { get; set; }

        public List<IBaseEvent> Events;

        public Dictionary<Type, Action<IBaseEvent>> Handlers;

        public void AddHandler<T>(Action<T> action) where T : IBaseEvent
        {
            Handlers.Add(typeof(T), (e) => {
                action((T)e);
            });
        }

        public AggregateRoot()
        {
            Handlers = new Dictionary<Type, Action<IBaseEvent>>();
            Events = new List<IBaseEvent>();
        }

        public void AddEvent(IBaseEvent _event)
        {
            _event.Version = GetNextVersion();
            Events.Add(_event);
        }

        public void ReconstituteFromEvents(List<BaseEvent> events)
        {
            Events.AddRange(events);
            foreach (var _event in Events)
            {
                if (Handlers.ContainsKey(_event.GetType()))
                {
                    Handlers[_event.GetType()](_event);
                }
            }
        }
        private int GetNextVersion()
        {
            return Events.Count + 1;
        }

    }
}
