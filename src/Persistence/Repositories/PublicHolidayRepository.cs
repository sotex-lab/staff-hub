using Domain.Models;
using Persistence.Contexts;
using Persistence.IRepository;

namespace Persistence.Repositories
{
    public class PublicHolidayRepository : Repository<PublicHoliday>, IPublicHolidayRepository
    {
        public PublicHolidayRepository(ApplicationDbContext db) : base(db)
        {
        }

        public int Count()
        {
            return _db.PublicHolidays.Count();
        }
    }
}
