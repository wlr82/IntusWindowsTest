using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.EntityConfigurations
{
    internal class ElementTypeEntityTypeConfiguration : IEntityTypeConfiguration<ElementType>
    {
        private readonly ModelBuilder _modelBuilder;

        public ElementTypeEntityTypeConfiguration(ModelBuilder builder)
        {
            _modelBuilder = builder;
        }

        public void Configure(EntityTypeBuilder<ElementType> builder)
        {
            builder.ToTable("ElementTypes");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Code).IsRequired();

            _modelBuilder.Entity<ElementType>().HasIndex(e => e.Code).IsUnique();
        }
    }
}
