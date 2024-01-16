using Domain.Models;
using Persistence.Contexts;
using Persistence.IRepository;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ITeamRepository Team { get; private set; }
        public ILeaveRepository Leave { get; private set; }
        public IPublicHolidayRepository PublicHoliday { get; private set; }
        public IDayTally DayTally { get; private set; }
        public IUserRepository User { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Team = new TeamRepository(_db);
            Leave = new LeaveRepository(_db);
            PublicHoliday = new PublicHolidayRepository(_db);
            DayTally = new DaysTallyRepository(_db);
            User = new UserRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
