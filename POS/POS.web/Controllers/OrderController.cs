using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class OrderController : Controller
    {
         readonly OrderService _service;
        readonly ShipperService _serviceShipper;
        readonly CustomerService _serviceCustomer;
        readonly EmployeeService _serviceEmployee;

        public OrderController(ApplicationContext context)
        {
            _service = new OrderService(context);
            _serviceCustomer = new CustomerService(context);
            _serviceShipper = new ShipperService(context);
            _serviceEmployee = new EmployeeService(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetOrder();
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Customer = new SelectList(_serviceCustomer.GetCustomer(), "Id", "CustomerName");
            ViewBag.Employee = new SelectList(_serviceEmployee.GetEmployee(), "Id", "FirstName");
            ViewBag.Shipper = new SelectList(_serviceShipper.GetShipper(), "Id", "CompanyName");
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            ViewBag.Customer = new SelectList(_serviceCustomer.GetCustomer(), "Id", "CustomerName");
            ViewBag.Employee = new SelectList(_serviceEmployee.GetEmployee(), "Id", "FirstName");
            ViewBag.Shipper = new SelectList(_serviceShipper.GetShipper(), "Id", "CompanyName");
            return PartialView("_Add");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var data = _service.ReadOrder(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Customer = new SelectList(_serviceCustomer.GetCustomer(), "Id", "CustomerName");
            ViewBag.Employee = new SelectList(_serviceEmployee.GetEmployee(), "Id", "FirstName");
            ViewBag.Shipper = new SelectList(_serviceShipper.GetShipper(), "Id", "CompanyName");
            var data = _service.ReadOrder(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteOrder(id);
            return Redirect("/Order/GetAll");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(
            [Bind("CustomerId, EmployeeId, ShipperId, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, Country")] OrderModel model)
        {
            if (ModelState.IsValid)
            {
                _service.AddOrders(new Orders(model));
                return Redirect("GetAll");
            }

            return View("Add", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id,CustomerId, EmployeeId, ShipperId, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, Country")] OrderModel model)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateOrder(model);
                return Redirect("GetAll");
            }

            return View("Edit", model);
        }

    }
}
