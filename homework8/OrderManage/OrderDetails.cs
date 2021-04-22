using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    public class OrderDetails//订单明细
    {
        public int Number { get; set; }
        public Goods Goods { get; set; }
        //public Goods Goods { set; get; }
        public override string ToString()
        {
            return Goods.Name + " 数量：" + Number + " 单价：" + Goods.Price;
        }
        public override bool Equals(object obj)
        {
            OrderDetails or = obj as OrderDetails;
            return this.Goods == or.Goods && this.Number == or.Number;
        }
        public OrderDetails()
        {

        }
        public OrderDetails(int num, Goods good)
        {
            this.Goods = good;
            this.Number = num;

        }
    }
}
