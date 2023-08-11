using MesInterface;
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
using System.IO;
using ConfigInfomation;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MESsoftware1.From
{
    public partial class Form_InterFaceSetting : Form
    {
        private MesRequestPara BatchPackRequestpara1;
        private MesRequestPara CheckBranchRequestpara;
        private MesRequestPara BatchPackRequestpara2;
        private string CheckBranchFilePath;
        private string BatchPackFilePath1;
        private string BatchPackFilePath2;
        private string LastInterFaceFilePath;
        public Form_InterFaceSetting()
        {
            InitializeComponent();

           
        }
        private void SetTextBox(MesRequestPara param)
        {
            if (param == null) return;
            cb_Enable.Checked = param.Enabled ? true : false;
            tb_interFaceName.Text = param.InterfaceName;
            tb_url.Text = param.Url;
            tb_username.Text = param.UserName;
            tb_password.Text = param.Password;
            tb_TimeOut.Text = param.TimeOut.ToString();
            tb_ReconnectTime.Text=param.TimeOutReConnectTime.ToString();
            tb_VerifyLength.Text=param.sfcLengthVerify.ToString();
            tb_VerifyHead.Text = param.sfcHeadVerify;
            tb_TImeOutRCTime.Text = param.ReConnectWaitTime.ToString();
            DGV_Param.ClearAll();
            DGV_Param.AddColumn("参数名", "key");
            DGV_Param.AddColumn("值", "value");
            DGV_Param.AddColumn("描述", "describe");
            DGV_Param.Columns[1].ReadOnly = false;
            for (int i = 0; i < param.RequestParameterList.Count; i++)
            {
                DGV_Param.AddRow(param.RequestParameterList[i].Key, param.RequestParameterList[i].Value, param.RequestParameterList[i].Description);
            }
        }
        private void Form_InterFaceSetting_Load(object sender, EventArgs e)
        {

            try
            {


                CheckBranchFilePath = AppDomain.CurrentDomain.BaseDirectory + $"Json\\micheckMarkAnddcPackForSfc.json";
                CheckBranchRequestpara = NopiHelper.Jason.ParseJsonFile<MesRequestPara>(CheckBranchFilePath);
                BatchPackFilePath1 = AppDomain.CurrentDomain.BaseDirectory + $"Json\\miAddCheckMarkAndPackForsfcBatch1.json";
                BatchPackRequestpara1 = NopiHelper.Jason.ParseJsonFile<MesRequestPara>(BatchPackFilePath1);
                BatchPackFilePath2 = AppDomain.CurrentDomain.BaseDirectory + $"Json\\miAddCheckMarkAndPackForsfcBatch2.json";
                BatchPackRequestpara2 = NopiHelper.Jason.ParseJsonFile<MesRequestPara>(BatchPackFilePath2);
                SetTextBox(CheckBranchRequestpara);
            }
            catch (Exception ex)
            {

                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex,"读取调用mes参数配置文件失败");
            }
            LastInterFaceFilePath = CheckBranchFilePath;
        }

        private void btn_AutoBranch_Click(object sender, EventArgs e)
        {
            try
            {
                SetTextBox(CheckBranchRequestpara);
                LastInterFaceFilePath = CheckBranchFilePath;
            }
            catch (Exception ex)
            {

                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, "读取调用mes参数配置文件失败");
            }
        }

        private void btn_Batchpack_Click(object sender, EventArgs e)
        {
           
            try
            {
                SetTextBox(BatchPackRequestpara1);
                LastInterFaceFilePath = BatchPackFilePath1;
            }
            catch (Exception ex)
            {

                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, "读取调用mes参数配置文件失败");
            }
        }
        private void MakeLog(MesRequestPara param, MesRequestPara SavePara)
        {
            try {
                string befor = "";
                string after = "";
                Type type = param.GetType();
                foreach (PropertyInfo p in type.GetProperties())
                {

                    //  if(p.Name=="")
                    if (p.Name == "RequestParameterList")
                    {
                        break;
                    }
                    else
                    {
                        befor += "(" + p.Name + ":";
                        befor += p.GetValue(param).ToString() + "),";
                    }
                }
                for (int i = 0; i < param.RequestParameterList.Count; i++)
                {
                    befor += "(" + param.RequestParameterList[i].Key + ":";
                    befor += param.RequestParameterList[i].Value + "),";
                }
                Type type1 = SavePara.GetType();
                foreach (PropertyInfo p in type.GetProperties())
                {
                    if (p.Name == "RequestParameterList")
                    {
                        break;
                    }
                    else
                    {
                        after += "(" + p.Name + ":";
                        after += p.GetValue(SavePara).ToString() + "),";
                    }
                }
                for (int i = 0; i < SavePara.RequestParameterList.Count; i++)
                {
                    after += "(" + SavePara.RequestParameterList[i].Key + ":";
                    after += SavePara.RequestParameterList[i].Value + "),";
                }
                LogSerilog.SerilogHelper.RuntimeInformationAsync($"MES接口配置文件修改成功,修改文件路径【{LastInterFaceFilePath}】,操作者【{ExtensionGlobalUtil.CurrentUserInfo.FullName}】,【{befor}】=>【{after}】");
            }
            catch (Exception e)
            {
                LogSerilog.SerilogHelper.RuntimeErrorAsync(e, "MES接口配置文件修改失败");
            }
             
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
     
            if (!ExtensionGlobalUtil.LoggingStatus)
            {
                MessageBox.Show("未检测到用户状态，请登录");
                return;
            }
            if (ProcessPLC.PlcOperator.PlcConnectStatus)
            {
                MessageBox.Show("处于运行状态，请停止运行进行操作");
                return;
            }
            DialogResult ret = MessageBox.Show("即将修改MES接口配置", "notify", MessageBoxButtons.YesNo);
            if (ret == DialogResult.No)
            {
                return;
            }
          
            MesRequestPara SavePara=new MesRequestPara (); 
            SavePara.Url = tb_url.Text.Trim();
            SavePara.UserName = tb_username.Text.Trim();
            SavePara.InterfaceName = tb_interFaceName.Text.Trim();
            SavePara.Enabled = cb_Enable.Checked;
            SavePara.Password=tb_password.Text.Trim();
            SavePara.TimeOut= tb_TimeOut.Text.Trim().ToInt();
           SavePara.TimeOutReConnectTime=tb_ReconnectTime.Text.Trim().ToInt();
            SavePara.sfcLengthVerify=tb_VerifyLength.Text.Trim().ToInt();
            SavePara.sfcHeadVerify = tb_VerifyHead.Text.Trim();
            SavePara.ReConnectWaitTime = tb_TImeOutRCTime.Text.Trim().ToInt();
            try
            {
                for (int i = 0; i < DGV_Param.RowCount; i++)
                {
                    RequestParameter para = new RequestParameter();
                    para.Key = DGV_Param.Rows[i].Cells[0].Value.ToString();
                    para.Value = DGV_Param.Rows[i].Cells[1].Value.ToString();
                    para.Description = DGV_Param.Rows[i].Cells[2].Value.ToString();
                    SavePara.RequestParameterList.Add(para);
                }
                string strJson = Newtonsoft.Json.JsonConvert.SerializeObject(SavePara, Newtonsoft.Json.Formatting.Indented);
              File.WriteAllText(LastInterFaceFilePath,strJson,Encoding.UTF8);

                if(LastInterFaceFilePath== CheckBranchFilePath)
                {
                    MakeLog(CheckBranchRequestpara, SavePara);
                }
                if(LastInterFaceFilePath== BatchPackFilePath1)
                {
                    MakeLog(BatchPackRequestpara1, SavePara);
                }
                if (LastInterFaceFilePath== BatchPackFilePath2)
                {
                    MakeLog(BatchPackRequestpara1, SavePara);
                }
             //   MakeLog(,SavePara);

                   // NopiHelper.Jason.ParseJsonFile<MesRequestPara>(LastInterFaceFilePath);
                Form_InterFaceSetting_Load(sender, e);

              


                //if (LastInterFaceFilePath == BatchPackFilePath)
                //{

                //    Type type = BatchPackRequestpara.GetType();
                //    foreach (PropertyInfo p in type.GetProperties())
                //    {

                //        //  if(p.Name=="")
                //        if (p.Name == "RequestParameterList")
                //        {
                //            break;
                //        }
                //        else
                //        {
                //            befor += "(" + p.Name + ":";
                //            befor += p.GetValue(BatchPackRequestpara).ToString() + "),";
                //        }
                //    }
                //    for (int i = 0; i < BatchPackRequestpara.RequestParameterList.Count; i++)
                //    {
                //        befor += "(" + BatchPackRequestpara.RequestParameterList[i].Key + ":";
                //        befor += BatchPackRequestpara.RequestParameterList[i].Value + "),";
                //    }
                //    Type type1 = SavePara.GetType();
                //    foreach (PropertyInfo p in type.GetProperties())
                //    {
                //        if (p.Name == "RequestParameterList")
                //        {
                //            break;
                //        }
                //        else
                //        {
                //            after += "(" + p.Name + ":";
                //            after += p.GetValue(SavePara).ToString() + "),";
                //        }
                //    }
                //    for (int i = 0; i < SavePara.RequestParameterList.Count; i++)
                //    {
                //        after += "(" + SavePara.RequestParameterList[i].Key + ":";
                //        after += SavePara.RequestParameterList[i].Value + "),";
                //    }
                //    BatchPackRequestpara = NopiHelper.Jason.ParseJsonFile<MesRequestPara>(BatchPackFilePath);
                //}
                ///  Form_InterFaceSetting_Load(sender, e);


            }


            catch (Exception ex)
            {

                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex,$"MES接口文件配置修改失败");
            }
            
          
        }

        private void btn_Batchpack2_Click(object sender, EventArgs e)
        {
            try
            {
                SetTextBox(BatchPackRequestpara2);
                LastInterFaceFilePath = BatchPackFilePath2;
            }
            catch (Exception ex)
            {

                LogSerilog.SerilogHelper.RuntimeErrorAsync(ex, "读取调用mes参数配置文件失败");
            }
        }
    }
}
