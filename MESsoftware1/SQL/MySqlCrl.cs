using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlPart.SQL
{
    public class MySqlCrl
    {
        /// <summary>
        /// Mysql ---如果上游的抽象类存在该函数，用override重写
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class SimpleDALMySql<T> where T : class, new()
        {
            public SqlSugarClient Db;

            /// <summary>
            /// 获取实例化对象
            /// </summary>
            /// <returns></returns>
            public static SimpleDALMySql<T> OpDB()
            {
                SimpleDALMySql<T> dbcontext_t = new SimpleDALMySql<T>();
                dbcontext_t.Db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = SqlPart.SugarSql.ConnectionString(),
                    DbType = SqlSugar.DbType.MySql,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                });
                return dbcontext_t;
            }

            protected SimpleDALMySql()
            {
                Db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = SqlPart.SugarSql.ConnectionString(),
                    DbType = SqlSugar.DbType.MySql,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                });
                //调式代码 用来打印SQL
                Db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    Console.WriteLine(sql + "\r\n" +
                        Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                    Console.WriteLine();
                };
            }
            public SimpleClient<T> CurrentDb
            {
                get
                {
                    return new SimpleClient<T>(Db);
                }
            }

            /// <summary>
            /// 获取所有
            /// </summary>
            /// <returns></returns>
            public virtual List<T> GetList()
            {
                return CurrentDb.GetList();
            }

            /// <summary>
            /// 根据表达式查询
            /// </summary>
            /// <returns></returns>
            public virtual List<T> GetList(Expression<Func<T, bool>> whereExpression)
            {
                return CurrentDb.GetList(whereExpression);
            }

            /// <summary>
            /// 根据表达式查询
            /// </summary>
            /// <returns></returns>
            public virtual T GetSingle(Expression<Func<T, bool>> whereExpression)
            {
                return CurrentDb.GetSingle(whereExpression);
            }

            /// <summary>
            /// 按条件查询出表格
            /// </summary>
            /// <param name="barcode"></param>
            /// <returns></returns>
            public virtual DataTable GetDataTable(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
            {
                if (whereExpression != null && orderByExpression != null)
                {
                    return CurrentDb.AsSugarClient().Queryable<T>().Where(whereExpression).OrderBy(orderByExpression, orderByType).ToDataTable();
                }
                else if (whereExpression != null)
                {
                    return CurrentDb.AsSugarClient().Queryable<T>().Where(whereExpression).ToDataTable();
                }
                else
                {
                    return CurrentDb.AsSugarClient().Queryable<T>().ToDataTable();
                }
            }

            /// <summary>
            /// 按条件查询List
            /// </summary>
            /// <param name="barcode"></param>
            /// <returns></returns>
            public virtual List<T> GetDataList(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
            {
                if (whereExpression != null)
                {
                    if (orderByExpression != null)
                    {
                        return CurrentDb.AsSugarClient().Queryable<T>().Where(whereExpression).OrderBy(orderByExpression, orderByType).ToList();
                    }
                    else
                    {
                        try
                        {
                            return CurrentDb.AsSugarClient().Queryable<T>().Where(whereExpression).ToList();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);

                        }
                        return null;
                    }
                }
                else
                {
                    return CurrentDb.AsSugarClient().Queryable<T>().ToList();
                }
            }
            /// <summary>
            /// 或者某一行，并以对象进行返回
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="barcode"></param>
            /// <returns></returns>
            public virtual T GetFirstObj(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Desc)
            {
                if (orderByExpression != null)
                {
                    return CurrentDb.AsSugarClient().Queryable<T>().Where(whereExpression).OrderBy(orderByExpression, orderByType).First();
                }
                else
                {
                    return CurrentDb.AsSugarClient().Queryable<T>().Where(whereExpression).First();
                }
            }

            /// <summary>
            /// 或者某一行，并以对象进行返回
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="barcode"></param>
            /// <returns></returns>
            public virtual T[] GetObjArray(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Desc)
            {
                if (orderByExpression != null)
                {
                    return CurrentDb.AsSugarClient().Queryable<T>().Where(whereExpression).OrderBy(orderByExpression, orderByType).ToArray();
                }
                else
                {
                    return CurrentDb.AsSugarClient().Queryable<T>().Where(whereExpression).ToArray();
                }
            }
            /// <summary>
            /// 根据主键查询
            /// </summary>
            /// <returns></returns>
            public virtual List<T> GetById(dynamic id)
            {
                return CurrentDb.GetById(id);
            }

            /// <summary>
            /// 根据主键删除
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public virtual bool Delete(dynamic id)
            {
                return CurrentDb.Delete(id);
            }

            public virtual bool DeleteById(dynamic id)
            {
                return CurrentDb.DeleteById(id);
            }
            /// <summary>
            /// 根据实体删除
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public virtual bool Delete(T data)
            {
                if (data == null)
                {
                    Console.WriteLine(string.Format("要删除的实体对象不能为空值！"));
                }
                return CurrentDb.Delete(data);
            }

            /// <summary>
            /// 根据主键删除
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public virtual bool Delete(dynamic[] ids)
            {
                if (ids.Count() <= 0)
                {
                    Console.WriteLine(string.Format("要删除的主键ids不能为空值！"));
                }
                return CurrentDb.AsDeleteable().In(ids).ExecuteCommand() > 0;
            }

            /// <summary>
            /// 根据表达式删除
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public virtual bool Delete(Expression<Func<T, bool>> whereExpression)
            {
                return CurrentDb.Delete(whereExpression);
            }

            /// <summary>
            /// 根据实体更新，实体需要有主键
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public bool Update(T obj)
            {
                if (obj == null)
                {
                    Console.WriteLine(string.Format("要更新的实体不能为空，必须带上主键！"));
                }
                return CurrentDb.Update(obj);
            }

            /// <summary>
            ///批量更新
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public virtual bool Update(List<T> objs)
            {
                if (objs.Count <= 0)
                {
                    Console.WriteLine(string.Format("要批量更新的实体不能为空，必须带上主键！"));
                    return false;
                }
                return CurrentDb.UpdateRange(objs);
            }

            /// <summary>
            ///批量更新，条件更新
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public virtual bool Update(Expression<Func<T, T>> columns, Expression<Func<T, bool>> whereExpression)
            {
                return CurrentDb.Update(columns, whereExpression);
            }

            /// <summary>
            /// 插入
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public virtual bool Insert(T obj)
            {
                return CurrentDb.Insert(obj);
            }


            /// <summary>
            /// 批量
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public virtual bool Insert(List<T> objs)
            {
                return CurrentDb.InsertRange(objs);
            }

            public virtual bool ExistAny(Expression<Func<T, bool>> whereExpression)
            {
                return CurrentDb.AsSugarClient().Queryable<T>().Any(whereExpression);
            }


            /// <summary>
            /// 根据表达式查询分页
            /// </summary>
            /// <returns></returns>
            public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel)
            {
                return CurrentDb.GetPageList(whereExpression, pageModel);
            }

            /// <summary>
            /// 根据表达式查询分页并排序
            /// </summary>
            /// <param name="whereExpression">it</param>
            /// <param name="pageModel"></param>
            /// <param name="orderByExpression">it=>it.id或者it=>new{it.id,it.name}</param>
            /// <param name="orderByType">OrderByType.Desc</param>
            /// <returns></returns>
            public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
            {
                return CurrentDb.GetPageList(whereExpression, pageModel, orderByExpression, orderByType);
            }
            public virtual DataTable GetPageDataTable(string selectItems, string where_expression, Dictionary<string, object> dictAddPara, string tableName, string tableNameAs, int pageIndex, int pageSize, out int totalNumber, out int totalPage, string orderfild = "")
            {
                DataTable dataTable = new DataTable(tableName);
                using (var db = SqlPart.SugarSql.GetInstance())
                {
                    if (!selectItems.Contains(orderfild)) { orderfild = ""; }
                    //var datax2 = CurrentDb.AsSugarClient().Queryable(tableName, tableNameAs).Where(where_expression).AddParameters(dictAddPara).Select(selectItems).OrderByIF(orderfild != "", orderfild);
                    //datax2.ToDataTablePage(0,2);

                    //int totalNumber=0;
                    totalNumber = 0;
                    totalPage = 0;
                    // var datab = CurrentDb.AsSugarClient().Queryable(tableName, tableNameAs).Where(where_expression).AddParameters(dictAddPara).Select(selectItems).OrderByIF(orderfild != "", orderfild).ToPageList(0, 2, ref totalNumber);
                    var datax = CurrentDb.AsSugarClient().Queryable(tableName, tableNameAs).Where(where_expression).AddParameters(dictAddPara).Select(selectItems).OrderByIF(orderfild != "", orderfild);
                    // var datax = db.Queryable(tableName, tableNameAs).Where(where_expression).AddParameters(dictAddPara).Select(selectItems).OrderByIF(orderfild != "", orderfild);
                    try
                    {

                        dataTable = datax.ToDataTablePage(pageIndex, pageSize, ref totalNumber, ref totalPage);
                    }
                    catch (Exception ex)
                    {//你可能忘记写@了};
                        Console.WriteLine(ex.Message);
                    }
                    return dataTable;
                }
            }
            public virtual DataTable FindTable(string selectItems, string where_expression, Dictionary<string, object> dictAddPara, string tableName, string tableNameAs, string orderfild = "")
            {
                DataTable dataTable = new DataTable(tableName);
                using (var db = SqlPart.SugarSql.GetInstance())
                {
                    if (!selectItems.Contains(orderfild)) { orderfild = ""; }
                    var datax = CurrentDb.AsSugarClient().Queryable(tableName, tableNameAs).Where(where_expression).AddParameters(dictAddPara).Select(selectItems).OrderByIF(orderfild != "", orderfild);
                    try
                    {
                        //datax.ToSql();
                        dataTable = datax.ToDataTable();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return dataTable;
                }
            }
            public virtual DataTable FindTable(string selectItems, string tableName, int limitCount, string orderfild = "")
            {
                if (!selectItems.Contains(orderfild)) { orderfild = ""; }
                //-------------------------------------------------------//
                DataTable dataTable = new DataTable(tableName);
                using (var db = SqlPart.SugarSql.GetInstance())
                {
                    try
                    {
                        var datax = CurrentDb.AsSugarClient().Queryable(tableName, "tb").Select(selectItems).OrderByIF(orderfild != "", orderfild).Take(limitCount);
                        //var datax = db.Queryable(tableName, "tb").Select(selectItems).OrderByIF(orderfild != "", orderfild).Take(limitCount);
                        dataTable = datax.ToDataTable();
                    }
                    catch (Exception ex)
                    {
                        //你可能忘记写@了};
                        Console.WriteLine(ex.Message);
                    }
                    return dataTable;
                }
            }

            /// <summary>
            /// 执行一些特殊的语句
            /// </summary>
            /// <param name="sql">SQL语句</param>
            /// <param name="trans">事务对象</param>
            public virtual int SqlExecute(string sql, Dictionary<string, object> dict)
            {
                List<SugarParameter> parameters = DictToList(dict);
                return CurrentDb.AsSugarClient().Ado.ExecuteCommand(sql, parameters);
            }
            /// <summary>
            /// 执行一些特殊的语句
            /// </summary>
            /// <param name="sql">SQL语句</param>
            /// <param name="trans">事务对象</param>
            public virtual int Tran(List<string> sqlCollection, List<Dictionary<string, object>> dictCollection)
            {
                var db = CurrentDb.AsSugarClient();
                //3 use try
                try
                {
                    db.Ado.BeginTran();
                    for (int i = 0; i < sqlCollection.Count; i++)
                    {
                        List<SugarParameter> parameters = DictToList(dictCollection[i]);
                        db.Ado.ExecuteCommand(sqlCollection[i], parameters);
                    }
                    db.Ado.CommitTran();
                }
                catch (Exception)
                {
                    db.Ado.RollbackTran();
                    throw;
                }
                return 0;
            }
            /// <summary>
            /// 字典转参数列表
            /// </summary>
            /// <param name="dict"></param>
            /// <returns></returns>
            private List<SugarParameter> DictToList(Dictionary<string, object> dict)
            {
                if (dict == null || dict.Count < 0) return null;
                List<SugarParameter> parameters = new List<SugarParameter>();
                for (int i = 0; dict != null && i < dict.Count; i++)
                {
                    KeyValuePair<string, object> keyValuePair = dict.ElementAt(i);
                    parameters.Add(new SugarParameter(keyValuePair.Key, keyValuePair.Value));
                }
                return parameters;
            }

            public virtual DataTable FindTable(string sql, Dictionary<string, object> dict)
            {
                List<SugarParameter> parameters = DictToList(dict);
                return CurrentDb.AsSugarClient().Ado.GetDataTable(sql, parameters);
            }
            //可以扩展更多方法
           
        }
    }
}
