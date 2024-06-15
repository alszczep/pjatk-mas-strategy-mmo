using api.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;

namespace api.DataAccess;

public class CoreDbContext : DbContext
{
    private readonly IConfiguration configuration;
    private readonly Uri webAppUrl;

    public CoreDbContext(IConfiguration configuration)
    {
        this.configuration = configuration;
        this.webAppUrl = new Uri(configuration["WebAppUrl"]);
    }

    // public CoreDbContext(DbContextOptions<DbContext> options, IConfiguration configuration)
    //     : base(options)
    // {
    //     this.configuration = configuration;
    // }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Village> Villages { get; set; } = null!;
    public DbSet<Building> Buildings { get; set; } = null!;
    public DbSet<BuildingBarracks> BuildingsBarracks { get; set; } = null!;
    public DbSet<BuildingResources> BuildingsResources { get; set; } = null!;
    public DbSet<BuildingInVillage> BuildingsInVillage { get; set; } = null!;
    public DbSet<MilitaryUnit> MilitaryUnits { get; set; } = null!;
    public DbSet<BuildingLevel> BuildingLevels { get; set; } = null!;
    public DbSet<Resources> Resources { get; set; } = null!;
    public DbSet<BuildingsQueue> BuildingsQueue { get; set; } = null!;
    public DbSet<MilitaryUnitsQueue> MilitaryUnitsQueue { get; set; } = null!;
    public DbSet<MilitaryUnitsInVillage> MilitaryUnitsInVillage { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;

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
                    j => j.HasOne<Village>().WithMany().HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.ClientCascade),
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientCascade)
                );
        });

        modelBuilder.Entity<Village>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Village");

            entity.Property(e => e.Name).HasMaxLength(120).IsRequired();
            entity.Property(e => e.CrestImageUrl);
            entity.Property(e => e.CreationDateTime).IsRequired();
            entity.Property(e => e.PositionX).IsRequired();
            entity.Property(e => e.PositionY).IsRequired();
            entity.Property(e => e.AvailableResourcesId).IsRequired();

            entity.HasIndex(e => new { e.PositionX, e.PositionY }).IsUnique();

            // entity.HasOne(e => e.AvailableResources).WithOne().HasForeignKey<Resources>(e => e.Id).IsRequired();
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Building");

            entity.Property(e => e.Name).HasMaxLength(120).IsRequired();
            entity.Property(e => e.MaxInVillage).IsRequired();
            entity.Property(e => e.ImageUrl).IsRequired();

            entity.HasDiscriminator(e => e.Type)
                .HasValue<BuildingBarracks>(BuildingType.Barracks)
                .HasValue<BuildingResources>(BuildingType.Resources);
        });

        modelBuilder.Entity<BuildingBarracks>(entity =>
        {
            entity.HasMany(e => e.TrainableUnits).WithMany(e => e.TrainableInBarracks)
                .UsingEntity<Dictionary<string, object>>(
                    "MilitaryUnitTrainableInBarracks",
                    j => j.HasOne<MilitaryUnit>().WithMany().HasForeignKey("MilitaryUnitId").HasPrincipalKey(e => e.Id)
                        .OnDelete(DeleteBehavior.ClientCascade),
                    j => j.HasOne<BuildingBarracks>().WithMany().HasForeignKey("BuildingBarracksId")
                        .HasPrincipalKey(e => e.Id)
                        .OnDelete(DeleteBehavior.ClientCascade)
                ).HasData(
                    Seed.GetMilitaryUnitTrainableInBarracksSeed()
                );

            entity.HasData(Seed.GetBuildingsBarracksSeed(this.webAppUrl));
        });

        modelBuilder.Entity<BuildingResources>(entity =>
        {
            entity.HasData(Seed.GetBuildingsResourcesSeed(this.webAppUrl));
        });

        modelBuilder.Entity<BuildingInVillage>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("BuildingInVillage");

            entity.Property(e => e.Level).IsRequired();
            entity.Property(e => e.BuildingSpot).IsRequired();

            entity.ToTable(t =>
            {
                t.HasCheckConstraint("CK_BuildingInVillage_BuildingSpot",
                    "BuildingSpot >= 0 AND BuildingSpot <= 9");
            });

            entity.HasOne(e => e.Building).WithMany(e => e.InVillages).IsRequired();
            entity.HasOne(e => e.Village).WithMany(e => e.Buildings).IsRequired();
        });

        modelBuilder.Entity<MilitaryUnit>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("MilitaryUnit");

            entity.Property(e => e.Name).HasMaxLength(120).IsRequired();
            entity.Property(e => e.Attack).IsRequired();
            entity.Property(e => e.Defense).IsRequired();
            entity.Property(e => e.IconUrl);
            entity.Property(e => e.MinBarracksLevel).IsRequired();
            entity.Property(e => e.TrainingTimeInSeconds).IsRequired();

            // entity.HasOne(e => e.TrainingCost).WithOne().HasForeignKey<Resources>(e => e.Id)
            //     .HasPrincipalKey<MilitaryUnit>(e => e.TrainingCostId).IsRequired();

            entity.HasData(Seed.GetMilitaryUnitsSeed(this.webAppUrl));
        });

        modelBuilder.Entity<BuildingLevel>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("BuildingLevel");

            entity.Property(e => e.Level).IsRequired();
            entity.Property(e => e.BuildingTimeInSeconds).IsRequired();
            entity.Property(e => e.TrainingTimeShortenedPercentage);
            entity.Property(e => e.BuildingId).IsRequired();
            entity.Property(e => e.ResourcesCostId).IsRequired();
            entity.Property(e => e.ResourcesProductionPerMinuteId);

            entity.ToTable(t =>
            {
                t.HasCheckConstraint("CK_BuildingLevel_TrainingTimeShortenedPercentage",
                    "TrainingTimeShortenedPercentage >= 0 AND TrainingTimeShortenedPercentage < 100");
            });

            // entity.HasOne(e => e.ResourcesCost).WithOne().HasForeignKey<Resources>(e => e.Id)
            //     .HasPrincipalKey<BuildingLevel>(e => e.ResourcesCostId).IsRequired();
            // entity.HasOne(e => e.ResourcesProductionPerMinute).WithOne().HasForeignKey<Resources>(e => e.Id)
            //     .HasPrincipalKey<BuildingLevel>(e => e.ResourcesProductionPerMinuteId);
            entity.HasOne(e => e.Building).WithMany(e => e.Levels).HasForeignKey(e => e.BuildingId).IsRequired();

            entity.HasData(Seed.GetBuildingLevelsSeed());
        });

        modelBuilder.Entity<Resources>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Resources");

            entity.Property(e => e.Wood).IsRequired();
            entity.Property(e => e.Iron).IsRequired();
            entity.Property(e => e.Wheat).IsRequired();
            entity.Property(e => e.Gold).IsRequired();

            entity.HasMany<BuildingLevel>().WithOne(e => e.ResourcesCost)
                .HasForeignKey(e => e.ResourcesCostId);
            entity.HasMany<BuildingLevel>().WithOne(e => e.ResourcesProductionPerMinute)
                .HasForeignKey(e => e.ResourcesProductionPerMinuteId);
            entity.HasMany<Village>().WithOne(e => e.AvailableResources).HasForeignKey(e => e.AvailableResourcesId)
                .OnDelete(DeleteBehavior.ClientCascade);
            entity.HasMany<MilitaryUnit>().WithOne(e => e.TrainingCost).HasForeignKey(e => e.TrainingCostId);

            entity.HasData(Seed.GetResourcesSeed());
        });

        modelBuilder.Entity<BuildingsQueue>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("BuildingsQueue");

            entity.Property(e => e.StartTime).IsRequired();
            entity.Property(e => e.EndTime).IsRequired();
            entity.Property(e => e.LevelAfterUpgrade).IsRequired();

            entity.HasOne(e => e.BuildingInVillage).WithMany().IsRequired();
        });

        modelBuilder.Entity<MilitaryUnitsQueue>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("MilitaryUnitsQueue");

            entity.Property(e => e.StartTime).IsRequired();
            entity.Property(e => e.EndTime).IsRequired();
            entity.Property(e => e.Amount).IsRequired();

            entity.HasOne(e => e.MilitaryUnit).WithMany().IsRequired();
            entity.HasOne(e => e.Village).WithMany().IsRequired();
        });

        modelBuilder.Entity<MilitaryUnitsInVillage>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("MilitaryUnitsInVillage");

            entity.Property(e => e.Amount).IsRequired();

            entity.HasOne(e => e.MilitaryUnit).WithMany().IsRequired();
            entity.HasOne(e => e.Village).WithMany().IsRequired();
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => new { e.PositionX, e.PositionY });

            entity.ToTable("Location");

            entity.Property(e => e.PositionX).IsRequired();
            entity.Property(e => e.PositionY).IsRequired();
            entity.Property(e => e.MilitaryUnitsDefensePercentageBonus).IsRequired();
            entity.Property(e => e.GoldProductionBonus);
            entity.Property(e => e.AllResourcesProductionPercentageLoss);

            entity.ToTable(t =>
            {
                t.HasCheckConstraint("CK_Location_MilitaryUnitsDefensePercentageBonus",
                    "MilitaryUnitsDefensePercentageBonus >= 0");
                t.HasCheckConstraint("CK_Location_GoldProductionBonus",
                    "GoldProductionBonus >= 0");
                t.HasCheckConstraint("CK_Location_AllResourcesProductionPercentageLoss",
                    "AllResourcesProductionPercentageLoss >= 0");
            });

            entity.HasOne(e => e.Village)
                .WithOne(e => e.Location)
                .HasForeignKey<Village>(e => new { e.PositionX, e.PositionY });

            entity.HasData(Seed.GetLocationsSeed());
        });
    }
}
