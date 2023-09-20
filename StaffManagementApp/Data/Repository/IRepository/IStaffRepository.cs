using StaffManagementApp.Models;

namespace StaffManagementApp.Data.Repository.IRepository
{
    public interface IStaffRepository : IRepository<Staff>
    {
        void Update(Staff obj);
    }
}
