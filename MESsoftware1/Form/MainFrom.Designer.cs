namespace MESsoftware1
{
    partial class MainFrom
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TabCtl_Log = new System.Windows.Forms.TabControl();
            this.tpRuntime = new System.Windows.Forms.TabPage();
            this.tb_Runtime = new System.Windows.Forms.RichTextBox();
            this.tpMES = new System.Windows.Forms.TabPage();
            this.tb_MES = new System.Windows.Forms.RichTextBox();
            this.Btn_Run = new Sunny.UI.UIButton();
            this.LED_CurrentHeartBeat = new Sunny.UI.UILedDisplay();
            this.Btn_Stop = new Sunny.UI.UIButton();
            this.Panel_Menu = new Sunny.UI.UIPanel();
            this.btn_GeneralSetting = new Sunny.UI.UIButton();
            this.Btn_InterFaceSetting = new Sunny.UI.UIButton();
            this.Btn_UserManage = new Sunny.UI.UIButton();
            this.btn_Signout = new Sunny.UI.UIButton();
            this.Lab_CurrentUser = new Sunny.UI.UILabel();
            this.Btn_Signin = new Sunny.UI.UIButton();
            this.Btn_PLCVariable = new Sunny.UI.UIButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_mainpage = new Sunny.UI.UIButton();
            this.Btn_ParamMonitor = new Sunny.UI.UIButton();
            this.Btn_check = new Sunny.UI.UIButton();
            this.TabCtl_Log.SuspendLayout();
            this.tpRuntime.SuspendLayout();
            this.tpMES.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TabCtl_Log
            // 
            this.TabCtl_Log.Controls.Add(this.tpRuntime);
            this.TabCtl_Log.Controls.Add(this.tpMES);
            this.TabCtl_Log.Location = new System.Drawing.Point(-4, 509);
            this.TabCtl_Log.Name = "TabCtl_Log";
            this.TabCtl_Log.SelectedIndex = 0;
            this.TabCtl_Log.Size = new System.Drawing.Size(1271, 213);
            this.TabCtl_Log.TabIndex = 1;
            // 
            // tpRuntime
            // 
            this.tpRuntime.Controls.Add(this.tb_Runtime);
            this.tpRuntime.Location = new System.Drawing.Point(4, 22);
            this.tpRuntime.Name = "tpRuntime";
            this.tpRuntime.Padding = new System.Windows.Forms.Padding(3);
            this.tpRuntime.Size = new System.Drawing.Size(1263, 187);
            this.tpRuntime.TabIndex = 0;
            this.tpRuntime.Text = "运行日志";
            this.tpRuntime.UseVisualStyleBackColor = true;
            // 
            // tb_Runtime
            // 
            this.tb_Runtime.BackColor = System.Drawing.SystemColors.Info;
            this.tb_Runtime.Location = new System.Drawing.Point(0, 0);
            this.tb_Runtime.Name = "tb_Runtime";
            this.tb_Runtime.ReadOnly = true;
            this.tb_Runtime.Size = new System.Drawing.Size(1263, 149);
            this.tb_Runtime.TabIndex = 0;
            this.tb_Runtime.Text = "";
            this.tb_Runtime.TextChanged += new System.EventHandler(this.tb_Runtime_TextChanged);
            // 
            // tpMES
            // 
            this.tpMES.Controls.Add(this.tb_MES);
            this.tpMES.Location = new System.Drawing.Point(4, 22);
            this.tpMES.Name = "tpMES";
            this.tpMES.Padding = new System.Windows.Forms.Padding(3);
            this.tpMES.Size = new System.Drawing.Size(1263, 187);
            this.tpMES.TabIndex = 1;
            this.tpMES.Text = "MES日志";
            this.tpMES.UseVisualStyleBackColor = true;
            // 
            // tb_MES
            // 
            this.tb_MES.BackColor = System.Drawing.SystemColors.Info;
            this.tb_MES.Location = new System.Drawing.Point(0, 0);
            this.tb_MES.Name = "tb_MES";
            this.tb_MES.ReadOnly = true;
            this.tb_MES.Size = new System.Drawing.Size(1265, 149);
            this.tb_MES.TabIndex = 0;
            this.tb_MES.Text = "";
            this.tb_MES.TextChanged += new System.EventHandler(this.tb_MES_TextChanged);
            // 
            // Btn_Run
            // 
            this.Btn_Run.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_Run.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Run.FillColor = System.Drawing.Color.Ivory;
            this.Btn_Run.FillPressColor = System.Drawing.Color.GreenYellow;
            this.Btn_Run.FillSelectedColor = System.Drawing.Color.Yellow;
            this.Btn_Run.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Run.ForeColor = System.Drawing.Color.Lime;
            this.Btn_Run.Location = new System.Drawing.Point(1, 170);
            this.Btn_Run.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Run.Name = "Btn_Run";
            this.Btn_Run.Size = new System.Drawing.Size(97, 40);
            this.Btn_Run.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Run.TabIndex = 2;
            this.Btn_Run.Text = "运行";
            this.Btn_Run.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Run.Click += new System.EventHandler(this.Btn_Run_Click);
            // 
            // LED_CurrentHeartBeat
            // 
            this.LED_CurrentHeartBeat.BackColor = System.Drawing.Color.Black;
            this.LED_CurrentHeartBeat.ForeColor = System.Drawing.Color.Lime;
            this.LED_CurrentHeartBeat.Location = new System.Drawing.Point(1, 132);
            this.LED_CurrentHeartBeat.Name = "LED_CurrentHeartBeat";
            this.LED_CurrentHeartBeat.Size = new System.Drawing.Size(190, 34);
            this.LED_CurrentHeartBeat.TabIndex = 3;
            this.LED_CurrentHeartBeat.TagString = "";
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_Stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Stop.FillColor = System.Drawing.Color.White;
            this.Btn_Stop.FillDisableColor = System.Drawing.Color.Gray;
            this.Btn_Stop.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Btn_Stop.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Stop.ForeColor = System.Drawing.Color.Red;
            this.Btn_Stop.Location = new System.Drawing.Point(95, 170);
            this.Btn_Stop.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Btn_Stop.RectSelectedColor = System.Drawing.Color.Red;
            this.Btn_Stop.Size = new System.Drawing.Size(96, 40);
            this.Btn_Stop.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Stop.TabIndex = 4;
            this.Btn_Stop.Text = "停止";
            this.Btn_Stop.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click);
            // 
            // Panel_Menu
            // 
            this.Panel_Menu.Font = new System.Drawing.Font("宋体", 9F);
            this.Panel_Menu.Location = new System.Drawing.Point(192, 1);
            this.Panel_Menu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Panel_Menu.MinimumSize = new System.Drawing.Size(1, 1);
            this.Panel_Menu.Name = "Panel_Menu";
            this.Panel_Menu.Size = new System.Drawing.Size(1075, 530);
            this.Panel_Menu.TabIndex = 5;
            this.Panel_Menu.Text = null;
            this.Panel_Menu.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_GeneralSetting
            // 
            this.btn_GeneralSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_GeneralSetting.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_GeneralSetting.Location = new System.Drawing.Point(1, 269);
            this.btn_GeneralSetting.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_GeneralSetting.Name = "btn_GeneralSetting";
            this.btn_GeneralSetting.Size = new System.Drawing.Size(190, 35);
            this.btn_GeneralSetting.TabIndex = 6;
            this.btn_GeneralSetting.Text = "通用配置";
            this.btn_GeneralSetting.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_GeneralSetting.Click += new System.EventHandler(this.btn_GeneralSetting_Click);
            // 
            // Btn_InterFaceSetting
            // 
            this.Btn_InterFaceSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_InterFaceSetting.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_InterFaceSetting.Location = new System.Drawing.Point(1, 304);
            this.Btn_InterFaceSetting.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_InterFaceSetting.Name = "Btn_InterFaceSetting";
            this.Btn_InterFaceSetting.Size = new System.Drawing.Size(190, 35);
            this.Btn_InterFaceSetting.TabIndex = 7;
            this.Btn_InterFaceSetting.Text = "接口配置";
            this.Btn_InterFaceSetting.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_InterFaceSetting.Click += new System.EventHandler(this.Btn_InterFaceSetting_Click);
            // 
            // Btn_UserManage
            // 
            this.Btn_UserManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_UserManage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_UserManage.Location = new System.Drawing.Point(1, 339);
            this.Btn_UserManage.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_UserManage.Name = "Btn_UserManage";
            this.Btn_UserManage.Size = new System.Drawing.Size(190, 35);
            this.Btn_UserManage.TabIndex = 8;
            this.Btn_UserManage.Text = "用户管理";
            this.Btn_UserManage.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_UserManage.Click += new System.EventHandler(this.Btn_UserManage_Click);
            // 
            // btn_Signout
            // 
            this.btn_Signout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Signout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Signout.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Signout.Location = new System.Drawing.Point(143, 96);
            this.btn_Signout.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Signout.Name = "btn_Signout";
            this.btn_Signout.Size = new System.Drawing.Size(48, 35);
            this.btn_Signout.Style = Sunny.UI.UIStyle.Custom;
            this.btn_Signout.TabIndex = 10;
            this.btn_Signout.TagString = "注销当前用户";
            this.btn_Signout.Text = "注销";
            this.btn_Signout.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Signout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // Lab_CurrentUser
            // 
            this.Lab_CurrentUser.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_CurrentUser.Location = new System.Drawing.Point(1, 96);
            this.Lab_CurrentUser.Name = "Lab_CurrentUser";
            this.Lab_CurrentUser.Size = new System.Drawing.Size(119, 33);
            this.Lab_CurrentUser.TabIndex = 11;
            this.Lab_CurrentUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Signin
            // 
            this.Btn_Signin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Signin.FillColor = System.Drawing.Color.Aqua;
            this.Btn_Signin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Signin.Location = new System.Drawing.Point(94, 96);
            this.Btn_Signin.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Signin.Name = "Btn_Signin";
            this.Btn_Signin.Size = new System.Drawing.Size(48, 35);
            this.Btn_Signin.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Signin.TabIndex = 12;
            this.Btn_Signin.TagString = "登录";
            this.Btn_Signin.Text = "登录";
            this.Btn_Signin.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Signin.Click += new System.EventHandler(this.Btn_Signin_Click);
            // 
            // Btn_PLCVariable
            // 
            this.Btn_PLCVariable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_PLCVariable.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_PLCVariable.Location = new System.Drawing.Point(1, 374);
            this.Btn_PLCVariable.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_PLCVariable.Name = "Btn_PLCVariable";
            this.Btn_PLCVariable.Size = new System.Drawing.Size(190, 35);
            this.Btn_PLCVariable.TabIndex = 13;
            this.Btn_PLCVariable.Text = "PLC";
            this.Btn_PLCVariable.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_PLCVariable.Click += new System.EventHandler(this.Btn_PLCVariable_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::MESsoftware1.Properties.Resources.微信图片_20230628133724;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-4, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 76);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btn_mainpage
            // 
            this.btn_mainpage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_mainpage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_mainpage.Location = new System.Drawing.Point(1, 213);
            this.btn_mainpage.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_mainpage.Name = "btn_mainpage";
            this.btn_mainpage.Size = new System.Drawing.Size(190, 55);
            this.btn_mainpage.TabIndex = 15;
            this.btn_mainpage.Text = "主页";
            this.btn_mainpage.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_mainpage.Click += new System.EventHandler(this.btn_mainpage_Click);
            // 
            // Btn_ParamMonitor
            // 
            this.Btn_ParamMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_ParamMonitor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_ParamMonitor.Location = new System.Drawing.Point(1, 406);
            this.Btn_ParamMonitor.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_ParamMonitor.Name = "Btn_ParamMonitor";
            this.Btn_ParamMonitor.Size = new System.Drawing.Size(190, 43);
            this.Btn_ParamMonitor.TabIndex = 16;
            this.Btn_ParamMonitor.Text = "参数监控";
            this.Btn_ParamMonitor.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_ParamMonitor.Click += new System.EventHandler(this.Btn_ParamMonitor_Click);
            // 
            // Btn_check
            // 
            this.Btn_check.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_check.Location = new System.Drawing.Point(1, 449);
            this.Btn_check.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_check.Name = "Btn_check";
            this.Btn_check.Size = new System.Drawing.Size(190, 43);
            this.Btn_check.TabIndex = 17;
            this.Btn_check.Text = "查询";
            this.Btn_check.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_check.Click += new System.EventHandler(this.Btn_check_Click);
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.Btn_check);
            this.Controls.Add(this.Btn_ParamMonitor);
            this.Controls.Add(this.btn_mainpage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Btn_PLCVariable);
            this.Controls.Add(this.Btn_Signin);
            this.Controls.Add(this.Lab_CurrentUser);
            this.Controls.Add(this.btn_Signout);
            this.Controls.Add(this.Btn_UserManage);
            this.Controls.Add(this.Btn_InterFaceSetting);
            this.Controls.Add(this.btn_GeneralSetting);
            this.Controls.Add(this.Panel_Menu);
            this.Controls.Add(this.Btn_Stop);
            this.Controls.Add(this.LED_CurrentHeartBeat);
            this.Controls.Add(this.Btn_Run);
            this.Controls.Add(this.TabCtl_Log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainFrom";
            this.Text = "0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrom_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrom_FormClosed);
            this.Shown += new System.EventHandler(this.MainFrom_Shown);
            this.TabCtl_Log.ResumeLayout(false);
            this.tpRuntime.ResumeLayout(false);
            this.tpMES.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabCtl_Log;
        private System.Windows.Forms.TabPage tpRuntime;
        private System.Windows.Forms.RichTextBox tb_Runtime;
        private System.Windows.Forms.TabPage tpMES;
        private System.Windows.Forms.RichTextBox tb_MES;
        private Sunny.UI.UIButton Btn_Run;
        private Sunny.UI.UILedDisplay LED_CurrentHeartBeat;
        private Sunny.UI.UIButton Btn_Stop;
        private Sunny.UI.UIPanel Panel_Menu;
        private Sunny.UI.UIButton btn_GeneralSetting;
        private Sunny.UI.UIButton Btn_InterFaceSetting;
        private Sunny.UI.UIButton Btn_UserManage;
        private Sunny.UI.UIButton btn_Signout;
        private Sunny.UI.UILabel Lab_CurrentUser;
        private Sunny.UI.UIButton Btn_Signin;
        private Sunny.UI.UIButton Btn_PLCVariable;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Sunny.UI.UIButton btn_mainpage;
        private Sunny.UI.UIButton Btn_ParamMonitor;
        private Sunny.UI.UIButton Btn_check;
    }
}

