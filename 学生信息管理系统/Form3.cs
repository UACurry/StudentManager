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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            DBcon Db = new DBcon();
            string str = "select * from Table_users";
            DataSet ds = Db.GetDataSet(str, "Table_users");
            this.dataGridView1.DataSource = ds.Tables["Table_users"].DefaultView; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //打开数据库并创建实例
                DBcon.GetCon();
                DBcon db = new DBcon();

                //选中项的列名
                string strcolumn = dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex].HeaderText;
                if (strcolumn == "id")
                {
                    MessageBox.Show("不能修改账号！", "提示");
                    return;
                }
                //选中项所在行的学号
                string strrow = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                //选中的值
                string value = dataGridView1.SelectedCells[0].Value.ToString();
                //更新语句
                string strcom = "update Table_users set " + strcolumn + "='" + value + "' where id = " + strrow;


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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //判断是否有信息可以删除
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("未选中或无可删除信息！");
                    return;
                }

                //删除选中的行
                if (MessageBox.Show("确定删除选中的行？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string str = "delete Table_users where id = '" + dataGridView1.SelectedRows[0].Cells["id"].Value + "'";
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }

            
        }
    }
}
