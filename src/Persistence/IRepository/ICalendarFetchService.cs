namespace Persistence.IRepository
{
    public interface ICalendarFetchService
    {
        Task GetAndSaveCalendarEventsAsync();
    }
}
