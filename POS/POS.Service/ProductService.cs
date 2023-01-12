using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class ProductService
    {
        private ProductModel EntityToModel( Products entity)
        {
            ProductModel result = new ProductModel();
            result.Id = entity.Id;
            result.SupplierId = entity.SupplierId;
            result.CategoryId= entity.CategoryId;
            result.Quantity= entity.Quantity;
            result.UnitPrice= entity.UnitPrice;
            result.UnitStock= entity.UnitStock;
            result.UnitOrder= entity.UnitOrder;
            result.Reorder= entity.Reorder;
            result.Discontinued= entity.Discontinued;

            return result;
        }
        private void ModelToEntity(ProductModel model, Products entity)
        {
            entity.SupplierId = model.SupplierId;
            entity.CategoryId = model.CategoryId;
            entity.Quantity = model.Quantity;
            entity.UnitPrice = model.UnitPrice;
            entity.UnitStock = model.UnitStock;
            entity.UnitOrder = model.UnitOrder;
            entity.Reorder= model.Reorder;
            entity.Discontinued= model.Discontinued;
        }
        private readonly ApplicationContext _context;

        public ProductService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Products> GetProduct()
        {
            return _context.productsEntities.ToList();
        }

        public void AddProduct(Products newRequest)
        {
            _context.productsEntities.Add(newRequest);
            _context.SaveChanges();
        }

        public ProductModel ReadProduct(int? id)
        {
            var prod = _context.productsEntities.Find(id);
            return EntityToModel(prod);
        }
        public void DeleteProduct(int? id)
        {
            var data = _context.productsEntities.Find(id);

            _context.productsEntities.Remove(data);
            _context.SaveChanges();
        }

        public void UpdateProduct(ProductModel product)
        {
            var prod = _context.productsEntities.Find(product.Id);
            ModelToEntity(product, prod);
            _context.productsEntities.Update(prod);
            _context.SaveChanges();
        }
    }
}
