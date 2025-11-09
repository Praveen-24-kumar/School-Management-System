using Dapper;
using Microsoft.AspNetCore.Routing;
using SchoolManagement.Models;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagement
{

    public class ExamDAL        
    {
        private readonly Common _common;
        public ExamDAL(Common common)
        {
            _common = common;
        }

        public int SetExam(ExamScheduleModel exam)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();

                param.Add("@ExamId", exam.ExamId);
                param.Add("@ExamName", exam.ExamName);
                param.Add("@SubjectType", exam.SubjectType);
                param.Add("@Class", exam.Class);
                param.Add("@Section", exam.Section);
                param.Add("@ExamTime", exam.ExamTime);
                param.Add("@EndTime", exam.EndTime);
                param.Add("@ExamDate", exam.ExamDate);
                result=con.Query<int>("sp_AddOrUpdateExamSchedule", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }

        public List<ExamScheduleModel> GetAllExamSchedules()
        {
            ExamSchedulePageViewModel exam = new ExamSchedulePageViewModel();
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                exam.ExamList=conn.Query<ExamScheduleModel>("sp_GetAllExamSchedules", commandType: CommandType.StoredProcedure).ToList();
            }
            return exam.ExamList;
        }

        public ExamScheduleModel GetExamScheduleById(int? id)
        {
            ExamScheduleModel ex = new ExamScheduleModel();
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@ExamId", id);
                ex = conn.Query<ExamScheduleModel>("sp_GetExamScheduleById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            return ex;
        }
        public int DeleteExam(int id)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@ExamId", id);
                result = conn.Query<int>("sp_DeleteExamSchedule", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            return result;
        }


    }
}
