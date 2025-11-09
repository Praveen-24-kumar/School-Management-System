using Dapper;
using SchoolManagement.Models;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public class DashboardDAL
    {
        private readonly Common _common;

        public DashboardDAL(Common common)
        {
            _common = common;
        }
        public DashboardViewModel GetDashboardData()
        {
            var model = new DashboardViewModel();
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                model.TotalStudents = con.ExecuteScalar<int>("SELECT COUNT(*) FROM Student");
                model.TotalParents = con.ExecuteScalar<int>("SELECT COUNT(*) FROM Student");
                model.TotalTeachers = con.ExecuteScalar<int>("SELECT COUNT(*) FROM Teacher");
                model.TotalEarnings = con.ExecuteScalar<decimal>(
                    "SELECT ISNULL(SUM(Fees), 0) FROM StudentFees"
                );

                //// 2. Chart Data (last 7 months)
                //model.Collections = con.Query<decimal>(
                //    "SELECT ISNULL(SUM(Fees),0) FROM StudentFees WHERE MONTH(Fees)=@Month",
                //    new { Month = DateTime.Now.Month }).AsList();

                //model.Fees = con.Query<decimal>(
                //    "SELECT ISNULL(SUM(FeeAmount),0) FROM Account WHERE MONTH(PaidDate)=@Month",
                //    new { Month = DateTime.Now.Month }).AsList();

                //model.Expenses = con.Query<decimal>(
                //    "SELECT ISNULL(SUM(Amount),0) FROM Expenses WHERE MONTH(ExpenseDate)=@Month",
                //    new { Month = DateTime.Now.Month }).AsList();

                //3.Notices(latest 5)
                model.Notices = con.Query<ModelNotice>(
                    "SELECT TOP 5 NoticeDate, Title, Details, PostedBy FROM Notice ORDER BY NoticeDate DESC"
                ).AsList();

                // 4. Recent Activities (latest 5)
                //model.RecentActivities = con.Query<RecentActivityModel>(
                //    "SELECT TOP 5 ActivityDate AS Date, Activity FROM RecentActivities ORDER BY ActivityDate DESC"
                //).AsList();
            }
            return model;
        }


    }
}
