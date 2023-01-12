using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    

    public class SupplierService
    {
        private SupplierModel EntityToModel(Supplier entity)
        {
            SupplierModel result = new SupplierModel();
            result.Id = entity.Id;
            result.CompanyName = entity.CompanyName;
            result.ContactName = entity.ContactName;
            result.ContactTitle = entity.ContactTitle;
            result.Address = entity.Address;
            result.City = entity.City;
            result.Region = entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country = entity.Country;
            result.Phone = entity.Phone;
            result.Fax = entity.Fax;
            result.HomePage = entity.HomePage;

            return result;
        }

        private void ModelToEntity(SupplierModel model,Supplier entity)
        {
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactName;
            entity.ContactTitle = model.ContactTitle;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.Phone = model.Phone;
            entity.Fax = model.Fax;
            entity.HomePage = model.HomePage;

        }
           private readonly ApplicationContext _context;

        public SupplierService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Supplier> GetSupplier() 
        {
            return _context.supplierEntities.ToList();
        }

        public void AddSupplier(Supplier newRequest)
        {
            _context.supplierEntities.Add(newRequest);
            _context.SaveChanges();
        }

        public SupplierModel ReadSupplier(int? id)
        {
            var supplier = _context.supplierEntities.Find(id);
            return EntityToModel( supplier);
        }
        public void DeleteSupplier(int? id)
        {
            var data = _context.supplierEntities.Find(id);

            _context.supplierEntities.Remove(data);
            _context.SaveChanges();
        }

        public void UpdateSupplier(SupplierModel supp)
        {
            var supplier = _context.supplierEntities.Find(supp.Id);
            ModelToEntity(supp, supplier);
            _context.supplierEntities.Update(supplier);
            _context.SaveChanges();
        }
    }
}
