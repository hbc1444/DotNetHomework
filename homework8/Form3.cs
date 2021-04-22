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
    public partial class Form3 : Form
    {
        OrderDetails thisDetail = null;
        public Form3()
        {
            InitializeComponent();
            Goods book = new Goods("book", 5);
            Goods pen = new Goods("pen", 4);
            Goods pencil = new Goods("pencil", 6);
            
            goodsBindingSource.Add(book);
            goodsBindingSource.Add(pen);
            goodsBindingSource.Add(pencil);
        }
        public OrderDetails getThisDetail()
        {
            return thisDetail;
        }

        public Form3(OrderDetails orderDetail) : this()
        {
            detailBindingSource.DataSource = orderDetail;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (Goods x in goodsBindingSource)
            {
                if (((OrderDetails)detailBindingSource.Current).Goods != null && x.Name == ((OrderDetails)detailBindingSource.Current).Goods.Name)
                {
                    comboBox1.SelectedItem = x;
                }
            }
            textBox1.Text = ((OrderDetails)detailBindingSource.Current).Number.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                ((OrderDetails)detailBindingSource.Current).Number = int.Parse(textBox1.Text);
            }
        }

        //提交明细
        private void button1_Click(object sender, EventArgs e)
        {
            thisDetail = (OrderDetails)detailBindingSource.Current;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((OrderDetails)detailBindingSource.Current).Goods = (Goods)comboBox1.SelectedItem;
        }
    }
}
