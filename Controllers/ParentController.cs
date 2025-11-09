using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    public class ParentController : Controller
    {
        private readonly ParentDAL _dal;

        public ParentController(ParentDAL dal)
        {
            _dal = dal;
        }
        public IActionResult ParentDetails()
        {
            var parentList = _dal.GetAllParentsFromStudents();
            return View(parentList);
        }
    }
}
