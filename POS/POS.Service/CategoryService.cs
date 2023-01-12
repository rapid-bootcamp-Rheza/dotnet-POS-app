using POS.Repository;
using POS.ViewModel;

namespace POS.Service
{
    
    public class CategoryService
    {
        private CategoryModel convertModel(Category entity)
        {
            CategoryModel result = new CategoryModel();
            result.Id = entity.Id;
            result.CategoryName = entity.CategoryName;
            result.Description = entity.Description;

            return result;
        }

        private void convertEntity(CategoryModel model, Category entity)
        {
            entity.CategoryName = model.CategoryName;
            entity.Description = model.Description; 
        }
        private readonly ApplicationContext _context;
        public CategoryService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.categoryEntities.ToList();
        }

        public void AddCategory(Category newRequest)
        {
            _context.categoryEntities.Add(newRequest);

             _context.SaveChanges();
        }
        public CategoryModel ReadCategory(int? id)
        {
            
            var category = _context.categoryEntities.Find(id);
            return convertModel(category);
        }
        public void DeleteCategory(int? id)
        {
            var entity = _context.categoryEntities.Find(id);

            _context.categoryEntities.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(CategoryModel category)
        {
            var entity = _context.categoryEntities.Find(category.Id);
            convertEntity(category,entity);
            _context.categoryEntities.Update(entity);
            _context.SaveChanges();

        }

    }
}