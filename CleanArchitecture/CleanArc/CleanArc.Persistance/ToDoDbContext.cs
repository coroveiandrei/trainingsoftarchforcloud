using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CleanArc.Common;
using CleanArc.Domain.Entities;
using Quotation.Domain.Entities.Authentication;
using System.Threading.Tasks;
using CleanArc.Application.Interfaces;
using System.Threading;

namespace CleanArc.Persistance
{
    [MapServiceDependency(nameof(ToDoDbContext))]
    public class ToDoDbContext : IdentityDbContext<User>, IDbContext, IToDoDbContext
    {
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
           : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoDbContext).Assembly);
        }

        Task IDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        void IDbContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
