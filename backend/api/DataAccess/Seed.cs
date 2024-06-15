using api.Models;

namespace api.DataAccess;

public class Seed
{
    private static readonly Guid GoldMineId = Guid.Parse("00000000-0000-0000-0000-000000000001");
    private static readonly Guid IronMineId = Guid.Parse("00000000-0000-0000-0000-000000000002");
    private static readonly Guid FarmId = Guid.Parse("00000000-0000-0000-0000-000000000003");
    private static readonly Guid WoodcuttersHutId = Guid.Parse("00000000-0000-0000-0000-000000000004");
    private static readonly Guid BarracksId = Guid.Parse("00000000-0000-0000-0000-000000000005");
    private static readonly Guid UniversityOfMilitaryTacticsId = Guid.Parse("00000000-0000-0000-0000-000000000006");

    private static readonly Guid SwordsmanId = Guid.Parse("00000000-0000-0000-0000-000000000001");
    private static readonly Guid ArcherId = Guid.Parse("00000000-0000-0000-0000-000000000002");
    private static readonly Guid KnightId = Guid.Parse("00000000-0000-0000-0000-000000000003");
    private static readonly Guid KnightOnHorsebackId = Guid.Parse("00000000-0000-0000-0000-000000000004");

    private static readonly Guid GoldMineL1ResourcesCostId = Guid.Parse("00000000-0000-0000-0000-000000000001");

    private static readonly Guid GoldMineL1ResourcesProductionPerMinuteId =
        Guid.Parse("00000000-0000-0000-0000-000000000002");

    private static readonly Guid GoldMineL2ResourcesCostId = Guid.Parse("00000000-0000-0000-0000-000000000003");

    private static readonly Guid GoldMineL2ResourcesProductionPerMinuteId =
        Guid.Parse("00000000-0000-0000-0000-000000000004");

    private static readonly Guid IronMineL1ResourcesCostId = Guid.Parse("00000000-0000-0000-0000-000000000005");

    private static readonly Guid IronMineL1ResourcesProductionPerMinuteId =
        Guid.Parse("00000000-0000-0000-0000-000000000006");

    private static readonly Guid IronMineL2ResourcesCostId = Guid.Parse("00000000-0000-0000-0000-000000000007");

    private static readonly Guid IronMineL2ResourcesProductionPerMinuteId =
        Guid.Parse("00000000-0000-0000-0000-000000000008");

    private static readonly Guid FarmL1ResourcesCostId = Guid.Parse("00000000-0000-0000-0000-000000000009");

    private static readonly Guid FarmL1ResourcesProductionPerMinuteId =
        Guid.Parse("00000000-0000-0000-0000-000000000010");

    private static readonly Guid FarmL2ResourcesCostId = Guid.Parse("00000000-0000-0000-0000-000000000011");

    private static readonly Guid FarmL2ResourcesProductionPerMinuteId =
        Guid.Parse("00000000-0000-0000-0000-000000000012");

    private static readonly Guid WoodcuttersHutL1ResourcesCostId = Guid.Parse("00000000-0000-0000-0000-000000000013");

    private static readonly Guid WoodcuttersHutL1ResourcesProductionPerMinuteId =
        Guid.Parse("00000000-0000-0000-0000-000000000014");

    private static readonly Guid WoodcuttersHutL2ResourcesCostId = Guid.Parse("00000000-0000-0000-0000-000000000015");

    private static readonly Guid WoodcuttersHutL2ResourcesProductionPerMinuteId =
        Guid.Parse("00000000-0000-0000-0000-000000000016");

    private static readonly Guid BarracksL1ResourcesCostId = Guid.Parse("00000000-0000-0000-0000-000000000017");
    private static readonly Guid BarracksL2ResourcesCostId = Guid.Parse("00000000-0000-0000-0000-000000000018");

    private static readonly Guid UniversityOfMilitaryTacticsL1ResourcesCostId =
        Guid.Parse("00000000-0000-0000-0000-000000000019");

    private static readonly Guid UniversityOfMilitaryTacticsL2ResourcesCostId =
        Guid.Parse("00000000-0000-0000-0000-000000000020");

    private static readonly Guid UniversityOfMilitaryTacticsL3ResourcesCostId =
        Guid.Parse("00000000-0000-0000-0000-000000000021");

