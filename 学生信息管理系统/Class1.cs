using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace 学生信息管理系统
{
    class DBcon
    {
        //定义一个SqlConnection的公共变量,用于判断数据库是否连接成功
        public static SqlConnection sql_con;
        public static string str_sqlcon = "data source = DESKTOP-8148TV5; database = student; integrated security = sspi";

        //建立数据库连接
        public static SqlConnection GetCon()
        {
            sql_con = new SqlConnection(str_sqlcon);
            sql_con.Open();
            return sql_con; //返回SqlConnection对象的信息
        }
        public void Con_Close()
        {
            if (sql_con.State == ConnectionState.Open)
            {
                sql_con.Close();    //数据库连接关闭
                sql_con.Dispose();  //释放sql_con变量的所有空间
            }
        }

        //执行提供的sql语句，返回sqldatareader对象，获取指定表的信息
        public SqlDataReader ExecuteQuery(string SQLstr)
        {
            GetCon();   //打开数据库连接

            //创建SqlCommand对象，用于执行Sql语句
            SqlCommand sql_com = sql_con.CreateCommand();

            sql_com.CommandText = SQLstr;   //获取指定的SQL语句
            SqlDataReader sql_read = sql_com.ExecuteReader();   //执行sql语句，生成一个sqldatareader对象

            return sql_read;


        }

        //执行insert update delete等语句
        public void ExecuteUpdate(string SQLstr)
        {
            GetCon();//打开数据库
            SqlCommand Sql_Com = new SqlCommand(SQLstr, sql_con);//创建sqlcommand对象，用于执行sql语句
            Sql_Com.ExecuteNonQuery();//执行sql语句
            Sql_Com.Dispose();//释放所有空间
            Con_Close();//调用Con_Close方法，数据库连接关闭
        }

        //创建DataSet对象
        public DataSet GetDataSet(string SQLstr, string tableName)
        {
            GetCon();   //打开数据库连接

            //创建一个SqlDataAdapter对象，并获取指定数据表的信息
            SqlDataAdapter sqlData = new SqlDataAdapter(SQLstr, sql_con);
            //创建DataSet对象
            DataSet dataSet = new DataSet();
            sqlData.Fill(dataSet, tableName);

            Con_Close();//关闭数据库连接
            return dataSet; //返回dataset对象的信息

        }
    }
}
