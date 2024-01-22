using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfigurations
{
    public class SubElementsEntityTypeConfiguration :IEntityTypeConfiguration<SubElement>
    {
        private readonly ModelBuilder _modelBuilder;
        public SubElementsEntityTypeConfiguration(ModelBuilder modelBuilder) 
        {
            _modelBuilder = modelBuilder;
        }

        public void Configure(EntityTypeBuilder<SubElement> builder)
        {
            builder.ToTable("SubElements");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Width).IsRequired();
            builder.Property(e => e.Height).IsRequired();
            builder.HasOne(e => e.Window).WithMany(p => p.SubElements);
        }
    }
}
