﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.DataAccess;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    partial class CoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("mas")
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assistant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Assistant", "mas");
                });

            modelBuilder.Entity("BuildingBarracksMilitaryUnit", b =>
                {
                    b.Property<Guid>("TrainableInBarracksId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainableUnitsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TrainableInBarracksId", "TrainableUnitsId");

                    b.HasIndex("TrainableUnitsId");

                    b.ToTable("BuildingBarracksMilitaryUnit", "mas");
                });

            modelBuilder.Entity("api.Models.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxInVillage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Building", "mas");

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("api.Models.BuildingInVillage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BuildingSpot")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<Guid>("VillageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("VillageId");

                    b.ToTable("BuildingInVillage", "mas", t =>
                        {
                            t.HasCheckConstraint("CK_BuildingInVillage_BuildingSpot", "BuildingSpot >= 0 AND BuildingSpot <= 9");
                        });
                });

            modelBuilder.Entity("api.Models.BuildingLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BuildingTimeInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<Guid>("ResourcesCostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResourcesProductionPerMinuteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("TrainingTimeShortenedPercentage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("ResourcesCostId");

                    b.HasIndex("ResourcesProductionPerMinuteId");

                    b.ToTable("BuildingLevel", "mas", t =>
                        {
                            t.HasCheckConstraint("CK_BuildingLevel_TrainingTimeShortenedPercentage", "TrainingTimeShortenedPercentage >= 0 AND TrainingTimeShortenedPercentage < 100");
                        });
                });

            modelBuilder.Entity("api.Models.BuildingsQueue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuildingInVillageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuildingInVillageId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LevelAfterUpgrade")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BuildingInVillageId");

                    b.HasIndex("BuildingInVillageId1");

                    b.ToTable("BuildingsQueue", "mas");
                });

            modelBuilder.Entity("api.Models.Location", b =>
                {
                    b.Property<int>("PositionX")
                        .HasColumnType("int");

                    b.Property<int>("PositionY")
                        .HasColumnType("int");

                    b.Property<int?>("AllResourcesProductionPercentageLoss")
                        .HasColumnType("int");

                    b.Property<int?>("GoldProductionBonus")
                        .HasColumnType("int");

                    b.Property<int>("MilitaryUnitsDefensePercentageBonus")
                        .HasColumnType("int");

                    b.HasKey("PositionX", "PositionY");

                    b.ToTable("Location", "mas", t =>
                        {
                            t.HasCheckConstraint("CK_Location_AllResourcesProductionPercentageLoss", "AllResourcesProductionPercentageLoss >= 0");

                            t.HasCheckConstraint("CK_Location_GoldProductionBonus", "GoldProductionBonus >= 0");

                            t.HasCheckConstraint("CK_Location_MilitaryUnitsDefensePercentageBonus", "MilitaryUnitsDefensePercentageBonus >= 0");
                        });
                });

            modelBuilder.Entity("api.Models.MilitaryUnit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<string>("IconUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinBarracksLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("MilitaryUnit", "mas");
                });

            modelBuilder.Entity("api.Models.MilitaryUnitsInVillage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid>("MilitaryUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VillageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VillageId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MilitaryUnitId");

                    b.HasIndex("VillageId");

                    b.HasIndex("VillageId1");

                    b.ToTable("MilitaryUnitsInVillage", "mas");
                });

            modelBuilder.Entity("api.Models.MilitaryUnitsQueue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MilitaryUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VillageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VillageId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MilitaryUnitId");

                    b.HasIndex("VillageId");

                    b.HasIndex("VillageId1");

                    b.ToTable("MilitaryUnitsQueue", "mas");
                });

            modelBuilder.Entity("api.Models.Resources", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gold")
                        .HasColumnType("int");

                    b.Property<int>("Iron")
                        .HasColumnType("int");

                    b.Property<int>("Wheat")
                        .HasColumnType("int");

                    b.Property<int>("Wood")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Resources", "mas");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JwtToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("User", "mas");
                });

            modelBuilder.Entity("api.Models.Village", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CrestImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PositionX")
                        .HasColumnType("int");

                    b.Property<int>("PositionY")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.HasIndex("PositionX", "PositionY")
                        .IsUnique();

                    b.ToTable("Village", "mas");
                });

            modelBuilder.Entity("api.Models.BuildingBarracks", b =>
                {
                    b.HasBaseType("api.Models.Building");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("api.Models.BuildingResources", b =>
                {
                    b.HasBaseType("api.Models.Building");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Assistant", b =>
                {
                    b.HasOne("api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("api.Models.Village", null)
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuildingBarracksMilitaryUnit", b =>
                {
                    b.HasOne("api.Models.BuildingBarracks", null)
                        .WithMany()
                        .HasForeignKey("TrainableInBarracksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.MilitaryUnit", null)
                        .WithMany()
                        .HasForeignKey("TrainableUnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.BuildingInVillage", b =>
                {
                    b.HasOne("api.Models.Building", "Building")
                        .WithMany("InVillages")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Village", "Village")
                        .WithMany("Buildings")
                        .HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Village");
                });

            modelBuilder.Entity("api.Models.BuildingLevel", b =>
                {
                    b.HasOne("api.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Resources", "ResourcesCost")
                        .WithMany()
                        .HasForeignKey("ResourcesCostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Resources", "ResourcesProductionPerMinute")
                        .WithMany()
                        .HasForeignKey("ResourcesProductionPerMinuteId");

                    b.Navigation("Building");

                    b.Navigation("ResourcesCost");

                    b.Navigation("ResourcesProductionPerMinute");
                });

            modelBuilder.Entity("api.Models.BuildingsQueue", b =>
                {
                    b.HasOne("api.Models.BuildingInVillage", "BuildingInVillage")
                        .WithMany()
                        .HasForeignKey("BuildingInVillageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.BuildingInVillage", null)
                        .WithMany("BuildingQueue")
                        .HasForeignKey("BuildingInVillageId1");

                    b.Navigation("BuildingInVillage");
                });

            modelBuilder.Entity("api.Models.MilitaryUnitsInVillage", b =>
                {
                    b.HasOne("api.Models.MilitaryUnit", "MilitaryUnit")
                        .WithMany()
                        .HasForeignKey("MilitaryUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Village", "Village")
                        .WithMany()
                        .HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Village", null)
                        .WithMany("MilitaryUnits")
                        .HasForeignKey("VillageId1");

                    b.Navigation("MilitaryUnit");

                    b.Navigation("Village");
                });

            modelBuilder.Entity("api.Models.MilitaryUnitsQueue", b =>
                {
                    b.HasOne("api.Models.MilitaryUnit", "MilitaryUnit")
                        .WithMany()
                        .HasForeignKey("MilitaryUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Village", "Village")
                        .WithMany()
                        .HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Village", null)
                        .WithMany("MilitaryUnitsQueue")
                        .HasForeignKey("VillageId1");

                    b.Navigation("MilitaryUnit");

                    b.Navigation("Village");
                });

            modelBuilder.Entity("api.Models.Resources", b =>
                {
                    b.HasOne("api.Models.Village", null)
                        .WithOne("AvailableResources")
                        .HasForeignKey("api.Models.Resources", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.Village", b =>
                {
                    b.HasOne("api.Models.User", "Owner")
                        .WithOne("OwnedVillage")
                        .HasForeignKey("api.Models.Village", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Location", "Location")
                        .WithOne("Village")
                        .HasForeignKey("api.Models.Village", "PositionX", "PositionY")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("api.Models.Building", b =>
                {
                    b.Navigation("InVillages");
                });

            modelBuilder.Entity("api.Models.BuildingInVillage", b =>
                {
                    b.Navigation("BuildingQueue");
                });

            modelBuilder.Entity("api.Models.Location", b =>
                {
                    b.Navigation("Village");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Navigation("OwnedVillage")
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.Village", b =>
                {
                    b.Navigation("AvailableResources")
                        .IsRequired();

                    b.Navigation("Buildings");

                    b.Navigation("MilitaryUnits");

                    b.Navigation("MilitaryUnitsQueue");
                });
#pragma warning restore 612, 618
        }
    }
}
