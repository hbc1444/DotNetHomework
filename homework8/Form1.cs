using OrderManage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework8
{
    public partial class Form1 : Form
    {
        OrderService orderService = new OrderService();
        public String QueryText { set; get; }//搜索输入内容
        public String QueryFactor { get; set; }//搜索条件选择
        public Form1()
        {
            InitializeComponent();

            Customer Tom = new Customer("Tom");
            Customer Bob = new Customer("Bob");

            Goods Book = new Goods("book", 10);
            Goods Pen = new Goods("pen", 8);
            Goods Pencil = new Goods("pencil", 5);

            OrderDetails orderDetail1 = new OrderDetails(5, Book);
            OrderDetails orderDetail2 = new OrderDetails(5, Pen);
            OrderDetails orderDetail3 = new OrderDetails(3, Pencil);
            List<OrderDetails> orderDetails1 = new List<OrderDetails>();
            orderDetails1.Add(orderDetail1);
            orderDetails1.Add(orderDetail2);
            
            Order order1 = new Order(1, Tom, orderDetails1);
            
            List<OrderDetails> orderDetails2 = new List<OrderDetails>();
            orderDetails2.Add(orderDetail2);
            orderDetails2.Add(orderDetail3);

            Order order2 = new Order(2, Bob, orderDetails2);

            orderService.Add(order1);
            orderService.Add(order2);

            orderBindingSource.DataSource = orderService.orderList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.DataBindings.Add("Text", this,"QueryText");

            String[] queryFactors = { "订单号", "客户名", "商品名" };
            comboBox1.DataSource = queryFactors;
            comboBox1.DataBindings.Add("SelectedItem", this, "QueryFactor");
        }


        //搜索按钮
        private void search_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                switch (comboBox1.SelectedItem)
                {
                    case ("订单号"):

                        orderBindingSource.DataSource = orderService.queryByOrderID(int.Parse(textBox1.Text));
                        orderBindingSource.ResetBindings(false);
                        break;
                    case ("客户名"):

                        orderBindingSource.DataSource = orderService.queryByCustomerName(textBox1.Text);
                        orderBindingSource.ResetBindings(false);
                        break;
                    case ("总金额"):
                        orderBindingSource.DataSource = orderService.queryByPrice(int.Parse(textBox1.Text));
                        orderBindingSource.ResetBindings(false);
                        break;

                }
            }
            else
            {
                orderBindingSource.DataSource = orderService.orderList;
                orderBindingSource.ResetBindings(false);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //detailBindingSource.DataSource = 
                string orderID1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                int id = int.Parse(orderID1);
                detailBindingSource.DataSource = orderService.queryByOrderID(id).details;
                detailBindingSource.ResetBindings(false);

            }
        }

        //添加订单
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(new Order());
            form2.ShowDialog();
            Order newOrder = form2.getThisOrder();
            newOrder.sumPrice();//计算一下总价格
            if (newOrder != null)
            {
                orderService.Add(newOrder);
                orderBindingSource.DataSource = orderService.orderList;
                orderBindingSource.ResetBindings(false);

            }
        }

        //修改订单
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2((Order)orderBindingSource.Current);
            form2.ShowDialog();
            orderBindingSource.DataSource = orderService.orderList;
            orderBindingSource.ResetBindings(false);
        }

        //删除订单
        private void button3_Click(object sender, EventArgs e)
        {
            Order o = (Order)orderBindingSource.Current;
            if (o != null)
            {
                orderService.Delete(o.OrderID);
                orderBindingSource.ResetBindings(false);
            }
        }
    }
}
