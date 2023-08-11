using ConfigInfomation;
using EntityOfSql;
using SqlPart.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MESsoftware1.User;
//using static Vanara.PInvoke.User32;

namespace MESsoftware1.From
{
    public partial class Form_CreatUser : Form
    {
        private bool usernameFormat=false;
        //private bool passwordFormat=false;
        //private bool accountFormat = false;
        private bool cardIDFormat=false;
        public bool CreateSuccessed = false;
        public Form_CreatUser()
        {
          
            InitializeComponent();
            if (!ExtensionGlobalUtil.LoggingStatus) return;
           if(ExtensionGlobalUtil.CurrentUserInfo.Character=="管理员")
              cb_Role.Items.AddRange(new object[] {
            "管理员",
            "PE",
            "ME",
            "OPN技师",
            "OPN操作员"});
           if(ExtensionGlobalUtil.CurrentUserInfo.Character == "OPN技师")
            {
                cb_Role.Items.AddRange(new object[] {
            "OPN操作员"});
            }
        }

 
        private void Btn_CreatUser_Click(object sender, EventArgs e)
        {
            bool CreatCondition = true;
            if (!ExtensionGlobalUtil.LoggingStatus)
            {
                MessageBox.Show("检测到当前不存在登录状态，请重新登录");
                this.Close(); 
                
                return;
            }
            if (cb_Role.Text=="")
            {
                //toolTip_Role
                toolTip_Role.Show("请为用户指定一个权限身份", cb_Role);
                CreatCondition= false;


            }
            //if(tb_Account.Text=="")
            //{
            //    toolTip_Account.Show("登录账号不能为空", tb_Account);
            //    CreatCondition = false;
            //}
            if (tb_CardID.Text=="")
            {
                toolTip_CardID.Show("卡号不能为空", tb_CardID);
                CreatCondition = false;
            }
            if(tb_Username.Text=="")
            {
                toolTip_UserName.Show("用户名不能为空", tb_Username);
                CreatCondition = false;
            }
            //if(tb_PassWord.Text=="")
            //{
            //    toolTip_PassWord.Show("密码不能为空", tb_PassWord);
            //    CreatCondition = false;
            //}
            if(!CreatCondition|! usernameFormat | !cardIDFormat/*| !passwordFormat|!accountFormat*/) { return; }
            
            UserManagerment userInfo = new UserManagerment();
            userInfo.Character=cb_Role.Text;
          //MD5Helper.EnCode(tb_PassWord.Text.Trim());
            userInfo.CreatTime = DateTime.Now;
          // MD5Helper.EnCode(tb_Account.Text.Trim());
            userInfo.FullName=tb_Username.Text;
            userInfo.Creator = ExtensionGlobalUtil.CurrentUserInfo.FullName;
            userInfo.LoginName = userInfo.PassWord = userInfo.CardId= MD5Helper.EnCode(tb_CardID.Text.Trim());
           bool ret= MySqlCrl.SimpleDALMySql<UserManagerment>.OpDB().Insert(userInfo);
            if (ret)
            {
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户:[{userInfo.FullName}]-权限:[{userInfo.Character}]-创建成功,创建人[{userInfo.Creator}]");
                MessageBox.Show($"用户:[{userInfo.FullName}],权限:[{userInfo.Character}]-创建成功,创建人[{userInfo.Creator}]");
                this.Close();
                CreateSuccessed = true;

            }
        }

        private void tb_Username_Click(object sender, EventArgs e)
        {
           
        }

        private void tb_Username_Enter(object sender, EventArgs e)
        {
            Lab_UserName.Text = "请输入不超过16位由中文和英文或数字组成的用户名";
        }

        private void tb_Username_Leave(object sender, EventArgs e)
        {
            Lab_UserName.Text = "";

        }

       // private void tb_Account_Enter(object sender, EventArgs e)
       // {
       //     Lab_Account.Text = "请输入10位由数字组成的卡号作为账号";
       ////     Regex.Match();
       // }

