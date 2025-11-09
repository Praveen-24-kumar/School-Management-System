namespace SchoolManagement.Models
{
    public class SubjectModel
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectType { get; set; }
        public string Class { get; set; }
        public string SubjectCode { get; set; }
    }
    public class SubjectMaster
    {
        public SubjectModel Subject { get; set; }
        public List<SubjectModel> SubjectList { get; set; }
    }
}
