using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    public class Goods
    {
        
    
        public String Name { set; get; }
        public int Price { set; get; }
        public override string ToString()
        {
            return Name + " " + Price + "$";
        }
        public Goods(String name, int price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
