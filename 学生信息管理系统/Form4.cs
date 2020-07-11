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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "select * from Students";
            DBcon con = new DBcon();
            DataSet ds = con.GetDataSet(str, "Students");
            this.dataGridView1.DataSource = ds.Tables["Students"].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBcon con = new DBcon();
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("请先输入要添加的信息！");
                return;
            }

            try
            {
                string str = "insert into Students values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                
                DBcon.GetCon();
                DBcon DB = new DBcon();
                DB.ExecuteUpdate(str);
                MessageBox.Show("插入成功！");                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
                
            }
            finally
            {
                con.Con_Close();
            }
       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //判断是否有信息可以删除
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("没有可删除信息！");
                return;
            }

            //删除选中的行
            if (MessageBox.Show("确定删除选中的行？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string str = "delete Students where 学号 = '" + dataGridView1.SelectedRows[0].Cells["学号"].Value + "'";
                DBcon db = new DBcon();
                DBcon.GetCon();
                db.ExecuteUpdate(str);
                MessageBox.Show("删除成功!");
            }
            else
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //打开数据库并创建实例
                DBcon.GetCon();
                DBcon db = new DBcon();

                //选中项的列名
                string strcolumn = dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex].HeaderText;
                //选中项所在行的学号
                string strrow = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                //选中的值
                string value = dataGridView1.SelectedCells[0].Value.ToString();
                //更新语句
                string strcom = "update Students set " + strcolumn + "='" + value + "' where 学号 = " + strrow;

                
                //更新操作
                db.ExecuteUpdate(strcom);
                MessageBox.Show("修改成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            finally
            {
                DBcon.sql_con.Close();
            }


        }
    }
}
