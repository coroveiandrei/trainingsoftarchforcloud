using CleanArc.Domain.Entities.Base;
using System;

namespace CleanArc.Domain.Entities
{
    public class ToDo: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}
