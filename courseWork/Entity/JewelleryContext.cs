using Microsoft.EntityFrameworkCore;

namespace courseWork.Entity
{
    public class JewelleryContext : DbContext
    {
        public JewelleryContext(DbContextOptions<JewelleryContext> options) : base(options) { }
        
        public DbSet<JewelleryEntity> JewelleryDB { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JewelleryEntity>().HasData(new JewelleryEntity()
            {
                Id = 1,
                Name = "Test1",
                Type = "Test1",
                Material = "Test1",
                Gemstones = "Test1",
                Size = 0,
                Price = 0,
            }
            );
        }
    }
}
