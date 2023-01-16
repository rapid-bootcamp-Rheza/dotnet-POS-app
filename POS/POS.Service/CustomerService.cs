using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class CustomerService
    {
       public CustomerModel EntityToModel(Customers entity) 
        { 
            CustomerModel result = new CustomerModel();
            result.Id= entity.Id;
            result.CompanyName=entity.CompanyName;
            result.CustomerName = entity.CustomerName;
            result.ContactTitle = entity.ContactTitle;
            result.Address = entity.Address;
            result.City = entity.City;
            result.Region = entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country = entity.Country;
            result.Phone = entity.Phone;
            result.Fax = entity.Fax;

            return result;
        }

        private void ModelToEntity(CustomerModel model, Customers entity)
        {
           
            entity.CompanyName= model.CompanyName;
            entity.CustomerName= model.CustomerName;
            entity.ContactTitle= model.ContactTitle;
            entity.Address= model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.Phone = model.Phone;
            entity.Fax = model.Fax;
        }

        private readonly ApplicationContext _context;

        public CustomerService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Customers> GetCustomer()
        {
            return _context.customersEntities.ToList();
        }

        public void AddCustomer(Customers customers)
        {
            _context.customersEntities.Add(customers);
            _context.SaveChanges();
        }

        public CustomerModel ReadCustomer(int? id)
        {
            var customer = _context.customersEntities.Find(id);

            return EntityToModel(customer);
        }

        public void DeleteCustomer(int? id)
        {
            var entity = _context.customersEntities.Find(id);

            _context.customersEntities.Remove(entity);
            _context.SaveChanges();

        }

        public void UpdateCustomer(CustomerModel customer)
        {
            var entity = _context.customersEntities.Find(customer.Id);

            ModelToEntity(customer, entity);

            _context.customersEntities.Update(entity);
            _context.SaveChanges();
        }
    }
}
