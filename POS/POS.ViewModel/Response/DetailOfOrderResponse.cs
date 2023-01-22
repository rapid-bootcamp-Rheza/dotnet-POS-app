using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Response
{
    public class DetailOfOrderResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }

        public int ShipperId { get; set; }

        public string ShipperName { get; set; }
        public int ShipperPhone { get; set; }
        public int Freight { get; set; }

        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string  ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public int ShipPostalCode { get; set; }
        public string Country { get; set; }

        public List<OrderDetailResponse> Details { get; set; }

        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double Shipping { get; set; }
        public double Total { get; set; }

    }
}
