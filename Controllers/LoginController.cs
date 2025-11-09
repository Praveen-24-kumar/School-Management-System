using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using Microsoft.AspNetCore.Http;
namespace SchoolManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginDAL _dal;
        public LoginController(LoginDAL dal)
        {
            _dal = dal;
        }
        public IActionResult Login()
        {
            return View();
        }


        //[HttpPost]
        //public IActionResult Login(LoginModel model)
        //{
        //    int result = _dal.GetLogin(model);

        //    if (result == 1)
        //    {
        //        HttpContext.Session.SetString("Username", model.Username);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Invalid Username or Password";
        //    }
        //    return View(model);


        //}





        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var user = _dal.GetLogin(model);

            if (user != null)
            {
                // ✅ Store info in Session
                //HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Name", user.Name);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid Username or Password";
                return View(model);
            }
        }









        // ✅ Logout Action
        public IActionResult Logout()
        {
            // clear session
            HttpContext.Session.Clear();

            // redirect back to login page
            return RedirectToAction("Login", "Login");
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

       


    }
}
