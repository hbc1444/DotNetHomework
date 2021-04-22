using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    public class Customer
    {
        public String Name { get; set; }
        public override String ToString()
        {
            return "客户:" + Name;
        }
        public Customer(String name)
        {
            this.Name = name;
        }
        
    }
}
