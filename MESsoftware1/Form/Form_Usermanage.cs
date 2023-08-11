using ConfigInfomation;
using EntityOfSql;
using Org.BouncyCastle.Asn1;
using SqlPart;
using SqlPart.SQL;
using SqlSugar;
using SqlSugar.Extensions;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MESsoftware1.From
{
    public partial class From_Usermanage : Form
    {
        private List<int> UserLevel = new List<int>();

        public From_Usermanage()
        {
            InitializeComponent();
        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void From_Usermanage_Load(object sender, EventArgs e)
        {
            //= MySqlCrl.SimpleDALMySql<UserManagerment>.OpDB().GetDataTable(null, null);
            // DGV_UserInfo
            DataTable rtn  =MySqlCrl.SimpleDALMySql<UserManagerment>.OpDB().FindTable("Select * from usermanagerment", null);
            if (rtn != null)
            {
             
                DGV_UserInfo.DataSource = rtn;
               
            }

           
           
        }

      
        private void DGV_UserInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex==3|| e.ColumnIndex == 2||e.ColumnIndex==1)
            {
                if (e.Value != null && e.Value.ToString().Length > 0)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }

            }
            

        }

        private void DGV_UserInfo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
        }

        private void Btn_CreateUser_Click(object sender, EventArgs e)
        {
            Form_CreatUser form_CreatUser = new Form_CreatUser();
            
            form_CreatUser.ShowDialog();
            if (form_CreatUser.CreateSuccessed)
            {
                From_Usermanage_Load(sender,e);
            }
        }

        private void Btn_DeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_UserInfo.RowCount > 0)
                {
                    string selete = DGV_UserInfo.CurrentRow.Cells[0].EditedFormattedValue.ToString();
                    DialogResult ret = MessageBox.Show($"即将删除用户:[{DGV_UserInfo.CurrentRow.Cells[5].EditedFormattedValue.ToString()}]" +
                        $",用户权限[{DGV_UserInfo.CurrentRow.Cells[4].EditedFormattedValue.ToString()}]", "Warning", MessageBoxButtons.YesNoCancel);
                    if(!ExtensionGlobalUtil.LoggingStatus)
                    {
                        MessageBox.Show("未检测到登录状态，请登陆后操作");
                        return;

                    }
                    if (ret == DialogResult.Yes)
                    {

                        bool delret = MySqlCrl.SimpleDALMySql<UserManagerment>.OpDB().DeleteById(selete.ToInt());
                        if (delret)
                        {
                            LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户:[{DGV_UserInfo.CurrentRow.Cells[5].EditedFormattedValue.ToString()}]-权限:[{DGV_UserInfo.CurrentRow.Cells[4].EditedFormattedValue.ToString()}]-已删除,执行者[{ExtensionGlobalUtil.CurrentUserInfo.FullName}]");
                            MessageBox.Show($"删除用户[{DGV_UserInfo.CurrentRow.Cells[5].EditedFormattedValue.ToString()}]成功");
                            From_Usermanage_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show($"删除用户[{DGV_UserInfo.CurrentRow.Cells[5].EditedFormattedValue.ToString()}]失败");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, "用户删除操作出现错误");
            }
          
            
        }

        private void ChangePassWord_Click(object sender, EventArgs e)
        {
            Form_ChangePassWord form_ChangePassWord= new Form_ChangePassWord(DGV_UserInfo.CurrentRow);
            form_ChangePassWord.ShowDialog();
        }

        private void Btn_RoleUser_Click(object sender, EventArgs e)
        {
         
        }

        private void DGV_UserInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (!ExtensionGlobalUtil.LoggingStatus) return;
            if (ExtensionGlobalUtil.CurrentUserInfo.Character == "管理员")
            {
                btn_ChangePassWord.Enabled = true;
                Btn_CreatUser.Enabled=true;
                Btn_DeleteUser.Enabled=true;
            }
            if(ExtensionGlobalUtil.CurrentUserInfo.Character=="OPN技师")
            {
                if (DGV_UserInfo.CurrentRow.Cells[4].Value.ToString()=="OPN操作员"||(ExtensionGlobalUtil.CurrentUserInfo.ID == DGV_UserInfo.CurrentRow.Cells[0].Value.ObjToInt()))
                {
                    btn_ChangePassWord.Enabled = true;
                   // Btn_DeleteUser.Enabled = true;
                }
                else
                {
                    btn_ChangePassWord.Enabled = false;
                   // Btn_DeleteUser.Enabled = false;
                }
                if(DGV_UserInfo.CurrentRow.Cells[4].Value.ToString() == "OPN操作员")
                {
                    Btn_DeleteUser.Enabled = true;
                }
                else
                {
                    Btn_DeleteUser.Enabled = false;
                }
                Btn_CreatUser.Enabled = true;
            }
            if(ExtensionGlobalUtil.CurrentUserInfo.Character=="ME")
            {
                
                Btn_DeleteUser.Enabled = false;
                Btn_CreatUser.Enabled = false;
                if (ExtensionGlobalUtil.CurrentUserInfo.ID == DGV_UserInfo.CurrentRow.Cells[0].Value.ObjToInt())
                {
                    btn_ChangePassWord.Enabled = true;
                }
                else
                {
                    btn_ChangePassWord.Enabled= false;
                }
            }
            if(ExtensionGlobalUtil.CurrentUserInfo.Character=="PE")
            {
               
                Btn_DeleteUser.Enabled = false;
                Btn_CreatUser.Enabled = false;
                if (ExtensionGlobalUtil.CurrentUserInfo.ID == DGV_UserInfo.CurrentRow.Cells[0].Value.ObjToInt())
                {
                    btn_ChangePassWord.Enabled = true;
                }
                else
                {
                    btn_ChangePassWord.Enabled = false;
                }
            }
            if(ExtensionGlobalUtil.CurrentUserInfo.Character == "OPN操作员")
            {
                btn_ChangePassWord.Enabled = false;
                Btn_DeleteUser.Enabled = false;
                Btn_CreatUser.Enabled = false;
            }
        }

        //private void From_Usermanage_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    if (form_ChangePassWord != null)
        //    {
        //        form_ChangePassWord.Dispose();
        //    }
        //    if (form_CreatUser != null)
        //    {
        //        form_CreatUser.Dispose();
        //    }
        //}


    }
}
