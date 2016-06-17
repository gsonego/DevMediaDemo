using System.Collections.Generic;
using System.Web.Http;

namespace DevMediaApi.Controllers
{
    [Authorize]
    public class OrdersController : ApiController
    {
        public IHttpActionResult GetOrders()
        {
            var list = new List<Order>
            {
                new Order {OrderId = 1, Number = 123, Customer = "ABCDEF", Ammout = 123.56M},
                new Order {OrderId = 2, Number = 345, Customer = "ZUADES", Ammout = 456.78M},
                new Order {OrderId = 3, Number = 678, Customer = "KUJGTD", Ammout = 789.00M}
            };

            return Ok(list);
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int Number { get; set; }
        public string Customer { get; set; }
        public decimal Ammout { get; set; }
    }
}
