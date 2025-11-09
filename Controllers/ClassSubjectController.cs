using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class ClassSubjectController : Controller
    {
        private readonly SubjectDAL _dal;

        public ClassSubjectController(SubjectDAL dal)
        {
            _dal = dal;
        }

        public IActionResult Index(int? id)
        {
            var model = new SubjectMaster();
            model.Subject = _dal.GetSubjectById(id);
            model.SubjectList = _dal.GetAllSubjects();
            return View(model);
        }

        [HttpGet]
        public IActionResult Save(int? id)
        {
            var model = new SubjectMaster();
            model.Subject = _dal.GetSubjectById(id);
            model.SubjectList = _dal.GetAllSubjects();
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Save(SubjectMaster model)
        {
             _dal.SetSubjects(model.Subject);
            return RedirectToAction("Index");
        }

        //public IActionResult Edit(int id)
        //{
        //    var subject = _dal.GetSubjectById(id);
        //    var data = new Tuple<SubjectModel, List<SubjectModel>>(subject, _dal.GetAllSubjects());
        //    return View("Index", data);
        //}

        public IActionResult Delete(int id)
        {
            _dal.DeleteSubject(id);
            return RedirectToAction("Index");
        }
    }
}
