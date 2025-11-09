using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserDAL _dal;

        public UsersController(UserDAL dal)
        {
            _dal = dal;
        }
        public IActionResult UsersList()
        {
            var model = _dal.GetAllUsers();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddUsers(int? id)
        {
            UsersModel model = new UsersModel();
            model = _dal.GetUserById(id);

            return View(model);

        }

        [HttpPost]
        public IActionResult AddUsers(UsersModel model)
        {
            _dal.AddorUpdate(model);
            return RedirectToAction("UsersList");
        }

        public IActionResult Delete(int id)
        {
            _dal.Delete(id);
            return RedirectToAction("UsersList");
        }
    }
}
