using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    public class Order
    {
        public int OrderID { get; set; }
        public int Price { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetails> details;

        public override bool Equals(object obj)
        {
            Order o = obj as Order;
            return o.OrderID == this.OrderID;
        }
        public Order(int id, Customer cust, List<OrderDetails> newDetails)
        {
            OrderID = id;
            Customer = cust;
            details = newDetails;
            sumPrice();
        }
        public Order()
        {

        }
        public void sumPrice()
        //更新订单总价格
        {
            this.Price = 0;
            foreach (OrderDetails x in details)
            {
                this.Price += x.Number * x.Goods.Price;
            }
        }
        public override string ToString()
        {
            string orderDetails = "";
            foreach (OrderDetails detail in details)
            {
                orderDetails = orderDetails + detail.ToString() + "\n";
            }
            return "ID:" + OrderID + " 客户:" + Customer.Name + " 订单总价：" + Price + "\n订单详细:\n" + orderDetails;
        }
    }
}
