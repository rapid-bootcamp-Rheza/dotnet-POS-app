using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;
        public ProductController(ApplicationContext context)
        {
            _service = new ProductService(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetProduct();
            return View(data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("SupplierId, CategoryId, Quantity, UnitPrice, UnitStock, UnitOrder, Reorder, Discontinued")] ProductModel request)
        {
            if (ModelState.IsValid)
            {
                _service.AddProduct(new Products (request));
                return Redirect("GetAll");
            }
            
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var data = _service.ReadProduct(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _service.ReadProduct(id);
            return View(data);
        }
        [HttpPost] 
        public IActionResult Update([Bind("Id,SupplierId, CategoryId, Quantity, UnitPrice, UnitStock, UnitOrder, Reorder, Discontinued")] ProductModel request)
        {
            if (ModelState.IsValid)
            {
               
                _service.UpdateProduct(request);
                return Redirect("GetAll");
            }
            return View("Edit", request);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteProduct(id);
            return Redirect("/Product/GetAll");
        }
    }
}
