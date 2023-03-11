using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }

        public NotFoundException(string name)
          : base($"Entity \"{name}\" was not found.")
        {
        }
    }
}
