using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _service;
        private readonly ShipperService _serviceShipper;
        private readonly CustomerService _serviceCustomer;
        private readonly EmployeeService _serviceEmployee;
        private readonly ProductService _serviceProduct;


        public OrderController(ApplicationContext context)
        {
            _service = new OrderService(context);
            _serviceCustomer = new CustomerService(context);
            _serviceShipper = new ShipperService(context);
            _serviceEmployee = new EmployeeService(context);
            _serviceProduct = new ProductService(context);
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
            ViewBag.Product = new SelectList(_serviceProduct.GetProduct(), "Id", "ProductName");
            return View();
        }

      /*  [HttpGet]
        public IActionResult AddModal()
        {
            ViewBag.Customer = new SelectList(_serviceCustomer.GetCustomer(), "Id", "CustomerName");
            ViewBag.Employee = new SelectList(_serviceEmployee.GetEmployee(), "Id", "FirstName");
            ViewBag.Shipper = new SelectList(_serviceShipper.GetShipper(), "Id", "CompanyName");
            ViewBag.Product = new SelectList(_serviceProduct.GetProduct(), "Id", "ProductName");
            return PartialView("_Add");
        }*/

        [HttpGet]
        public IActionResult Detail(int? id)
        {
            var data = _service.ReadOrderInvoice(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Customer = new SelectList(_serviceCustomer.GetCustomer(), "Id", "CustomerName");
            ViewBag.Employee = new SelectList(_serviceEmployee.GetEmployee(), "Id", "FirstName");
            ViewBag.Product = new SelectList(_serviceProduct.GetProduct(), "Id", "ProductName");
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
            [Bind("CustomerId, EmployeeId, ShipperId, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, Country, OrderDetail")] OrderModel model)
        {
            if (ModelState.IsValid)
            {
                _service.AddOrders(model);
                return Redirect("GetAll");
            }

            return View("Add", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id,CustomerId, EmployeeId, ShipperId, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, Country, OrderDetail")] OrderModel model)
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
