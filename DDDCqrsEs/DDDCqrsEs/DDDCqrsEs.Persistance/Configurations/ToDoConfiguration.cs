using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDCqrsEs.Domain.Entities;

namespace DDDCqrsEs.Persistance.Configurations
{
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.HasIndex(e => e.Name);

            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
        }
    }
}
