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
    public class OrderDetailService
    {
        private OrderDetailModel EntityToModel(OrderDetails entity)
        {
            OrderDetailModel res = new OrderDetailModel();
            res.Id = entity.Id;
            res.OrderId = entity.OrderId;
            res.ProductId = entity.ProductId;
            res.UnitPrice= entity.UnitPrice;
            res.Quantity = entity.Quantity;
            res.Discount= entity.Discount;
            return res;
        }

        private void ModelToEntity(OrderDetailModel model, OrderDetails entity)
        {
            entity.OrderId= model.OrderId;
            entity.ProductId= model.ProductId;
            entity.UnitPrice= model.UnitPrice;
            entity.Quantity= model.Quantity;
            entity.Discount= model.Discount;
        }

        private readonly ApplicationContext _context;

        public OrderDetailService(ApplicationContext context)
        {
            _context = context;
        }

        public List<OrderDetails> GetOrderdetail()
        {
            return _context.orderDetailsEntities.Include(a=> a.Product).Include(b=> b.Order).ToList();
        }

        public void AddOrderDetails(OrderDetails entity)
        {
            _context.orderDetailsEntities.Add(entity);
            _context.SaveChanges();
        }

        public OrderDetailModel RedOrderDetail(int?id)
        {
            var od = _context.orderDetailsEntities.Find(id);

            return EntityToModel(od);
        }

        public void DeleteOrderDetail(int? id)
        {
            var od = _context.orderDetailsEntities.Find(id);

            _context.orderDetailsEntities.Remove(od); 
            _context.SaveChanges();
        }

        public void UpdateOrderDetail(OrderDetailModel orderDetail)
        {
            var od = _context.orderDetailsEntities.Find(orderDetail.Id);

            ModelToEntity(orderDetail, od);

            _context.orderDetailsEntities.Update(od);
            _context.SaveChanges();
        }
    }
}
