using ConfigInfomation;
using LogSerilog;
using MySqlX.XDevAPI.Common;
using NPOI.OpenXmlFormats.Dml;
using NPOI.POIFS.NIO;
using NPOI.SS.Formula.Functions;
using ProcessPLC;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace MESsoftware1
{
    public partial class Form_Variable : Form
    {
        public static bool isShown;
        public static Sunny.UI.UIDataGridView dataGridView;
        private List<string> CanChangedValue=new List<string>();
        public static Thread RealTime = new Thread(ShowRealTimeValue);
        DataTable dtConfig = new DataTable();
        public Form_Variable()
        {
            InitializeComponent();
           // Btn_Save.Enabled = false;
            // Console.WriteLine(str);
            isShown = false;
            dataGridView = DGV_PLCVariableMap;
            loadExcel();
            Btn_Save.Enabled = true;
            Btn_CloseMonitor.Enabled = false;
        }

        private  void Btn_Show_Click(object sender, EventArgs e)
        {
            if(! ProcessPLC.PlcOperator.PlcConnectStatus)
            {
                MessageBox.Show("未检测到与PLC连接，请检查网络或PLC配置");
                return;
            }
            //Btn_Save.Enabled = true;
            isShown = true;
            Btn_Save.Enabled = false;
            Btn_CloseMonitor.Enabled = true;
            Btn_Show.Enabled=false;
            if (RealTime.IsAlive)
            {
                Console.WriteLine("Running");
                return;
            }
            RealTime.Start();
            RealTime.IsBackground = true;

        }
        private static  void ShowRealTimeValue()
        {

            while (true)
            {
              
                try
                {
                    if (isShown&&ProcessPLC.PlcOperator.PlcConnectStatus && DataSignalAddressUtil.DataSignalAddressConfigList.Count > 0 && dataGridView.Rows.Count > 0 && dataGridView.Columns.Count > 8)
                    {

                        foreach (var rv in DataSignalAddressUtil.DataSignalAddressConfigList)
                        {
                            if (dataGridView.Rows.Count >= 0)
                            {
                                if (rv.DataType == PlcDataType.Int)
                                {

                                    short integrate;
                                    PlcOperator.ReadValueByConfig(rv, out integrate);
                                    dataGridView.BeginInvoke(new Action(() => dataGridView.Rows[rv.Sequence - 1].Cells[8].Value = integrate.ToString()));
                                }
                                if (rv.DataType == PlcDataType.String)
                                {
                                    string str = string.Empty;
                                    PlcOperator.ReadValueByConfig(rv, out str);
                                   dataGridView.BeginInvoke(new Action(()=> dataGridView.Rows[rv.Sequence - 1].Cells[8].Value = str.ToString().Replace("\0", string.Empty)));
                                }
                                if (rv.DataType == PlcDataType.Real)
                                {
                                    float f1oat;
                                    PlcOperator.ReadValueByConfig(rv, out f1oat);
                                    dataGridView.BeginInvoke(new Action(() => dataGridView.Rows[rv.Sequence - 1].Cells[8].Value = f1oat.ToString()));
                                }
                            }
                            else
                            {
                                continue;
                            }
                           
                        }

                    }
                    else if(isShown && dataGridView.Rows.Count > 0 && dataGridView.Columns.Count > 8)
                    {
                        foreach(var rv in DataSignalAddressUtil.DataSignalAddressConfigList)
                        {
                            if(dataGridView.Rows.Count>=0)
                            {
                                 dataGridView.BeginInvoke(new Action(()=> dataGridView.Rows[rv.Sequence - 1].Cells[8].Value = "DisConnected"));
                               
                            }
                            else
                            {
                                continue;
                            }
                           // dataGridView.BeginInvoke(new Action(() => dataGridView.Rows[rv.Sequence -1].Cells[8].Value = "DisConnect"));
                         
                        }
                    }
                }
                catch (Exception ex)
                {
                  //  if(ex.Message!=)
                    SerilogHelper.RuntimeErrorAsync(ex, $"显示实时值异常,{ex.Message}");
                }

                Thread.Sleep(100);

            }
        }
        private async void  loadExcel()
        {
          
            try
            {
                await Task.Run(() =>
                {
                    string fileName = AppDomain.CurrentDomain.BaseDirectory + "Excel\\PlcData.xlsx";
                    dtConfig = NopiHelper.Execl.ExcelToDatatable(fileName, "Sheet1", true);
                    DGV_PLCVariableMap.BeginInvoke(new Action(() => { DGV_PLCVariableMap.DataSource = dtConfig.Copy();  }));
                 
                  //  Console.WriteLine("1111");
                    

                });
                for (int i = 0; i < DGV_PLCVariableMap.Columns.Count; i++)
                {
                    if (i == 4 || i == 5)
                    {
                        DGV_PLCVariableMap.Columns[i].ReadOnly = false;
                        for(int j = 0;j<DGV_PLCVariableMap.RowCount;j++)
                        {

                            CanChangedValue.Add("序号:["+DGV_PLCVariableMap.Rows[j].Cells[0].Value.ToString()+"]["+DGV_PLCVariableMap.Columns[i].Name.ToString()+"](" +DGV_PLCVariableMap.Rows[j].Cells[i].Value.ToString()+") ");
                        }
                        continue;
                    }

                    DGV_PLCVariableMap.Columns[i].ReadOnly = true;
                }
               
                  
                
            }
            catch (Exception ex)
            {

                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, ex.Message);
            }
           
          
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
           DialogResult ret= MessageBox.Show("即将修改PLC变量表", "notify", MessageBoxButtons.OKCancel);
            if (ret != DialogResult.OK)
            {
                return;
            }
            if(!ExtensionGlobalUtil.LoggingStatus)
            {
                MessageBox.Show("检测到未存在登录用户,请重新登录后再进行操作");
                return;
            }
            if (ProcessPLC.PlcOperator.PlcConnectStatus)
            {
                MessageBox.Show("处于运行状态，请停止运行进行操作");
                return;
            }
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "Excel\\PlcData.xlsx";
            try
            {

                NopiHelper.Execl.DataTableToExcle(fileName, (DataTable)DGV_PLCVariableMap.DataSource, "Sheet1");
                // DataTable tdt = (DataTable)DGV_PLCVariableMap.DataSource;
                List<string> tempList = new List<string>();
                string str = "";
                for (int i = 0; i < DGV_PLCVariableMap.Columns.Count; i++)
                {
                    if (i == 4 || i == 5)
                    {
                        for (int j = 0; j < DGV_PLCVariableMap.RowCount; j++)
                        {

                            tempList.Add("序号:[" + DGV_PLCVariableMap.Rows[j].Cells[0].Value.ToString() + "][" + DGV_PLCVariableMap.Columns[i].Name.ToString() + "](" + DGV_PLCVariableMap.Rows[j].Cells[i].Value.ToString() + ") ");
                        }
                        continue;
                    }
                }
                for (int i = 0;i <tempList.Count; i++)
                {
                    if (tempList[i].ToString() != CanChangedValue[i] . ToString())
                    {
                        str += "{【" + CanChangedValue[i] +"】=>【" + tempList[i] + "】}";
                    }
                }
                CanChangedValue.Clear();
                CanChangedValue = tempList;
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"PLC变量已保存,操作人[{ExtensionGlobalUtil.CurrentUserInfo.FullName}],修改值{str}");
                //LogStr = "";
            }
            catch (Exception ex)
            {

                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, ex.Message);
            }
           
        }

        private void Form_Variable_ParentChanged(object sender, EventArgs e)
        {
            isShown = false;
        }

        private void Btn_CloseMonitor_Click(object sender, EventArgs e)
        {
            isShown = false;
          //  Btn_Save.Enabled = true;
            loadExcel();
            Btn_Save.Enabled = true;
            Btn_CloseMonitor.Enabled = false;
            Btn_Show .Enabled= true;
        }
    }
}
