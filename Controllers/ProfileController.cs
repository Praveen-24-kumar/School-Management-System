using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserDAL _dal;

        public ProfileController(UserDAL dal)
        {
            _dal = dal;
        }

        public IActionResult MyProfile()
        {
            

            return View();
        }
    }
}