    private static readonly Guid SwordsmanTrainingCostId = Guid.Parse("00000000-0000-0000-0000-000000000022");
    private static readonly Guid ArcherTrainingCostId = Guid.Parse("00000000-0000-0000-0000-000000000023");
    private static readonly Guid KnightTrainingCostId = Guid.Parse("00000000-0000-0000-0000-000000000024");
    private static readonly Guid KnightOnHorsebackTrainingCostId = Guid.Parse("00000000-0000-0000-0000-000000000025");


    public static BuildingResources[] GetBuildingsResourcesSeed(Uri webAppUrl)
    {
        return new BuildingResources[]
        {
            new()
            {
                Id = GoldMineId, Name = "Gold mine", MaxInVillage = 2,
                ImageUrl = new Uri(webAppUrl, "buildings/gold_mine.svg").ToString()
            },
            new()
            {
                Id = IronMineId, Name = "Iron mine", MaxInVillage = 2,
                ImageUrl = new Uri(webAppUrl, "buildings/iron_mine.svg").ToString()
            },
            new()
            {
                Id = FarmId, Name = "Farm", MaxInVillage = 2,
                ImageUrl = new Uri(webAppUrl, "buildings/farm.svg").ToString()
            },
            new()
            {
                Id = WoodcuttersHutId, Name = "Woodcutter's hut", MaxInVillage = 2,
                ImageUrl = new Uri(webAppUrl, "buildings/woodcutters_hut.svg").ToString()
            }
        };
    }

    public static BuildingBarracks[] GetBuildingsBarracksSeed(Uri webAppUrl)
    {
        return new BuildingBarracks[]
        {
            new()
            {
                Id = BarracksId, Name = "Barracks", MaxInVillage = 1,
                ImageUrl = new Uri(webAppUrl, "buildings/barracks.svg").ToString()
            },
            new()
            {
                Id = UniversityOfMilitaryTacticsId, Name = "University of military tactics", MaxInVillage = 1,
                ImageUrl = new Uri(webAppUrl, "buildings/fortress.svg").ToString()
            }
        };
    }

    public static BuildingLevel[] GetBuildingLevelsSeed()
    {
        return new BuildingLevel[]
        {
            new()
            {
                BuildingId = GoldMineId,
                Id = Guid.NewGuid(), Level = 1, BuildingTimeInSeconds = 60,
                TrainingTimeShortenedPercentage = 0,
                ResourcesCostId = GoldMineL1ResourcesCostId,
                ResourcesProductionPerMinuteId = GoldMineL1ResourcesProductionPerMinuteId
            },
            new()
            {
                BuildingId = GoldMineId,
                Id = Guid.NewGuid(), Level = 2, BuildingTimeInSeconds = 150,
                TrainingTimeShortenedPercentage = 10,
                ResourcesCostId = GoldMineL2ResourcesCostId,
                ResourcesProductionPerMinuteId = GoldMineL2ResourcesProductionPerMinuteId
            },
            new()
            {
                BuildingId = IronMineId,
                Id = Guid.NewGuid(), Level = 1, BuildingTimeInSeconds = 60,
                TrainingTimeShortenedPercentage = 0,
                ResourcesCostId = IronMineL1ResourcesCostId,
                ResourcesProductionPerMinuteId = IronMineL1ResourcesProductionPerMinuteId
            },
            new()
            {
                BuildingId = IronMineId,
                Id = Guid.NewGuid(), Level = 2, BuildingTimeInSeconds = 150,
                TrainingTimeShortenedPercentage = 10,
                ResourcesCostId = IronMineL2ResourcesCostId,
                ResourcesProductionPerMinuteId = IronMineL2ResourcesProductionPerMinuteId
            },
            new()
            {
                BuildingId = FarmId,
                Id = Guid.NewGuid(), Level = 1, BuildingTimeInSeconds = 60,
                TrainingTimeShortenedPercentage = 0,
                ResourcesCostId = FarmL1ResourcesCostId,
                ResourcesProductionPerMinuteId = FarmL1ResourcesProductionPerMinuteId
            },
            new()
            {
                BuildingId = FarmId,
                Id = Guid.NewGuid(), Level = 2, BuildingTimeInSeconds = 150,
                TrainingTimeShortenedPercentage = 10,
                ResourcesCostId = FarmL2ResourcesCostId,
                ResourcesProductionPerMinuteId = FarmL2ResourcesProductionPerMinuteId
            },
            new()
            {
                BuildingId = WoodcuttersHutId,
                Id = Guid.NewGuid(), Level = 1, BuildingTimeInSeconds = 60,
                TrainingTimeShortenedPercentage = 0,
                ResourcesCostId = WoodcuttersHutL1ResourcesCostId,
                ResourcesProductionPerMinuteId = WoodcuttersHutL1ResourcesProductionPerMinuteId
            },
            new()
            {
                BuildingId = WoodcuttersHutId,
                Id = Guid.NewGuid(), Level = 2, BuildingTimeInSeconds = 150,
                TrainingTimeShortenedPercentage = 10,
                ResourcesCostId = WoodcuttersHutL2ResourcesCostId,
                ResourcesProductionPerMinuteId = WoodcuttersHutL2ResourcesProductionPerMinuteId
            },
            new()
            {
                BuildingId = BarracksId,
                Id = Guid.NewGuid(), Level = 1, BuildingTimeInSeconds = 60,
                TrainingTimeShortenedPercentage = 0,
                ResourcesCostId = BarracksL1ResourcesCostId,
                ResourcesProductionPerMinuteId = null
            },
            new()
            {
                BuildingId = BarracksId,
                Id = Guid.NewGuid(), Level = 2, BuildingTimeInSeconds = 150,
                TrainingTimeShortenedPercentage = 10,
                ResourcesCostId = BarracksL2ResourcesCostId,
                ResourcesProductionPerMinuteId = null
            },
            new()
            {
                BuildingId = UniversityOfMilitaryTacticsId,
                Id = Guid.NewGuid(), Level = 1, BuildingTimeInSeconds = 90,
                TrainingTimeShortenedPercentage = 0,
                ResourcesCostId = UniversityOfMilitaryTacticsL1ResourcesCostId,
                ResourcesProductionPerMinuteId = null
            },
            new()
            {
                BuildingId = UniversityOfMilitaryTacticsId,
                Id = Guid.NewGuid(), Level = 2, BuildingTimeInSeconds = 200,
                TrainingTimeShortenedPercentage = 10,
                ResourcesCostId = UniversityOfMilitaryTacticsL2ResourcesCostId,
                ResourcesProductionPerMinuteId = null
            },
            new()
            {
                BuildingId = UniversityOfMilitaryTacticsId,
                Id = Guid.NewGuid(), Level = 3, BuildingTimeInSeconds = 500,
                TrainingTimeShortenedPercentage = 20,
                ResourcesCostId = UniversityOfMilitaryTacticsL3ResourcesCostId,
                ResourcesProductionPerMinuteId = null
            }
        };
    }

