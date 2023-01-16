using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _service;

        public EmployeeController(ApplicationContext context)
        {
            _service = new EmployeeService(context);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetEmployee();
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
            var data = _service.ReadEmployee(id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var data = _service.ReadEmployee(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteEmployee(id);
            return Redirect("/Employee/GetAll");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("LastName, FirstName, Title, TittleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country,HomePhone, Extension, Notes, ReportTo")] EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                _service.AddEmployee(new Employees(model));
                return Redirect("GetAll");
            }
            return View("Add",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id,LastName, FirstName, Title, TittleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country,HomePhone, Extension, Notes, ReportTo")] EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateEmployee(model);
                return Redirect("GetAll");
            }

            return View("Edit", model);
        }
    }
}
