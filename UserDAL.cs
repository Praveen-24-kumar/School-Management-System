using Dapper;
using SchoolManagement.Models;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public class UserDAL
    {
        private readonly Common _common;

        public UserDAL(Common common)
        {
            _common = common;
        }

        public int AddorUpdate(UsersModel model)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();

                param.Add("@UserId", model.UserId);
                param.Add("@Name", model.Name);
                param.Add("@Username", model.Username);
                param.Add("@Password", model.Password);
                param.Add("@PhoneNo", model.PhoneNo);
                param.Add("@Role", model.Role);
                param.Add("@IsActive", model.IsActive);
                param.Add("@Deleted", model.Deleted);

                result = con.Query<int>("AddOrUpdateUserList", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }


        public List<UsersModel> GetAllUsers()
        {
            List<UsersModel> usersModels = new List<UsersModel>();
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                usersModels = conn.Query<UsersModel>("GetAllUsers", commandType: CommandType.StoredProcedure).ToList();

            }
            return usersModels;
        }

        public UsersModel GetUserById(int? id)
        {
            UsersModel users = new UsersModel();
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();

                param.Add("@UserId", id);
                using (var multi = con.QueryMultiple("GetUserById", param, commandType: CommandType.StoredProcedure))
                {
                    users = multi.Read<UsersModel>().FirstOrDefault();
                    if (users == null)
                    {
                        users = new UsersModel();
                    }
                    if (!multi.IsConsumed)
                    {
                        users.RoleList = multi.Read<DropdownList>().ToList();
                    }
                }

            }
            return users;
        }

        public int Delete(int id)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@UserId", id);

                result = con.Query<int>("DeleteUser", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;

        }

       



    }
}

