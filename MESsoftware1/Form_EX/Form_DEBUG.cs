using MESsoftware1.DEBUG;
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
    public partial class Form_DEBUG : Form
    {
        private static bool IsClick;
        public Form_DEBUG()
        {
            InitializeComponent();
            if (IsClick )
            {
                Btn_DEBUG_MODE.Text = "调试模式已启动";
              Btn_DEBUG_MODE.FillColor = Color.Orange;
               
            }
            else
            {
                 Btn_DEBUG_MODE.Text = "调试模式";
               Btn_DEBUG_MODE.FillColor = Color.Green;
            }
            tb_BranchFirst.Text=DEBUGFORPLC.Branch.ToString();
            tb_Batch.Text=DEBUGFORPLC.Batch.ToString();
        }

        private void Btn_DEBUG_MODE_Click(object sender, EventArgs e)
        {
            IsClick = !IsClick;
            if (IsClick)
            {
                Btn_DEBUG_MODE.Text = "调试模式已启动";
               Btn_DEBUG_MODE.FillColor = Color.Orange;
                DEBUGFORPLC._DEBUG_MODE = true;
                DEBUGFORPLC.Branch = tb_BranchFirst.Text.ToShort();

                DEBUGFORPLC.Batch = tb_Batch.Text.ToShort();
            }
            else
            {
                Btn_DEBUG_MODE.Text = "调试模式";
                Btn_DEBUG_MODE.FillColor = Color.Green;
                DEBUGFORPLC._DEBUG_MODE = false;
                DEBUGFORPLC.Branch = 0;
                DEBUGFORPLC.Batch = 0;
            }
        }
    }
}