       // private void tb_Account_Leave(object sender, EventArgs e)
       // {
       //     Lab_Account.Text = "";
       // }

     

       // private void tb_PassWord_Enter(object sender, EventArgs e)
       // {
       //     Lab_PassWord.Text = "请输入10位由数字组成的卡号作位密码";
       // }


        private void tb_CardID_Leave(object sender, EventArgs e)
        {
            Lab_CardID.Text = "";
        }

        //private void tb_PassWord_Leave(object sender, EventArgs e)
        //{
        //    Lab_PassWord.Text = "";
        //}

        private void tb_CardID_Enter(object sender, EventArgs e)
        {
            Lab_CardID.Text = "请使用刷卡器录入卡号";
        }

        //private void tb_Account_TextChanged(object sender, EventArgs e)
        //{
        ////  bool ret=  Regex.IsMatch(tb_Account.Text, @"(?=.*[a-zA-Z0-9]+$).{8,16}$");
        //    bool ret = Regex.IsMatch(tb_Account.Text, @"(?=.*[0-9]+$).{10,10}$");
        //    if (!ret) {
        //        accountFormat = false;
        //        Lab_Account.ForeColor = Color.Red;
        //        tb_Account.RectColor = Color.Red; 
        //    }
        //    else
        //    {
        //        accountFormat = true;
        //        Lab_Account.ForeColor= Color.Green; 
        //        tb_Account.RectColor = Color.Green;
        //    }
        //}
        ///(?!.*\s)(?!^[\u4e00-\u9fa5]+$)(?!^[0-9]+$)(?!^[A-z]+$)(?!^[^A-z0-9]+$)^.{8,16}$/
        //private void tb_PassWord_TextChanged(object sender, EventArgs e)//(?=(.*[a-z]))(?=(.*[A-Z]))(?=(.*\d))[A-Za-z\d@!%*#?&,.+-S*$].{8,16}$
        //{
        //    //const string PASSWORD_STRENGTH_2 = @"(?!.*\s)(?!^[\u4e00-\u9fa5]+$)(?!^[0-9]+$)(?!^[A-z]+$)(?!^[^A-z0-9]+$)^.{8,16}$";
        //    const string PASSWORD_STRENGTH_2 = @"(?=.*[0-9]+$).{10,10}$";
        //    bool ret = Regex.IsMatch(tb_PassWord.Text, PASSWORD_STRENGTH_2);
        //    if (!ret) { tb_PassWord.RectColor = Color.Red; Lab_PassWord.ForeColor = Color.Red; passwordFormat = false; }
        //    else { tb_PassWord.RectColor = Color.Green; Lab_PassWord.ForeColor = Color.Green; passwordFormat = true; }
        //}

        private void tb_Username_TextChanged(object sender, EventArgs e)
        {
             
            bool ret = ((tb_Username.Text != "") && (Regex.IsMatch(tb_Username.Text, @"^[\u4e00-\u9fa5_a-zA-Z0-9]+$")));
            //^[^\s]*$
            if (!ret)
            {
                Lab_UserName.ForeColor = Color.Red;
                tb_Username.RectColor = Color.Red;
                usernameFormat = false;
            }
            else
            {
                Lab_UserName.ForeColor = Color.Green;
                tb_Username.RectColor = Color.Green;
                usernameFormat = true;
            }
        }

        private void tb_CardID_TextChanged(object sender, EventArgs e)
        {
          bool ret=  Regex.IsMatch(tb_CardID.Text, @"(?=.*[0-9]+$).{10,10}$");
            if (!ret) 
            {
                Lab_CardID.ForeColor = Color.Red;
                tb_CardID.RectColor = Color.Red;
                cardIDFormat = false;
            }
            else
            {
                Lab_CardID.ForeColor = Color.Green;
                tb_CardID.RectColor = Color.Green;
                cardIDFormat = true;

            }
        }
    }
}
