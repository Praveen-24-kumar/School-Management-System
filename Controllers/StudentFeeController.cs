using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class StudentFeeController : Controller

    {
        private readonly FeeDAL _dal;

        public StudentFeeController(FeeDAL dal)
        {
            _dal = dal;
        }
        public IActionResult StudentFeeList( string nameSearch,string classSearch)
        {
            var fee = _dal.GetAllStudentFee();
            if (!string.IsNullOrEmpty(nameSearch))
            {
                nameSearch = nameSearch.ToLower();
                fee = fee.
                    Where(f => f.Name.ToLower().ToString().Contains(nameSearch)).ToList();
            }
            if (!string.IsNullOrEmpty(classSearch))
            {
                fee = fee.Where(f => f.Class.ToString().Contains(classSearch)).ToList();
            }
            return View(fee);
        }

        [HttpGet]
        public IActionResult AddPayment(int? Id)
        {
            PaymentInfoModel payment = new PaymentInfoModel();
            payment = _dal.GetStudentFeeById(Id);
            return View(payment);
        }

        [HttpPost]
        public IActionResult SavePayment(PaymentInfoModel model)
        {
            _dal.SetStudentFee(model);
            return RedirectToAction("StudentFeeList");
        }

        public IActionResult DeleteFee(int Id)
        {
            _dal.DeleteFeeById(Id);
            return RedirectToAction("StudentFeeList");
        }
    }
}
