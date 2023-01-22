using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.ViewModel;
using POS.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class OrderService
    {
        //Entity To Model
        public OrderModel ETMOrder(Orders entity)
        {
            var model= new OrderModel(); 
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
            model.OrderDetail = new List<OrderDetailModel>();
            foreach (var item in entity.OrderDetail)
            {
                model.OrderDetail.Add(ETMOrderDetail(item));
            }
            return model;
        }
        //Model To Entity

        private Orders MTEOrder(OrderModel model)
        {
            var entity = new Orders();
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
            entity.OrderDetail = new List<OrderDetails>();
            foreach (var item in model.OrderDetail)
            {
                entity.OrderDetail.Add(MTEOrderDetail(item));
            }

            return entity;
            
        }
        private OrderDetailModel ETMOrderDetail(OrderDetails entity)
        {
            var model = new OrderDetailModel();
            model.Id = entity.Id;
            model.ProductId = entity.ProductId;
            //model.OrderId = entity.OrderId;
            model.UnitPrice = entity.UnitPrice;
            model.Quantity = entity.Quantity;
            model.Discount= entity.Discount;

            return model;

        }

        private OrderDetails MTEOrderDetail(OrderDetailModel model)
        {
            var entity = new OrderDetails();
           
            entity.ProductId = model.ProductId;
            entity.OrderId = model.OrderId;
            entity.UnitPrice = model.UnitPrice;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;

            return entity;
        }

        private DetailOfOrderResponse ETMResponseDetail(Orders entity)
        {
            var Customer = _context.customersEntities.Find(entity.CustomerId);
            var Shipper = _context.shipperEntities.Find(entity.ShipperId);

            var response = new DetailOfOrderResponse();
            response.Id = entity.Id;
            response.CustomerId = Customer.Id;
            response.CustomerName = Customer.CustomerName;
            response.OrderDate = entity.OrderDate;
            response.RequiredDate = entity.RequiredDate;
            response.ShippedDate = entity.ShippedDate;
            response.ShipperId = Shipper.Id;
            response.ShipperName = Shipper.CompanyName;
            response.ShipperPhone = Shipper.Phone;
            response.Freight = entity.Freight;
            response.ShipName = entity.ShipName;
            response.ShipAddress = entity.ShipAddress;
            response.ShipCity = entity.ShipCity;
            response.ShipRegion = entity.ShipRegion;
            response.ShipPostalCode = entity.ShipPostalCode;
            response.Country = entity.Country;
            response.Details = new List<OrderDetailResponse>();

            foreach (var item in entity.OrderDetail)
            {
                response.Details.Add(ETMDetailResponse(item));
            }
            var subtotal = 0.0;
            foreach (var item in response.Details)
            {
                item.Subtotal = item.Quantity * item.UnitPrice * (1 - item.Discount / 100);
                subtotal += item.Subtotal;
            }

            response.SubTotal = subtotal;
            response.Tax = 0.1 * subtotal;
            response.Shipping = 0;
            response.Total = response.SubTotal + response.Tax + response.Shipping;

            return response;
        }

        private OrderDetailResponse ETMDetailResponse(OrderDetails entity)
        {
            var model = new OrderDetailResponse();
            var product = _context.productsEntities.Find(entity.ProductId);

            model.Id = entity.Id;
            model.ProductId = product.Id;
            model.ProductName = product.ProductName;
            model.UnitPrice = entity.UnitPrice;
            model.Quantity = entity.Quantity;
            model.Discount = entity.Discount;

            return model;
        }

             
        private readonly ApplicationContext _context;

        public OrderService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Orders> GetOrder()
        {
           // return _context.ordersEntities.Include(a=>a.Customer).Include(b=> b.Employee).Include(c=>c.Shipper).ToList();
           return _context.ordersEntities.ToList();
        }
        public void AddOrders(OrderModel order)
        {
            // _context.ordersEntities.Add(order);
            // _context.SaveChanges();

            var newData = MTEOrder(order);
            _context.ordersEntities.Add(newData);
            foreach (var item in newData.OrderDetail)
            {
                item.OrderId = order.Id;
                _context.orderDetailsEntities.Add(item);
            }
            _context.SaveChanges();
        }
        public OrderModel ReadOrder(int? id)
        {
            /*var order = _context.ordersEntities.Find(id);

            return ETMOrder(order);*/

            var order = _context.ordersEntities.Find(id);
            var details = _context.orderDetailsEntities.Where(x => x.OrderId == id);
            foreach (var item in details)
            {

            }
            return ETMOrder(order);
        }

        public DetailOfOrderResponse ReadOrderInvoice(int? id)
        {
            var orderEntity = _context.ordersEntities.Find(id);
            var detailEntity = _context.orderDetailsEntities.Where(x => x.OrderId == id).ToList();
            orderEntity.OrderDetail = detailEntity;
            var orderResponse = ETMResponseDetail(orderEntity);
            return orderResponse;
        }
        public void DeleteOrder(int? id)
        {
            //delete order
            var order = _context.ordersEntities.Find(id);
            _context.ordersEntities.Remove(order);

            var detail = _context.orderDetailsEntities.Where(xx => xx.Id == id);
            foreach (var item in detail)
            {
                _context.orderDetailsEntities.Remove(item);
            }
            
            _context.SaveChanges();

        }

        public void UpdateOrder(OrderModel order)
        {
          /*  var entity = _context.ordersEntities.Find(order.Id);

            MTEOrder(order, entity);


            _context.ordersEntities.Update(entity);
            _context.SaveChanges();*/
          //read fromd database
             var entityOrder = _context.ordersEntities.Find(order.Id);
            var orderDetailList = _context.orderDetailsEntities.Where(x => x.OrderId == order.Id).ToList();

            //convert model with updated data into entity
            var updateEntity = MTEOrder(order);

            //copy all property
            entityOrder.CustomerId = updateEntity.CustomerId;
            entityOrder.EmployeeId = updateEntity.EmployeeId;
            entityOrder.OrderDate = updateEntity.OrderDate;
            entityOrder.RequiredDate = updateEntity.RequiredDate;
            entityOrder.ShippedDate = updateEntity.ShippedDate;
            entityOrder.ShipperId = updateEntity.ShipperId;
            entityOrder.Freight = updateEntity.Freight;
            entityOrder.ShipName = updateEntity.ShipName;
            entityOrder.ShipAddress = updateEntity.ShipAddress;
            entityOrder.ShipCity = updateEntity.ShipCity;
            entityOrder.ShipRegion = updateEntity.ShipRegion;
            entityOrder.ShipPostalCode= updateEntity.ShipPostalCode;
            entityOrder.Country = updateEntity.Country;
            entityOrder.OrderDetail = updateEntity.OrderDetail;

            //update order entity

            _context.ordersEntities.Update(entityOrder);

            foreach (var newOrder in entityOrder.OrderDetail)
            {
                newOrder.OrderId = order.Id;
                foreach (var item in orderDetailList)
                {
                    if (newOrder.ProductId == item.ProductId)
                    {
                        item.ProductId = newOrder.ProductId;
                        item.UnitPrice = newOrder.UnitPrice;
                        item.Quantity = newOrder.Quantity;
                        item.Discount  = newOrder.Discount;

                        _context.orderDetailsEntities.Update(item);
                    }
                }
                
            }
            _context.SaveChanges();
        }
    }
}
