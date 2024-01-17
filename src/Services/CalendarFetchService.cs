using Domain.Models;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Persistence.IRepository;

namespace Services
{
    public class CalendarFetchService : ICalendarFetchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private EventsResource.ListRequest request;

        public CalendarFetchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            var apiKey = Environment.GetEnvironmentVariable("GOOGLE_CALENDAR_API_KEY")!;
            string calendarId = "sr.rs.official#holiday@group.v.calendar.google.com";
            var calendarService = new CalendarService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = "StaffHub"
            });
            request = calendarService.Events.List(calendarId);
            request.Fields = "items(summary,start,end)";
        }

        public async Task GetAndSaveCalendarEventsAsync()
        {
            DateTime startPeriod;
            DateTime endPeriod;

            if (_unitOfWork.PublicHoliday.Count() == 0)
            {
                startPeriod = DateTime.Now;
                endPeriod = startPeriod.AddMonths(13);
            }
            else
            {
                var lastInDb = _unitOfWork.PublicHoliday.GetAll().OrderByDescending(x => x.EndDate).First();
                startPeriod = DateTime.Now.AddMonths(13);
                endPeriod = startPeriod.AddMonths(1);

                if (lastInDb.EndDate >= DateOnly.FromDateTime(startPeriod))
                    return;
            }

            var response = await request.ExecuteAsync();
            foreach (var item in Compare(startPeriod, endPeriod, response))
            {
                PublicHoliday publicHoliday = new PublicHoliday
                {
                    Name = item.Summary,
                    StartDate = DateOnly.FromDateTime(item.Start.DateTime ?? DateTime.Parse(item.Start.Date)),
                    EndDate = DateOnly.FromDateTime(item.End.DateTime ?? DateTime.Parse(item.End.Date))
                };

                _unitOfWork.PublicHoliday.Add(publicHoliday);
            }

            _unitOfWork.Save();
        }

        private IEnumerable<Event> Compare(DateTime startPeriod, DateTime endPeriod, Events response) => response.Items
                        .Where(item => (item.Start.DateTime ?? DateTime.Parse(item.Start.Date)) >= startPeriod
                                    && (item.Start.DateTime ?? DateTime.Parse(item.Start.Date)) <= endPeriod);
    }
}
