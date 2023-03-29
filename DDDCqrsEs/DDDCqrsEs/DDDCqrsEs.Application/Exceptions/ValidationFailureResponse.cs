using System;
using System.Collections.Generic;
using System.Text;

namespace DDDCqrsEs.Application.Exceptions
{
    public class ValidationFailureRespone
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}