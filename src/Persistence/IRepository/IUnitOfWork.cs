namespace Persistence.IRepository
{
    public interface IUnitOfWork
    {
        ITeamRepository Team { get; }
        ILeaveRepository Leave { get; }

        void Save();
    }
}
