using Dapper;
using SchoolManagement.Models;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public class NoticeDAL
    {
        private readonly Common _common;
        public NoticeDAL(Common common)
        {
            _common = common;
        }

        public int SetNotice(ModelNotice notice)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param=new DynamicParameters();  
                param.Add("@NoticeId",notice.NoticeId);
                param.Add("@Title" ,notice.Title);
                param.Add("Details",notice.Details);
                param.Add("PostedBy", notice.PostedBy);
                param.Add("NoticeDate", notice.NoticeDate);

                result=con.Query<int>("AddorUpdateNotice", param,commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }

        public List<ModelNotice> GetNoticeList()
        {
            NoticeBoardViewModel notice =new NoticeBoardViewModel();
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
               notice.NoticeList = conn.Query<ModelNotice>("GetAllNotices", commandType: CommandType.StoredProcedure).ToList();

            }
            return notice.NoticeList;
        }
        public ModelNotice GetNoticeById(int? Id)
        {
            ModelNotice notice = new ModelNotice();
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                var param= new DynamicParameters();
                param.Add(@"NoticeId",Id);
                notice = conn.Query<ModelNotice>("GetNoticeById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return notice;
        }

        public int DeleteNotice(int? Id)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param=new DynamicParameters();
                param.Add("@NoticeId", Id); ;
                result=con.Query<int>("DeleteNotice",param, commandType: CommandType.StoredProcedure).FirstOrDefault();    
            }
            return result;
        }
    }
}
