using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class ShipperController : Controller
    {
        private readonly ShipperService _service;

        public ShipperController(ApplicationContext context)
        {
            _service = new ShipperService(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetShipper();
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("_Add");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var data = _service.ReadShipper(id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteShipper(id);
            return Redirect("/Shipper/GetAll");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var data = _service.ReadShipper(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("CompanyName,Phone")] ShipperModel model)
        {
            if (ModelState.IsValid)
            {
                _service.AddShipper(new Shippers (model));
                return Redirect("GetAll");
                
            }
            return View("Add", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, CompanyName, Phone")] ShipperModel model)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateShipper(model);
                return Redirect("GetAll");
            }

            return View("Edit", model);
        }
    }
}
