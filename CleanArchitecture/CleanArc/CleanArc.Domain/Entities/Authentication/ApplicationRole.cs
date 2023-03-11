
using Microsoft.AspNetCore.Identity;
using CleanArc.Domain.Entities;

namespace Quotation.Domain.Entities.Authentication
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public RoleTypeEnum RoleType { get; set; }
    }
}
