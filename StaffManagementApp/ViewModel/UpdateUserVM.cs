using Microsoft.AspNetCore.Mvc.Rendering;
using StaffManagementApp.Models;

namespace StaffManagementApp.ViewModel
{
    public class UpdateUserVM
    {
        public Staff Staff { get; set; }
        public List<string> TeamNames { get; set; }
        public int SelectedTeamId { get; set; }
        public IEnumerable<SelectListItem> TeamsListList { get; internal set; }
    }
}
