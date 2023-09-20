using StaffManagementApp.Data.Repository.IRepository;
using StaffManagementApp.Models;

namespace StaffManagementApp.Data.Repository
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        private ApplicationDbContext _db;
        public StaffRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Staff obj)
        {
            _db.Update(obj);
        }
    }
}
