using System;

namespace DDDCqrsEs.Domain.Events
{
    public class ToDoAdded : IEvent
    {
        public Guid TodoId { get; set; }

        public ToDoAdded(Guid todoId)
        {
            TodoId = todoId;
        }
    }
}
