using StaffManagementApp.Data.Repository.IRepository;

namespace StaffManagementApp.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IStaffRepository Staff { get; private set; }
        public ITeamRepository Teams { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Staff = new StaffRepository(_db);
            Teams = new TeamRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
