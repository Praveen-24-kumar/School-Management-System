using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class ExamScheduleController : Controller
    {
        private readonly ExamDAL _dal;  
        public ExamScheduleController(ExamDAL dal)
        {
            _dal = dal;
        }

        public IActionResult ExamSchedule(int? id,string classSearch)
        {
            var model = new ExamSchedulePageViewModel();
            model.Exam = _dal.GetExamScheduleById(id);
            model.ExamList = _dal.GetAllExamSchedules();
            if (!string.IsNullOrEmpty(classSearch))
            {
                model.ExamList = model.ExamList.
                    Where(e => e.Class.ToString().Contains(classSearch)).ToList();
            }
            return View(model);
        }

        //[HttpGet]
        //public IActionResult Save(int? id)
        //{
        //    var model = new ExamSchedulePageViewModel();
        //    model.Exam = _dal.GetExamScheduleById(id);
        //    model.ExamList = _dal.GetAllExamSchedules();
        //    return View("ExamSchedule", model);
        //}

        [HttpPost]
        public IActionResult Save(ExamSchedulePageViewModel model)
        {
            _dal.SetExam(model.Exam);
            return RedirectToAction("ExamSchedule");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _dal.DeleteExam(id);
            return RedirectToAction("ExamSchedule");
        }



    }
}
