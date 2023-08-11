using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SqlPart
{

    public class SugarSql
    {
        public static string ConnectionString(int index = 1)
        {
            string reval = System.Configuration.ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
         
            return reval;
        }
        public static SqlSugarClient GetInstance(SqlSugar.DbType dbType = SqlSugar.DbType.MySql, int index = 1)
        {
            return new SqlSugarClient(new ConnectionConfig()
            {
                DbType = dbType,
                ConnectionString = ConnectionString(index),
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true,
                AopEvents = new AopEvents
                {
                    OnLogExecuting = (sql, p) =>
                    {
                        Console.WriteLine(sql);
                        Console.WriteLine(string.Join(",", p?.Select(it => it.ParameterName + ":" + it.Value)));
                    }
                }
            });
        }
        public static bool CheckConnect()
        {
            SqlSugarClient db = GetInstance();
            string connectionString = db.CurrentConnectionConfig.ConnectionString;//连接字符串
            try
            {
                db.Open();
                LogSerilog.SerilogHelper._SystemLogger.Information($"连接mysql数据库成功.连接字符串【{connectionString}】");
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"连接mysql数据库失败，【{ex.Message}】.连接字符串【{connectionString}】", "出错");
                LogSerilog.SerilogHelper._SystemLogger.Error($"连接mysql数据库失败，【{ex.Message}】.连接字符串【{connectionString}】", "出错");
                return false;
            }
            finally
            {
                db.Close();
            }
        }

    }
}
