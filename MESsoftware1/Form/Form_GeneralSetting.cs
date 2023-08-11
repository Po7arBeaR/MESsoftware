using ConfigInfomation;
using NPOI.SS.Formula.Functions;
using SqlSugar;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace MESsoftware1.From
{
  
    public partial class Form_GeneralSetting : Form
    {
        private GeneralType generalType=new GeneralType();
        public Form_GeneralSetting()
        {
            InitializeComponent();
        }

        private void Form_GeneralSetting_Load(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Lab_FilePath.Text = config.FilePath;
                AppConfig.AppConfigUtil.ReadAppConfig();
                int siemensPlcPort;
                int.TryParse(AppConfig.AppConfigUtil.GetAppConfigValue("SiemensPlcPort"), out siemensPlcPort);
                string siemensPlcIP = AppConfig.AppConfigUtil.GetAppConfigValue("SiemensPlcIP");
                int AutoLogoutSettingtime;
                int.TryParse(AppConfig.AppConfigUtil.GetAppConfigValue("AutoLogoutSettingtime"), out AutoLogoutSettingtime);
                string BranchLogPath = AppConfig.AppConfigUtil.GetAppConfigValue("BranchInterfaceLogPath");
                string BatchPackLogPath = AppConfig.AppConfigUtil.GetAppConfigValue("BatchInterfaceLogPath");
                string FormName = AppConfig.AppConfigUtil.GetAppConfigValue("FormName");
                string reval = System.Configuration.ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
                string programNmae = System.Configuration.ConfigurationManager.ConnectionStrings["mysql"].ProviderName;
                 iptb_PLCAddress.Text = siemensPlcIP;
                tb_port.Text = siemensPlcPort.ToString();
                tb_AutoSignOutTime.Text = AutoLogoutSettingtime.ToString();
                tb_SqlConfig.Text = reval;
                tb_programName.Text = programNmae;
                lab_BatchLogPath.Text = BatchPackLogPath;
                lab_BranchLogPath.Text = BranchLogPath;
                tb_FormName.Text = FormName;
                generalType.ip = siemensPlcIP;
                generalType.port = siemensPlcPort;
                generalType.AutoLogoutSettingTime= AutoLogoutSettingtime;
                generalType.SqlConnectionString = reval;
                generalType.SqlProviderName = programNmae;
                generalType.BatchPath = BatchPackLogPath;
                generalType.BrachPath = BranchLogPath;
                generalType.FormName= FormName;
            }
            catch (Exception ex)
            {

                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, "通用配置读取失败");
            }
         
        }

        private void ui_Save_Click(object sender, EventArgs e)
        {
            if(!ExtensionGlobalUtil.LoggingStatus)
            {
                MessageBox.Show("用户未登录");
                return;
            }
            if(ProcessPLC.PlcOperator.PlcConnectStatus)
            {
                MessageBox.Show("处于运行状态，请停止运行进行操作");
                return;
            }
          DialogResult ret=  MessageBox.Show("即将修改配置文件","notify",MessageBoxButtons.OKCancel);
            if(ret==DialogResult.OK)
            {
                try
                {
                    AppConfig.AppConfigUtil.WriteAppConfig("SiemensPlcIP", iptb_PLCAddress.Text.Trim());
                    AppConfig.AppConfigUtil.WriteAppConfig("SiemensPlcPort", tb_port.Text.Trim());
                    AppConfig.AppConfigUtil.WriteAppConfig("AutoLogoutSettingtime", tb_AutoSignOutTime.Text.Trim());
                    AppConfig.AppConfigUtil.WriteAppConfig("BatchInterfaceLogPath", lab_BatchLogPath.Text.Trim());
                    AppConfig.AppConfigUtil.WriteAppConfig("BranchInterfaceLogPath", lab_BranchLogPath.Text.Trim());
                    AppConfig.AppConfigUtil.WriteAppConfig("FormName",tb_FormName.Text.Trim());
                    //      ConfigurationManager.ConnectionStrings["mysql"].ConnectionString = tb_SqlConfig.Text.Trim();
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.ConnectionStrings.ConnectionStrings["mysql"].ProviderName = tb_programName.Text.Trim();
                    config.ConnectionStrings.ConnectionStrings["mysql"].ConnectionString = tb_SqlConfig.Text.Trim();
               
                    GeneralType temp=new GeneralType();
                    temp.ip = iptb_PLCAddress.Text.Trim();
                    temp.port = tb_port.Text.ToInt();
                    temp.AutoLogoutSettingTime = tb_AutoSignOutTime.Text.ToInt();
                    temp.SqlConnectionString = tb_SqlConfig.Text.Trim();
                    temp.SqlProviderName = tb_programName.Text.Trim();
                    temp.BrachPath = lab_BranchLogPath.Text.Trim();
                    temp.BatchPath = lab_BatchLogPath.Text.Trim();
                    temp.FormName=tb_FormName.Text.Trim();
                    Type type = generalType.GetType();
                    string log = "";
                    foreach (PropertyInfo p in type.GetProperties())
                    {
                       if(p.GetValue(generalType).ToString()!=p.GetValue(temp).ToString())
                        {
                            log +="["+ p.Name + "(" + p.GetValue(generalType).ToString() + ")=>(" + p.GetValue(temp)+")]";
                        }
                    }
                        LogSerilog.SerilogHelper.RuntimeInformationAsync($"通用配置文件已修改，操作者[{ExtensionGlobalUtil.CurrentUserInfo.FullName}]修改值:{log}");
                    generalType = temp;
                    ExtensionGlobalUtil.AdminTimeoutMinute = tb_AutoSignOutTime.Text.Trim().ToDouble();
                    Form_GeneralSetting_Load(sender, e);
                }
                catch (Exception ex)
                {
                    LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, "通用配置保存失败");

                }
            }
           
          
        }

        private void btn_BranchLogPath_Click(object sender, EventArgs e)
        {
            fbd_BranchPath.Description = "请选择文件夹";
            fbd_BranchPath.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd_BranchPath.ShowNewFolderButton = true;
            if (lab_BranchLogPath.Text.Length > 0) fbd_BranchPath.SelectedPath = lab_BranchLogPath.Text;
            if (fbd_BranchPath.ShowDialog() == DialogResult.OK)
            {
                lab_BranchLogPath.Text = fbd_BranchPath.SelectedPath;
            }


        }

        private void btn_BatchPackLogPath_Click(object sender, EventArgs e)
        {
            fbd_BatchPath.Description = "请选择文件夹";
            fbd_BatchPath.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd_BatchPath.ShowNewFolderButton = true;
            if (lab_BatchLogPath.Text.Length > 0) fbd_BatchPath.SelectedPath = lab_BatchLogPath.Text;
            if (fbd_BatchPath.ShowDialog() == DialogResult.OK)
            {
                lab_BatchLogPath.Text = fbd_BatchPath.SelectedPath;
            }
        }

     
    }
    class GeneralType
    {
        public string ip { get; set; }
        public int port { get; set; }
        public int AutoLogoutSettingTime { get; set; }
        public string SqlConnectionString { get; set; }
        public string SqlProviderName { get; set; }

        public string BrachPath { get; set; }
        public string BatchPath { get; set; }

        public string FormName { get;set; }
    }
}
