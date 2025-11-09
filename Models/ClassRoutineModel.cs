using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class ClassRoutineModel
    {
        public int RoutineId { get; set; }
        public string DayOfWeek { get; set; }
        public string Class { get; set; }
        public string SubjectName { get; set; }
        public string SubjectType { get; set; }
        public string SubjectCode { get; set; }
        public string Section { get; set; }
        public string Teacher { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        //[DataType(DataType.Date)]
        public string Date { get; set; }
    }

    public class ClassRoutinePageViewModel
{
    public ClassRoutineModel Routine { get; set; }
    public List<ClassRoutineModel> RoutineList { get; set; }
}
}
