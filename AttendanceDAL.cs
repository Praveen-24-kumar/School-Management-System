using Dapper;
using System.Data.SqlClient;

namespace SchoolManagement.Models
{
    public class AttendanceDAL
    {
        private readonly Common _common;

        public AttendanceDAL(Common common)
        {
            _common = common;
        }

        public List<string> GetClasses()
        {
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                return con.Query<string>("SELECT DISTINCT Class FROM Student").ToList();
            }
        }

        public List<string> GetSections()
        {
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                return con.Query<string>("SELECT DISTINCT Section FROM Student").ToList();
            }
        }

        public List<StudentAttendance> GetAttendance(string className, string section, string month, int year)
        {
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                // Step 1: Get Students of that Class & Section
                var students = con.Query<(int StudentId, string Name)>(
                    "SELECT StudentId, Name FROM Student WHERE Class=@Class AND Section=@Section",
                    new { Class = className, Section = section }).ToList();

                // Step 2: Create Attendance List
                var result = new List<StudentAttendance>();

                foreach (var st in students)
                {
                    var sa = new StudentAttendance
                    {
                        StudentId = st.StudentId,
                        StudentName = st.Name,
                        Days = new Dictionary<int, string>() // initialize days dictionary
                    };

                    // Step 3: Fetch Attendance from DB
                    var attendance = con.Query<(DateTime AttendanceDate, bool IsPresent)>(
                        "SELECT AttendanceDate, IsPresent FROM Attendance " +
                        "WHERE StudentId=@Id AND MONTH(AttendanceDate)=@Month AND YEAR(AttendanceDate)=@Year",
                        new { Id = st.StudentId, Month = DateTime.ParseExact(month, "MMMM", null).Month, Year = year }).ToList();

                    foreach (var at in attendance)
                    {
                        // ✅ Convert bool to ✔ ✘
                        sa.Days[at.AttendanceDate.Day] = at.IsPresent ? "✔" : "✘";
                    }

                    result.Add(sa);
                }

                return result;
            }
        }

        public void SaveAttendance(int studentId, DateTime date, bool isPresent)
        {
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {

                var sql = @"
        IF EXISTS (SELECT 1 FROM Attendance WHERE StudentId=@StudentId AND AttendanceDate=@Date)
            UPDATE Attendance SET IsPresent=@IsPresent WHERE StudentId=@StudentId AND AttendanceDate=@Date
        ELSE
            INSERT INTO Attendance (StudentId, AttendanceDate, IsPresent) 
            VALUES (@StudentId, @Date, @IsPresent)";

                con.Execute(sql, new { StudentId = studentId, Date = date, IsPresent = isPresent });
            }

        }
    }

}


