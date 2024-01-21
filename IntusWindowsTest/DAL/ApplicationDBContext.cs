using DAL.Entities;
using DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL("Server=localhost;port=4304;database=IntusTest;user=root;password=some_pass");          
        }

        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Window> Windows { get; set; }
        public virtual DbSet<ElementType> ElementTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StatesEntityTypeConfiguration(modelBuilder));
            modelBuilder.ApplyConfiguration(new OrdersEntityTypeConfiguration(modelBuilder));
            modelBuilder.ApplyConfiguration(new WindowsEntityTypeConfiguration(modelBuilder));
            modelBuilder.ApplyConfiguration(new ElementTypeEntityTypeConfiguration(modelBuilder));
            //modelBuilder.ApplyConfiguration(new ParsingTaskEntityTypeConfiguration());
        }
    }
}
