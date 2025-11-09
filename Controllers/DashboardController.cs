using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
//using SchoolManagement.DAL; // Your DAL to get dashboard data

namespace SchoolManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DashboardDAL _dal;

        public DashboardController(DashboardDAL dal)
        {
            _dal = dal;
        }

        public IActionResult Admin()
        {
            var model = _dal.GetDashboardData(); // Returns DashboardViewModel

            model.RecentActivities = new List<RecentActivityModel>
    {
        new RecentActivityModel {
            Date = DateTime.Now,
            Activity = "Student John submitted homework on time. Teacher reviewed and approved the submission. Another student completed extra credit assignment."
        },
        new RecentActivityModel {
            Date = DateTime.Now.AddMinutes(-30),
            Activity = "Parent meeting scheduled for next Monday. Discussion about exam preparation and attendance."
        }
    };
            return View(model);



        }

    }
}
