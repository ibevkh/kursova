using Microsoft.EntityFrameworkCore;

namespace courseWork.Entity
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext>options) : base(options) { }

        public DbSet<ClientEntity> ClientDb { get; set; }
    }
}
