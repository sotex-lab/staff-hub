using Domain.Models;

namespace Persistence.IRepository
{
    public interface IPublicHolidayRepository : IRepository<PublicHoliday>
    {
        int Count();
    }
}
