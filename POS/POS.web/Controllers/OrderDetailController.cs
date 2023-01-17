using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class OrderDetailController : Controller
    {
        readonly OrderDetailService _service;
        readonly ProductService _serviceProduct;
        readonly OrderService _serviceOrder;

        public OrderDetailController(ApplicationContext context) {
            _service = new OrderDetailService(context);
            _serviceProduct = new ProductService(context);
            _serviceOrder = new OrderService(context);
        }

        [HttpGet]
        public IActionResult GetAll() {
            var data = _service.GetOrderdetail();
            return View(data);
        }
        [HttpGet]
        public IActionResult Add() {
            ViewBag.Product = new SelectList(_serviceProduct.GetProduct(), "Id", "ProductName");
            ViewBag.Order = new SelectList(_serviceOrder.GetOrder(), "Id", "ShipName");
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            ViewBag.Product = new SelectList(_serviceProduct.GetProduct(), "Id", "ProductName");
            ViewBag.Order = new SelectList(_serviceOrder.GetOrder(), "Id", "ShipName");
            return PartialView("_Add");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var data = _service.RedOrderDetail(id);
            return View(data);    
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Product = new SelectList(_serviceProduct.GetProduct(), "Id", "ProductName");
            ViewBag.Order = new SelectList(_serviceOrder.GetOrder(), "Id", "ShipName");
            var data = _service.RedOrderDetail(id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteOrderDetail(id);
            return Redirect("/OrderDetail/GetAll");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("OrderId, ProductId, UnitPrice, Quantity,Discount")] OrderDetailModel model)
        {
            if (ModelState.IsValid)
            {
                _service.AddOrderDetails(new OrderDetails(model));
                return Redirect("GetAll");
            }
            return View("Add", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id,OrderId, ProductId, UnitPrice, Quantity,Discount")] OrderDetailModel model)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateOrderDetail(model);
                return Redirect("GetAll");
            }

            return View("Edit", model);
        }
    }
}
