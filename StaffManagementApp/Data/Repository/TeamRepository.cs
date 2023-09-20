using StaffManagementApp.Data.Repository.IRepository;
using StaffManagementApp.Models;

namespace StaffManagementApp.Data.Repository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        private ApplicationDbContext _db;
        public TeamRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Team obj)
        {
            _db.Update(obj);
        }
    }
}
