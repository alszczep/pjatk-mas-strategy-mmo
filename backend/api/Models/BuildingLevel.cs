namespace api.Models;

public class BuildingLevel
{
    public Guid Id { get; init; }
    public int Level { get; init; }
    public int BuildingTimeInSeconds { get; init; }

    private int? trainingTimeShortenedPercentage;

    public int? TrainingTimeShortenedPercentage
    {
        get
        {
            if (this.Building.Type != BuildingType.Barracks)
                throw new InvalidOperationException("Building type has to be barracks");

            if (!this.trainingTimeShortenedPercentage.HasValue)
                throw new InvalidOperationException(
                    "For building type barracks, TrainingTimeShortenedPercentage has to be set");

            return this.trainingTimeShortenedPercentage;
        }
        init => this.trainingTimeShortenedPercentage = value;
    }

    public Guid ResourcesCostId { get; init; }
    public Resources ResourcesCost { get; init; } = null!;
    public Guid? ResourcesProductionPerMinuteId { get; init; }
    private Resources? resourcesProductionPerMinute;

    public Resources? ResourcesProductionPerMinute
    {
        get
        {
            if (this.Building.Type != BuildingType.Resources)
                throw new InvalidOperationException("Building type has to be resources");

            if (this.resourcesProductionPerMinute == null)
                throw new InvalidOperationException(
                    "For building type resources, ResourcesProductionPerMinute has to be set");

            return this.resourcesProductionPerMinute;
        }

        init => this.resourcesProductionPerMinute = value;
    }

    public Guid BuildingId { get; init; }
    public Building Building { get; init; } = null!;
}
