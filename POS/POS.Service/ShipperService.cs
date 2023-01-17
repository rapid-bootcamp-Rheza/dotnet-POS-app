using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class ShipperService
    {
        private ShipperModel EntityToModel( Shippers entity)
        {
            ShipperModel r = new ShipperModel();
            r.Id = entity.Id;
            r.CompanyName = entity.CompanyName;
            r.Phone = entity.Phone;
            return r;
        }
        private void ModelToEntity(ShipperModel model, Shippers entity )
        {
            entity.CompanyName= model.CompanyName;
            entity.Phone= model.Phone;
        }

        private readonly ApplicationContext _context;

        public ShipperService(ApplicationContext context )
        {
            _context = context;
        }

        public List<Shippers> GetShipper()
        {
            return _context.shipperEntities.ToList();
        }
        public void AddShipper(Shippers shipper)
        {
            _context.shipperEntities.Add(shipper);
            _context.SaveChanges();
        }
        public ShipperModel ReadShipper(int? id)
        {
            var ship = _context.shipperEntities.Find(id);
            return EntityToModel(ship);

        }
        public void DeleteShipper(int? id)
        {
            var data = _context.shipperEntities.Find(id);

            _context.shipperEntities.Remove(data);
            _context.SaveChanges();

        }
        public void UpdateShipper(ShipperModel model)
        {
            var ship = _context.shipperEntities.Find(model.Id);

            ModelToEntity(model, ship);
            _context.shipperEntities.Update(ship);
            _context.SaveChanges();
        }
    }
}
