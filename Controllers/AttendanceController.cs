using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly AttendanceDAL _dal;

        public AttendanceController(AttendanceDAL dal)
        {
            _dal = dal;
        }

        [HttpGet]
        public IActionResult Attendance()
        {
            var model = new AttendanceViewModel
            {
                Classes = _dal.GetClasses(),
                Sections = _dal.GetSections(),
                Months = new List<string> { "January", "February", "March", "April", "May", "June",
                                            "July", "August", "September", "October", "November", "December" },
                Years = Enumerable.Range(2020, 10).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Attendance(AttendanceViewModel model)
        {
            model.Classes = _dal.GetClasses();
            model.Sections = _dal.GetSections();
            model.Months = new List<string> { "January", "February", "March", "April", "May", "June",
                                              "July", "August", "September", "October", "November", "December" };
            model.Years = Enumerable.Range(2020, 10).ToList();

            // Fetch Attendance for selected class/section
            model.StudentAttendances = _dal.GetAttendance(model.SelectedClass, model.SelectedSection, model.SelectedMonth, model.SelectedYear);

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveAttendance([FromBody] AttendanceEntry entry)
        {
            try
            {
                _dal.SaveAttendance(entry.StudentId, entry.Date, entry.IsPresent);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SaveBulkAttendance([FromBody] AttendanceBulkRequest request)
        {
            try
            {
                foreach (var entry in request.Entries)
                {
                    var date = new DateTime(request.Year, request.Month, entry.Day);
                    _dal.SaveAttendance(entry.StudentId, date, entry.IsPresent);
                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
