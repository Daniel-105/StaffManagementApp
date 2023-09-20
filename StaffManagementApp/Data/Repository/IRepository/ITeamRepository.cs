using StaffManagementApp.Models;

namespace StaffManagementApp.Data.Repository.IRepository
{
    public interface ITeamRepository : IRepository<Team>
    {
        void Update(Team obj);
    }
}
