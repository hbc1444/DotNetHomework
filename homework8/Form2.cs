using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManage;

namespace homework8
{
    public partial class Form2 : Form
    {
        Order thisOrder = null;//保存结果
        
        public Form2()
        {
            InitializeComponent();
            Customer customer1 = new Customer("Tom");
            Customer customer2 = new Customer("Bob");

            Goods apple = new Goods("book", 5);
            Goods egg = new Goods("pen", 4);
            Goods milk = new Goods("pencil", 6);
            customerBindingSource.Add(customer1);
            customerBindingSource.Add(customer2);
            goodsBindingSource.Add(apple);
            goodsBindingSource.Add(egg);
            goodsBindingSource.Add(milk);

        }

        public Order getThisOrder()
        {
            return thisOrder;
        }

        public Form2(Order order) : this()
        {
            orderBindingSource.DataSource = order;
            detailsBindingSource.DataSource = order.details;
        }

        
        //保存订单
        private void button4_Click(object sender, EventArgs e)
        {
            thisOrder = (Order)orderBindingSource.Current;
            this.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
            foreach (Customer x in customerBindingSource)
            {
                if(((Order)orderBindingSource.Current).Customer!=null && x.Name== ((Order)orderBindingSource.Current).Customer.Name)
                {
                    comboBox1.SelectedItem = x;
                }
            }
            textBox1.Text = ((Order)orderBindingSource.Current).OrderID.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                ((Order)orderBindingSource.Current).OrderID = int.Parse(textBox1.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Order)orderBindingSource.Current).Customer = (Customer)comboBox1.SelectedItem;
        }

        //添加明细
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(new OrderDetails());
            form3.ShowDialog();
            OrderDetails newDetail = form3.getThisDetail();
            if (newDetail != null)
            {
                if (((Order)orderBindingSource.Current).details == null)
                {
                    ((Order)orderBindingSource.Current).details = new List<OrderDetails>();
                }
                ((Order)orderBindingSource.Current).details.Add(newDetail);
                detailsBindingSource.DataSource = ((Order)orderBindingSource.Current).details;
                detailsBindingSource.ResetBindings(false);


            }
        }

        //修改明细
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3((OrderDetails)detailsBindingSource.Current);
            form3.ShowDialog();
            detailsBindingSource.ResetBindings(false);
        }

        //删除明细
        private void button3_Click(object sender, EventArgs e)
        {
            OrderDetails o = (OrderDetails)detailsBindingSource.Current;
            if (o != null)
            {
                ((Order)orderBindingSource.Current).details.Remove(o);
                detailsBindingSource.DataSource = ((Order)orderBindingSource.Current).details;
                detailsBindingSource.ResetBindings(false);
            }
        }
    }
    
}