    public static MilitaryUnit[] GetMilitaryUnitsSeed(Uri webAppUrl)
    {
        return new MilitaryUnit[]
        {
            new()
            {
                Id = SwordsmanId, Name = "Swordsman", Attack = 10, Defense = 10,
                IconUrl = new Uri(webAppUrl, "units/swordsman.svg").ToString(), MinBarracksLevel = 2,
                TrainingCostId = SwordsmanTrainingCostId,
                TrainingTimeInSeconds = 10
            },
            new()
            {
                Id = ArcherId, Name = "Archer", Attack = 15, Defense = 5,
                IconUrl = new Uri(webAppUrl, "units/archer.svg").ToString(), MinBarracksLevel = 1,
                TrainingCostId = ArcherTrainingCostId,
                TrainingTimeInSeconds = 15
            },
            new()
            {
                Id = KnightId, Name = "Knight", Attack = 20, Defense = 25,
                IconUrl = new Uri(webAppUrl, "units/knight.svg").ToString(), MinBarracksLevel = 1,
                TrainingCostId = KnightTrainingCostId,
                TrainingTimeInSeconds = 40
            },
            new()
            {
                Id = KnightOnHorsebackId, Name = "Knight on horseback", Attack = 40, Defense = 20,
                IconUrl = new Uri(webAppUrl, "units/knight_on_horseback.svg").ToString(),
                MinBarracksLevel = 3,
                TrainingCostId = KnightOnHorsebackTrainingCostId,
                TrainingTimeInSeconds = 60
            }
        };
    }

    public static Dictionary<string, object>[] GetMilitaryUnitTrainableInBarracksSeed()
    {
        return new Dictionary<string, object>[]
        {
            new()
            {
                { "BuildingBarracksId", BarracksId },
                { "MilitaryUnitId", SwordsmanId }
            },
            new()
            {
                { "BuildingBarracksId", BarracksId },
                { "MilitaryUnitId", ArcherId }
            },
            new()
            {
                { "BuildingBarracksId", UniversityOfMilitaryTacticsId },
                { "MilitaryUnitId", KnightId }
            },
            new()
            {
                { "BuildingBarracksId", UniversityOfMilitaryTacticsId },
                { "MilitaryUnitId", KnightOnHorsebackId }
            }
        };
    }

