using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SqlPart.SQL;
using static SqlPart.SQL.MySqlCrl;
using EntityOfSql;
using ConfigInfomation;
using MESsoftware1.SQL;
using MESsoftware1.User;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace MESsoftware1
{
    public partial class Form_LoginForCard : Form
    {

        public bool bLogin = false;
        private DateTime _dt = DateTime.Now;
        private KeyboardHookListener _inputListener;
        private string m_cardId = "";
        private DateTime tempDt=DateTime.Now;
        private System.Timers.Timer m_timer=new System.Timers.Timer();
       
        public Form_LoginForCard()
        {
            InitializeComponent();
            _inputListener=  new KeyboardHookListener(new AppHooker());
            _inputListener.KeyDown += OnKeyDown;
            _inputListener.Start();
            m_timer.Interval = 1000;
            m_timer.Elapsed += M_timer_Elapsed;
        }

        private void M_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            LogSerilog.SerilogHelper.RuntimeInformationAsync($"输入间隔超过1秒，判断为手动输入!");
            m_cardId = "";
            m_timer.Stop();
           
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    m_timer.Stop ();
                    m_cardId = m_cardId.Replace("D", string.Empty);
                    string cardId = m_cardId;
                    cardId = MD5Helper.EnCode(cardId);
                    bool rtn = SimpleDALMySql<UserManagerment>.OpDB().ExistAny(x => x.CardId == cardId);//验证账号密码
                    if (rtn)
                    {
                        //获取登录信息
                        UserManagerment userInfo = SimpleDALMySql<UserManagerment>.OpDB().GetFirstObj(x => x.CardId == cardId);
                        if (userInfo == null || string.IsNullOrEmpty(userInfo.FullName))
                        {
                            LogSerilog.SerilogHelper.RuntimeInformationAsync($"未找到相应的角色,软件无法运行。一个用户必须配置一个角色");
                            //   MessageBox.Show($"未找到相应的角色,软件无法运行。一个用户必须配置一个角色");
                            return;
                        }
                        ExtensionGlobalUtil.CurrentUserInfo = userInfo;
                        ExtensionGlobalUtil.LoggingStatus = true;
                        this.DialogResult = DialogResult.OK;//获取登录信息
                        bLogin = true;
                        LogSerilog.SerilogHelper.RuntimeInformationAsync($"登录成功:用户{userInfo.FullName}，权限：{userInfo.Character}");
                        ExtensionGlobalUtil.RoleManage = SimpleDALMySql<RoleManage>.OpDB().GetFirstObj(x => x.RoleName == userInfo.Character);
                    }
                    else
                    {
                        //  btnLogin.Enabled = true;
                        m_cardId = "";
                        LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户或密码错误,请检查后重新输入!");
                        //  MessageBox.Show("用户或密码错误,请检查后重新输入!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, "登录失败");
                    MessageBox.Show("登录失败:" + ex.Message);

                }
            }
            //   _dt = DateTime.Now;
            tempDt = DateTime.Now;          //保存按键按下时刻的时间点
            TimeSpan ts = tempDt.Subtract(_dt);     //获取时间间隔
            if (m_cardId.Length > 0)
            {
                if (ts.TotalMilliseconds > 100)                           //判断时间间隔，如果时间间隔大于50毫秒，则将TextBox清空
                {
                    // tempDt = DateTime.Now;
                    m_cardId = "";
                    // Console.WriteLine("1111");
                    // MessageBox.Show("请使用刷卡器登录");
                    LogSerilog.SerilogHelper.RuntimeInformationAsync($"请使用刷卡器登录!");
                    return;
                }

            }
            m_cardId += e.KeyCode.ToString();
            if (m_cardId.Length == 1 || (m_cardId.Length == 2 && m_cardId[0]=='D'))
            {
                Console.WriteLine("timerstart");
                m_timer.Start();
            }
            //    Console.WriteLine(m_cardId);
            _dt = tempDt;
        }
        //private void tb_LoginFromCard_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyCode == Keys.Enter)
        //    {
        //        try
        //        {
        //            string cardId = tb_LoginFromCard.Text.Trim();
        //            cardId=MD5Helper.EnCode(cardId);
        //            bool rtn = SimpleDALMySql<UserManagerment>.OpDB().ExistAny(x => x.CardId == cardId);//验证账号密码
        //            if (rtn)
        //            {
        //                //获取登录信息
        //                UserManagerment userInfo = SimpleDALMySql<UserManagerment>.OpDB().GetFirstObj(x => x.CardId == cardId);
        //                if (userInfo == null || string.IsNullOrEmpty(userInfo.FullName))
        //                {
        //                    LogSerilog.SerilogHelper.RuntimeInformationAsync($"未找到相应的角色,软件无法运行。一个用户必须配置一个角色");
        //                    MessageBox.Show($"未找到相应的角色,软件无法运行。一个用户必须配置一个角色");
        //                    return;
        //                }
        //                ExtensionGlobalUtil.CurrentUserInfo = userInfo;
        //                ExtensionGlobalUtil.LoggingStatus = true;
        //                this.DialogResult = DialogResult.OK;//获取登录信息
        //                bLogin = true;
        //                LogSerilog.SerilogHelper.RuntimeInformationAsync($"登录成功:用户{userInfo.FullName}，权限：{userInfo.Character}");
        //                ExtensionGlobalUtil.RoleManage = SimpleDALMySql<RoleManage>.OpDB().GetFirstObj(x => x.RoleName == userInfo.Character);
        //            }
        //            else
        //            {
        //                //  btnLogin.Enabled = true;
        //                LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户或密码错误,请检查后重新输入!");
        //                MessageBox.Show("用户或密码错误,请检查后重新输入!");
        //                return;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, "登录失败");
        //            MessageBox.Show("登录失败:" + ex.Message);
                   
        //        }
        //    }
        //  //  _dt = DateTime.Now;
        //    DateTime tempDt = DateTime.Now;          //保存按键按下时刻的时间点
        //    TimeSpan ts = tempDt.Subtract(_dt);     //获取时间间隔
        //    if(tb_LoginFromCard.Text.Length > 0 )
        //    if (ts.TotalMilliseconds > 100)                           //判断时间间隔，如果时间间隔大于50毫秒，则将TextBox清空
        //    {
        //        MessageBox.Show("请使用刷卡器登录");
        //        tb_LoginFromCard.Text = "";
        //    }
        //    _dt = tempDt;
        //    // MessageBox.Show("请使用刷卡器登录");
        //    //  tb_LoginFromCard.Text = "";
        //}

        private void Form_LoginForCard_Load(object sender, EventArgs e)
        {

        }

        private void Form_LoginForCard_KeyPress(object sender, KeyPressEventArgs e)
        {
          //  Console.WriteLine(e.KeyChar);
        }

   

        private void Form_LoginForCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("hello");
            _inputListener.KeyDown -= OnKeyDown;
            _inputListener.Dispose();
        }
    }
}
