using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 学生信息管理系统
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string str1 = comboBox1.Text.ToString();
            string str2 = textBox8.Text.ToString().Trim();
            if (str1 == "" || str2 == "")
            {
                MessageBox.Show("输入不能为空！");
                return;
            }

            string str = "select * from Students where " + str1 + "='" + str2 + "'";
            DBcon con = new DBcon();
            DataSet ds = con.GetDataSet(str, "Students");

            this.dataGridView1.DataSource = ds.Tables["Students"].DefaultView;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox8.Clear();
            this.dataGridView1.DataSource = "";
        }
    }
}
