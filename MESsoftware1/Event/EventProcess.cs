using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ProcessPLC;
using EventType;
using MesInterface;
using MESsoftware1.MES;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using LogSerilog;
using MESsoftware1.sfcBatchPack;
using static ProcessPLC.CheckBranchPLCIndex;
using Sunny.UI;
using MESsoftware1.SQL;
using SqlPart.SQL;
using Org.BouncyCastle.Asn1.Ocsp;
using MESsoftware1.DEBUG;

namespace MyEvent
{
    public partial class EventProcess
    {
        /// <summary>
        /// 侧缝焊日志 显示所有日志：运行日志、MES日志、刷新DataGridView
        /// </summary>
     //   public static CustomSysMsg SysMsg_SideSeam = new CustomSysMsg("log_cfh");

        /// <summary>
        /// 显示所有日志：运行日志、MES日志、刷新DataGridView事件，如果数据表为空，就不刷新DataGridView，
        /// 如果数据表不为空，只显示最新的200条生产记录
        /// </summary>
      //  public static event Action<string> ShowMesLogRefreshEvent;
        /// <summary>
        /// 显示条码事件
        /// </summary>
        //public static event Action<string> ShowBarcodeEvent;
        /// <summary>
        /// 主线程是否已停止
        /// </summary>
        public static bool ThreadStop = true;//用于停止线程
        /// <summary>
        /// 全局变量模组条码。当某一个模组条码进站成功后，将全局变量赋值为进站成功条码，直到触发出站信号该条码才清空。
        /// 该变量不为空时，扫码无效
        /// </summary>
        public static volatile string ModuleBarcode = string.Empty;
        public static EventBindPara[] EventBindParaAr = new EventBindPara[2];

        /// <summary>
        /// 事件处理:第一个参数是触发名称，第二个参数是反馈名称，返回bool结果
        /// </summary>
    //    public static event Func<string, string, bool> EventTrigProcess;

        /// <summary>
        /// 上一次的字典信息,键为触发信号名称，值为触发信号的当前值
        /// </summary>
        static Dictionary<string, short> dictLast = new Dictionary<string, short>();

        public static bool Station1ExecuteOnly1Flag = false;
        public static bool station2ExecuteOnlyFlag1= false;
        public static bool station2ExecuteOnlyFlag2 = false;
       //private static BranchCheckPLCStringCollection BCcode1=new BranchCheckPLCStringCollection();
       // private static BranchCheckPLCStringCollection BCcode2 = new BranchCheckPLCStringCollection();
       // private static BatchPackStringCollection BPcode1=new BatchPackStringCollection();
       // private static BatchPackStringCollection BPcode2 = new BatchPackStringCollection();

