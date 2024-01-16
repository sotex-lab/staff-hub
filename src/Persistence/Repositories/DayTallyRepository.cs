using System.Linq.Expressions;
using Domain.Models;
using Persistence.Contexts;
using Persistence.IRepository;

namespace Persistence.Repositories
{
    public class DayTallyRepository : Repository<DaysTally>, IDayTally
    {
        private ApplicationDbContext _db;
        public DayTallyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public List<DaysTally> TallyList()
        {
            return _db.DaysTallies.ToList();
        }
    }
}
