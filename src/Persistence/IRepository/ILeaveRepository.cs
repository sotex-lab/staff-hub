using Domain.Models;

namespace Persistence.IRepository
{
    public interface ILeaveRepository : IRepository<Leave>
    {
        void Update(Leave obj);
    }
}
