using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生信息管理系统
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" )
            {
                MessageBox.Show("输入能为空", "提示");
                return;
            }
            if ( textBox3.Text != "1" && textBox3.Text != "2" && textBox3.Text != "3")
            {
                MessageBox.Show("权限等级只能为（1,2,3）", "提示");
                return;
            }

            DBcon DB = new DBcon();
            string str = "insert into Table_users values ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim()+ "')";
            try
            {
                DBcon.GetCon();     
                DB.ExecuteUpdate(str);
                MessageBox.Show("添加成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            finally
            {
                DB.Con_Close();
            }
            
        }
    }
}
