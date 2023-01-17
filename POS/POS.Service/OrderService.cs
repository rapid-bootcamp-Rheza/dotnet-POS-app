using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class OrderService
    {
        public OrderModel EntityToModel(Orders entity)
        {
            OrderModel model= new OrderModel(); 
            model.Id= entity.Id;
            model.CustomerId= entity.CustomerId;
            model.EmployeeId= entity.EmployeeId;
            model.ShipperId= entity.ShipperId;
            model.OrderDate= entity.OrderDate;
            model.RequiredDate= entity.RequiredDate;
            model.ShippedDate = entity.ShippedDate;
            model.ShipVia= entity.ShipVia;
            model.Freight= entity.Freight;
            model.ShipName= entity.ShipName;
            model.ShipAddress= entity.ShipAddress;
            model.ShipCity= entity.ShipCity;
            model.ShipRegion= entity.ShipRegion;
            model.ShipPostalCode= entity.ShipPostalCode;
            model.Country= entity.Country;

            return model;
        }

        private void ModelToEntity(OrderModel model, Orders entity)
        {
            entity.CustomerId= model.CustomerId;
            entity.EmployeeId= model.EmployeeId;
            entity.ShipperId= model.ShipperId;
            entity.OrderDate= model.OrderDate;
            entity.RequiredDate= model.RequiredDate;
            entity.ShippedDate= model.ShippedDate;
            entity.ShipVia= model.ShipVia;
            entity.Freight= model.Freight;
            entity.ShipName= model.ShipName;
            entity.ShipAddress= model.ShipAddress;
            entity.ShipCity= model.ShipCity;
            entity.ShipRegion= model.ShipRegion;
            entity.ShipPostalCode= model.ShipPostalCode;
            entity.Country= model.Country;
        }
        private readonly ApplicationContext _context;

        public OrderService(ApplicationContext context)
        {
            _context = context;
        }
        public List<Orders> GetOrder()
        {
            return _context.ordersEntities.Include(a=>a.Customer).Include(b=> b.Employee).Include(c=>c.Shipper).ToList();
        }
        public void AddOrders(Orders order)
        {
            _context.ordersEntities.Add(order);
            _context.SaveChanges();
        }
        public OrderModel ReadOrder(int? id)
        {
            var order = _context.ordersEntities.Find(id);

            return EntityToModel(order);
        }
        public void DeleteOrder(int? id)
        {
            var entity = _context.ordersEntities.Find(id);

            _context.ordersEntities.Remove(entity);
            _context.SaveChanges();

        }

        public void UpdateOrder(OrderModel order)
        {
            var entity = _context.ordersEntities.Find(order.Id);

            ModelToEntity(order, entity);

            _context.ordersEntities.Update(entity);
            _context.SaveChanges();
        }
    }
}
