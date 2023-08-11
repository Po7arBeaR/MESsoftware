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
    public partial class Form_mainPage : Form
    {
      
        public Form_mainPage()
        {
            InitializeComponent();
        }
        
       

        private void Form_mainPage_Load(object sender, EventArgs e)
        {

        }

        private void Btn_DEBUGPage_Click(object sender, EventArgs e)
        {
            Form_DEBUG form = new Form_DEBUG();
            form.ShowDialog();
        }
    }
}
