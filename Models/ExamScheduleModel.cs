    namespace SchoolManagement.Models
{
    public class ExamScheduleModel
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public string SubjectType { get; set; }
        public int Class { get; set; }
        public string Section { get; set; }
        public TimeSpan ExamTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string ExamDate { get; set; }
    }

    public class ExamSchedulePageViewModel
    {
        public ExamScheduleModel Exam { get; set; }
        public List<ExamScheduleModel> ExamList { get; set; }
    }
}
