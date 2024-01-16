using Domain.Models;
using Persistence.Contexts;

namespace Persistence.IRepository
{
    public interface IPublicHolidayRepository : IRepository<PublicHoliday>
    {
        int Count();
    }
}
