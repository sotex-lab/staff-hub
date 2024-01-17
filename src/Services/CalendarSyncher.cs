using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence.IRepository;
using Sgbj.Cron;

namespace Services
{
    public class CalendarSyncher : BackgroundService
    {
        private readonly IServiceScope _scope;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICalendarFetchService _calendarFetchService;
        private readonly ILogger<CalendarSyncher> _logger;

        public CalendarSyncher(IServiceScopeFactory factory, ILogger<CalendarSyncher> logger)
        {
            _scope = factory.CreateScope();
            _calendarFetchService = _scope.ServiceProvider.GetRequiredService<ICalendarFetchService>();
            _unitOfWork = _scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _calendarFetchService.GetAndSaveCalendarEventsAsync();

            using var timer = new CronTimer("0 0 1 * *", TimeZoneInfo.Local);

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                _logger.LogInformation("Syncing calendar...");
                await _calendarFetchService.GetAndSaveCalendarEventsAsync();
                _logger.LogInformation("Finished syncing calendar...");
            }
        }
    }
}
