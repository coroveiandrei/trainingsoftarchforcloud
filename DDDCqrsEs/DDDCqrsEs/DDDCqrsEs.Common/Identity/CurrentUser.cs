using DDDCqrsEs.Common.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDCqrsEs.Common.Identity
{
    public class CurrentUser
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public Role? Role { get; set; }
    }
}
