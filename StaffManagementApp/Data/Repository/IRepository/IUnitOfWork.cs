namespace StaffManagementApp.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStaffRepository Staff { get; }
        ITeamRepository Teams { get; }
        void Save();
    }
}
