using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class TransportModel
    {
        public int TransportId { get; set; }

        [Required(ErrorMessage = "Route Name is required.")]
        [StringLength(100, ErrorMessage = "Route Name can't be longer than 100 characters.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Route Name must contain only letters and spaces.")]
        public string RouteName { get; set; }

        [Required(ErrorMessage = "Vehicle Number is required.")]
        [StringLength(50)]
        public string VehicleNo { get; set; }

        [Required(ErrorMessage = "Driver Name is required.")]
        [StringLength(100)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Driver Name must contain only letters and spaces.")]
        public string DriverName { get; set; }


        [Required(ErrorMessage = "Driver License is required.")]
        [StringLength(50)]
        public string DriverLicense { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Contact Number must contain only numbers.")]
        [StringLength(15, ErrorMessage = "Contact Number can't be longer than 15 digits.")]
        public string ContactNumber { get; set; }
    }

    public class TransportPageViewModel
    {
        public TransportModel Transport { get; set; }
        public List<TransportModel> TransportList { get; set; }
    }
}
