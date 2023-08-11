using EntityOfSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SqlPart.SQL.MySqlCrl;
using ConfigInfomation;
using MESsoftware1.SQL;

namespace MESsoftware1.From
{
    public partial class Form_LoginFormForPassWord : Form
    {
        public bool bLogin = false;
        public Form_LoginFormForPassWord()
        {
            InitializeComponent();
        }

        private void Btn_Loggin_Click(object sender, EventArgs e)
        {
 #region 检查验证
            if (tb_Account.Text.Trim() == "")
            {
                tb_Account.Enabled = true;
                MessageBox.Show("请输入用户名");
                return;
            }
            if (tb_Pwd.Text.Trim() == "")
            {
                tb_Pwd.Enabled = true;
                MessageBox.Show("请输入密码");
                return;
            }
#endregion
            try
            {
                string password =tb_Pwd.Text.Trim();    
                string logName = tb_Account.Text.Trim();
                bool rtn = SimpleDALMySql<UserManagerment>.OpDB().ExistAny(x => x.LoginName == logName && x.PassWord == password);//验证账号密码
                if (rtn)
                {
                    //获取登录信息
                    UserManagerment userInfo = SimpleDALMySql<UserManagerment>.OpDB().GetFirstObj(x => x.LoginName == logName);
                    if (userInfo == null || string.IsNullOrEmpty(userInfo.LoginName))
                    {
                        LogSerilog.SerilogHelper.RuntimeInformationAsync($"未找到{logName}相应的角色,软件无法运行。一个用户必须配置一个角色");
                        MessageBox.Show($"未找到{logName}相应的角色,软件无法运行。一个用户必须配置一个角色");
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
                    Btn_Loggin.Enabled = true;
                    LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户或密码错误,请检查后重新输入!");
                    MessageBox.Show("用户或密码错误,请检查后重新输入!");
                    return;
                }
            }
            catch (Exception ex)
            {
                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, "登录失败");
                MessageBox.Show("登录失败:" + ex.Message);
            }
        }

        private void Form_LoginFormForPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_Loggin_Click(sender, e);
            }
        }

        private void tb_Pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_Loggin_Click(sender, e);
            }
        }
    }
}