        public static void SetStringCollection()
        {
        
            //BCcode1.CheckRequset = "Station1CheckRequset";
            //BCcode1.CheckCode = "Station1CheckCode1";
            //BCcode1.ReturnSfc = "Station1CheckCodeRsfc1";
            //BCcode1.CheckCodeResult = "Station1CheckCodeResult1";
            //BCcode1.GroupCode = "Station1GroupCode1";
            //BCcode1.GroupBasis = "Station1GroupBasis1";
            //BCcode1.lableRemark = "Station1LabelRemarks1";
            //BCcode1.HandleStatus = "Station1HandleStatus";

            //BCcode2.CheckRequset = "Station1CheckRequset";
            //BCcode2.CheckCode = "Station1CheckCode2";
            //BCcode2.ReturnSfc = "Station1CheckCodeRsfc2";
            //BCcode2.CheckCodeResult = "Station1CheckCodeResult2";
            //BCcode2.GroupCode = "Station1GroupCode2";
            //BCcode2.GroupBasis = "Station1GroupBasis2";
            //BCcode2.lableRemark = "Station1LabelRemarks2";
            //BCcode2.HandleStatus = "Station1HandleStatus";

            //BPcode1.CheckRequset = "Station2CheckRequset";
            //BPcode1.CheckCode = "Station2CheckCode1";
            //BPcode1.GroupCode = "Station2GroupCode1";
            //BPcode1.GroupBasis = "Station2GroupBasis1";
            //BPcode1.LableRemarks = "Station2LabelRemarks1";
            //BPcode1.CodeResult = "Station2CodeRet1";
            //BPcode1.HandleStatus = "Station2HandleStatus1";

            //BPcode2.CheckRequset = "Station3CheckRequset";
            //BPcode2.CheckCode = "Station3CheckCode1";
            //BPcode2.GroupCode = "Station3GroupCode1";
            //BPcode2.GroupBasis = "Station3GroupBasis1";
            //BPcode2.LableRemarks = "Station3LabelRemarks1";
            //BPcode2.CodeResult = "Station3CodeRet1";
            //BPcode2.HandleStatus = "Station3HandleStatus1";
        }
        public static void MainFlowStart()
        {
            ThreadStop = false;//一定得初始化下

         // 新增心跳逻辑线程：每隔0.5秒写1，下一次0.5秒写2。软件只写。PLC监控心跳地址的值在3秒内是否有变化
            AsyncHeartBeatFlow();
           
            //异步重新连接PLC线程
            AsyncReconnect();
          //  SetStringCollection();
            AsyncBranchCheck();
            AsyncBatchPack();
            AsynPLcParamMonitor();
        }
        public static volatile bool heartBeatFlag = true;
        /// <summary>
        /// PLC连接状态
        /// </summary>
        static bool PLCConnectStatus = false;//软件通讯
        /// <summary>
        /// 重连次数
        /// </summary>
        public static int ReConnectCount = 0;
        /// <summary>
        /// 新增心跳逻辑线程：每隔0.5秒写1，下一次0.5秒写2。软件只写。PLC监控心跳地址的值在3秒内是否有变化
        /// 软件监控SetItemInfo 是否失败
        /// </summary>
         public static MESCallCheckInterFace CallCheckBranch= new MESCallCheckInterFace();
        public static MESCallBatchInterface CallBatchPack=new MESCallBatchInterface();
        static void AsyncHeartBeatFlow()
        {
            #region 新增心跳逻辑线程：每隔0.5秒写1，下一次0.5秒写2。软件只写。PLC监控心跳地址的值在3秒内是否有变化
            Task.Factory.StartNew(async () =>
            {
                try
                {
                    while (!ThreadStop)
                    {
                        heartBeatFlag = !heartBeatFlag;
                        bool rtn = ProcessPLC.PlcOperator.WriteValueByName("HeartBeat", (short)(heartBeatFlag ? 1 : 2));
                        if (!rtn)
                        {
                            await LogSerilog.SerilogHelper.RuntimeInformationAsync($"心跳包【HeartBeat】写入失败,请检查网络以及是否已连接到PLC");
                            PLCConnectStatus = false;
                            ReConnectCount++;
                            if (ReConnectCount == 1)
                            {
                                //重新连接
                                Task<bool> task = new Task<bool>(ProcessPLC.PlcOperator.m_PlcTcp.IniPlcCon);//不阻塞另外一个通道
                                task.Start();
                            }
                        }
                        else
                        {
                            //重新连接第一次进入
                            if (!PLCConnectStatus)
                            {
                                HeartBeatCon();
                                PLCConnectStatus = true;
                            }
                            ReConnectCount = 0;
                        }
                        if (ReConnectCount >= 100)
                        {
                            //EventSetPLCConnectStatus.Invoke(119);
                            break;//如果200次还是不行，不再继续进行写入
                        }
                        //心跳修改为2秒
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    LogSerilog.SerilogHelper.RuntimeInformationAsync($"心跳包，写入心跳值时出现异常,原因：{ex.Message}");
                }
            });
            #endregion
        }

        /// <summary>
        /// 异步重连PLC线程
        /// </summary>
        static void AsyncReconnect()
        {
            #region 
            Task.Factory.StartNew(() =>
            {
                try
                {
                    while (!ThreadStop)
                    {
                        bool isReconnectOperator = false;//是否重连操作
                        bool rtn = Reconnect(out isReconnectOperator);
                        if (rtn && isReconnectOperator)
                        {
                            LogSerilog.SerilogHelper.RuntimeInformationAsync($"重新连接PLC【{ProcessPLC.PlcOperator.m_PlcTcp.GetPLCIP()}】成功...");
                        }
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    LogSerilog.SerilogHelper.RuntimeInformationAsync($"重新连接PLC线程出现异常,原因：{ex.Message}");
                }
            });
            #endregion
        }

        /// <summary>
        /// 重新连接PLC
        /// </summary>
        /// <returns></returns>
        public static bool Reconnect(out bool isReconnectOperator)
        {
            isReconnectOperator = false;
            if (!ProcessPLC.PlcOperator.PlcConnectStatus)
            {
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"与PLC的连接已断开,尝试重新连接PLC【{ProcessPLC.PlcOperator.m_PlcTcp.GetPLCIP()}】");
                //断线重连
                Task<bool> task = new Task<bool>(ProcessPLC.PlcOperator.m_PlcTcp.IniPlcCon);//不阻塞另外一个通道
                task.Start();
                System.Threading.Thread.Sleep(100);
                Task.WaitAll(new Task[] { task }, 3000);
                isReconnectOperator = true;
            }
            return ProcessPLC.PlcOperator.PlcConnectStatus;
        }
        static void HeartBeatCon()
        {
            //重新连接第一次进入
            if (!PLCConnectStatus)
            {
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"【PLC】心跳正常....");
                PLCConnectStatus = true;
                ReConnectCount = 0;
            }
        }
        static bool HeartBeatDisCon()
        {
            LogSerilog.SerilogHelper.RuntimeInformationAsync($"【PLC】心跳异常,重连次数【{ReConnectCount}】");
            PLCConnectStatus = false;
            ReConnectCount++;
            if (ReConnectCount == 1)
            {
                //第一次进入
            }
            else if (ReConnectCount >= 1000)
            {
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"心跳异常....已无法修改,超过1000次，请重新连接重试");
                return false;//如果1000次还是不行，不再继续进行写入
            }
            return true;
        }

