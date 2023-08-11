using EntityOfSql;
using MESsoftware1.SQL;
using SqlPart.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESsoftware1.Form_EX
{
    public partial class Form_Check : Form
    {
        public Form_Check()
        {
            InitializeComponent();
            dtp_StartTime.Value=DateTime.Now.AddDays(-1);
            dtp_EndTime.Value = DateTime.Now;
           // dgv_DataTable.AutoGenerateColumns = false;

        }

        private async void Btn_Check_Click(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
          await  Task.Run(() =>
            {
                if (tb_CheckWithCode.Text.Trim() == "")
                {
                    dt = MySqlCrl.SimpleDALMySql<HistoryData>.OpDB().GetDataTable(m => m.CreateTime >= dtp_StartTime.Value && m.CreateTime <= dtp_EndTime.Value);
                }
                else
                {
                    dt = MySqlCrl.SimpleDALMySql<HistoryData>.OpDB().GetDataTable(m => m.CreateTime >= dtp_StartTime.Value && m.CreateTime <= dtp_EndTime.Value && m.sfc == tb_CheckWithCode.Text.Trim());
                }

               dgv_DataTable.BeginInvoke(new Action(()=>dgv_DataTable.DataSource = dt));
               lab_Count.BeginInvoke(new Action(()=> lab_Count.Text = $"{dgv_DataTable.RowCount}"));
            });
          
        }
    }
}
