using ConfigInfomation;
using EntityOfSql;
using MESsoftware1.SQL;
using SqlPart.SQL;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESsoftware1.Form_EX
{
    public partial class Form_AddParameter : Form
    {
        public bool CreateSuccess=false;
        public Form_AddParameter()
        {
            InitializeComponent();
            cb_Type.Items.AddRange(new object[] {"Int","Real" });
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if(!ExtensionGlobalUtil.LoggingStatus)
            {
                MessageBox.Show("检测到当前不存在登录状态，请重新登录");
                this.Close();
                return;
            }
            if(tb_DB.Text==string.Empty||tb_Address.Text==string.Empty||tb_Discription.Text==string.Empty||cb_Type.Text==string.Empty)
            {
                MessageBox.Show("内容不能留空");
                return;
            }
            plclogparammap plclogparammap = new plclogparammap();
            plclogparammap.DB="DB"+tb_DB.Text.ToString();
            plclogparammap.Address=tb_Address.Text.ToInt();
            plclogparammap.Description=tb_Discription.Text.ToString();
            plclogparammap.Type=cb_Type.Text.ToString();
            plclogparammap.ChangeTime=DateTime.Now;
            plclogparammap.CurrentValue = "0";
            plclogparammap.LastValue = "0";
            bool ret = MySqlCrl.SimpleDALMySql<plclogparammap>.OpDB().Insert(plclogparammap);
            if (ret)
            {  
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户:[{ExtensionGlobalUtil.CurrentUserInfo.FullName}]-权限:[{ExtensionGlobalUtil.CurrentUserInfo.Character}]-创建PLC参数监控成功 DB:[{plclogparammap.DB}] 地址:[{plclogparammap.Address}]数据类型[{plclogparammap.Type}] 描述[{plclogparammap.Description}]");
                MessageBox.Show($"用户:[{ExtensionGlobalUtil.CurrentUserInfo.FullName} ],权限:[ {ExtensionGlobalUtil.CurrentUserInfo.Character} ]-创建PLC参数监控成功 DB:[ {plclogparammap.DB} ] 地址:[ {plclogparammap.Address} ]数据类型[ {plclogparammap.Type} ] 描述[ {plclogparammap.Description}]");
                this.Close();
                CreateSuccess = true;
            }
        }
    }
}
