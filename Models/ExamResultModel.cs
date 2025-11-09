namespace SchoolManagement.Models
{
    public class ExamResultModel
    {
        public int ResultId { get; set; }
        public int StudentId { get; set; }
        public string ExamName { get; set; }
        public string Subject { get; set; }
        public float GradePoint { get; set; }
        public float PercentFrom { get; set; }
        public float PercentUpto { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
