using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class ClassRoutineController : Controller
    {
        private readonly RoutineDLA _dal;
        public ClassRoutineController(RoutineDLA dal)
        {
            _dal = dal;
        }
        [HttpGet]
        public IActionResult ClassRoutine(string classSearch, int? id)
        {
            var model = new ClassRoutinePageViewModel();
            var allRoutines = _dal.GetAllRoutine();

            if (!string.IsNullOrEmpty(classSearch))
            {
                allRoutines = allRoutines
                    .Where(s => s.Class != null && s.Class.Contains(classSearch, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            model.RoutineList = allRoutines;
            model.Routine = id.HasValue ? _dal.GetRoutineById(id.Value) : null;
            ViewBag.ClassSearch = classSearch;

            return View(model);
        }


        [HttpGet]
        public IActionResult Save(int? id)
        {
            var model = new ClassRoutinePageViewModel();
            model.Routine = _dal.GetRoutineById(id);
            model.RoutineList = _dal.GetAllRoutine();
            return View("ClassRoutine", model);
        }

        [HttpPost]
        public IActionResult Save(ClassRoutinePageViewModel model)
        {
            
                _dal.SetRoutine(model.Routine);
                // Optional: TempData or ViewBag for success message
                return RedirectToAction("ClassRoutine");
           
        }

        public IActionResult Delete(int id)
        {
            _dal.DeleteRoutine(id);
            return RedirectToAction("ClassRoutine");
        }



    }
}
