using DAL.Entities;
using DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

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
            //builder.UseMySQL("Server=localhost;port=4304;database=IntusTest;user=root;password=some_pass");          
        }

        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Window> Windows { get; set; }
        public virtual DbSet<SubElement> SubElements { get; set; }
        public virtual DbSet<ElementType> ElementTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StatesEntityTypeConfiguration(modelBuilder));
            modelBuilder.ApplyConfiguration(new OrdersEntityTypeConfiguration(modelBuilder));
            modelBuilder.ApplyConfiguration(new WindowsEntityTypeConfiguration(modelBuilder));
            modelBuilder.ApplyConfiguration(new ElementTypeEntityTypeConfiguration(modelBuilder));
            modelBuilder.ApplyConfiguration(new SubElementsEntityTypeConfiguration(modelBuilder));

            LoadTestData(modelBuilder);
        }

        private void LoadTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().HasData(
                new { Id = 1, Code = "NY" },
                new { Id = 2, Code = "CA" });

            modelBuilder.Entity<Order>().HasData(
                new { Id = 1, Name = "New York Building 1", StateId = 1 },
                new { Id = 2, Name = "California Hotel AJK", StateId = 2 });

            modelBuilder.Entity<Window>().HasData(
                new { Id = 1, Name = "A51", QuantityOfWindows = 4, OrderId = 1 },
                new { Id = 2, Name = "C Zone 5", QuantityOfWindows = 2, OrderId = 1 },
                new { Id = 3, Name = "GLB", QuantityOfWindows = 3, OrderId = 2 },
                new { Id = 4, Name = "OHF", QuantityOfWindows = 10, OrderId = 2 });

            modelBuilder.Entity<ElementType>().HasData(
                new { Id = 1, Code = "Window" },
                new { Id = 2, Code = "Doors" });

            modelBuilder.Entity<SubElement>().HasData(
                new { Id = 1, WindowId = 1, Element = "1", ElementTypeId = 2, Width = 1200, Height = 1850},
                new { Id = 2, WindowId = 1, Element = "2", ElementTypeId = 1, Width = 800, Height = 1850},
                new { Id = 3, WindowId = 1, Element = "3", ElementTypeId = 1, Width = 700, Height = 1850},
                new { Id = 4, WindowId = 2, Element = "1", ElementTypeId = 1, Width = 1500, Height = 2000},
                new { Id = 5, WindowId = 3, Element = "1", ElementTypeId = 2, Width = 1400, Height = 2200},
                new { Id = 6, WindowId = 3, Element = "2", ElementTypeId = 1, Width = 600, Height = 2200},
                new { Id = 7, WindowId = 4, Element = "1", ElementTypeId = 1, Width = 1500, Height = 2000},
                new { Id = 8, WindowId = 4, Element = "1", ElementTypeId = 1, Width = 1500, Height = 2000});
        }
    }
}
