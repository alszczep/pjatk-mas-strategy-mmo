using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.DataAccess;

public class CoreDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=api;UID=sa;PWD=Pass123@;TrustServerCertificate=True;MultipleActiveResultSets=true");
    }
}
