using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class CategoryController : Controller
    {
        
        //private readonly ApplicationContext _context;
        private readonly CategoryService _service;
        public CategoryController(ApplicationContext context)
        {
            //_context = context;
            _service = new CategoryService(context);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var Data = _service.GetCategories();
            return View(Data);
        }

        [HttpGet]
       
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("CategoryName, Description")] CategoryModel request)
        {
             
            if (ModelState.IsValid)
            {
                _service.AddCategory(new Category(request));
                return Redirect("GetAll");
            }
            return View("Add", request);
            //return View();
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var data = _service.ReadCategory(id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var data = _service.ReadCategory(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, CategoryName, Description")] CategoryModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Update(request);
                return Redirect("GetAll");
            }
           return View("Edit", request);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteCategory(id);
            return Redirect("/Category/GetAll");
        }


    }
}
