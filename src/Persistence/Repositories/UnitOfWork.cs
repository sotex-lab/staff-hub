using Persistence.Contexts;
using Persistence.IRepository;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ITeamRepository Team { get; private set; }
        public ILeaveRepository Leave { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Team = new TeamRepository(_db);
            Leave = new LeaveRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
