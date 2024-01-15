using Domain.Models;
using Persistence.Contexts;
using Persistence.IRepository;

namespace Persistence.Repositories
{
    public class LeaveRepository : Repository<Leave>, ILeaveRepository
    {
        private ApplicationDbContext _db;
        public LeaveRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Leave obj)
        {
            _db.Leaves.Update(obj);
        }
    }
}
