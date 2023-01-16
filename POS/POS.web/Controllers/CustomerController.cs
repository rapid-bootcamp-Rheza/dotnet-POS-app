using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _service;

        public CustomerController(ApplicationContext context)
        {
            _service = new CustomerService(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetCustomer();
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
            var data = _service.ReadCustomer(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var data = _service.ReadCustomer(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteCustomer(id);
            return Redirect("/Customer/GetAll");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("CompanyName,CustomerName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                _service.AddCustomer(new Customers(model));
                return Redirect("GetAll");
            }

            return View("Add", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id,CompanyName,CustomerName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateCustomer(model);
                return Redirect("GetAll");
            }

            return View("Edit", model);
        }

    }
}
