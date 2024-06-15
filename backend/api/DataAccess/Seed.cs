using api.Models;

namespace api.DataAccess;

public class Seed
{
    public static Building[] GetBuildingsSeed(Uri webAppUrl)
    {
        return new Building[]
        {
            new BuildingBarracks
            {
                Id = Guid.NewGuid(), Name = "Barracks", MaxInVillage = 1,
                ImageUrl = new Uri(webAppUrl, "buildings/barracks.svg").ToString(),
                Levels = new List<BuildingLevel>()
                {
                    new()
                    {
                        Id = Guid.NewGuid(), Level = 1, BuildingTimeInSeconds = 60,
                        TrainingTimeShortenedPercentage = 0,
                        ResourcesCost = new Resources()
                        {
                            Id = Guid.NewGuid(), Wood = 100, Iron = 20, Wheat = 0, Gold = 20
                        }
                    },
                    new()
                    {
                        Id = Guid.NewGuid(), Level = 2, BuildingTimeInSeconds = 150,
                        TrainingTimeShortenedPercentage = 10,
                        ResourcesCost = new Resources()
                        {
                            Id = Guid.NewGuid(), Wood = 120, Iron = 25, Wheat = 0, Gold = 25
                        }
                    }
                },
                TrainableUnits = new List<MilitaryUnit>
                {
                    new()
                    {
                        Id = Guid.NewGuid(), Name = "Swordsman", Attack = 10, Defense = 10,
                        IconUrl = new Uri(webAppUrl, "units/swordsman.svg").ToString(), MinBarracksLevel = 2,
                        TrainingCost = new Resources()
                        {
                            Id = Guid.NewGuid(), Wood = 30, Iron = 30, Wheat = 25, Gold = 20
                        }
                    },
                    new()
                    {
                        Id = Guid.NewGuid(), Name = "Archer", Attack = 15, Defense = 5,
                        IconUrl = new Uri(webAppUrl, "units/archer.svg").ToString(), MinBarracksLevel = 1,
                        TrainingCost = new Resources()
                        {
                            Id = Guid.NewGuid(), Wood = 50, Iron = 20, Wheat = 25, Gold = 15
                        }
                    }
                }
            },
            new BuildingBarracks
            {
                Id = Guid.NewGuid(), Name = "University of military tactics", MaxInVillage = 1,
                ImageUrl = new Uri(webAppUrl, "buildings/fortress.svg").ToString(),
                Levels = new List<BuildingLevel>()
                {
                    new()
                    {
                        Id = Guid.NewGuid(), Level = 1, BuildingTimeInSeconds = 90,
                        TrainingTimeShortenedPercentage = 0,
                        ResourcesCost = new Resources()
                        {
                            Id = Guid.NewGuid(), Wood = 150, Iron = 100, Wheat = 0, Gold = 50
                        }
                    },
                    new()
                    {
                        Id = Guid.NewGuid(), Level = 2, BuildingTimeInSeconds = 200,
                        TrainingTimeShortenedPercentage = 10,
                        ResourcesCost = new Resources()
                        {
                            Id = Guid.NewGuid(), Wood = 180, Iron = 120, Wheat = 0, Gold = 60
                        }
                    },
                    new()
                    {
                        Id = Guid.NewGuid(), Level = 3, BuildingTimeInSeconds = 500,
                        TrainingTimeShortenedPercentage = 20,
                        ResourcesCost = new Resources()
                        {
                            Id = Guid.NewGuid(), Wood = 200, Iron = 150, Wheat = 0, Gold = 70
                        }
                    }
                },
                TrainableUnits = new List<MilitaryUnit>
                {
                    new()
                    {
                        Id = Guid.NewGuid(), Name = "Knight", Attack = 20, Defense = 25,
                        IconUrl = new Uri(webAppUrl, "units/knight.svg").ToString(), MinBarracksLevel = 1,
                        TrainingCost = new Resources()
                        {
                            Id = Guid.NewGuid(), Wood = 0, Iron = 60, Wheat = 30, Gold = 60
                        }
                    },
                    new()
                    {
                        Id = Guid.NewGuid(), Name = "Knight on horseback", Attack = 40, Defense = 20,
                        IconUrl = new Uri(webAppUrl, "units/knight_on_horseback.svg").ToString(),
                        MinBarracksLevel = 3,
                        TrainingCost = new Resources()
                        {
                            Id = Guid.NewGuid(), Wood = 0, Iron = 80, Wheat = 30, Gold = 70
                        }
                    }
                }
            },
            new BuildingResources
            {
                Id = Guid.NewGuid(), Name = "Gold mine", MaxInVillage = 2,
                ImageUrl = new Uri(webAppUrl, "buildings/gold_mine.svg").ToString(),
                Levels = new List<BuildingLevel>()
                {
                    new()
                    {
                        Id = Guid.NewGuid(), Level = 1, BuildingTimeInSeconds = 60,
                        TrainingTimeShortenedPercentage = 0,
                        ResourcesCost = new Resources()
                        {
                            Id = Guid.NewGuid(), Wood = 100, Iron = 20, Wheat = 0, Gold = 20
                        },
                        ResourcesProductionPerMinute = new Resources()
                        {
                            Id = Guid.NewGuid(), Wood = 0, Iron = 0, Wheat = 0, Gold = 1
                        }
                    },
                    new()
                    {
                        Id = Guid.NewGuid(), Level = 2, BuildingTimeInSeconds = 150,
                        TrainingTimeShortenedPercentage = 10,
                        ResourcesCost = new Resources()
                        {
                            Id = Guid.NewGuid(), Wood = 120, Iron = 25, Wheat = 0, Gold = 25
                        },
                        ResourcesProductionPerMinute = new Resources()
                        {
                            Id = Guid.NewGuid(), Wood = 0, Iron = 0, Wheat = 0, Gold = 2
                        }
                    }
                }
            },
            new BuildingResources
            {
                Id = Guid.NewGuid(), Name = "Iron mine", MaxInVillage = 2,
                ImageUrl = new Uri(webAppUrl, "buildings/iron_mine.svg").ToString()
            },
            new BuildingResources
            {
                Id = Guid.NewGuid(), Name = "Farm", MaxInVillage = 2,
                ImageUrl = new Uri(webAppUrl, "buildings/farm.svg").ToString()
            },
            new BuildingResources
            {
                Id = Guid.NewGuid(), Name = "Woodcutter's hut", MaxInVillage = 2,
                ImageUrl = new Uri(webAppUrl, "buildings/woodcutters_hut.svg").ToString()
            }
        };
    }

