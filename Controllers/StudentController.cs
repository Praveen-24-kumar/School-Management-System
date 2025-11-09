using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly DAL _dal;
        private readonly IWebHostEnvironment _env;

        public StudentController(DAL dal, IWebHostEnvironment env)
        {
            _dal = dal;
            _env = env;
        }

        public IActionResult StudentList(string rollSearch, string classSearch)
        {
            var students = _dal.GetAllStudents();
            if (!string.IsNullOrEmpty(rollSearch))
            {
                students = students
                    .Where(s => s.Roll.ToString().Contains(rollSearch))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(classSearch))
            {
                students = students
                    .Where(s => s.Class != null && s.Class.Contains(classSearch, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            return View(students);
        }

        [HttpGet]
        public IActionResult Add(int? id)
        {
            AddStudentModel student = new AddStudentModel();
            if (id.HasValue)
                student = _dal.GetAddStudentById(id);

            if (student == null)
            {
                student = new AddStudentModel();
            }
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentModel model)
        {
            // Upload Student Photo
            if (model.StudentPhoto != null && model.StudentPhoto.Length > 0)
            {
                string folder = "StudentImage/image";
                string fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.StudentPhoto.FileName);
                string serverFolder = Path.Combine(_env.WebRootPath, folder);

                if (!Directory.Exists(serverFolder))
                    Directory.CreateDirectory(serverFolder);

                string fullPath = Path.Combine(serverFolder, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await model.StudentPhoto.CopyToAsync(stream);
                }

                model.StudentPhotoPath = "/" + folder + "/" + fileName;
            }

            // Upload Parent Photo
            if (model.ParentPhoto != null && model.ParentPhoto.Length > 0)
            {
                string folder = "ParentImage/image";
                string fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ParentPhoto.FileName);
                string serverFolder = Path.Combine(_env.WebRootPath, folder);

                if (!Directory.Exists(serverFolder))
                    Directory.CreateDirectory(serverFolder);

                string fullPath = Path.Combine(serverFolder, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await model.ParentPhoto.CopyToAsync(stream);
                }

                model.ParentPhotoPath = "/" + folder + "/" + fileName;
            }
           

            // Save to DB
            _dal.SetStudent(model);

            return RedirectToAction("StudentList");
        }






        public IActionResult Details(int id)
        {
            var student = _dal.GetAddStudentById(id);
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            _dal.DeleteStudentById(id);
            return RedirectToAction("StudentList");
        }


        [HttpGet]
        public IActionResult GetNextRoll(int classNumber)
        {
            var students = _dal.GetAllStudents()
                               .Where(s => s.Class == classNumber.ToString())
                               .ToList();

            int nextRoll = 1;
            if (students.Any())
            {
                int maxRoll = students.Max(s => s.Roll);
                nextRoll = maxRoll + 1;
            }

            return Json(new { roll = nextRoll });
        }


        [HttpGet]
        public IActionResult GetNextAdmissionNo(string className)
        {
            // Get all students in this class
            var students = _dal.GetAllStudents()
                               .Where(s => s.Class == className)
                               .ToList();

            // Extract last sequence numbers safely
            var lastAdmissionNumbers = students
                .Select(s => s.AdmissionNo)
                .Where(x => !string.IsNullOrEmpty(x) && x.Length >= 3) // ensure length
                .Select(x =>
                {
                    int num = 0;
                    // Try parsing last 3 digits
                    int.TryParse(x.Substring(x.Length - 3), out num);
                    return num;
                });

            int nextSeq = lastAdmissionNumbers.Any() ? lastAdmissionNumbers.Max() + 1 : 1;

            // Format admission number
            string year = DateTime.Now.ToString("yy");  // e.g., 22
            string admissionNo = $"R{year}{className}CA{nextSeq:000}";

            return Json(new { admissionNo });
        }


    }
}
