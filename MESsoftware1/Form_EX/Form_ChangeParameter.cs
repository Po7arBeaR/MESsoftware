using ConfigInfomation;
using EntityOfSql;
using MESsoftware1.SQL;
using NPOI.Util;
using SqlPart.SQL;
using SqlSugar.Extensions;
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
    public partial class Form_ChangeParameter : Form
    {
        public bool ChangeSuccess=false;
        private plclogparammap m_plclogparammap=new plclogparammap();
        public Form_ChangeParameter(DataGridViewRow currentRow)
        {
            InitializeComponent();
            m_plclogparammap.ID = currentRow.Cells[0].Value.ObjToInt();
            m_plclogparammap.DB = currentRow.Cells[1].Value.ToString();
            m_plclogparammap.Address = currentRow.Cells[2].Value.ObjToInt();
            m_plclogparammap.Type = currentRow.Cells[3].Value.ToString();
            m_plclogparammap.Description = currentRow.Cells[4].Value.ToString();
            m_plclogparammap.CurrentValue = currentRow.Cells[5].Value.ToString();
            m_plclogparammap.LastValue = currentRow.Cells[6].Value.ToString();
            m_plclogparammap.ChangeTime = currentRow.Cells[7].Value.ToString().ToDateTime();
            cb_Type.Items.AddRange(new object[] {"Int","Real" });
        }

        private void Form_ChangeParameter_Load(object sender, EventArgs e)
        {
            Lab_ID.Text=m_plclogparammap.ID.ToString();
            tb_DB.Text=m_plclogparammap.DB.Substring(2);
            tb_Address.Text=m_plclogparammap.Address.ToString();
            tb_DIscription.Text = m_plclogparammap.Description;

        }

        private void btn_Change_Click(object sender, EventArgs e)
        {
            if (!ExtensionGlobalUtil.LoggingStatus)
            {
                MessageBox.Show("检测到当前不存在登录状态，请重新登录");
                this.Close();
                return;
            }
            if (tb_DB.Text == string.Empty || tb_Address.Text == string.Empty || tb_DIscription.Text == string.Empty || cb_Type.Text == string.Empty)
            {
                MessageBox.Show("内容不能留空");
                return;
            }
            plclogparammap tempForLog ;
            tempForLog= m_plclogparammap.Copy();

            string str4Log = $"序号[{m_plclogparammap.ID}]";
            m_plclogparammap.DB = "DB"+tb_DB.Text;
            m_plclogparammap.Address=tb_Address.Text.ToInt();
            m_plclogparammap.Description=tb_DIscription.Text;
            m_plclogparammap.Type=cb_Type.Text;
            bool ret = MySqlCrl.SimpleDALMySql<plclogparammap>.OpDB().Update(m_plclogparammap);
            if(m_plclogparammap.DB!=tempForLog.DB)
            {
                str4Log += $"DB:[{tempForLog.DB}]=>[{m_plclogparammap.DB}]";
            }
            if(m_plclogparammap.Address!=tempForLog.Address)
            {
                str4Log += $"地址:[{tempForLog.Address}]=>[{m_plclogparammap.Address}]";
            }
            if(m_plclogparammap.Description!=tempForLog.Description)
            {
                str4Log += $"描述:[{tempForLog.Description}]=>[{m_plclogparammap.Description}]";
            }
            if(m_plclogparammap.Type!=tempForLog.Type)
            {
                str4Log += $"类型:[{tempForLog.Type}]=>[{m_plclogparammap.Type}]";
            }
            if (ret)
            {
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"用户:[{ExtensionGlobalUtil.CurrentUserInfo.FullName}]-权限:[{ExtensionGlobalUtil.CurrentUserInfo.Character}]-修改PLC监控地址成功{str4Log} ");
                MessageBox.Show($"用户:[{ExtensionGlobalUtil.CurrentUserInfo.FullName} ],权限:[ {ExtensionGlobalUtil.CurrentUserInfo.Character} ]-修改PLC监控地址成功 {str4Log}");
                this.Close();
            }
            ChangeSuccess = true;

        }
    }
}
