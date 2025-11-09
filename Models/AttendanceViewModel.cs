namespace SchoolManagement.Models
{
    public class AttendanceViewModel
    {
        public string SelectedClass { get; set; }
        public string SelectedSection { get; set; }
        public string SelectedMonth { get; set; }
        public int SelectedYear { get; set; }

        public List<string> Classes { get; set; } = new();
        public List<string> Sections { get; set; } = new();
        public List<string> Months { get; set; } = new();
        public List<int> Years { get; set; } = new();

        public List<StudentAttendance> StudentAttendances { get; set; } = new();
    }

    public class StudentAttendance
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public Dictionary<int, string> Days { get; set; } = new(); // Key = Day, Value = "✔" or "✘"
    }

    public class AttendanceEntry
    {
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }

        public int Day { get; set; }
    }

    public class AttendanceBulkRequest
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public List<AttendanceEntry> Entries { get; set; }
    }
}
