using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using static SchoolManagement.Models.TransportModel;

namespace SchoolManagement.Controllers
{
    public class TransportController : Controller
    {
        private readonly TransportDAL _dal;
        public TransportController(TransportDAL dal)
        {
            _dal = dal;
        }
        public IActionResult VechileTransport(int? Id)
        {
            var model = new TransportPageViewModel();
            model.Transport=_dal.GetTransportById(Id);
            model.TransportList = _dal.GetAllTransports();
            return View(model);
        }

        [HttpPost]
        public IActionResult save(TransportPageViewModel model)
        {
            _dal.SetTransport(model.Transport);
            return RedirectToAction("VechileTransport");
        }

        public IActionResult Delete(int Id)
        {           
            _dal.DeleteTransport(Id);
            return RedirectToAction("VechileTransport");
        }


    }
}
