using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class EmployeeService
    {
        private EmployeeModel EntityToModel(Employees entity)
        {
            EmployeeModel r = new EmployeeModel();
            r.Id= entity.Id;
            r.FirstName=entity.FirstName;
            r.LastName=entity.LastName;
            r.Title=entity.Title;
            r.TittleOfCourtesy = entity.TittleOfCourtesy;
            r.BirthDate = entity.BirthDate;
            r.HireDate= entity.HireDate;    
            r.Address= entity.Address;
            r.City= entity.City;
            r.Region= entity.Region;
            r.PostalCode= entity.PostalCode;
            r.Country= entity.Country;
            r.HomePhone= entity.HomePhone;
            r.Extension= entity.Extension;
            r.Notes= entity.Notes;
            r.ReportTo= entity.ReportTo;

            return r;
        }

        private void ModelToEntity(EmployeeModel model , Employees entity)
        {
            
            entity.FirstName= model.FirstName;
            entity.LastName= model.LastName;
            entity.Title= model.Title;
            entity.TittleOfCourtesy = model.TittleOfCourtesy;
            entity.BirthDate= model.BirthDate;
            entity.HireDate= model.HireDate;
            entity.Address= model.Address;
            entity.City= model.City;
            entity.Region= model.Region;
            entity.PostalCode= model.PostalCode;
            entity.Country= model.Country;
            entity.HomePhone= model.HomePhone;
            entity.Extension= model.Extension;
            entity.Notes= model.Notes;
            entity.ReportTo= model.ReportTo;

        }

        private readonly ApplicationContext _context;

        public EmployeeService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Employees> GetEmployee()
        {
            return _context.employeeEntities.ToList();
        }

        public void AddEmployee(Employees employee)
        {
            _context.employeeEntities.Add(employee);
            _context.SaveChanges();
        }

        public EmployeeModel ReadEmployee(int? id)
        {
            var employee = _context.employeeEntities.Find(id);
            return EntityToModel(employee);
        }

        public void DeleteEmployee(int? id)
        {
            var entity = _context.employeeEntities.Find(id);

            _context.employeeEntities.Remove(entity);
            _context.SaveChanges();
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            var entity = _context.employeeEntities.Find(employee.Id);
            ModelToEntity(employee, entity);
            _context.employeeEntities.Update(entity);
            _context.SaveChanges();
        }
    }
}
