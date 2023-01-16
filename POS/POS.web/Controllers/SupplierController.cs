using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierService _service;
        public SupplierController(ApplicationContext context)
        {
            _service = new SupplierService(context);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetSupplier();
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
            var data = _service.ReadSupplier(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var data = _service.ReadSupplier(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteSupplier(id);
            return Redirect("/Supplier/GetAll");
        }
        [HttpPost]
        public IActionResult Save([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage")] SupplierModel request)
        {
            if (ModelState.IsValid)
            {
                _service.AddSupplier(new Supplier(request));
                return Redirect("GetAll");
            }
            return View("Add");
        }
        [HttpPost]
        public IActionResult Update([Bind("Id, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage")] SupplierModel request)
        {
            if (ModelState.IsValid)
            {
               
               _service.UpdateSupplier(request);
                return Redirect("GetAll");
            }
            return View("Edit", request);
          
        }
    }
}
