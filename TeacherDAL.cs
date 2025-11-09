using Dapper;
using SchoolManagement.Models;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public class TeacherDAL
    {
        private readonly Common _common;

        public TeacherDAL(Common common)
        {
            _common = common;
        }

        // ✅ ADD or UPDATE Teacher
        public int AddorUpdateTeacher(AddTeacherModel teacher)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();

                
                param.Add("@TeacherId", teacher.TeacherId); 

                param.Add("@Name", teacher.Name);
                param.Add("@Gender", teacher.Gender);
                param.Add("@DateOfBirth", teacher.DateOfBirth);
                param.Add("@Class", teacher.Class);
                param.Add("@Section", teacher.Section);
                param.Add("@Subject", teacher.Subject);
                param.Add("@IdNo", teacher.IdNo);
                param.Add("@Religion", teacher.Religion);
                param.Add("@Email", teacher.Email);
                param.Add("@PhoneNo", teacher.PhoneNo);
                param.Add("@Address", teacher.Address);
                param.Add("@PhotoPath", teacher.PhotoPath);
                param.Add("@JoiningDate", teacher.JoiningDate);

                result = con.Query<int>("sp_AddTeacher", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return result;
        }

        
        public List<AddTeacherModel> GetAllTeacher()
        {
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                return conn.Query<AddTeacherModel>("GetAllTeachers", commandType: CommandType.StoredProcedure).ToList();
            }
        }

       
        public AddTeacherModel GetTeacherById(int? Id)
        {
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@TeacherId", Id);

                return con.Query<AddTeacherModel>("GetTeacherById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

      
        public int DeleteTeacherById(int Id)
        {
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@TeacherId", Id);

                return con.Query<int>("sp_DeleteTeacher", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
