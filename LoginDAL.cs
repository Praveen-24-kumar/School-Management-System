using Dapper;
using SchoolManagement.Models;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public class LoginDAL
    {
        private readonly Common _common;

        public LoginDAL(Common common)
        {
            _common = common;
        }

        //public int GetLogin(LoginModel model)
        //{
        //    int result = 0;
        //    using (SqlConnection con = new SqlConnection(_common.getConnection()))
        //    {
        //        var param = new DynamicParameters();
        //        param.Add("@Id", model.Id);
        //        param.Add("@Username", model.Username);
        //        param.Add("@Password", model.Password);

        //        result = con.Query<int>("sp_GetLogin", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //    }

        //    return result;
        //}


        // DAL
        public UsersModel GetLogin(LoginModel model)
        {
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var user = con.QueryFirstOrDefault<UsersModel>(
                    "SELECT * FROM Users WHERE Username=@Username AND Password=@Password",
                    new { model.Username, model.Password });

                return user;
            }
        }






        // ✅ Check if Email Exists (Used for Forgot Password)
        public LoginModel GetUserByEmail(string username)
        {
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username AND IsActive = 1";
                return con.QueryFirstOrDefault<LoginModel>(query, new { Username = username });
            }
        }
    }
}
