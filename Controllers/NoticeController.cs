using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class NoticeController : Controller
    {
        private readonly NoticeDAL _dal;
        public NoticeController(NoticeDAL dal)
        {
            _dal = dal;
        }
        public IActionResult Notice(int? Id,string dataSearch)
        {
            var model = new NoticeBoardViewModel();
            model.NoticeForm=_dal.GetNoticeById(Id);
            model.NoticeList=_dal.GetNoticeList();
            if (!string.IsNullOrEmpty(dataSearch))
            {
                model.NoticeList = model.NoticeList
                    .Where(n => n.NoticeDate.ToString("dd/MM/yyyy")
            .Contains(dataSearch))
            .ToList();
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult save(NoticeBoardViewModel model)
        {
            // Always set server-side posting date
            model.NoticeForm.NoticeDate = DateTime.Now;

            _dal.SetNotice(model.NoticeForm);

            return RedirectToAction("Notice");
        }


        public IActionResult Delete(int Id)
        {
            _dal.DeleteNotice(Id);
            return RedirectToAction("Notice");
        }

        public IActionResult GetNoticeById(int? Id)
        {
            ModelNotice notice = new ModelNotice();
            notice = _dal.GetNoticeById(Id);
            return View(notice); // ✅ Fixed 'view' to 'View'
        }
    }
}
