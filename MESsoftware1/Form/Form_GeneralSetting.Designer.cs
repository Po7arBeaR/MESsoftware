namespace MESsoftware1.From
{
    partial class Form_GeneralSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.iptb_PLCAddress = new Sunny.UI.UIIPTextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.tb_port = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.tb_AutoSignOutTime = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.tb_SqlConfig = new Sunny.UI.UITextBox();
            this.ui_Save = new Sunny.UI.UIButton();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.tb_programName = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.Lab_FilePath = new Sunny.UI.UILabel();
            this.fbd_BranchPath = new System.Windows.Forms.FolderBrowserDialog();
            this.fbd_BatchPath = new System.Windows.Forms.FolderBrowserDialog();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.lab_BranchLogPath = new Sunny.UI.UILabel();
            this.lab_BatchLogPath = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.btn_BranchLogPath = new System.Windows.Forms.Button();
            this.btn_BatchPackLogPath = new System.Windows.Forms.Button();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.tb_FormName = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // iptb_PLCAddress
            // 
            this.iptb_PLCAddress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.iptb_PLCAddress.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.iptb_PLCAddress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iptb_PLCAddress.Location = new System.Drawing.Point(151, 77);
            this.iptb_PLCAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.iptb_PLCAddress.MinimumSize = new System.Drawing.Size(1, 1);
            this.iptb_PLCAddress.Name = "iptb_PLCAddress";
            this.iptb_PLCAddress.Padding = new System.Windows.Forms.Padding(1);
            this.iptb_PLCAddress.ShowText = false;
            this.iptb_PLCAddress.Size = new System.Drawing.Size(150, 29);
            this.iptb_PLCAddress.Style = Sunny.UI.UIStyle.Custom;
            this.iptb_PLCAddress.TabIndex = 0;
            this.iptb_PLCAddress.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(51, 79);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "PLC地址：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(36, 135);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(115, 23);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "PLC端口号：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_port
            // 
            this.tb_port.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_port.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_port.Location = new System.Drawing.Point(151, 135);
            this.tb_port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_port.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_port.Name = "tb_port";
            this.tb_port.Padding = new System.Windows.Forms.Padding(5);
            this.tb_port.ShowText = false;
            this.tb_port.Size = new System.Drawing.Size(150, 29);
            this.tb_port.TabIndex = 3;
            this.tb_port.Text = "0";
            this.tb_port.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_port.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.tb_port.Watermark = "";
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(5, 197);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(158, 23);
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "自动登出时间(ms)：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            // 
            // tb_AutoSignOutTime
            // 
            this.tb_AutoSignOutTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_AutoSignOutTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_AutoSignOutTime.Location = new System.Drawing.Point(151, 192);
            this.tb_AutoSignOutTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_AutoSignOutTime.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_AutoSignOutTime.Name = "tb_AutoSignOutTime";
            this.tb_AutoSignOutTime.Padding = new System.Windows.Forms.Padding(5);
            this.tb_AutoSignOutTime.ShowText = false;
            this.tb_AutoSignOutTime.Size = new System.Drawing.Size(150, 29);
            this.tb_AutoSignOutTime.TabIndex = 5;
            this.tb_AutoSignOutTime.Text = "0";
            this.tb_AutoSignOutTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_AutoSignOutTime.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.tb_AutoSignOutTime.Watermark = "";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(19, 255);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(109, 23);
            this.uiLabel4.TabIndex = 6;
            this.uiLabel4.Text = "数据库设置：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_SqlConfig
            // 
            this.tb_SqlConfig.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_SqlConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SqlConfig.Location = new System.Drawing.Point(151, 251);
            this.tb_SqlConfig.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_SqlConfig.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_SqlConfig.Name = "tb_SqlConfig";
            this.tb_SqlConfig.Padding = new System.Windows.Forms.Padding(5);
            this.tb_SqlConfig.ShowText = false;
            this.tb_SqlConfig.Size = new System.Drawing.Size(452, 29);
            this.tb_SqlConfig.TabIndex = 7;
            this.tb_SqlConfig.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_SqlConfig.Watermark = "";
            // 
            // ui_Save
            // 
            this.ui_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ui_Save.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ui_Save.Location = new System.Drawing.Point(55, 440);
            this.ui_Save.MinimumSize = new System.Drawing.Size(1, 1);
            this.ui_Save.Name = "ui_Save";
            this.ui_Save.Size = new System.Drawing.Size(100, 35);
            this.ui_Save.TabIndex = 8;
            this.ui_Save.Text = "保存配置";
            this.ui_Save.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ui_Save.Click += new System.EventHandler(this.ui_Save_Click);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(610, 255);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(114, 23);
            this.uiLabel5.TabIndex = 9;
            this.uiLabel5.Text = "提供程序名：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_programName
            // 
            this.tb_programName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_programName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_programName.Location = new System.Drawing.Point(716, 251);
            this.tb_programName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_programName.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_programName.Name = "tb_programName";
            this.tb_programName.Padding = new System.Windows.Forms.Padding(5);
            this.tb_programName.ShowText = false;
            this.tb_programName.Size = new System.Drawing.Size(255, 29);
            this.tb_programName.TabIndex = 10;
            this.tb_programName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_programName.Watermark = "";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(18, 34);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(132, 23);
            this.uiLabel6.TabIndex = 11;
            this.uiLabel6.Text = "配置文件地址:";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lab_FilePath
            // 
            this.Lab_FilePath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_FilePath.Location = new System.Drawing.Point(141, 34);
            this.Lab_FilePath.Name = "Lab_FilePath";
            this.Lab_FilePath.Size = new System.Drawing.Size(906, 23);
            this.Lab_FilePath.TabIndex = 12;
            this.Lab_FilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(19, 345);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(186, 23);
            this.uiLabel7.TabIndex = 13;
            this.uiLabel7.Text = "电芯分流接口日志地址：";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_BranchLogPath
            // 
            this.lab_BranchLogPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_BranchLogPath.Location = new System.Drawing.Point(197, 346);
            this.lab_BranchLogPath.Name = "lab_BranchLogPath";
            this.lab_BranchLogPath.Size = new System.Drawing.Size(774, 23);
            this.lab_BranchLogPath.TabIndex = 14;
            this.lab_BranchLogPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_BatchLogPath
            // 
            this.lab_BatchLogPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_BatchLogPath.Location = new System.Drawing.Point(196, 387);
            this.lab_BatchLogPath.Name = "lab_BatchLogPath";
            this.lab_BatchLogPath.Size = new System.Drawing.Size(775, 23);
            this.lab_BatchLogPath.TabIndex = 16;
            this.lab_BatchLogPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(19, 386);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(186, 23);
            this.uiLabel9.TabIndex = 15;
            this.uiLabel9.Text = "批量打包接口日志地址：";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_BranchLogPath
            // 
            this.btn_BranchLogPath.Location = new System.Drawing.Point(977, 348);
            this.btn_BranchLogPath.Name = "btn_BranchLogPath";
            this.btn_BranchLogPath.Size = new System.Drawing.Size(33, 23);
            this.btn_BranchLogPath.TabIndex = 17;
            this.btn_BranchLogPath.Text = "...";
            this.btn_BranchLogPath.UseVisualStyleBackColor = true;
            this.btn_BranchLogPath.Click += new System.EventHandler(this.btn_BranchLogPath_Click);
            // 
            // btn_BatchPackLogPath
            // 
            this.btn_BatchPackLogPath.Location = new System.Drawing.Point(977, 386);
            this.btn_BatchPackLogPath.Name = "btn_BatchPackLogPath";
            this.btn_BatchPackLogPath.Size = new System.Drawing.Size(33, 23);
            this.btn_BatchPackLogPath.TabIndex = 18;
            this.btn_BatchPackLogPath.Text = "...";
            this.btn_BatchPackLogPath.UseVisualStyleBackColor = true;
            this.btn_BatchPackLogPath.Click += new System.EventHandler(this.btn_BatchPackLogPath_Click);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(28, 304);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(100, 23);
            this.uiLabel8.TabIndex = 19;
            this.uiLabel8.Text = "窗口名称：";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           
            // 
            // tb_FormName
            // 
            this.tb_FormName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_FormName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_FormName.Location = new System.Drawing.Point(151, 304);
            this.tb_FormName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_FormName.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_FormName.Name = "tb_FormName";
            this.tb_FormName.Padding = new System.Windows.Forms.Padding(5);
            this.tb_FormName.ShowText = false;
            this.tb_FormName.Size = new System.Drawing.Size(333, 29);
            this.tb_FormName.TabIndex = 20;
            this.tb_FormName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_FormName.Watermark = "";
          
            // 
            // Form_GeneralSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1073, 497);
            this.Controls.Add(this.tb_FormName);
            this.Controls.Add(this.uiLabel8);
            this.Controls.Add(this.btn_BatchPackLogPath);
            this.Controls.Add(this.btn_BranchLogPath);
            this.Controls.Add(this.lab_BatchLogPath);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.lab_BranchLogPath);
            this.Controls.Add(this.uiLabel7);
            this.Controls.Add(this.Lab_FilePath);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.tb_programName);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.ui_Save);
            this.Controls.Add(this.tb_SqlConfig);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.tb_AutoSignOutTime);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.iptb_PLCAddress);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_GeneralSetting";
            this.Text = "GeneralSettingFrom";
            this.Load += new System.EventHandler(this.Form_GeneralSetting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIIPTextBox iptb_PLCAddress;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox tb_port;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox tb_AutoSignOutTime;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox tb_SqlConfig;
        private Sunny.UI.UIButton ui_Save;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox tb_programName;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel Lab_FilePath;
        private System.Windows.Forms.FolderBrowserDialog fbd_BranchPath;
        private System.Windows.Forms.FolderBrowserDialog fbd_BatchPath;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel lab_BranchLogPath;
        private Sunny.UI.UILabel lab_BatchLogPath;
        private Sunny.UI.UILabel uiLabel9;
        private System.Windows.Forms.Button btn_BranchLogPath;
        private System.Windows.Forms.Button btn_BatchPackLogPath;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UITextBox tb_FormName;
    }
}