using AppConfig;
using MESsoftware1.From;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using ConfigInfomation;
using System.IO;

namespace MESsoftware1
{
   
    internal static class Program
    {
        private static Mutex mutex = null;
       


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool newMutexCreated = false;
            try
            {
                mutex = new Mutex(false, "AutoProgram_SNK", out newMutexCreated);//Application.ExecutablePath
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(1);
                return;
            }
            if (!newMutexCreated)
            {
                MessageBox.Show($"应用程序【{Application.ProductName}】已经运行中，不能重复运行。【不能打开多个应用程序】", "重复运行", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Thread.Sleep(1000);
                Environment.Exit(1);//退出程序
                return;
            }
            AppConfigUtil.ReadAppConfig();

            LogSerilog.SerilogHelper.Configure(AppConfig.AppConfigUtil.GetAppConfigValue("BatchInterfaceLogPath").ToString(), AppConfig.AppConfigUtil.GetAppConfigValue("BranchInterfaceLogPath").ToString());
    
            int AutoLogoutSettingTime=0;
            if (!int.TryParse(AppConfig.AppConfigUtil.GetAppConfigValue("AutoLogoutSettingtime"), out AutoLogoutSettingTime))
            {
                ExtensionGlobalUtil.AdminTimeoutMinute = -1;
            }
       ExtensionGlobalUtil.AdminTimeoutMinute = AutoLogoutSettingTime;
            ExtensionGlobalUtil.RoleManage=new SQL.RoleManage();
            // string ret1=BLL.AppConfig.AppConfigUtil.GetAppConfigValue("SiemensPlcIP");
            SqlPart.SugarSql.CheckConnect();
          Global.GlobalEventDetector glo=new Global.GlobalEventDetector();
            glo.Subscribe();
           Application.Run(new MainFrom());
           glo.Unsubscribe();
           return;                
        }
    }
}
