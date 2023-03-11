using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.QueryProjections
{
    public class ToDoProjection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