        static void AsynPLcParamMonitor()
        {
            Task.Factory.StartNew(() =>
            {
                while(!ThreadStop)
                {
                    try
                    {
                        if (ProcessPLC.PlcOperator.PlcConnectStatus)
                        {

                            foreach (var param in  DataSignalAddressUtil. ParamMonitorAddressConfigList)
                            {
                                
                                switch (param.DataType)
                                {
                                    case PlcDataType.Int:
                                        {
                                            short ret = 0;
                                            if (PlcOperator.ReadValueByConfig<short>(param, out ret))
                                            {
                                                plclogparammap Item = MySqlCrl.SimpleDALMySql<plclogparammap>.OpDB().GetFirstObj(x => x.ID == param.ID);
                                                if (Item.CurrentValue.ToInt() != ret)
                                                {
                                                    Item.LastValue = Item.CurrentValue;
                                                    Item.CurrentValue = ret.ToString();
                                                    Item.ChangeTime = DateTime.Now;
                                                    MySqlCrl.SimpleDALMySql<plclogparammap>.OpDB().Update(Item);
                                                    SerilogHelper.RuntimeInformationAsync($"检测到PLC参数{Item.Description}已更改，新值{Item.CurrentValue},旧值{Item.LastValue},更改时间{Item.ChangeTime}");
                                                }
                                            }
                                            break;
                                        }
                                    case PlcDataType.Real:
                                        {
                                            float  ret = 0;
                                            if (PlcOperator.ReadValueByConfig<float>(param, out ret))
                                            {
                                                plclogparammap Item = MySqlCrl.SimpleDALMySql<plclogparammap>.OpDB().GetFirstObj(x => x.ID == param.ID);
                                               
                                                if (Item.CurrentValue.ToFloat() != ret)
                                                {
                                                    Item.LastValue = Item.CurrentValue;
                                                    Item.CurrentValue = ret.ToString();
                                                    Item.ChangeTime = DateTime.Now;
                                                    MySqlCrl.SimpleDALMySql<plclogparammap>.OpDB().Update(Item);
                                                    SerilogHelper.RuntimeInformationAsync($"检测到PLC参数{Item.Description}已更改，新值{Item.CurrentValue},旧值{Item.LastValue},更改时间{Item.ChangeTime}");
                                                }
                                            }
                                            break;
                                        }
                                        
                                    default:
                                        SerilogHelper.RuntimeInformationAsync("PLC参数监控不支持改类型变量");
                                        break;
                                        

                                }
                               
                               
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                        SerilogHelper.RuntimeErrorAsync(ex, "PLC参数检测线程运行异常");
                    }
                    Thread.Sleep(1500);
                }
            });
        }
        static void  AsyncBranchCheck()
        {
            Task.Factory.StartNew(() =>
            {

            while (!ThreadStop)
            {
                try
                {
                    short FistCheckRequest = 0;
                    PlcOperator.ReadValueByName(DataSignalAddressUtil.CheckBranchPLCConfig.CheckRequest.EnglishName, out FistCheckRequest);
                       // Console.WriteLine(FistCheckRequest);
                        if (FistCheckRequest == 0)
                        {

                            Station1ExecuteOnly1Flag = false;
                            ProcessPLC.PlcOperator.WriteValueByName<short>(DataSignalAddressUtil.CheckBranchPLCConfig.HandleStaus.EnglishName, 0);
                        }
                        if (FistCheckRequest == 1&& !Station1ExecuteOnly1Flag)
                        {
                           
                            Station1ExecuteOnly1Flag = true;
                            ProcessPLC.PlcOperator.WriteValueByName<short>(DataSignalAddressUtil.CheckBranchPLCConfig.HandleStaus.EnglishName, 1);
                            if (!GlobalUtil.CheckBranch.Enabled)
                            {
                                LogSerilog.SerilogHelper.MESInformationAsync($"micheckMarkAnddcPackForSfc接口没有启动，直接按OK处理", MESInterfaceType.Check);
                                ProcessPLC.PlcOperator.WriteValueByName<short>(DataSignalAddressUtil.CheckBranchPLCConfig.HandleStaus.EnglishName, 2);
                                return;
                            }
                      
                            HandleBranchCheckEvent(DataSignalAddressUtil.CheckBranchPLCConfig.collection1);
                            HandleBranchCheckEvent(DataSignalAddressUtil.CheckBranchPLCConfig.collection2);
                            ProcessPLC.PlcOperator.WriteValueByName<short>(DataSignalAddressUtil.CheckBranchPLCConfig.HandleStaus.EnglishName, 2);

                        }
                    }
                catch (Exception ex)
                {
                    LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, $"【AsyncBranchCheck】出现异常：{ex.Message}");
                    //return false;
                }
                    Thread.Sleep(200);
                }
            });
        }
        static void AsyncBatchPack()
            {

            Task.Factory.StartNew( () =>
            {
                while (!ThreadStop)
                {
                    try
                    { 
                        short SecondCheckStation2Request = 0;
                   
                        PlcOperator.ReadValueByName(DataSignalAddressUtil.BatchPackPLCConfig1.packRequest.EnglishName, out SecondCheckStation2Request);
                    //   
                        if ( SecondCheckStation2Request == 0 )
                        {

                            station2ExecuteOnlyFlag1 = false;
                            ProcessPLC.PlcOperator.WriteValueByName<short>(DataSignalAddressUtil.BatchPackPLCConfig1.handleStaus.EnglishName, 0);
                        }
                        if (SecondCheckStation2Request == 1 && !station2ExecuteOnlyFlag1)
                        {
                           
                            station2ExecuteOnlyFlag1 = true;
                            ProcessPLC.PlcOperator.WriteValueByName<short>(DataSignalAddressUtil.BatchPackPLCConfig1.handleStaus.EnglishName, 1);
                            if (!GlobalUtil.BatchPackMark1.Enabled)
                            {
                                LogSerilog.SerilogHelper.MESInformationAsync($"MachineIntegration接口没有启动直接按OK处理", MESInterfaceType.Batch);
                                ProcessPLC.PlcOperator.WriteValueByName<short>(DataSignalAddressUtil.BatchPackPLCConfig1.handleStaus.EnglishName, 2);
                                continue;
                            }
                            else
                            {
                                HandleBatchPackEvent(DataSignalAddressUtil.BatchPackPLCConfig1, GlobalUtil.BatchPackMark1);
                                
                                ProcessPLC.PlcOperator.WriteValueByName<short>(DataSignalAddressUtil.BatchPackPLCConfig1.handleStaus.EnglishName, 2);

                            }

                        }



                  

                        short SecondCheckStation3Request = 0;
                        PlcOperator.ReadValueByName(DataSignalAddressUtil.BatchPackPLCConfig2.packRequest.EnglishName, out SecondCheckStation3Request);
                        if (SecondCheckStation3Request == 0)
                        {
                            station2ExecuteOnlyFlag2 = false;
                            ProcessPLC.PlcOperator.WriteValueByName<short>(DataSignalAddressUtil.BatchPackPLCConfig2.handleStaus.EnglishName, 0);
                        }
                        if(SecondCheckStation3Request==1&&!station2ExecuteOnlyFlag2)
                         {
                            station2ExecuteOnlyFlag2 = true;
                            ProcessPLC.PlcOperator.WriteValueByName<short> (DataSignalAddressUtil.BatchPackPLCConfig2.handleStaus.EnglishName, 1);
                            if (!GlobalUtil.BatchPackMark2.Enabled)
                            {
                                LogSerilog.SerilogHelper.MESInformationAsync($"MachineIntegration接口没有启动直接按OK处理", MESInterfaceType.Batch);
                                ProcessPLC.PlcOperator.WriteValueByName<short>(DataSignalAddressUtil.BatchPackPLCConfig2.handleStaus.EnglishName, 2);
                                continue;
                            }
                            else
                            {
                                HandleBatchPackEvent(DataSignalAddressUtil.BatchPackPLCConfig2, GlobalUtil.BatchPackMark2);
                       
                                ProcessPLC.PlcOperator.WriteValueByName<short>(DataSignalAddressUtil.BatchPackPLCConfig2.handleStaus.EnglishName, 2);

                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, $"扫描触发信号线程【AsyncBatchPack】出现异常：{ex.Message}");
                        //return false;
                    }
                    Thread.Sleep(200);
                }
            });

        }
        public static  void HandleBranchCheckEvent(CheckBranchPLC StrCollection  )
        {
            string barcode = string.Empty;

            try
            {
                PlcOperator.ReadValueByName(StrCollection.sfc.EnglishName, out barcode);
                barcode = barcode.Replace("\0", string.Empty);
                if(!DEBUGFORPLC._DEBUG_MODE)
                {
                    if (barcode.Length != GlobalUtil.CheckBranch.sfcLengthVerify || !barcode.Contains(GlobalUtil.CheckBranch.sfcHeadVerify))
                    {
                        LogSerilog.SerilogHelper.MESInformationAsync($"【电芯分流电芯码校验】sfc不通过校验返回NG,sfc[{barcode}],长度【{barcode.Length}】,设定长度【{GlobalUtil.CheckBranch.sfcLengthVerify}】,设定头部【{GlobalUtil.CheckBranch.sfcHeadVerify}】", MESInterfaceType.Check);
                        ProcessPLC.PlcOperator.WriteValueByName<short>(StrCollection.Result.EnglishName, 4);
                        return;
                    }
                }
               
                LogSerilog.SerilogHelper.MESInformationAsync($"【电芯分流电芯码校验】触发,模组条码：【{barcode}】", MESInterfaceType.Check);
                 ResponseResult responseResult = CallCheckBranch.CheckMarkAndDcPackForSfcCall(barcode, GlobalUtil.CheckBranch);
                if (DEBUGFORPLC._DEBUG_MODE)
                {
                    ProcessPLC.PlcOperator.WriteValueByName(StrCollection.Result.EnglishName, DEBUGFORPLC.Branch);
                    ProcessPLC.PlcOperator.WriteValueByName(StrCollection.groupBasis.EnglishName, "this is a fake groupBasis");
                    ProcessPLC.PlcOperator.WriteValueByName(StrCollection.groupCode.EnglishName, "this is a fake groupCode");
                    ProcessPLC.PlcOperator.WriteValueByName(StrCollection.labelRemark.EnglishName, "this is a fake labelRemark");
                    ProcessPLC.PlcOperator.WriteValueByName(StrCollection.retsfc.EnglishName, barcode);
                }
                else
                {
                    if(responseResult.JgeMarkBrach==3)
                    {
                        LogSerilog.SerilogHelper.MESInformationAsync($"【电芯分流电芯码校验】分组依据无法与配置分组配置匹配，返回结果[{responseResult.JgeMarkBrach}]", MESInterfaceType.Check);
                    }
                    ProcessPLC.PlcOperator.WriteValueByName(StrCollection.Result.EnglishName, (short)(responseResult.Code == 0 ? responseResult.JgeMarkBrach : (responseResult.Code > 0 ? 3 : 5)));
                    ProcessPLC.PlcOperator.WriteValueByName(StrCollection.groupBasis.EnglishName, responseResult.GropBasis);
                    ProcessPLC.PlcOperator.WriteValueByName(StrCollection.groupCode.EnglishName, responseResult.GroupCode);
                    ProcessPLC.PlcOperator.WriteValueByName(StrCollection.labelRemark.EnglishName, responseResult.lableRemarks);
                    ProcessPLC.PlcOperator.WriteValueByName(StrCollection.retsfc.EnglishName, responseResult.Sfc);
                    //   responseResult
                }

                if (responseResult.Code>=0)
                {
                    MESsoftware1.SQL.HistoryData historyData = new MESsoftware1.SQL.HistoryData();
                    historyData.Code = responseResult.Code;
                    historyData.Message = responseResult.Message;
                    historyData.labelRemarks = responseResult.lableRemarks;
                    historyData.GroupBasis = responseResult.GropBasis;
                    historyData.GroupCode = responseResult.GroupCode;
                    historyData.sfc = responseResult.Sfc;
                    historyData.InterFaceName = "电芯分流接口";
                    historyData.Count = -1;
                    historyData.CreateTime= DateTime.Now;
                    MySqlCrl.SimpleDALMySql<HistoryData>.OpDB().Insert(historyData);
                }
             
                LogSerilog.SerilogHelper.MESInformationAsync($"【电芯分流电芯码校验】接口已调用,Code【{responseResult.Code}】,信息【{responseResult.Message}】,开始时间[{responseResult.StartTime}],结束时间[{responseResult.EndTime}],耗时【{responseResult.SpendTime}ms】", MESInterfaceType.Check);
            }
            catch (Exception ex)
            {

                LogSerilog.SerilogHelper.MESErrorAsync(ex,$"【电芯分流电芯码校验】调用异常【{ex.Message}】", MESInterfaceType.Check);
                ProcessPLC.PlcOperator.WriteValueByName<short>(StrCollection.Result.EnglishName, 2);
            }
          
        }
        public static  void HandleBatchPackEvent(BatchPackPLCIndex StrCollection, MesRequestPara mesRequestPara)
        {
          
            string packGroup=string.Empty;
         
            try
            {
                PlcOperator.ReadValueByName(StrCollection.collection.groupBasis[0].EnglishName, out packGroup);            
                packGroup = packGroup.Replace("\0", string.Empty);
                List<requestSfcDetail> sfclist = new List<requestSfcDetail>();

               
                string sfcLog = "";
                string packGroupCodeLog = "";
                string countLog="";
                string lengthLog = "";
                bool sfcIsVerify = true;
                short Count = 0;
                string sfc = string.Empty;
                int VerifyNumb= int.Parse(mesRequestPara.RequestParameterList.Find(x => x.Key == "VerifyNumb")?.Value);
                if(VerifyNumb <= 0)
                {
                    LogSerilog.SerilogHelper.MESInformationAsync($"【电芯批量打包校验】设置读取配置文件，检验电芯个数【{VerifyNumb}】，不符合配置要求，请检查配置", MESInterfaceType.Batch);
                    ProcessPLC.PlcOperator.WriteValueByName<short>(StrCollection.Result.EnglishName, 4);
                    return;
                }
                if (StrCollection.collection.sfc.Count== VerifyNumb && StrCollection.collection.groupCode.Count== VerifyNumb)
                {

                    PlcOperator.ReadValueByName(StrCollection.count.EnglishName, out Count);
                    if(Count<=0)
                    {
                        LogSerilog.SerilogHelper.MESInformationAsync($"【电芯批量打包校验】，PLC计数为【{Count}】，不符合调用接口规则", MESInterfaceType.Batch);
                        ProcessPLC.PlcOperator.WriteValueByName<short>(StrCollection.Result.EnglishName, 4);
                        return;
                    }
                    for (int i = 0; i < VerifyNumb; i++)
                    {
                        requestSfcDetail sfcDetail = new requestSfcDetail();
                        PlcOperator.ReadValueByName(StrCollection.collection.sfc[i].EnglishName, out sfc);
                        sfcDetail.sfc = sfc.Replace("\0", string.Empty);
                        string packGroupCode = string.Empty;
                        PlcOperator.ReadValueByName(StrCollection.collection.groupCode[i].EnglishName, out packGroupCode);
                        sfcDetail.packGroupCode = packGroupCode.Replace("\0", string.Empty);
                        
                        sfcDetail.sequence = (((Count-1)* VerifyNumb) +(i+1)).ToString();
                       // Console.WriteLine(sfcDetail.sfc);
                        sfclist.Add(sfcDetail);
                    }

               
                    foreach (var item in sfclist)
                    {
                       
                        sfcLog += '['+item.sfc + ']';
                        lengthLog += '['+item.sfc.Length.ToString() + ']';
                        packGroupCodeLog += '['+item.packGroupCode + ']';
                        countLog +='['+ item.sequence + ']';
                        
                        if (mesRequestPara.sfcLengthVerify != item.sfc.Length||!item.sfc.Contains(mesRequestPara.sfcHeadVerify)||item.sequence.ToInt()<=0)
                        {
                            sfcIsVerify = false;
                        }
                        
                    }
                  
                }
                else
                {
                    LogSerilog.SerilogHelper.MESInformationAsync($"【电芯批量打包校验】PLC采集项配置与设定采集个数不匹配.请检查配置文件,设置采集个数[{VerifyNumb}],PLC采集项个数[{StrCollection.collection.sfc.Count},{StrCollection.collection.groupCode.Count}]", MESInterfaceType.Batch);
                    return;
                }
                if (!DEBUGFORPLC._DEBUG_MODE)
                {
                    if (!sfcIsVerify)
                    {
                        LogSerilog.SerilogHelper.MESInformationAsync($"【电芯批量打包校验】sfc不通过校验返回NG,sfc{sfcLog},长度:{lengthLog},设定长度{mesRequestPara.sfcLengthVerify},设定头部{mesRequestPara.sfcHeadVerify},打包顺序{countLog}", MESInterfaceType.Batch);
                        ProcessPLC.PlcOperator.WriteValueByName<short>(StrCollection.Result.EnglishName, 4);
                        return;
                    }
                }
              
                 LogSerilog.SerilogHelper.MESInformationAsync($"【电芯批量打包校验】触发,模组条码：{sfcLog},分组代码:{packGroupCodeLog},打包顺序{countLog},分组依据[{packGroup}]", MESInterfaceType.Batch);
                 ResponseResult responseResult = CallBatchPack.SfcBatchPackCall(sfclist,packGroup, mesRequestPara );

                if(DEBUGFORPLC._DEBUG_MODE)
                {
                   ProcessPLC.PlcOperator.WriteValueByName(StrCollection.Result.EnglishName, DEBUGFORPLC.Batch);
                }
                else
                {
                    ProcessPLC.PlcOperator.WriteValueByName(StrCollection.Result.EnglishName, (short)(responseResult.Code == 0 ? 1 : (responseResult.Code > 0 ? 3 : 5)));
                }
              
                  if(responseResult.Code >= 0)
                {
                 

                    for (int i = 0; i < sfclist.Count; i++)
                    {
                        MESsoftware1.SQL.HistoryData historyData = new MESsoftware1.SQL.HistoryData();
                        historyData.Code = responseResult.Code;
                        historyData.Message = responseResult.Message;
                        historyData.labelRemarks = responseResult.lableRemarks;
                        historyData.GroupBasis = responseResult.GropBasis;
                        historyData.GroupCode = responseResult.GroupCode;
                        historyData.sfc = sfclist[i].sfc;
                        historyData.InterFaceName = "批量打包接口";
                        historyData.Count = sfclist[i].sequence.ToInt();
                        historyData.CreateTime = DateTime.Now;
                        MySqlCrl.SimpleDALMySql<HistoryData>.OpDB().Insert(historyData);
                    }
                  

                }
                  
                  LogSerilog.SerilogHelper.MESInformationAsync($"【电芯批量打包校验】接口已调用.Code【{responseResult.Code}】,信息：{responseResult.Message},开始时间[{responseResult.StartTime}],结束时间[{responseResult.EndTime}],耗时【{responseResult.SpendTime}ms】", MESInterfaceType.Batch);
            }   
            catch (Exception ex)
            {

                LogSerilog.SerilogHelper.MESErrorAsync(ex,$"[批量打包接口]调用异常【{ex.Message}】", MESInterfaceType.Batch);
                ProcessPLC.PlcOperator.WriteValueByName<short>(StrCollection.Result.EnglishName, 2);
            }
        }
        
    }
   

    }

