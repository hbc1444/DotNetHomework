using System;
using System.Collections.Generic;
using System.Linq;


namespace homework5
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Customer Tom = new Customer("Tom");
            Goods book = new Goods("book", 10);
            OrderDetails orderDetails = new OrderDetails(5,book);
            List < OrderDetails > orderDetail1= new List<OrderDetails>();
            orderDetail1.Add(orderDetails);
            Order order1 = new Order(1000, Tom, orderDetail1);

            OrderService service = new OrderService();
            service.Add(order1);
            Order query1=service.queryByOrderID(1000);
            Console.Write(query1.ToString());
        }
    }
    class OrderService
    {
        private List<Order> orderList = new List<Order>();

        
        public bool Add(Order order)
        //增加
        {
            if (order == null)
                throw new System.Exception();
            bool erised = false;
            foreach(Order item in orderList)
            {
                if (item.Equals(order))
                {
                    erised = true;
                }
            }
            if (erised)
            {
                Console.WriteLine("该订单已存在");
                throw new System.Exception();
            }
            orderList.Add(order);
            return true;

        }
        public bool Delete(int id)
        //删除
        {
            bool isFind = false;
            Order order = null;
            foreach (var item in orderList)
            {
                if (item.OrderID == id)
                {
                    isFind = true;
                    order = item;
                }
            }

            if (!isFind)
                throw new System.Exception();
            orderList.Remove(order);
            return true;
        }

        public bool Update(int id, Order order)
        //修改
        {

            bool isFind = false;
            Order or = null;
            foreach (var item in orderList)
            {
                if (item.OrderID == id)
                {
                    isFind = true;
                    or = item;
                }
            }

            //var q = from o in orders where o.Id == id select o;

            if (!isFind)
            {
                Console.WriteLine("订单不存在。");
                throw new System.Exception();
            }
            if (order != null)
            {
                orderList.Remove(or);
                orderList.Add(order);
            }

            return true;
        }

        //按照订单号查询
        public Order queryByOrderID(int id)
        {
            var query = orderList.Where(od => od.OrderID == id);

            List<Order> list = query.ToList();
            if (list.Count != 0)
            {
                return list.FirstOrDefault();
            }
            else
            {
                throw new Exception();
            }
        }
        
        //按照商品名称查询
        public List<Order> queryByGoodsName(String goodsName)
        {
            var query = from od
                        in orderList
                        where od.details.Where(s => s.goods.Name == goodsName) != null
                        orderby od.Price
                        select od;
            List<Order> list = query.ToList();
            if (list.Count != 0)
            {
                return list;
            }
            else
            {
                throw new Exception();
            }
        }
        
        //按照客户查询
        public List<Order> queryByCustomer(Customer cus)
        {
            var query = from od
                        in orderList
                        where od.Customer.Equals(cus)
                        orderby od.Price
                        select od;
            List<Order> list = query.ToList();
            if(list.Count != 0)
            {
                return list;
            }
            else
            {
                throw new Exception();
            }
        } 


        //按照订单金额进行查询
        public List<Order> queryByPrice(int price)
        {
            var query = from od
                        in orderList
                        where od.Price == price
                        select od;
            List<Order> list = query.ToList();
            if (list.Count != 0)
            {
                return list;
            }
            else
            {
                throw new Exception();
            }
        }


        //按订单总金额排序
        public void sortLists()
        {
            if (orderList == null)
            {
                return;
            }
            orderList.Sort((o1, o2)=>o1.Price.CompareTo(o2.Price));
        } 

    }
    //订单类
    class Order
    {
        public int price;
        public Customer customer;
        public int OrderID { get; set; }
        public int Price { get => price; }
        public Customer Customer { get; set; }
        public List<OrderDetails> details;

        public override bool Equals(object obj)
        {
            Order o = obj as Order;
            return o.OrderID == this.OrderID;
        }
        public Order(int id,Customer cust,List<OrderDetails> newDetails)
        {
            OrderID = id;
            Customer = cust;
            details = newDetails;
            sumPrice();
        }
        public void sumPrice()
        //更新订单总价格
        {
            price = 0;
            foreach(OrderDetails x in details)
            {
                price += x.number * x.goods.Price;
            }
        }
        public override string ToString()
        {
            string orderDetails="";
            foreach (OrderDetails detail in details){
                orderDetails = orderDetails+detail.ToString()+"\n";
            }
            return "ID:"+OrderID+" 客户:"+Customer.Name+" 订单总价："+price+"\n订单详细:\n"+orderDetails;
        }
    }
    class OrderDetails//订单明细
    {
        public int number;
        public Goods goods;
        public int Number { get=>number; }
        //public Goods Goods { set; get; }
        public override string ToString()
        {
            return goods.Name + " 数量：" + number+" 单价："+goods.Price;
        }
        public override bool Equals(object obj)
        {
            OrderDetails or = obj as OrderDetails;
            return this.goods == or.goods && this.number == or.number;
        }
        public OrderDetails(int num,Goods good)
        {
            this.goods = good;
            this.number = num;

        }
    }
    class Goods
    {
        public String name;
        public int price;
        public String Name { get => name; }
        public int Price { get =>price; }
        public override string ToString()
        {
            return Name+" "+Price+"$";
        }
        public Goods(String name,int price)
        {
            this.name = name;
            this.price = price;
        }
    }
    class Customer
    {
        private String name;
        public String Name { get => name; }
        public override String ToString()
        {
            return "客户:"+Name;
        }
        public Customer(String name)
        {
            this.name = name;
        }
    }
}
