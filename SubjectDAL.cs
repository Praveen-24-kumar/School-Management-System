using Dapper;
using SchoolManagement.Models;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public class SubjectDAL
    {
        private readonly Common _common;

        public SubjectDAL(Common common)
        {
            _common = common;
        }

        public int SetSubjects(SubjectModel model)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@SubjectId", model.SubjectId);
                param.Add("@SubjectName", model.SubjectName);
                param.Add("@SubjectType", model.SubjectType);
                param.Add("@Class", model.Class);
                param.Add("@SubjectCode", model.SubjectCode);
                result = con.Query<int>("sp_AddOrUpdateSubject", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            return result;
        }

        public List<SubjectModel> GetAllSubjects()
        {
            SubjectMaster subjects = new SubjectMaster();
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                subjects.SubjectList = con.Query<SubjectModel>("sp_GetAllSubjects", commandType: CommandType.StoredProcedure).ToList();
            }
            return subjects.SubjectList;
        }

        public SubjectModel GetSubjectById(int? id)
        {
            SubjectModel subject = new SubjectModel();
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@SubjectId", id);
                subject = conn.Query<SubjectModel>("sp_GetSubjectById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            return subject;
        }

        

        public int  DeleteSubject(int? id)
        {
            var result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@SubjectId", id);
                result=con.Query<int>("sp_DeleteSubject", param, commandType: CommandType.StoredProcedure).FirstOrDefault(); 

            }
            return result;
        }
    }
}

