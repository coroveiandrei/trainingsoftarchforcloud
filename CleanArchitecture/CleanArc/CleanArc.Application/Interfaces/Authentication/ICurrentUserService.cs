using Quotation.Domain.Entities.Authentication;

namespace CleanArc.Application.Interfaces.Authentication
{
    public interface ICurrentUserService
    {
        CurrentUser GetCurrentUser();
    }
}
