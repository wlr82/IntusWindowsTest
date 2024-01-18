using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.EntityConfigurations
{
    public class OrdersEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        private readonly ModelBuilder _modelBuilder;

        public OrdersEntityTypeConfiguration(ModelBuilder builder)
        {
            _modelBuilder = builder;
        }

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
        }
    }
}
