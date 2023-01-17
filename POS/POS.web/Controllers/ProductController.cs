using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class ProductController : Controller
    {
        //private readonly ProductService _service;
        readonly ProductService _service;
        readonly CategoryService _serviceCategory;
        readonly SupplierService _serviceSupplier;
        public ProductController(ApplicationContext context)
        {
            _service = new ProductService(context);
            _serviceCategory = new CategoryService(context);
            _serviceSupplier = new SupplierService(context);
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
            ViewBag.Categories = new SelectList(_serviceCategory.GetCategories(), "Id", "CategoryName");
            ViewBag.Supplier = new SelectList(_serviceSupplier.GetSupplier(), "Id", "CompanyName");
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            ViewBag.Categories = new SelectList(_serviceCategory.GetCategories(), "Id", "CategoryName");
            ViewBag.Supplier = new SelectList(_serviceSupplier.GetSupplier(), "Id", "CompanyName");

            return PartialView("_Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("ProductName, SupplierId, CategoryId, Quantity, UnitPrice, UnitStock, UnitOrder, Reorder, Discontinued")] ProductModel request)
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
            ViewBag.Categories = new SelectList(_serviceCategory.GetCategories(), "Id", "CategoryName");
            ViewBag.Supplier = new SelectList(_serviceSupplier.GetSupplier(), "Id", "CompanyName");

            var data = _service.ReadProduct(id);
            return View(data);
        }
        [HttpPost] 
        public IActionResult Update([Bind("Id,ProductName, SupplierId, CategoryId, Quantity, UnitPrice, UnitStock, UnitOrder, Reorder, Discontinued")] ProductModel request)
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
