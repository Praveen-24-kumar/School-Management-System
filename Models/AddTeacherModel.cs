using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SchoolManagement.Models
{
    public class AddTeacherModel
    {
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Joining Date is required")]
        [DataType(DataType.Date)]
        public string JoiningDate { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Class must be alphanumeric")]
        public string Class { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Section must be alphanumeric")]
        public string Section { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Subject must contain only letters")]
        public string Subject { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\-]*$", ErrorMessage = "ID must be alphanumeric")]
        public string IdNo { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Religion must contain only letters")]
        public string Religion { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must be 10 digits")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be exactly 10 digits")]
        public string PhoneNo { get; set; }

        public string Address { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        public string PhotoPath { get; set; }
    }
}
