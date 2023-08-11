using ConfigInfomation;
using EntityOfSql;
using MESsoftware1.User;
using Org.BouncyCastle.Bcpg.OpenPgp;
using SqlPart.SQL;
using SqlSugar.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vanara.PInvoke;

namespace MESsoftware1.From
{
    public partial class Form_ChangePassWord : Form
    {
        UserManagerment userManagerment = new UserManagerment();
     //  private bool passwordFormat=false;
        private bool cardIDFormat=false;
        public Form_ChangePassWord(DataGridViewRow currentRow)
        {
            InitializeComponent();
            if (currentRow.Cells.Count == 8)
            {
                userManagerment.ID = currentRow.Cells[0].Value.ObjToInt();
                userManagerment.LoginName = currentRow.Cells[1].Value.ToString();
                userManagerment.PassWord = currentRow.Cells[2].Value.ToString();
                userManagerment.CardId = currentRow.Cells[3].Value.ToString();
                userManagerment.Character = currentRow.Cells[4].Value.ToString();
                userManagerment.FullName = currentRow.Cells[5].Value.ToString();
                userManagerment.CreatTime = currentRow.Cells[6].Value.ObjToDate();
                userManagerment.Creator= currentRow.Cells[7].Value.ToString();
            }
        
            Lab_CurrentUserName.Text =userManagerment.FullName.ToString();
            Lab_Role.Text=userManagerment.Character.ToString();
        }

        private void Form_ChangePassWord_Load(object sender, EventArgs e)
        {
           
        }

        //private void Btn_ChangePassWord_Click(object sender, EventArgs e)
        //{
        //    if (!ExtensionGlobalUtil.LoggingStatus)
        //    {
        //        MessageBox.Show("检测到当前不存在登录状态，请重新登录");
        //        this.Close();

        //        return;
        //    }
        //    if (tb_NewPassWord.Text == "")
        //    {
        //        toolTip_NewPassWord.Show("密码不能为空", tb_NewPassWord);
        //        return;
        //    }
        //    if(!passwordFormat)
        //    {
        //        toolTip_NewPassWord.Show("输入8-16位由英文，数字，符号，组成的密码，必须包含数字,字母或字符中的两种", tb_NewPassWord);
        //        return;
        //    }
        //    userManagerment.CardId=userManagerment.PassWord=userManagerment.LoginName= MD5Helper.EnCode(tb_NewPassWord.Text.Trim());
            
        //    bool ret=MySqlCrl.SimpleDALMySql<UserManagerment>.OpDB().Update(userManagerment);
        //   if (ret)
        //    {
        //        LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户[{userManagerment.FullName}]密码已被修改,执行者[{ExtensionGlobalUtil.CurrentUserInfo.FullName}]");
        //        MessageBox.Show($"用户[{userManagerment.FullName}]密码已被修改,执行者[{ExtensionGlobalUtil.CurrentUserInfo.FullName}]");
               
        //    }
        //   else
        //    {
        //        MessageBox.Show($"用户[{userManagerment.FullName}]密码修改失败");
        //    }

        //}

        private void Btn_ChangeCardID_Click(object sender, EventArgs e)
        {
            if (!ExtensionGlobalUtil.LoggingStatus)
            {
                MessageBox.Show("检测到当前不存在登录状态，请重新登录");
                this.Close();

                return;
            }
            if (tb_NewCardID.Text == "")
            {
                toolTip_NewCard.Show("卡号不能为空", tb_NewCardID);
                return;
            }
            if (!cardIDFormat)
            {
                toolTip_NewCard.Show("请使用刷卡器输入卡号", tb_NewCardID);
                return;
            }
            string Encoded = MD5Helper.EnCode(tb_NewCardID.Text.Trim());
            userManagerment.CardId = userManagerment.PassWord = userManagerment.LoginName = MD5Helper.EnCode(tb_NewCardID.Text.Trim());
            bool ret=MySqlCrl.SimpleDALMySql<UserManagerment>.OpDB().Update(userManagerment);
            if (ret)
            {
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户[{userManagerment.FullName}]卡号已被修改,执行者{ExtensionGlobalUtil.CurrentUserInfo.FullName}");
                MessageBox.Show($"用户[{userManagerment.FullName}]卡号已被修改,执行者{ExtensionGlobalUtil.CurrentUserInfo.FullName}");
               
            }
        }

        //private void tb_NewPassWord_TextChanged(object sender, EventArgs e)
        //{
      
        //   // const string PASSWORD_STRENGTH_2 = @"(?!.*\s)(?!^[\u4e00-\u9fa5]+$)(?!^[0-9]+$)(?!^[A-z]+$)(?!^[^A-z0-9]+$)^.{8,16}$";
        //   const string PASSWORD_STRENGTH_2 = @"(?=.*[0-9]+$).{10,10}$";
        //    bool ret = Regex.IsMatch(tb_NewPassWord.Text, PASSWORD_STRENGTH_2);
        //    if (!ret) { tb_NewPassWord.RectColor = Color.Red; tb_NewPassWord.ForeColor = Color.Red; passwordFormat = false; }
        //    else { tb_NewPassWord.RectColor = Color.Green; tb_NewPassWord.ForeColor = Color.Green; passwordFormat = true; }
        //}

        private void tb_NewCardID_TextChanged(object sender, EventArgs e)
        {

         
            bool ret = Regex.IsMatch(tb_NewCardID.Text, @"(?=.*[0-9]+$).{10,10}$");
            if (!ret)
            {
                tb_NewCardID.ForeColor = Color.Red;
                tb_NewCardID.RectColor = Color.Red;
                cardIDFormat = false;
            }
            else
            {
                tb_NewCardID.ForeColor = Color.Green;
                tb_NewCardID.RectColor = Color.Green;
                cardIDFormat = true;

            }
        }
    }
}