namespace Persistence.IRepository
{
    public interface IUnitOfWork
    {
        ITeamRepository Team { get; }
        ILeaveRepository Leave { get; }
        IPublicHolidayRepository PublicHoliday { get; }
        IDayTally DayTally { get; }
        IUserRepository User { get; }
        void Save();
    }
}
