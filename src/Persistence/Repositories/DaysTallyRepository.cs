using System.Linq.Expressions;
using Domain.Models;
using Persistence.Contexts;
using Persistence.IRepository;

namespace Persistence.Repositories
{
    public class DaysTallyRepository : Repository<DaysTally>, IDayTally
    {
        public DaysTallyRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
