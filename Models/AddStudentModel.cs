using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class AddStudentModel
    {
        public int StudentId { get; set; } = 0;

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Class is required")]
        public string Class { get; set; }

        [Required(ErrorMessage = "Section is required")]
        public string Section { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public string DOB { get; set; }

        [Required(ErrorMessage = "Roll is required")]
        [Range(1, 999, ErrorMessage = "Roll must be between 1 and 999")]
        public int Roll { get; set; }

        [Required(ErrorMessage = "Admission No is required")]
        public string AdmissionNo { get; set; }

        [Required(ErrorMessage = "Religion is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Religion can only contain letters and spaces")]
        public string Religion { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Father Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Father Name can only contain letters and spaces")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Mother Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Mother Name can only contain letters and spaces")]
        public string MotherName { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Father Occupation can only contain letters and spaces")]
        public string FatherOccupation { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Mother Occupation can only contain letters and spaces")]
        public string MotherOccupation { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Nationality is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Nationality can only contain letters and spaces")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Present Address is required")]
        public string PresentAddress { get; set; }

        [Required(ErrorMessage = "Permanent Address is required")]
        public string PermanentAddress { get; set; }

        public string PaymentType { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Amount must be positive")]
        public int Amount { get; set; }

        public string Status { get; set; }

        [NotMapped]
        public IFormFile? StudentPhoto { get; set; }
        public string StudentPhotoPath { get; set; }

        [NotMapped]
        public IFormFile? ParentPhoto { get; set; }
        public string ParentPhotoPath { get; set; }

        public ParentModel Parent { get; set; }
    }
}
