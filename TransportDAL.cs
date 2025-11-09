using Dapper;
using Microsoft.AspNetCore.Routing;
using SchoolManagement.Models;
using System.Data;
using System.Data.SqlClient;
using static SchoolManagement.Models.TransportModel;

namespace SchoolManagement
{
    public class TransportDAL
    {
        private readonly Common _common;

        public TransportDAL(Common common)
        {
            _common = common;   
        } 

        public int SetTransport(TransportModel vehicle)
        {
            int result = 0;

            using (SqlConnection con =new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@TransportId", vehicle.TransportId);
                param.Add("@RouteName", vehicle.RouteName);
                param.Add("@VehicleNo", vehicle.VehicleNo);
                param.Add("@DriverName", vehicle.DriverName);
                param.Add("@DriverLicense", vehicle.DriverLicense);
                param.Add("@ContactNumber", vehicle.ContactNumber);
                result= con.Query<int>("sp_AddOrUpdateTransport", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }

        public List<TransportModel> GetAllTransports()
        {
            TransportPageViewModel tran=new TransportPageViewModel();
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                tran.TransportList = conn.Query<TransportModel>("sp_GetAllTransports", commandType: CommandType.StoredProcedure).ToList();
            }
            return tran.TransportList;
        }

        public TransportModel GetTransportById(int? Id)
        {
            TransportModel trans =new TransportModel();
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param=new DynamicParameters();
                param.Add("@TransportId", Id);
                trans = con.Query<TransportModel>("sp_GetTransportById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return trans;
        }
        //public TransportModel DeleteById(int? Id)
        //{
        //    TransportModel transport = new TransportModel();
        //    using (SqlConnection con = new SqlConnection(_common.getConnection()))
        //    {
        //        var param = new DynamicParameters();
        //        param.Add("@TransportId", Id);
        //        transport= con.Query<TransportModel>("sp_DeleteTransport", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //    }
        //    return transport;
        //}



        public int DeleteTransport(int? id)
        {
            var result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@TransportId", id);
                result = con.Query<int>("sp_DeleteTransport", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            return result;
        }
    }
}
