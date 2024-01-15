using Domain.Models;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Persistence.Contexts;
using Persistence.IRepository;

namespace Services
{
    public class CalendarFetchService : ICalendarFetchService
    {
        private ApplicationDbContext _db;

        string ApiKey;
        string CalendarId = "sr.rs.official#holiday@group.v.calendar.google.com";

        public CalendarFetchService(ApplicationDbContext db)
        {
            _db = db;
            ApiKey = Environment.GetEnvironmentVariable("GOOGLE_CALENDAR_API_KEY")!;
        }

        public async Task GetAndSaveCalendarEventsAsync()
        {
            var holidaysInDatabase = _db.PublicHolidays.ToList();
            if (!holidaysInDatabase.Any())
            {
                DateTime currentDate = DateTime.Now;
                DateTime startPeriod = currentDate;
                DateTime endPeriod = startPeriod.AddMonths(13);

                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    ApiKey = ApiKey,
                    ApplicationName = "StaffHub"
                });

                var request = service.Events.List(CalendarId);
                request.Fields = "items(summary,start,end)";
                var response = await request.ExecuteAsync();

                var holidaysForNext13Months = response.Items
                    .Where(item => (item.Start.DateTime ?? DateTime.Parse(item.Start.Date)) >= startPeriod
                                && (item.Start.DateTime ?? DateTime.Parse(item.Start.Date)) <= endPeriod).ToList();

                foreach (var item in holidaysForNext13Months)
                {
                    PublicHoliday publicHoliday = new PublicHoliday
                    {
                        Name = item.Summary,
                        StartDate = DateOnly.FromDateTime(item.Start.DateTime ?? DateTime.Parse(item.Start.Date)),
                        EndDate = DateOnly.FromDateTime(item.End.DateTime ?? DateTime.Parse(item.End.Date))
                    };

                    _db.PublicHolidays.Add(publicHoliday);
                }
            }
            else
            {
                var lastPublicHoliday = _db.PublicHolidays.OrderByDescending(h => h.Id).FirstOrDefault();

                DateOnly startPeriod = lastPublicHoliday.EndDate;
                DateOnly endPeriod = startPeriod.AddMonths(1);

                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    ApiKey = ApiKey,
                    ApplicationName = "StaffHub"
                });

                var request = service.Events.List(CalendarId);
                request.Fields = "items(summary,start,end)";
                var response = await request.ExecuteAsync();

                var holidaysForOneMonth = response.Items
                    .Where(item => (DateOnly.FromDateTime(item.Start.DateTime ?? DateTime.Parse(item.Start.Date))) >= startPeriod
                                && (DateOnly.FromDateTime(item.Start.DateTime ?? DateTime.Parse(item.Start.Date))) <= endPeriod).ToList();

                foreach (var item in holidaysForOneMonth)
                {
                    PublicHoliday publicHoliday = new PublicHoliday
                    {
                        Name = item.Summary,
                        StartDate = DateOnly.FromDateTime(item.Start.DateTime ?? DateTime.Parse(item.Start.Date)),
                        EndDate = DateOnly.FromDateTime(item.End.DateTime ?? DateTime.Parse(item.End.Date))
                    };

                    _db.PublicHolidays.Add(publicHoliday);
                }
            }

            await _db.SaveChangesAsync();
        }
    }
}
