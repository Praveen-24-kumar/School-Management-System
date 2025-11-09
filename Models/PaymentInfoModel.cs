using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class PaymentInfoModel
    {
        public int StudentFeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ParentName { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public decimal Fees { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentMethod { get; set; }

        public List<DropdownList> StudentList { get; set; } = new List<DropdownList>();
    }
}
