namespace api.Models;

public class BuildingLevel
{
    public Guid Id { get; init; }
    public int Level { get; init; }
    public int BuildingTimeInSeconds { get; init; }
    public int? TrainingTimeShortenedInSeconds { get; init; }

    public Resources ResourcesCost { get; init; } = null!;
    public Resources? ResourcesProductionPerMinute { get; init; }
    public Building Building { get; init; } = null!;

    public int GetTrainingShortenedTimeInSeconds()
    {
        if (this.Building.Type == BuildingType.Barracks)
        {
            if (!this.TrainingTimeShortenedInSeconds.HasValue)
                throw new InvalidOperationException(
                    "For building type barracks, TrainingTimeShortenedInSeconds has to be set");

            return this.TrainingTimeShortenedInSeconds.Value;
        }

        throw new InvalidOperationException("Building type has to be barracks");
    }

    public Resources GetProductionPerMinute()
    {
        if (this.Building.Type == BuildingType.Resources)
        {
            if (this.ResourcesProductionPerMinute == null)
                throw new InvalidOperationException(
                    "For building type resources, ResourcesProductionPerMinute has to be set");

            return this.ResourcesProductionPerMinute;
        }

        throw new InvalidOperationException("Building type has to be resources");
    }
}
