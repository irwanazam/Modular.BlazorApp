using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Api.Orders.Domains
{
    public class Order
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }

        public Buyer Buyer { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        //public List<OrderItem> Items { get; set; }
        //public Payment Payment { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Paid,
        Shipped,
        Delivered,
        Canceled
    }
}