    public static Location[] GetLocationsSeed()
    {
        return new Location[]
        {
            new()
            {
                PositionX = 0,
                PositionY = 0,
                MilitaryUnitsDefensePercentageBonus = 0,
                GoldProductionBonus = null,
                AllResourcesProductionPercentageLoss = null
            },
            new()
            {
                PositionX = 0,
                PositionY = 1,
                MilitaryUnitsDefensePercentageBonus = 10,
                GoldProductionBonus = 10,
                AllResourcesProductionPercentageLoss = null
            },
            new()
            {
                PositionX = 1,
                PositionY = 0,
                MilitaryUnitsDefensePercentageBonus = 20,
                GoldProductionBonus = null,
                AllResourcesProductionPercentageLoss = 10
            },
            new()
            {
                PositionX = 1,
                PositionY = 1,
                MilitaryUnitsDefensePercentageBonus = 0,
                GoldProductionBonus = 10,
                AllResourcesProductionPercentageLoss = 10
            },
            new()
            {
                PositionX = 2,
                PositionY = 0,
                MilitaryUnitsDefensePercentageBonus = 0,
                GoldProductionBonus = 20,
                AllResourcesProductionPercentageLoss = null
            },
            new()
            {
                PositionX = 2,
                PositionY = 1,
                MilitaryUnitsDefensePercentageBonus = 20,
                GoldProductionBonus = null,
                AllResourcesProductionPercentageLoss = 20
            },
            new()
            {
                PositionX = 2,
                PositionY = 2,
                MilitaryUnitsDefensePercentageBonus = 10,
                GoldProductionBonus = null,
                AllResourcesProductionPercentageLoss = null
            }
        };
    }
}
