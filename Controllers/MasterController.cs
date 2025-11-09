using SchoolManagement;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class MasterController : Controller
    {
        private readonly MasterDAL _dal;
        public MasterController(MasterDAL dal)
        {
            _dal = dal;
        }
        public IActionResult UsersRoleList()
        {

            var model = _dal.GetAllRoles();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddUsersRole(int? id)
        {
            MasterModel model = new MasterModel();



            model = _dal.GetRoleById(id);
            if (model == null)
            {
                model = new MasterModel(); // fallback to empty model
            }


            return View(model);
        }

        [HttpPost]

        public IActionResult AddUsersRole(MasterModel model)
        {
            _dal.AddorUpdate(model);

            return RedirectToAction("UsersRoleList");
        }

        public IActionResult Delete(int id)
        {
            _dal.Delete(id);
            return RedirectToAction("UsersRoleList");
        }
    }
}
