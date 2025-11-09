using Dapper;
using SchoolManagement;
using SchoolManagement.Models;

using System.Data;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public class MasterDAL
    {
        private readonly Common _common;
        public MasterDAL(Common common)
        {
            _common = common;

        }

        public int AddorUpdate(MasterModel model)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();

                param.Add("@Id", model.Id);
                param.Add("@Name", model.Name);
                param.Add("@Role", model.Role);
                param.Add("@Designation", model.Designation);
                param.Add("@IsActive", model.IsActive);

                result = con.Query<int>("SP_Master_AddOrUpdate", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            return result;
        }


        public List<MasterModel> GetAllRoles()
        {
            List<MasterModel> models = new List<MasterModel>();

            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                models = conn.Query<MasterModel>("SP_Master_GetAll", commandType: CommandType.StoredProcedure).ToList();
            }
            return models;
        }

        public MasterModel GetRoleById(int? id)
        {
            MasterModel model = new MasterModel();
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@Id", id);
                model = conn.Query<MasterModel>("SP_Master_GetById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return model;
        }

        public int Delete(int id)
        {

            int result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@Id", id);
                result = con.Query<int>("SP_Master_Delete", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;

        }
    }
}
