using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class BookModel
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Book Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Book Name can contain only letters and numbers")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Subject must contain only letters")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Writer Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Writer Name must contain only letters")]
        public string WriterName { get; set; }

        [Required(ErrorMessage = "Class is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Class must be alphanumeric")]
        public string Class { get; set; }

        [Required(ErrorMessage = "Publishing Year is required")]
        [Range(1900, 2100, ErrorMessage = "Publishing Year must be between 1900 and 2100")]
        public int PublishingYear { get; set; }

        [Required(ErrorMessage = "Upload Date is required")]
        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }

        [Required(ErrorMessage = "ID No is required")]
        [RegularExpression(@"^[a-zA-Z0-9\-]+$", ErrorMessage = "ID must be alphanumeric")]
        public string IdNo { get; set; }

        public DateTime CreatingDate { get; set; }
    }
}
