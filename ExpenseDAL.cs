using Dapper;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using SchoolManagement.Models;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public class ExpenseDAL      
    {
        private readonly Common _common;

        public ExpenseDAL(Common common)
        {
            _common = common;
        }

        public int  SetExpense(ExpenseModel model)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
               
                param.Add("@ID",model.ID);
                param.Add("@ExpenseType",model.ExpenseType);
                param.Add("@Name", model.Name);
                param.Add("@Amount", model.Amount);
                param.Add("@Status", model.Status);
                param.Add("@Phone", model.Phone);
                param.Add("@Email", model.Email);
                param.Add("@Date", model.Date);

                result=con.Query<int>("sp_AddOrUpdateExpense", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }

        public List<ExpenseModel> GetExpenseList()
        {
            List<ExpenseModel> exp=new List<ExpenseModel>();
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                exp = conn.Query<ExpenseModel>("sp_GetAllExpenses", commandType: CommandType.StoredProcedure).ToList();
            }
            return exp;
        }

        public ExpenseModel GetExpeseById(int? Id)
        {
            ExpenseModel expense = new ExpenseModel();
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("ID",Id);
                expense=con.Query<ExpenseModel>("sp_GetExpenseById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return expense;
        }
    }
}
