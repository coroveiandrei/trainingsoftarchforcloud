using MediatR;
using CleanArc.Application.Common;
using System.Threading;
using System.Threading.Tasks;
using CleanArc.Application.Interfaces.Authentication;

namespace CleanArc.Infrastructure.RequestBehaviours
{
    public class CurrentUserBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
      where TRequest : IRequest<TResponse>
    {
        private readonly ICurrentUserService _currentUserService;

        public CurrentUserBehavior(ICurrentUserService currentUserService)
        {
            this._currentUserService = currentUserService;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var castedRequest = (request as BaseRequest<TResponse>);
            castedRequest.User = _currentUserService.GetCurrentUser();
            return next();
        }
    }
}
