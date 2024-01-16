using Domain.Models;
using Persistence.Contexts;
using Persistence.IRepository;

namespace Persistence.Repositories
{
    public class PublicHolidayRepository : Repository<PublicHoliday>, IPublicHolidayRepository
    {
        private ApplicationDbContext _db;
        public PublicHolidayRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.PublicHolidays.Count();
        }

        public List<PublicHoliday> HolidayList()
        {
            return _db.PublicHolidays.ToList();
        }
    }
}
