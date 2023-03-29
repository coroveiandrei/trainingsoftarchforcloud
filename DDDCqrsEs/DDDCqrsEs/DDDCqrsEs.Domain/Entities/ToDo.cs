using DDDCqrsEs.Domain.Entities.Base;
using System;

namespace DDDCqrsEs.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class ToDo: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}
