using Domain.Models;
using Persistence.Contexts;
using Persistence.IRepository;

namespace Persistence.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
