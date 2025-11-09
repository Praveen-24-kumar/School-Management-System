using Dapper;
using SchoolManagement.Models;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public class ParentDAL
    {
        private readonly Common _common;

        public ParentDAL(Common common)
        {
            _common=common;
        }
        public List<ParentModel> GetAllParentsFromStudents()
        {
            List<ParentModel> parents = new List<ParentModel>();
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {

                parents = con.Query<ParentModel>("sp_GetAllParents", commandType: CommandType.StoredProcedure).ToList();
            }
            return parents;
        }

        //public int AddParent(ParentModel parent)
        //{
        //  using(SqlConnection con=new SqlConnection(_common.getConnection()))
        //    {
        //       var param= new DynamicParameters();
        //        param.Add("@FatherName", parent.FatherName);
        //        param.Add("@Gender", parent.Gender);
        //        param.Add("@Occupation", parent.Occupation);
        //        param.Add("@Address", parent.Address);
        //        param.Add("@MobileNo", parent.MobileNo);
        //        param.Add("@Email", parent.Email);
        //        param.Add("@Photo", parent.Photo);


        //        param.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);

        //        con.Execute("sp_AddParent", param, commandType: CommandType.StoredProcedure);

        //        return param.Get<int>("@ID");
        //    }
        //}

    }
}
