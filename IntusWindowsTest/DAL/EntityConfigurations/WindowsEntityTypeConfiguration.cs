using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.EntityConfigurations
{
    public class WindowsEntityTypeConfiguration : IEntityTypeConfiguration<Window>
    {
        private readonly ModelBuilder _modelBuilder;

        public WindowsEntityTypeConfiguration(ModelBuilder builder)
        {
            _modelBuilder = builder;
        }

        public void Configure(EntityTypeBuilder<Window> builder)
        {
            builder.ToTable("Windows");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.QuantityOfWindows).IsRequired();
            builder.HasOne(e => e.Order).WithMany(p => p.Windows);
        }
    }
}
