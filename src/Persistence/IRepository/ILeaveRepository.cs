using Domain.Models;

namespace Persistence.IRepository
{
    public interface ILeaveRepository : IRepository<Leave>
    {
        List<Leave> LeaveList();
    }
}
