using MESsoftware1.SQL;
using SqlPart.SQL;
using SqlSugar.Extensions;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace ProcessPLC
{
 
        public class DataSignalAddressUtil
        {
            /// <summary>
            /// 与PLC信号地址配置，这里是额外数据项
            /// </summary>
        public static List<DataSignalAddressConfig> DataSignalAddressConfigList = new List<DataSignalAddressConfig>();
        public static CheckBranchPLCIndex CheckBranchPLCConfig=new CheckBranchPLCIndex();
        public static BatchPackPLCIndex BatchPackPLCConfig1=new BatchPackPLCIndex();
        public static BatchPackPLCIndex BatchPackPLCConfig2=new BatchPackPLCIndex();
        public static List<ParamMonitorConfig> ParamMonitorAddressConfigList=new List<ParamMonitorConfig>();
       
        /// <summary>
        /// 加载PLC地址表配置
        /// </summary>
        public static bool LoadPlcAddressConfig()
            {
                DataSignalAddressConfigList.Clear();
                string fileName = AppDomain.CurrentDomain.BaseDirectory + "Excel\\PlcData.xlsx";
                try
                {
                //DataTable dtConfig = new DataTable();
                DataTable dtConfig = NopiHelper.Execl.ExcelToDatatable(fileName,"Sheet1",true);
                    for (int i = 0; i < dtConfig.Rows.Count; i++)
                    {
                        string sequence = dtConfig.Rows[i]["序号"].ToString();
                        string equipmentName = dtConfig.Rows[i]["设备名称"].ToString();
                        string chineseName = dtConfig.Rows[i]["中文名称"].ToString();
                        string englishName = dtConfig.Rows[i]["英文名称"].ToString();
                        string dataSourceNumber = dtConfig.Rows[i]["数据源"].ToString();
                        string offsetAddress = dtConfig.Rows[i]["偏移地址"].ToString();
                        string dataType = dtConfig.Rows[i]["数据类型"].ToString();
                        string dataLength = dtConfig.Rows[i]["数据长度"].ToString();
                        string currentValue = dtConfig.Rows[i]["当前值"].ToString();
                        string dataCategory = dtConfig.Rows[i]["数据类别"].ToString();
                        string eventNumber = dtConfig.Rows[i]["事件编号"].ToString();
                        string enabledNumericValid = dtConfig.Rows[i]["启用数值校验"].ToString();
                        string minValue = dtConfig.Rows[i]["数值最小值"].ToString();
                        string maxValue = dtConfig.Rows[i]["数值最大值"].ToString();
                        string chineseDescription = dtConfig.Rows[i]["描述"].ToString();
                        //if (dataSourceNumber.StartsWith("DB", StringComparison.CurrentCultureIgnoreCase))
                        //{
                        //    dataSourceNumber = dataSourceNumber.Substring(2);
                        //}
                        //else if (dataSourceNumber.StartsWith("M", StringComparison.CurrentCultureIgnoreCase))
                        //{
                        //    dataSourceNumber = dataSourceNumber.Substring(1);
                        //}
                        SignalCategory signalCategory = SignalCategory.Numerical;
                        Enum.TryParse(dataCategory, true, out signalCategory);
                        Enum.TryParse(dataType, true, out PlcDataType dataTypeResult);
                        DataSignalAddressConfigList.Add(new DataSignalAddressConfig()
                        {
                            Sequence = int.Parse(sequence),
                            EquipmentName = equipmentName,
                            ChineseName = chineseName,
                            EnglishName = englishName,
                            DataSourceNumber = dataSourceNumber,
                            OffsetAddress = ushort.Parse(offsetAddress),
                            DataType = dataTypeResult,
                            DataLength = int.Parse(dataLength),
                            CurrentValue = currentValue,
                            SignalCategory = signalCategory,
                            EventNumber = int.Parse(eventNumber),
                            EnabledNumericValid = (enabledNumericValid == "1" ? 1 : 0),
                            MinValue = minValue,
                            MaxValue = maxValue,
                            ChineseDescription = chineseDescription,
                        });
                    }
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"读取PLC地址表配置成功，读取文件[{fileName}],数据条数【{dtConfig.Rows.Count}】");
                }
                catch (Exception ex)
                {
                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex,$"读取PLC地址表配置失败" );
                }
            return DataSignalAddressConfigList.Count > 0;
            }

        public static bool LoadParamMonitorAddressConfig()
        {
            ParamMonitorAddressConfigList.Clear();
            try
            {
                DataTable rtn = MySqlCrl.SimpleDALMySql<plclogparammap>.OpDB().FindTable("Select * from plclogparammap", null);
                if(rtn.Rows.Count>0)
                {
                    for (int i = 0; i < rtn.Rows.Count; i++)
                    {
                        int id= rtn.Rows[i]["id"].ObjToInt();
                        string db = rtn.Rows[i]["DB"].ToString();
                        int address = rtn.Rows[i]["Address"].ObjToInt();
                        string type = rtn.Rows[i]["Type"].ToString();
                        Enum.TryParse(type, true, out PlcDataType dataTypeResult);
                        ParamMonitorAddressConfigList.Add(new ParamMonitorConfig()
                        {
                            ID = id,
                            DB  = db,
                            Address=(ushort)address,
                            DataType=dataTypeResult

                        });

                    }
                    LogSerilog.SerilogHelper.RuntimeInformationAsync($"读取PLC参数监控地址表配置成功，读取表[plclogparammap],数据条数【{rtn.Rows.Count}】");
                }
            }
            catch (Exception ex)
            {

                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, $"读取PLC参数监控地址表配置失败");
            }
     
            

            return ParamMonitorAddressConfigList.Count>0;

        }
        public static bool LoadPlcDataCollection()
        {
            try
            {
                if (DataSignalAddressConfigList.Count > 0)
                {
                    //CheckBranchPLCConfig分组
                    CheckBranchPLCConfig.CheckRequest= DataSignalAddressConfigList.Find(x => x.EventNumber == 2);               
                    CheckBranchPLCConfig.collection1.sfc = DataSignalAddressConfigList.Find(x => x.EventNumber ==3 );
                    CheckBranchPLCConfig.collection1.retsfc= DataSignalAddressConfigList.Find(x => x.EventNumber == 4);
                    CheckBranchPLCConfig.collection1.groupCode = DataSignalAddressConfigList.Find(x => x.EventNumber == 5);
                    CheckBranchPLCConfig.collection1.groupBasis = DataSignalAddressConfigList.Find(x => x.EventNumber == 6);
                    CheckBranchPLCConfig.collection1.labelRemark = DataSignalAddressConfigList.Find(x => x.EventNumber == 7);
                    CheckBranchPLCConfig.HandleStaus = DataSignalAddressConfigList.Find(x => x.EventNumber == 8);
                    CheckBranchPLCConfig.collection1.Result = DataSignalAddressConfigList.Find(x => x.EventNumber == 31);

                    CheckBranchPLCConfig.collection2.sfc = DataSignalAddressConfigList.Find(x => x.EventNumber == 30);
                    CheckBranchPLCConfig.collection2.retsfc = DataSignalAddressConfigList.Find(x => x.EventNumber == 32);
                    CheckBranchPLCConfig.collection2.groupCode = DataSignalAddressConfigList.Find(x => x.EventNumber == 33);
                    CheckBranchPLCConfig.collection2.groupBasis = DataSignalAddressConfigList.Find(x => x.EventNumber == 34);
                    CheckBranchPLCConfig.collection2.labelRemark = DataSignalAddressConfigList.Find(x => x.EventNumber == 35);
                    CheckBranchPLCConfig.collection2.Result = DataSignalAddressConfigList.Find(x => x.EventNumber == 36);

                    //BatchPackPLCConifg1
                    BatchPackPLCConfig1.packRequest= DataSignalAddressConfigList.Find(x => x.EventNumber == 9);
                    BatchPackPLCConfig1.collection.sfc = DataSignalAddressConfigList.FindAll(x => x.EventNumber == 10);
                    BatchPackPLCConfig1.collection.retsfc = DataSignalAddressConfigList.FindAll(x => x.EventNumber == 11);
                    BatchPackPLCConfig1.collection.groupCode = DataSignalAddressConfigList.FindAll(x => x.EventNumber == 12);
                    BatchPackPLCConfig1.collection.groupBasis = DataSignalAddressConfigList.FindAll(x => x.EventNumber == 13);
                    BatchPackPLCConfig1.collection.labelRemark = DataSignalAddressConfigList.FindAll(x => x.EventNumber == 14);
                    BatchPackPLCConfig1.Result= DataSignalAddressConfigList.Find(x => x.EventNumber == 15);
                    BatchPackPLCConfig1.handleStaus = DataSignalAddressConfigList.Find(x => x.EventNumber == 16);
                    BatchPackPLCConfig1.count = DataSignalAddressConfigList.Find(x => x.EventNumber == 17);

                    //BatchPackPLCConifg2

                    BatchPackPLCConfig2.packRequest = DataSignalAddressConfigList.Find(x => x.EventNumber == 18);
                    BatchPackPLCConfig2.collection.sfc = DataSignalAddressConfigList.FindAll(x => x.EventNumber == 19);
                    BatchPackPLCConfig2.collection.retsfc = DataSignalAddressConfigList.FindAll(x => x.EventNumber == 20);
                    BatchPackPLCConfig2.collection.groupCode = DataSignalAddressConfigList.FindAll(x => x.EventNumber == 21);
                    BatchPackPLCConfig2.collection.groupBasis = DataSignalAddressConfigList.FindAll(x => x.EventNumber == 22);
                    BatchPackPLCConfig2.collection.labelRemark = DataSignalAddressConfigList.FindAll(x => x.EventNumber == 23);
                    BatchPackPLCConfig2.Result = DataSignalAddressConfigList.Find(x => x.EventNumber == 24);
                    BatchPackPLCConfig2.handleStaus = DataSignalAddressConfigList.Find(x => x.EventNumber == 25);
                    BatchPackPLCConfig2.count = DataSignalAddressConfigList.Find(x => x.EventNumber == 26);
                    }
            }
            catch
            { 
            
            }   
            return true;
        }

        }
    public class CheckBranchPLCIndex
    {
       public DataSignalAddressConfig CheckRequest { get; set; }//1
        public DataSignalAddressConfig HandleStaus { get; set; }//8
        public CheckBranchPLC collection1 =new CheckBranchPLC();
        public CheckBranchPLC collection2 = new CheckBranchPLC();
        public class CheckBranchPLC
        {
            public DataSignalAddressConfig sfc { get; set; }

            public DataSignalAddressConfig retsfc { get; set; }

            public DataSignalAddressConfig groupCode { get; set; }

            public DataSignalAddressConfig groupBasis { get; set; }
            public DataSignalAddressConfig labelRemark { get; set; }

            public DataSignalAddressConfig Result { get; set; }
        }//3 4 5 6 7 30
    }

    public class BatchPackPLCIndex
    {
        public DataSignalAddressConfig packRequest;//9
        public DataSignalAddressConfig Result;//15
        public DataSignalAddressConfig handleStaus;//16
        public DataSignalAddressConfig count;//17

        public BatchPackPLC collection =new BatchPackPLC();
        public class BatchPackPLC
        {
            public List<DataSignalAddressConfig> sfc { get; set; }
            public List<DataSignalAddressConfig> retsfc { get; set;}
            public List<DataSignalAddressConfig> groupCode { get; set; }
            public List<DataSignalAddressConfig> groupBasis { get; set; }
            public List<DataSignalAddressConfig> labelRemark { get; set; }
         

        }
    }
   

}
