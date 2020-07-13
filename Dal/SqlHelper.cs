using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class SqlHelper
    {
        //读取配置文件，创建链接字符串
        private static string conn = ConfigurationManager.ConnectionStrings["DLconnection"].ConnectionString;

        public static int ExecuteNonQuery(string sql,params SqlParameter[] parameter)
        {
            //创建数据库连接
            using (SqlConnection con=new SqlConnection(conn)) {

                //打开数据库
                con.Open();

                //创建执行数据库命令的对象
                SqlCommand cmd = con.CreateCommand();

                //执行sql语句
                cmd.CommandText = sql;

                //给sql语句传递参数
                cmd.Parameters.AddRange(parameter);

                //返回受影响的行数
                return cmd.ExecuteNonQuery();
            }
        }

        public static DataSet ExecuteDataSet(string sql, params SqlParameter[] parameter)
        {
            using (SqlConnection con=new SqlConnection(conn)) {
                con.Open();

                SqlCommand cmd = new SqlCommand(sql,con);

                cmd.Parameters.AddRange(parameter);

                SqlDataAdapter apter = new SqlDataAdapter();

                //创建DateSet集合
                DataSet dataset = new DataSet();

                //填充集合
                apter.Fill(dataset);

                return dataset;
            }
        }

        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameter)
        {
            using (SqlConnection con=new SqlConnection(conn)) {
                

                SqlCommand cmd = new SqlCommand(sql,con);

                if (parameter != null)
                {
                    cmd.Parameters.AddRange(parameter);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }

            
        }


        public static DataTable ExecuteDataTable(string sql ,params SqlParameter[] parameter)
        {
            //创建DataTable对象
            DataTable dt = new DataTable();
            using (SqlDataAdapter apter=new SqlDataAdapter(sql,conn))
            {
                if (parameter != null)
                {
                    apter.SelectCommand.Parameters.AddRange(parameter);
                }

                apter.Fill(dt);
            }

            return dt;
        }

        public static DataTable ExecuteDataTableTwo(string sql, params SqlParameter[] parameter)
        {
            //创建DataTable对象
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddRange(parameter);

                SqlDataAdapter apter = new SqlDataAdapter();

                //填充集合
                apter.Fill(dt);

                return dt;
            }
        }

        //执行查询一条数据(-----存储过程-----)
        public static DataTable pageDataTable(string sql, CommandType cmdType, params SqlParameter[] Parameters)
        {
            DataTable table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
            {

                adapter.SelectCommand.CommandType = cmdType;

                if (Parameters != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(Parameters);
                }
                adapter.Fill(table);
            }
            return table;
        }
    }
}
