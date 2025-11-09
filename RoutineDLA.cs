using Dapper;
using Microsoft.AspNetCore.Routing;
using SchoolManagement.Models;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public class RoutineDLA
    {
        private readonly Common _common;

        public RoutineDLA(Common common)
        {
            _common = common;
        }

        public int SetRoutine(ClassRoutineModel routine)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@RoutineId", routine.RoutineId);
                param.Add("@DayOfWeek", routine.DayOfWeek);
                param.Add("@Class", routine.Class);
                param.Add("@SubjectName", routine.SubjectName);
                param.Add("@SubjectType", routine.SubjectType);
                param.Add("@SubjectCode", routine.SubjectCode);
                param.Add("@Section", routine.Section);
                param.Add("@Teacher", routine.Teacher);
                param.Add("@StartTime", routine.StartTime);
                param.Add("@EndTime", routine.EndTime);
                param.Add("@Date", routine.Date);

                result = con.Query<int>("sp_AddOrUpdateClassRoutine", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            return result;
        }

        public List<ClassRoutineModel> GetAllRoutine()
        {
            ClassRoutinePageViewModel subjects = new ClassRoutinePageViewModel();
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                subjects.RoutineList = conn.Query<ClassRoutineModel>("sp_GetAllClassRoutine", commandType: CommandType.StoredProcedure).ToList();
            }
            return subjects.RoutineList;
        }

        public ClassRoutineModel GetRoutineById(int? id)
        {
            ClassRoutineModel rou = new ClassRoutineModel();
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@RoutineId", id);
                rou = conn.Query<ClassRoutineModel>("sp_GetClassRoutineById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            return rou;
        }

        public int DeleteRoutine(int? id)
        {
            int result = 0;      
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@RoutineId", id);
                result = conn.Query<int>("sp_DeleteClassRoutine", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            return result;
        }
    }
}
