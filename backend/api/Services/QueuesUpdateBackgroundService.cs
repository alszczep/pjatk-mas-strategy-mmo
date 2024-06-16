using api.Services.Interfaces;

namespace api.Services;

public class QueuesUpdateBackgroundService : BackgroundService
{
    private IServiceProvider serviceProvider;
    private ILogger<QueuesUpdateBackgroundService> logger;

    public QueuesUpdateBackgroundService(
        IServiceProvider serviceProvider,
        ILogger<QueuesUpdateBackgroundService> logger)
    {
        this.serviceProvider = serviceProvider;
        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            this.logger.LogInformation("Running queues and resources update");

            using (IServiceScope scope = this.serviceProvider.CreateScope())
            {
                IBuildingsService buildingsService = scope.ServiceProvider.GetRequiredService<IBuildingsService>();
                IVillagesService villagesService = scope.ServiceProvider.GetRequiredService<IVillagesService>();
                await buildingsService.UpdateBuildingsQueueGlobally(cancellationToken);
                await villagesService.UpdateResourcesGlobally(cancellationToken);
            }

            await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
        }
    }
}
