using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class TeacherController : Controller

        
    {
        private readonly TeacherDAL _dal;
        private readonly IWebHostEnvironment _env;

        public TeacherController(TeacherDAL dal,IWebHostEnvironment env)
        {
            _dal = dal;
            _env = env;
        }
        public IActionResult TeacherList()
        {
            var teachers=_dal.GetAllTeacher();

            return View(teachers);
        }

        [HttpGet]
        //public IActionResult AddTeacher(int? Id)
        //{
        //    AddTeacherModel teacher = new AddTeacherModel();
        //    teacher = _dal.GetTeacherById(Id);
        //    return View(teacher);
        //}
        public IActionResult AddTeacher(int? Id)
        {
            AddTeacherModel teacher = new AddTeacherModel();

            if (Id.HasValue)
            {
                teacher = _dal.GetTeacherById(Id);

                if (teacher == null)
                {
                    return NotFound(); // 🛡️ Prevents passing null to view
                }
            }

            return View(teacher);
        }


        [HttpPost]
        public async Task<IActionResult> AddTeacher(AddTeacherModel model)
        {

            if (model.Photo != null && model.Photo.Length > 0)
            {
                string folder = "TeacherImage/image";
                string fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo.FileName);
                string serverFolder = Path.Combine(_env.WebRootPath, folder);

                if (!Directory.Exists(serverFolder))
                    Directory.CreateDirectory(serverFolder);

                string fullPath = Path.Combine(serverFolder, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await model.Photo.CopyToAsync(stream);
                }

                model.PhotoPath = "/" + Path.Combine(folder, fileName).Replace("\\", "/");

            }
                _dal.AddorUpdateTeacher(model);
            return RedirectToAction("TeacherList");

            
        }

        public IActionResult Delete(int Id)
        {
            var result= _dal.DeleteTeacherById(Id);
            return RedirectToAction("TeacherList");
        }

        public IActionResult TeacherDetails(int Id)
        {
            var teacher = _dal.GetTeacherById(Id);
            return View(teacher);
        }
    }
}
