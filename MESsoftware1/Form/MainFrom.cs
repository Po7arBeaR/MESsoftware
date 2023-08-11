using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogSerilog;
using Serilog;
using MyEvent;
using System.Diagnostics.Eventing.Reader;
using System.Threading;
using MESsoftware1.PLC;
using ConfigInfomation;
using MESsoftware1.From;
using static Google.Protobuf.WellKnownTypes.Field.Types;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using Sunny.UI;
using NPOI.XSSF.UserModel;
using EntityOfSql;
using Sunny.UI.Win32;
using MESsoftware1.Form_EX;
using ProcessPLC;

namespace MESsoftware1
{
    public partial class MainFrom : Form
    {
      //  Form_InterFaceSetting Form_interFace = new Form_InterFaceSetting();
      //  Form_MainPage Form_Container = new Form_MainPage();
        public MainFrom()
        {

            //     EventProcess.ShowMesLogRefreshEvent += EventProcess_RuntimeLog;
            //   EventProcess.ShowBarcodeEvent += EventProcess_MesLog;
            InitializeComponent();
            SerilogHelper.ConnectTextBox(ref tb_Runtime, ref tb_MES);
          
            if (ExtensionGlobalUtil.CurrentUserInfo != null)
            {
                Lab_CurrentUser.Text = ExtensionGlobalUtil.CurrentUserInfo.FullName;
                btn_Signout.Enabled = true;
                Btn_Signin.Enabled = false;
            }
            else
            {
                Lab_CurrentUser.Text = "";
                btn_Signout.Enabled = false;
                Btn_Signin.Enabled = true;
            }
          
        }
        delegate void ClearDelegate();
        delegate void SetDelegate(Control form);
        delegate void ShowDelegate();
        private void Control_Add(Form form,bool Enable=true)
        {
         
            Panel_Menu.Invoke((ClearDelegate)Panel_Menu.Controls.Clear);    //移除所有控件
            form.TopLevel = false;      //设置为非顶级窗体
           // form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //设置窗体为非边框样式
            form.Dock = System.Windows.Forms.DockStyle.Fill;                  //设置样式是否填充整个panel
            form.Size = Panel_Menu.Size;
           Panel_Menu.Invoke((SetDelegate)Panel_Menu.Controls.Add,form);        //添加窗体
            if(!Enable) form.Enabled = false;
            form.Invoke((ShowDelegate)form.Show);                     //窗体运行
        }
        private  void Btn_Stop_Click(object sender, EventArgs e)
        {
            

           // Btn_Stop.Enabled = false;
            PLCEngine.StopEngine();     
            Btn_Stop.Enabled = true;
            SerilogHelper.RuntimeInformationAsync($"已关闭引擎，停止运行.");
            
            Btn_Run.Enabled = true;
        }

