using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class UsersModel
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PhoneNo { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }

        public string Deleted { get; set; }


        public List<DropdownList> RoleList { get; set; } = new List<DropdownList>();
    }
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
    }
}