    public static Resources[] GetResourcesSeed()
    {
        return new Resources[]
        {
            new()
            {
                Id = GoldMineL1ResourcesCostId,
                Wood = 100,
                Iron = 20,
                Wheat = 0,
                Gold = 10
            },
            new()
            {
                Id = GoldMineL1ResourcesProductionPerMinuteId,
                Wood = 0,
                Iron = 0,
                Wheat = 0,
                Gold = 1
            },
            new()
            {
                Id = GoldMineL2ResourcesCostId,
                Wood = 120,
                Iron = 25,
                Wheat = 0,
                Gold = 15
            },
            new()
            {
                Id = GoldMineL2ResourcesProductionPerMinuteId,
                Wood = 0,
                Iron = 0,
                Wheat = 0,
                Gold = 2
            },
            new()
            {
                Id = IronMineL1ResourcesCostId,
                Wood = 100,
                Iron = 10,
                Wheat = 0,
                Gold = 20
            },
            new()
            {
                Id = IronMineL1ResourcesProductionPerMinuteId,
                Wood = 0,
                Iron = 1,
                Wheat = 0,
                Gold = 0
            },
            new()
            {
                Id = IronMineL2ResourcesCostId,
                Wood = 120,
                Iron = 15,
                Wheat = 0,
                Gold = 25
            },
            new()
            {
                Id = IronMineL2ResourcesProductionPerMinuteId,
                Wood = 0,
                Iron = 2,
                Wheat = 0,
                Gold = 0
            },
            new()
            {
                Id = FarmL1ResourcesCostId,
                Wood = 120,
                Iron = 0,
                Wheat = 5,
                Gold = 0
            },
            new()
            {
                Id = FarmL1ResourcesProductionPerMinuteId,
                Wood = 0,
                Iron = 0,
                Wheat = 1,
                Gold = 0
            },
            new()
            {
                Id = FarmL2ResourcesCostId,
                Wood = 150,
                Iron = 0,
                Wheat = 10,
                Gold = 0
            },
            new()
            {
                Id = FarmL2ResourcesProductionPerMinuteId,
                Wood = 0,
                Iron = 0,
                Wheat = 2,
                Gold = 0
            },
            new()
            {
                Id = WoodcuttersHutL1ResourcesCostId,
                Wood = 60,
                Iron = 10,
                Wheat = 15,
                Gold = 8
            },
            new()
            {
                Id = WoodcuttersHutL1ResourcesProductionPerMinuteId,
                Wood = 1,
                Iron = 0,
                Wheat = 0,
                Gold = 0
            },
            new()
            {
                Id = WoodcuttersHutL2ResourcesCostId,
                Wood = 80,
                Iron = 15,
                Wheat = 20,
                Gold = 10
            },
            new()
            {
                Id = WoodcuttersHutL2ResourcesProductionPerMinuteId,
                Wood = 2,
                Iron = 0,
                Wheat = 0,
                Gold = 0
            },
            new()
            {
                Id = BarracksL1ResourcesCostId,
                Wood = 100,
                Iron = 20,
                Wheat = 0,
                Gold = 20
            },
            new()
            {
                Id = BarracksL2ResourcesCostId,
                Wood = 120,
                Iron = 25,
                Wheat = 0,
                Gold = 25
            },
            new()
            {
                Id = UniversityOfMilitaryTacticsL1ResourcesCostId,
                Wood = 150,
                Iron = 100,
                Wheat = 0,
                Gold = 50
            },
            new()
            {
                Id = UniversityOfMilitaryTacticsL2ResourcesCostId,
                Wood = 180,
                Iron = 120,
                Wheat = 0,
                Gold = 60
            },
            new()
            {
                Id = UniversityOfMilitaryTacticsL3ResourcesCostId,
                Wood = 200,
                Iron = 150,
                Wheat = 0,
                Gold = 70
            },
            new()
            {
                Id = SwordsmanTrainingCostId,
                Wood = 30,
                Iron = 30,
                Wheat = 25,
                Gold = 20
            },
            new()
            {
                Id = ArcherTrainingCostId,
                Wood = 50,
                Iron = 20,
                Wheat = 25,
                Gold = 15
            },
            new()
            {
                Id = KnightTrainingCostId,
                Wood = 0,
                Iron = 60,
                Wheat = 30,
                Gold = 60
            },
            new()
            {
                Id = KnightOnHorsebackTrainingCostId,
                Wood = 0,
                Iron = 80,
                Wheat = 30,
                Gold = 70
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
