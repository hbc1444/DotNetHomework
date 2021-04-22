using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    public class OrderService
    {
        public List<Order> orderList = new List<Order>();


        public bool Add(Order order)
        //增加
        {
            if (order == null)
                throw new System.Exception();
            bool erised = false;
            foreach (Order item in orderList)
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
                        where od.details.Where(s => s.Goods.Name == goodsName) != null
                        orderby od.Price
                        select od;
            List<Order> list = query.ToList();
           
            return list;
           
        }
        
        //按照客户名查询
        public List<Order> queryByCustomerName(String cus)
        {
            var query = from od
                        in orderList
                        where od.Customer.Name.Equals(cus)
                        orderby od.Price
                        select od;
            List<Order> list = query.ToList();
            return list;
            //if (list.Count != 0)
            //{
            //    return list;
            //}
            //else
            //{
            //    throw new Exception();
            //}
        }


        //按照订单金额进行查询
        public List<Order> queryByPrice(int price)
        {
            var query = from od
                        in orderList
                        where od.Price == price
                        select od;
            List<Order> list = query.ToList();
            
            return list;
            
        }


        //按订单总金额排序
        public void sortLists()
        {
            if (orderList == null)
            {
                return;
            }
            orderList.Sort((o1, o2) => o1.Price.CompareTo(o2.Price));
        }

    }
}
