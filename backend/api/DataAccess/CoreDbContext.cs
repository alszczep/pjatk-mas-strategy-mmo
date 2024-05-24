using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.DataAccess;

public class CoreDbContext : DbContext
{
    private readonly IConfiguration configuration;

    public CoreDbContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    // public CoreDbContext(DbContextOptions<DbContext> options, IConfiguration configuration)
    //     : base(options)
    // {
    //     this.configuration = configuration;
    // }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Village> Villages { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(this.configuration["ConnectionStrings:DefaultConnection"])
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("mas");

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("User");

            entity.Property(e => e.Username).HasMaxLength(120).IsRequired();
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.JwtToken);
            entity.HasOne(e => e.OwnedVillage).WithOne(e => e.Owner).HasForeignKey<Village>(e => e.OwnerId)
                .IsRequired();
            entity.HasMany(e => e.AssistedVillages).WithMany(e => e.Assistants)
                .UsingEntity<Dictionary<string, object>>(
                    "Assistant",
                    j => j.HasOne<Village>().WithMany().HasForeignKey("Id").OnDelete(DeleteBehavior.ClientCascade),
                    j => j.HasOne<User>().WithMany().HasForeignKey("Id").OnDelete(DeleteBehavior.ClientCascade)
                );
        });

        modelBuilder.Entity<Village>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Village");

            entity.Property(e => e.Name).HasMaxLength(120).IsRequired();
            entity.Property(e => e.CrestImageUrl);
            entity.Property(e => e.CreationDateTime).IsRequired();
        });

        // modelBuilder.Entity<Assistant>(entity =>
        // {
        //     entity.HasKey(e => e.Id);
        //
        //     entity.ToTable("Assistant");
        //
        //     entity.HasOne(e => e.User).WithMany(e => e.AssistedVillages).HasForeignKey(e => e.UserId).IsRequired();
        //     entity.HasOne(e => e.Village).WithMany(e => e.Assistants).HasForeignKey(e => e.VillageId).IsRequired();
        // });
    }
}
