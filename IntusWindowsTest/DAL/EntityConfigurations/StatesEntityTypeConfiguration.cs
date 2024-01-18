using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfigurations
{
    public class StatesEntityTypeConfiguration : IEntityTypeConfiguration<State>
    {
        private readonly ModelBuilder _modelBuilder;

        public StatesEntityTypeConfiguration(ModelBuilder builder)
        {
            _modelBuilder = builder;
        }

        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("States");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Code).IsRequired();

            _modelBuilder.Entity<State>().HasIndex(e => e.Code).IsUnique();
        }
    }
}
