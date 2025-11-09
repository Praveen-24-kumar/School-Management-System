using Dapper;
using NuGet.DependencyResolver;
using SchoolManagement.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;

namespace SchoolManagement
{
    public class FeeDAL
    {
        private readonly Common _common;

        public FeeDAL(Common common)
        {
            _common = common;
        }

        public int SetStudentFee(PaymentInfoModel model)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@StudentFeeId", model.StudentFeeId);
                param.Add("@Name", model.Name);
                param.Add("@Gender", model.Gender);
                param.Add("@ParentName", model.ParentName);
                param.Add("@Class", model.Class);
                param.Add("@Section", model.Section);
                param.Add("@Fees", model.Fees);
                param.Add("@Status", model.Status);
                param.Add("@Phone", model.Phone);
                param.Add("@Email", model.Email);
                param.Add("@Photo", model.Photo);
                param.Add("@PaymentMethod", model.PaymentMethod);
                param.Add("@PaymentDate", model.PaymentDate);


                result = con.Query<int>("sp_AddOrUpdateStudentFee", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }

        public List<PaymentInfoModel> GetAllStudentFee()
        {
            List<PaymentInfoModel> fee = new List<PaymentInfoModel>();
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                fee = conn.Query<PaymentInfoModel>("sp_GetAllStudentFees", commandType: CommandType.StoredProcedure).ToList();
            }
            return fee;
        }

        public PaymentInfoModel GetStudentFeeById(int? Id)
        {
            PaymentInfoModel pay = new PaymentInfoModel();
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@StudentFeeId", Id);
                using (var multi = con.QueryMultiple("sp_GetStudentFeeById", param, commandType: CommandType.StoredProcedure))
                {
                    pay = multi.Read<PaymentInfoModel>().FirstOrDefault();
                    if (pay ==null)
                    {
                        pay = new PaymentInfoModel();
                    }
                    if (!multi.IsConsumed)
                    {
                        pay.StudentList = multi.Read<DropdownList>().ToList();
                    }
                }
            }
            return pay;
        }
        public int DeleteFeeById(int? Id)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("StudentFeeId", Id);
                result = con.Query<int>("sp_DeleteFeeById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }
    }
}
;
