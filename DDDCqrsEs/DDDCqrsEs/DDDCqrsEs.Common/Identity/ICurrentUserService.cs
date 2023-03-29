using System;
using System.Collections.Generic;
using System.Text;

namespace DDDCqrsEs.Common.Identity
{
    public interface ICurrentUserService
    {
        CurrentUser GetCurrentUser();
    }
}
