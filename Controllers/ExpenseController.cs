    using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseDAL _dal;

        public ExpenseController(ExpenseDAL dal)
        {   
            _dal = dal;
        }
        public IActionResult ExpenseList()
        {
            var result=_dal.GetExpenseList();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddExpense(int? Id)
        {
            ExpenseModel exp = new ExpenseModel();
           exp=_dal.GetExpeseById(Id);
            return View(exp);
        }
        [HttpPost]
        public IActionResult AddExpense(ExpenseModel model)
        {
            _dal.SetExpense(model);
            return RedirectToAction("ExpenseList");
        }
    }
}
