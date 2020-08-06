using Microsoft.EntityFrameworkCore;

namespace ShrtLy.DAL
{
    public class ShrtLyContext : DbContext
    {
        public ShrtLyContext(DbContextOptions<ShrtLyContext> options)
            : base(options)
        {
        }

        public DbSet<LinkEntity> Links { get; set; }
    }
}
