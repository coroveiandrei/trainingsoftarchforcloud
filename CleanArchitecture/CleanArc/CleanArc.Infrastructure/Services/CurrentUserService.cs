using Microsoft.AspNetCore.Http;
using CleanArc.Application.Interfaces.Authentication;
using CleanArc.Common;
using CleanArc.Domain.Entities;
using Quotation.Domain.Entities.Authentication;
using System;
using System.Security.Claims;

namespace CleanArc.Infrastructure.Services
{
    [MapServiceDependency(nameof(CurrentUserService))]
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public CurrentUser GetCurrentUser()
        {
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                return null;
            var result = new CurrentUser();
            result.Username = _httpContextAccessor.HttpContext.User.Identity.Name;
            result.UserId = new Guid(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                return null;
            foreach (var role in (RoleTypeEnum[])Enum.GetValues(typeof(RoleTypeEnum)))
            {
                if(_httpContextAccessor.HttpContext.User.IsInRole(role.ToString()))
                {
                    result.Role = role;
                }
            }
            return result;
        }
    }
}
