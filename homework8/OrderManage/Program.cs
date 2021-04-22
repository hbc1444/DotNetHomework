using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Customer Tom = new Customer("Tom");
            Goods book = new Goods("book", 10);
            OrderDetails orderDetails = new OrderDetails(5, book);
            List<OrderDetails> orderDetail1 = new List<OrderDetails>();
            orderDetail1.Add(orderDetails);
            Order order1 = new Order(1000, Tom, orderDetail1);

            Customer Bob = new Customer("Bob");
            Goods Pen = new Goods("pen", 10);
            OrderDetails orderDetail2 = new OrderDetails(5, Pen);
            List<OrderDetails> orderDetails2 = new List<OrderDetails>();
            orderDetails2.Add(orderDetail2);
            Order order2 = new Order(2, Bob, orderDetails2);
            

            OrderService service = new OrderService();
            service.Add(order1);
            service.Add(order2);
            Order query1 = service.queryByOrderID(1000);
            Console.Write(query1.ToString());
            //Order query2 = service.queryByGoodsName("book");

            return;
        }
    }
}
