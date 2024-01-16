using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.IRepository;
using Sgbj.Cron;

namespace Services
{
    public class CronJobService : BackgroundService
    {
        private readonly IServiceScope _scope;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICalendarFetchService _calendarFetchService;

        public CronJobService(IServiceScopeFactory factory)
        {
            _scope = factory.CreateScope();
            _calendarFetchService = _scope.ServiceProvider.GetRequiredService<ICalendarFetchService>();
            _unitOfWork = _scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_unitOfWork.PublicHoliday.Count() == 0)
                await _calendarFetchService.GetAndSaveCalendarEventsAsync();

            using var timer = new CronTimer("0 0 1 * *", TimeZoneInfo.Local);

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                await _calendarFetchService.GetAndSaveCalendarEventsAsync();
            }
        }
    }
}
