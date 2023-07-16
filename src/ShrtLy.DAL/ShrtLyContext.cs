using Microsoft.EntityFrameworkCore;
using ShrtLy.DAL.Entitites;

namespace ShrtLy.DAL
{
    public class ShrtLyContext : DbContext
    {
        public ShrtLyContext(DbContextOptions<ShrtLyContext> options): base(options) {}

        public DbSet<LinkEntity> Links { get; set; }
    }
}

// FOR GENERATION MIGRATIONS
// dotnet ef migrations add Initial --project "src/ShrtLy.DAL/ShrtLy.DAL.csproj" --startup-project "src/ShrtLy.Api/ShrtLy.Api.csproj"