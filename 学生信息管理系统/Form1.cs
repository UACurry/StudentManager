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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;



            string str = "data source = DESKTOP-8148TV5; database = student; integrated security = sspi";
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();

            //确定登录人员的权限等级
            string s = comboBox1.Text;
            if (s == "学生") { x = 1; }
            if (s == "教师") { x = 2; }
            if (s == "管理员") { x = 3; }
            

            //判断是否输入为空
            if ((comboBox1.Text == "") || (textBox1.Text == "") || textBox2.Text == "")
            {
                MessageBox.Show("输入不能为空！", "提示");
            }

            //判断帐号 密码 权限 是否相匹配
            String sqlCommand = "select id,password,power from Table_users where id='" + textBox1.Text + "' and password='" + textBox2.Text + "' and power='" + x + "' ";//SQL语句实现表数据的读取

            SqlCommand sqlCom = new SqlCommand(sqlCommand, sqlConnection);

            SqlDataReader sqlDataReader = sqlCom.ExecuteReader();



            switch (x)
            {
                //确定权限决定跳转哪个界面
                case 1:
                    {
                        if (sqlDataReader.HasRows)//判断帐号是否正确
                        {
                            Form2 form2 = new Form2();
                            form2.学生信息管理ToolStripMenuItem.Visible = false;
                            form2.用户管理ToolStripMenuItem.Visible = false;
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("请输入正确的密码", "提示");
                            textBox1.Clear();
                            textBox2.Clear();
                            return;
                        }
                        break;
                    }
                case 2:
                    {
                        if (sqlDataReader.HasRows)
                        {
                            Form2 form2 = new Form2();
                            this.Hide();
                            form2.用户管理ToolStripMenuItem.Visible = false;


                            form2.Show();
                        }
                        else
                        {
                            MessageBox.Show("请输入正确的密码", "提示");
                            textBox1.Clear();
                            textBox2.Clear();
                            return;
                        }
                        break;
                    }
                case 3:
                    {
                        if (sqlDataReader.HasRows)
                        {
                            Form2 form2 = new Form2();
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("请输入正确的密码", "提示");
                            textBox1.Clear();
                            textBox2.Clear();
                            return;
                        }
                        break;
                    }

            }
            sqlConnection.Close();
        }
    }
}
