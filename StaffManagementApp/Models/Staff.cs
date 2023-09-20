using System.ComponentModel.DataAnnotations;

namespace StaffManagementApp.Models
{
    public class Staff
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Hobbies { get; set; }
        public string Team { get; set; }
        public string? ImageURL { get; set; }
        public string? Email { get; set; }
    }
}
