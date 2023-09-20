namespace StaffManagementApp.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStaffRepository Staff { get; }
        void Save();
    }
}
