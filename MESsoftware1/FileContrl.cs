using MySqlX.XDevAPI.Relational;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NopiHelper
{

    class Execl
    {

        #region 读取Excel数据
        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名，true是</param>
        /// <returns>返回的DataTable</returns>
        public static DataTable ExcelToDatatable(string fileName, string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
           
            IWorkbook workbook = null;
            int cellCount = 0;//列数
            int rowCount = 0;//行数
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read); ;
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                {
                    workbook = new XSSFWorkbook(fs);
                }
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                {
                    workbook = new HSSFWorkbook(fs);
                }
                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);//根据给定的sheet名称获取数据
                }
                else
                {
                    //也可以根据sheet编号来获取数据
                    sheet = workbook.GetSheetAt(0);//获取第几个sheet表（此处表示如果没有给定sheet名称，默认是第一个sheet表）  
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    cellCount = firstRow.LastCellNum; //第一行最后一个cell的编号 即总的列数
                    if (isFirstRowColumn)//如果第一行是标题行
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)//第一行列数循环
                        {
                            DataColumn column = new DataColumn(firstRow.GetCell(i).StringCellValue);//获取标题
                            data.Columns.Add(column);//添加列
                        }
                        startRow = sheet.FirstRowNum + 1;//1（即第二行，第一行0从开始）
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;//0
                    }
                    //最后一行的标号
                    rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)//循环遍历所有行
                    {
                        IRow row = sheet.GetRow(i);//第几行
                        if (row == null)
                        {
                            continue; //没有数据的行默认是null;
                        }
                        //将excel表每一行的数据添加到datatable的行中
                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                            {
                                dataRow[j] = row.GetCell(j).ToString();
                            }
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                fs.Close();
                return data;
            }
            catch (Exception ex)
            {
                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, ex.Message);
            }
            finally
            {
               
            }
            return data; 
        }

         public static void  DataTableToExcle(string fileName, DataTable dt,string sheetName)
        {

            //以文件流创建excel文件
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            try
            {
                //Offic2007以上
                IWorkbook workbook = new XSSFWorkbook();
                //Offic2007以下
                if (fileName.ToLower().EndsWith(".xls"))
                {
                    workbook = new HSSFWorkbook();
                }
                //创建一个sheet页

                ISheet sheet;
                if (sheetName!= null)
                {
                    sheet=workbook.CreateSheet(sheetName);
                }
                else
                {
                    sheet = workbook.CreateSheet("sheet1");
                }
               

                //创建第一行数据并将表头写进去
                IRow rowHead = sheet.CreateRow(0);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    rowHead.CreateCell(j).SetCellValue(dt.Columns[j].ColumnName);

                }

                //将数据逐行写入
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        row.CreateCell(j).SetCellValue(Convert.ToString(dt.Rows[i][j]));
                    }
                }
                workbook.Write(fs);
                //资源释放
               
            }
            catch (Exception)
            {

                throw;
            }
            finally
            { 
                fs.Close(); 
            }

        
         
        }

    }
    class Jason
    {
        public static T ParseJsonFile<T>(string fileName) where T : class
        {
            if (!File.Exists(fileName))
            {
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"不存在配置文件，请检查.\n【{fileName}】");
                return default(T);
            }
           // 
            string rdJson = File.ReadAllText(fileName, Encoding.UTF8);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(rdJson);
        }
        #endregion
    }

}