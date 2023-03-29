using MediatR;
using DDDCqrsEs.Domain.Entities;
using DDDCqrsEs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDCqrsEs.Domain.Events
{
    public interface IBaseEvent : IRequest<Unit>
    {
        public DateTime TimeStamp { get; }
        public string EventType { get; set; }
        public Guid AggregateId { get; set; }
        public StockModel Stock { get; set; }
        public int Version { get; set; }
    }
}
