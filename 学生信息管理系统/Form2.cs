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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void 重新登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.TopLevel = false;
            form5.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form5);
            form5.Show();
        }

        private void 学生信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.TopLevel = false;
            form4.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form4);
            form4.Show();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.TopLevel = false;
            form3.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form3);
            form3.Show();
        }
    }
}
