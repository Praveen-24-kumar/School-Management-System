using Dapper;
using SchoolManagement.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;


namespace SchoolManagement.Models


{
    public class DAL
    {
        private readonly Common _common;

        public DAL(Common common)
        {
            _common = common;
        }

        public int SetStudent(AddStudentModel student)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                // Add all parameters
                param.Add("@StudentId", student.StudentId);
                
                param.Add("@Name", student.Name);
                param.Add("@Class", student.Class);
                param.Add("@Section", student.Section);
                param.Add("@Gender", student.Gender);
                param.Add("@DOB", student.DOB);
                param.Add("@Roll", student.Roll);
                param.Add("@AdmissionNo", student.AdmissionNo);
                param.Add("@Religion", student.Religion);
                param.Add("@Email", student.Email);

                param.Add("@FatherName", student.FatherName);
                param.Add("@MotherName", student.MotherName);
                param.Add("@FatherOccupation", student.FatherOccupation);
                param.Add("@MotherOccupation", student.MotherOccupation);
                param.Add("@Phone", student.Phone);
                param.Add("@Nationality", student.Nationality);
                param.Add("@PresentAddress", student.PresentAddress);
                param.Add("@PermanentAddress", student.PermanentAddress);
                param.Add("@StudentPhotoPath", student.StudentPhotoPath);
                param.Add("@ParentPhotoPath", student.ParentPhotoPath);
                param.Add("@PaymentType", student.PaymentType);
                param.Add("@Amount", student.Amount);
                param.Add("@Status", student.Status);

                // Save only file paths (not the actual file)
                //param.Add("@StudentPhotoPath", student.StudentPhoto != null ? "/images/students/" + student.StudentPhoto.FileName : null);
                //param.Add("@ParentPhotoPath", student.ParentPhoto != null ? "/images/parents/" + student.ParentPhoto.FileName : null);

                result = con.Query<int>("sp_AddStudent", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }
        public List<AddStudentModel> GetAllStudents()
        {
                List<AddStudentModel> studentList =new List<AddStudentModel>();

            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                studentList = conn.Query<AddStudentModel>("sp_GetAllStudents", commandType: CommandType.StoredProcedure).ToList();
            }
            return studentList;
        }
            
        public AddStudentModel GetAddStudentById(int? Id)
        {
            AddStudentModel addstudent = new AddStudentModel();
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@StudentID", Id);
                addstudent = con.Query<AddStudentModel>("sp_GetStudentById",param,commandType: CommandType.StoredProcedure).FirstOrDefault();
                //if (addstudent == null)
                //{
                //    addstudent = new AddStudentModel();
                //}
            }
            return addstudent;
        }

        public int DeleteStudentById(int Id)
        {
            var result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@StudentId", Id);
                result = con.Query<int>("sp_DeleteStudent", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }

        

    }
}

