using MyEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesInterface;
using MESsoftware1.SQL;
using SqlPart.SQL;
using System.Data;
using NopiHelper;
using ProcessPLC;

namespace MESsoftware1.PLC
{
    public class PLCEngine
    {
        
            /// <summary>
            /// 启动引擎【运行按钮】
            /// </summary>
            public static bool StartEngine()
            {
            AppConfig.AppConfigUtil.ReadAppConfig();
                bool LoadFileResult= LoadSystemConfig();
               bool LodMesConfigResult= LoadMesInterfaceConfig();
                bool connectResult = ConnectPlc();

                return connectResult&LoadFileResult&LodMesConfigResult;
            }

            /// <summary>
            /// 停止引擎【停止按钮】
            /// </summary>
            public static void StopEngine()
            {
                //关闭线程
                EventProcess.ThreadStop = true;
                ProcessPLC.PlcOperator.StopPlcCon();
            }

            /// <summary>
            /// 加载系统配置App.exe.config，加载PLC地址表
            /// </summary>
            public static bool LoadSystemConfig()
            {

            return ProcessPLC.DataSignalAddressUtil.LoadPlcAddressConfig() & ProcessPLC.DataSignalAddressUtil.LoadPlcDataCollection()& ProcessPLC.DataSignalAddressUtil.LoadParamMonitorAddressConfig();
            }

            /// <summary>
            /// 加载MES接口配置
            /// </summary>
            public static bool LoadMesInterfaceConfig()
            {
            bool result = true;
             GlobalUtil.CheckBranch = NopiHelper.Jason.ParseJsonFile<MesRequestPara>(AppDomain.CurrentDomain.BaseDirectory + $"Json\\micheckMarkAnddcPackForSfc.json");
            if( GlobalUtil.CheckBranch.RequestParameterList.Count>0  )
            {
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"加载MES接口配置【micheckMarkAnddcPackForSfc.json】成功");

            }
            else
            {
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"加载MES接口配置【micheckMarkAnddcPackForSfc.json】失败");
                result = false;
            }
            
            GlobalUtil.BatchPackMark1 = NopiHelper.Jason.ParseJsonFile<MesRequestPara>(AppDomain.CurrentDomain.BaseDirectory + $"Json\\miAddCheckMarkAndPackForsfcBatch1.json");
            if( GlobalUtil.BatchPackMark1.RequestParameterList.Count>0 )
            {
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"加载MES接口配置【miAddCheckMarkAndPackForsfcBatch1.json】成功");
              
            }
            else
            {
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"加载MES接口配置【miAddCheckMarkAndPackForsfcBatch1.json】失败");
                result = false;
            }
             
            

            GlobalUtil.BatchPackMark2 =NopiHelper.Jason.ParseJsonFile<MesRequestPara>(AppDomain.CurrentDomain.BaseDirectory + $"Json\\miAddCheckMarkAndPackForsfcBatch2.json");
            if ( GlobalUtil.BatchPackMark2.RequestParameterList.Count>0 )
            {
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"加载MES接口配置【miAddCheckMarkAndPackForsfcBatch2.json】成功");
              
            }
            else
            {
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"加载MES接口配置【miAddCheckMarkAndPackForsfcBatch2.json】失败");
                result = false;
            }
            return result;
        }
        
            /// <summary>
            /// 加载自定义配置
            /// </summary>
            public static void LoadCustomConfig()
            {

            }

            /// <summary>
            /// 连接西门子PLC
            /// </summary>
            /// <returns></returns>
            public static  bool  ConnectPlc()
            {
                int siemensPlcPort;
                int.TryParse(AppConfig.AppConfigUtil.GetAppConfigValue("SiemensPlcPort"), out siemensPlcPort);
                string siemensPlcIP = AppConfig.AppConfigUtil.GetAppConfigValue("SiemensPlcIP");
                bool connectResult = ProcessPLC.PlcOperator.ConnectSiemensPlc(siemensPlcIP, siemensPlcPort);
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"连接PLC【{siemensPlcIP}:{siemensPlcPort}】的结果【{connectResult}】");
                return connectResult;
            }
        }
    
}