        private async void Btn_Run_Click(object sender, EventArgs e)
        {
            Btn_Run.Enabled = false;     
            bool result = PLCEngine.StartEngine();
            if (!result)
            {
               await LogSerilog.SerilogHelper.RuntimeErrorAsync(null,"启动引擎失败，请查看配置是否错误，PLC是否已连接");
                Btn_Run.Enabled = true;
                return;
            }
            await LogSerilog.SerilogHelper.RuntimeInformationAsync($"启动引擎运行成功...");

            Thread thread = new Thread(new ThreadStart(EventProcess.MainFlowStart));
            thread.IsBackground = true;
            thread.Start();
        }
        private void ClockShow()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    string FormName = AppConfig.AppConfigUtil.GetAppConfigValue("FormName");
                    this.BeginInvoke(new Action(() => { this.Text = FormName + DateTime.Now.ToString(); }));
                    Thread.Sleep(1000);
                }



            });
            

        }
        private void SignStatusToPlc()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (ProcessPLC.PlcOperator.PlcConnectStatus)
                    {
                        short SignStatus = 0;
                        if (ExtensionGlobalUtil.LoggingStatus)
                        {
                            Enum.TryParse(ExtensionGlobalUtil.CurrentUserInfo.Character, true, out ConfigInfomation.CharacterType Character);
                          
                            switch (Character)
                            {
                                case CharacterType.管理员:
                                    SignStatus = 5;

                                    break;
                                case CharacterType.PE:
                                    SignStatus = 4;
                                    break;
                                case CharacterType.ME:
                                    SignStatus = 3;
                                    break;
                                case CharacterType.OPN技师:
                                    SignStatus = 2;
                                    break;
                                case CharacterType.OPN操作员:
                                    SignStatus = 1;
                                    break;
                            }
                           // Console.WriteLine(SignStatus);
                            PlcOperator.WriteValueByName("UserSignInStatus", SignStatus);
                            PlcOperator.WriteValueByName("UserSignInName", ExtensionGlobalUtil.CurrentUserInfo.FullName);
                        }
                        else
                        {
                            PlcOperator.WriteValueByName("UserSignInStatus", SignStatus);
                            PlcOperator.WriteValueByName("UserSignInName", "---");
                        }
                       
                    }
                    Thread.Sleep(1000);
                }

            });
        }

        private void tb_Runtime_TextChanged(object sender, EventArgs e)
        {
           
            int maxLine = 500;//最大显示行数100行
            if (tb_Runtime.Lines.Length > maxLine)
            {
                tb_Runtime.Text = tb_Runtime.Text.Substring(tb_Runtime.Lines[0].Length + 1);
            }

        }
        private void tb_MES_TextChanged(object sender, EventArgs e)
        {
            
            int maxLine = 500;//最大显示行数100行
            if (tb_MES.Lines.Length > maxLine)
            {
                tb_MES.Text = tb_Runtime.Text.Substring(tb_Runtime.Lines[0].Length + 1);
            }
        }

    

        private void Btn_UserManage_Click(object sender, EventArgs e)
        {
            SetButtonEnableList(5);

            From_Usermanage form = new From_Usermanage();
            bool b = false;
            if (ExtensionGlobalUtil.RoleManage.UserManageFormPermissions == 1)
            {
                b = true;
            }
            Control_Add(form,b);
        }

        private void btn_GeneralSetting_Click(object sender, EventArgs e)
        {
            SetButtonEnableList(2);
            Form_GeneralSetting form = new Form_GeneralSetting();
            bool b = false;
            if (ExtensionGlobalUtil.RoleManage.GeneralSettingFormPermissions == 1)
            {
                b = true;
            }
            Control_Add(form,b);
        }

        private void Btn_InterFaceSetting_Click(object sender, EventArgs e)
        {
            SetButtonEnableList(3);
            Form_InterFaceSetting form = new Form_InterFaceSetting();
            bool b = false;
            if(ExtensionGlobalUtil.RoleManage.InterFaceSettingFormPermissions==1)
            {
                b = true;
            }
            Control_Add(form, b);
        }
         
       
        
        public  void AutoSignout()
        {
           
            Task.Factory.StartNew(() =>
            {
            while (ExtensionGlobalUtil.AdminTimeoutMinute > 0)
            {
                   // Console.WriteLine($"{ExtensionGlobalUtil.AdminTimeoutMinute}");
                if (DateTime.Now.Subtract(ExtensionGlobalUtil.LastOperateTime).TotalMilliseconds >= ExtensionGlobalUtil.AdminTimeoutMinute)
                {



                    if ( ExtensionGlobalUtil.LoggingStatus)
                        {
                            UserManagerment user = ExtensionGlobalUtil.CurrentUserInfo;
                            
                            LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户[{user.FullName}]已超过[{ExtensionGlobalUtil.AdminTimeoutMinute/1000}]秒未操作,已自动登出");
                            ExtensionGlobalUtil.LoggingStatus = false;
                            ExtensionGlobalUtil.CurrentUserInfo = null;
                            ExtensionGlobalUtil.RoleManage = new SQL.RoleManage();
                            
                            Form_mainPage form = new Form_mainPage();
                            SetButtonEnableList(1);
                            Control_Add(form,false);
                            Btn_Signin.BeginInvoke(new Action(() => { Btn_Signin.Enabled = true; }));
                            btn_Signout.BeginInvoke(new Action(()=>{ btn_Signout.Enabled = false; }));
                            Lab_CurrentUser.BeginInvoke(new Action(() => { Lab_CurrentUser.Text = ""; }));
                        }

                    }
                    
                    Thread.Sleep(1000);
                }
            });
          

        }
        private void DisplayPlcStatus()
        {
            bool LEDFlash=false;
            Task.Factory.StartNew(() =>
            {
              
                while (true)
                {
                    try
                    {
                        if (this.IsHandleCreated)
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                if (ProcessPLC.PlcOperator.PlcConnectStatus)
                                {
                                    if (LEDFlash)
                                    {
                                        LED_CurrentHeartBeat.Text = "Running:01";
                                        LEDFlash = false;
                                    }
                                   
                                    else
                                    {
                                        LED_CurrentHeartBeat.Text = "Running:10";
                                        LEDFlash = true;
                                    }
                                }
                                else
                                {
                                    LED_CurrentHeartBeat.Text = "----------";
                                }

                            }));
                        }
                        if (EventProcess.ThreadStop&& ProcessPLC.PlcOperator.PlcConnectStatus)
                        {
                            
                            PLCEngine.StopEngine();
                        }
                    }
                    catch { }
                    Thread.Sleep(2000);
                }
            });
        }
        private void SetButtonEnableList(int selectPage)
        {
           Btn_UserManage.BeginInvoke(new Action(()=> Btn_UserManage.Enabled = true));
           btn_GeneralSetting.BeginInvoke(new Action(()=>  btn_GeneralSetting.Enabled = true));
           Btn_InterFaceSetting.BeginInvoke(new Action(()=>  Btn_InterFaceSetting.Enabled = true));
           btn_mainpage.BeginInvoke(new Action(()=> btn_mainpage.Enabled = true));
           Btn_ParamMonitor.BeginInvoke(new Action(()=>  Btn_ParamMonitor.Enabled = true));
           Btn_check.BeginInvoke(new Action(()=>Btn_check.Enabled = true));
           Btn_PLCVariable.BeginInvoke(new Action(()=>Btn_PLCVariable.Enabled = true));
            switch(selectPage)
            {
                case 1:
                    btn_mainpage.BeginInvoke(new Action(() => btn_mainpage.Enabled = false));
                    break;
                case 2:
                    btn_GeneralSetting.BeginInvoke(new Action(() => btn_GeneralSetting.Enabled = false));
                    break;
                case 3:
                    Btn_InterFaceSetting.BeginInvoke(new Action(() => Btn_InterFaceSetting.Enabled = false));
                    break;
                case 4:
                    Btn_PLCVariable.BeginInvoke(new Action(() => Btn_PLCVariable.Enabled = false));
                    break;
                case 5:
                    Btn_UserManage.BeginInvoke(new Action(() => Btn_UserManage.Enabled = false));
                    break;
                case 6:
                    Btn_ParamMonitor.BeginInvoke(new Action(() => Btn_ParamMonitor.Enabled = false));
                    break;
                case 7:
                    Btn_check.BeginInvoke(new Action(() => Btn_check.Enabled = false));
                    break;
                default : 
                    break;
            }
        }
        private void MainFrom_Shown(object sender, EventArgs e)
        {
            AutoSignout();
            DisplayPlcStatus();
            ClockShow();
            SignStatusToPlc();
            SetButtonEnableList(1);
             Form_mainPage form = new Form_mainPage();
            Control_Add(form, false);
         
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            UserManagerment user = ExtensionGlobalUtil.CurrentUserInfo;
            LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户[{user.FullName}]已登出");
            btn_Signout.Enabled = false;
            Btn_Signin.Enabled = true;
            ExtensionGlobalUtil.LoggingStatus = false;
            ExtensionGlobalUtil.CurrentUserInfo = null;
            ExtensionGlobalUtil.RoleManage =new SQL.RoleManage();
            Lab_CurrentUser.Text = "";
            SetButtonEnableList(1);
            Form_mainPage form = new Form_mainPage();
            Control_Add(form, false);

        }

        private void Btn_Signin_Click(object sender, EventArgs e)
        {
            int AllowUserAccountLogin = 0;
            int.TryParse(AppConfig.AppConfigUtil.GetAppConfigValue("AllowUserAccountLogin"), out AllowUserAccountLogin);
            if (AllowUserAccountLogin==1)
            {
                DialogResult ret = MessageBox.Show("是否选择刷卡登录", "Notify", MessageBoxButtons.YesNoCancel);
               
                if (ret == DialogResult.Yes)
                {

                    Form_LoginForCard form_LoginForCard = new Form_LoginForCard();
                    form_LoginForCard.StartPosition = FormStartPosition.CenterScreen;
                    if (DialogResult.OK == form_LoginForCard.ShowDialog())
                    {
                        if (form_LoginForCard.bLogin)
                        {
                            if (ExtensionGlobalUtil.CurrentUserInfo != null)
                            {
                                Lab_CurrentUser.Text = ExtensionGlobalUtil.CurrentUserInfo.FullName;
                                btn_Signout.Enabled = true;
                                Btn_Signin.Enabled = false;
                                LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户[{ExtensionGlobalUtil.CurrentUserInfo.FullName}]已登录");
                            }

                        }
                        Form_mainPage form = new Form_mainPage();
                        bool b = false;
                        if (ExtensionGlobalUtil.RoleManage.MainFormPermissions == 1)
                        {
                            b = true;
                        }
                        SetButtonEnableList(1);
                        Control_Add(form, b);
                        form_LoginForCard.Dispose();

                        return;
                    }

                }
                else if (ret == DialogResult.No)
                {
                    Form_LoginFormForPassWord form_LoginFormForPassWord = new Form_LoginFormForPassWord();
                    form_LoginFormForPassWord.StartPosition = FormStartPosition.CenterScreen;
                    if (DialogResult.OK == form_LoginFormForPassWord.ShowDialog())
                    {
                        if (form_LoginFormForPassWord.bLogin)
                        {
                            if (ExtensionGlobalUtil.CurrentUserInfo != null)
                            {
                                Lab_CurrentUser.Text = ExtensionGlobalUtil.CurrentUserInfo.FullName;
                                btn_Signout.Enabled = true;
                                Btn_Signin.Enabled = false;
                                LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户[{ExtensionGlobalUtil.CurrentUserInfo.FullName}]已登录");

                            }
                        }
                    }
                    Form_mainPage form = new Form_mainPage();
                    bool b = false;
                    if (ExtensionGlobalUtil.RoleManage.MainFormPermissions == 1)
                    {
                        b = true;
                    }
                    SetButtonEnableList(1);
                    Control_Add(form, b);
                    form_LoginFormForPassWord.Dispose();
                    return;

                }
                
              
            }
            else
            {
                Form_LoginForCard form_LoginForCard = new Form_LoginForCard();
                form_LoginForCard.StartPosition = FormStartPosition.CenterScreen;
                if (DialogResult.OK == form_LoginForCard.ShowDialog())
                {
                    if (form_LoginForCard.bLogin)
                    {
                        if (ExtensionGlobalUtil.CurrentUserInfo != null)
                        {
                            Lab_CurrentUser.Text = ExtensionGlobalUtil.CurrentUserInfo.FullName;
                            btn_Signout.Enabled = true;
                            Btn_Signin.Enabled = false;
                            LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户[{ExtensionGlobalUtil.CurrentUserInfo.FullName}]已登录");
                        }

                    }
                    Form_mainPage form = new Form_mainPage();
                    bool b = false;
                    if (ExtensionGlobalUtil.RoleManage.MainFormPermissions == 1)
                    {
                        b = true;
                    }
                    SetButtonEnableList(1);
                    Control_Add(form, b);
                    form_LoginForCard.Dispose();
                }
            }
        }
        private void Btn_PLCVariable_Click(object sender, EventArgs e)
        {
            Form_Variable form = new Form_Variable();
           bool b = false;
         if (ExtensionGlobalUtil.RoleManage.PLCVariableFormPermissions==1)
            {
                b = true;
            }
            SetButtonEnableList(4);
            Control_Add(form, b);
        }

        private void MainFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ret= MessageBox.Show("即将关闭程序", "notify", MessageBoxButtons.OKCancel);
            if (ret != DialogResult.OK)
            {
                e.Cancel = true;
            }
          
        }

        private void btn_mainpage_Click(object sender, EventArgs e)
        {
            Form_mainPage form = new Form_mainPage();
            bool b = false;
            if (ExtensionGlobalUtil.RoleManage.MainFormPermissions == 1)
            {
                b = true;
            }
            SetButtonEnableList(1);
            Control_Add(form, b);
        }

        private void Btn_ParamMonitor_Click(object sender, EventArgs e)
        {
            Form_ParameterMonitor form = new Form_ParameterMonitor();
            bool b = false;
            if (ExtensionGlobalUtil.RoleManage.ParameterMonitor == 1)
            {
                b = true;
            }
            SetButtonEnableList(6);
            Control_Add(form, b);
        }

        private void Btn_check_Click(object sender, EventArgs e)
        {
            Form_Check form = new Form_Check();
            bool b = false;
            if (ExtensionGlobalUtil.RoleManage.CheckPermissions == 1)
            {
                b = true;
            }
            SetButtonEnableList(7);
            Control_Add(form, b);
        }

        private void MainFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            PLCEngine.StopEngine();
        }
    }
    }



