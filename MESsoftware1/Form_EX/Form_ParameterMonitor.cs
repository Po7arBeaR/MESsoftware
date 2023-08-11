using ConfigInfomation;
using EntityOfSql;
using MESsoftware1.From;
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
    public partial class Form_ParameterMonitor : Form
    {
        public Form_ParameterMonitor()
        {
            InitializeComponent();
        }

        private void Form_ParameterMonitor_Load(object sender, EventArgs e)
        {
            DataTable rtn = MySqlCrl.SimpleDALMySql<plclogparammap>.OpDB().FindTable("Select * from plclogparammap", null);
            if (rtn != null)
            {

                DGV_PLCParaMap.DataSource = rtn;

            }
           
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            Form_AddParameter form=new Form_AddParameter();
            form.ShowDialog();
            if(form.CreateSuccess)
            {
                Form_ParameterMonitor_Load(sender, e);
            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_PLCParaMap.RowCount > 0)
                {
                    string selete = DGV_PLCParaMap.CurrentRow.Cells[0].EditedFormattedValue.ToString();
                    DialogResult ret = MessageBox.Show($"即将删除监控配置 序号:[{DGV_PLCParaMap.CurrentRow.Cells[0].EditedFormattedValue.ToString()}]" +
                        $",描述[{DGV_PLCParaMap.CurrentRow.Cells[4].EditedFormattedValue.ToString()}]", "Warning", MessageBoxButtons.YesNoCancel);
                    if (!ExtensionGlobalUtil.LoggingStatus)
                    {
                        MessageBox.Show("未检测到登录状态，请登陆后操作");
                        return;

                    }
                    if (ret == DialogResult.Yes)
                    {

                        bool delret = MySqlCrl.SimpleDALMySql<plclogparammap>.OpDB().DeleteById(selete.ToInt());
                        if (delret)
                        {
                            LogSerilog.SerilogHelper.RuntimeInformationAsync($"监控配置 序号:[{DGV_PLCParaMap.CurrentRow.Cells[0].EditedFormattedValue.ToString()}]-描述:[{DGV_PLCParaMap.CurrentRow.Cells[4].EditedFormattedValue.ToString()}]-已删除,执行者[{ExtensionGlobalUtil.CurrentUserInfo.FullName}]");
                            MessageBox.Show($"监控配置 序号[{DGV_PLCParaMap.CurrentRow.Cells[0].EditedFormattedValue.ToString()}]成功");
                            Form_ParameterMonitor_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show($"监控配置[{DGV_PLCParaMap.CurrentRow.Cells[0].EditedFormattedValue.ToString()}]失败");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, "删除操作出现错误");
            }
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            Form_ChangeParameter form = new Form_ChangeParameter(DGV_PLCParaMap.CurrentRow);
            form.ShowDialog();
            if (form.ChangeSuccess)
            {
                Form_ParameterMonitor_Load(sender, e);
            }
        }

        private void btn_Flash_Click(object sender, EventArgs e)
        {
            Form_ParameterMonitor_Load(sender, e);
        }
    }
}
