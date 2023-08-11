namespace MESsoftware1.From
{
    partial class Form_CreatUser
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
            this.components = new System.ComponentModel.Container();
            this.tb_CardID = new Sunny.UI.UITextBox();
            this.cb_Role = new Sunny.UI.UIComboBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.Btn_CreatUser = new Sunny.UI.UIButton();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.tb_Username = new Sunny.UI.UITextBox();
            this.toolTip_UserName = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Account = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_PassWord = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_CardID = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Role = new System.Windows.Forms.ToolTip(this.components);
            this.Lab_UserName = new Sunny.UI.UILabel();
            this.Lab_CardID = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // tb_CardID
            // 
            this.tb_CardID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_CardID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_CardID.Location = new System.Drawing.Point(122, 111);
            this.tb_CardID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_CardID.MaxLength = 10;
            this.tb_CardID.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_CardID.Name = "tb_CardID";
            this.tb_CardID.Padding = new System.Windows.Forms.Padding(5);
            this.tb_CardID.PasswordChar = '*';
            this.tb_CardID.ShowText = false;
            this.tb_CardID.Size = new System.Drawing.Size(174, 29);
            this.tb_CardID.TabIndex = 3;
            this.tb_CardID.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_CardID.Watermark = "";
            this.tb_CardID.TextChanged += new System.EventHandler(this.tb_CardID_TextChanged);
            this.tb_CardID.Leave += new System.EventHandler(this.tb_CardID_Leave);
            this.tb_CardID.Enter += new System.EventHandler(this.tb_CardID_Enter);
            // 
            // cb_Role
            // 
            this.cb_Role.DataSource = null;
            this.cb_Role.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cb_Role.FillColor = System.Drawing.Color.White;
            this.cb_Role.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Role.Location = new System.Drawing.Point(122, 175);
            this.cb_Role.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_Role.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_Role.Name = "cb_Role";
            this.cb_Role.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cb_Role.Size = new System.Drawing.Size(174, 29);
            this.cb_Role.TabIndex = 4;
            this.cb_Role.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb_Role.Watermark = "";
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(90, 83);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 23);
            this.uiLabel3.TabIndex = 6;
            this.uiLabel3.Text = "卡号:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(90, 147);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(100, 23);
            this.uiLabel4.TabIndex = 7;
            this.uiLabel4.Text = "权限：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_CreatUser
            // 
            this.Btn_CreatUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_CreatUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_CreatUser.Location = new System.Drawing.Point(169, 225);
            this.Btn_CreatUser.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_CreatUser.Name = "Btn_CreatUser";
            this.Btn_CreatUser.Size = new System.Drawing.Size(100, 35);
            this.Btn_CreatUser.TabIndex = 8;
            this.Btn_CreatUser.Text = "创建";
            this.Btn_CreatUser.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_CreatUser.Click += new System.EventHandler(this.Btn_CreatUser_Click);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(72, 22);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(100, 23);
            this.uiLabel5.TabIndex = 9;
            this.uiLabel5.Text = "用户名:";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_Username
            // 
            this.tb_Username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Username.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Username.Location = new System.Drawing.Point(127, 49);
            this.tb_Username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Username.MaxLength = 16;
            this.tb_Username.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Padding = new System.Windows.Forms.Padding(5);
            this.tb_Username.ShowText = false;
            this.tb_Username.Size = new System.Drawing.Size(253, 29);
            this.tb_Username.TabIndex = 10;
            this.tb_Username.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_Username.Watermark = "";
            this.tb_Username.Click += new System.EventHandler(this.tb_Username_Click);
            this.tb_Username.TextChanged += new System.EventHandler(this.tb_Username_TextChanged);
            this.tb_Username.Leave += new System.EventHandler(this.tb_Username_Leave);
            this.tb_Username.Enter += new System.EventHandler(this.tb_Username_Enter);
            // 
            // toolTip_UserName
            // 
            this.toolTip_UserName.Tag = "用户名不能为空";
            // 
            // toolTip_Account
            // 
            this.toolTip_Account.Tag = "账号不能为空";
            // 
            // toolTip_PassWord
            // 
            this.toolTip_PassWord.Tag = "密码不能为空";
            // 
            // toolTip_CardID
            // 
            this.toolTip_CardID.Tag = "卡号不能为空";
            // 
            // toolTip_Role
            // 
            this.toolTip_Role.Tag = "请为用户指定权限";
            // 
            // Lab_UserName
            // 
            this.Lab_UserName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_UserName.Location = new System.Drawing.Point(135, 22);
            this.Lab_UserName.Name = "Lab_UserName";
            this.Lab_UserName.Size = new System.Drawing.Size(275, 23);
            this.Lab_UserName.TabIndex = 11;
            this.Lab_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lab_CardID
            // 
            this.Lab_CardID.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Lab_CardID.Location = new System.Drawing.Point(131, 84);
            this.Lab_CardID.Name = "Lab_CardID";
            this.Lab_CardID.Size = new System.Drawing.Size(274, 23);
            this.Lab_CardID.TabIndex = 14;
            this.Lab_CardID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_CreatUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 280);
            this.Controls.Add(this.Lab_CardID);
            this.Controls.Add(this.Lab_UserName);
            this.Controls.Add(this.tb_Username);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.Btn_CreatUser);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.cb_Role);
            this.Controls.Add(this.tb_CardID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_CreatUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_CreatUser";
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITextBox tb_CardID;
        private Sunny.UI.UIComboBox cb_Role;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIButton Btn_CreatUser;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox tb_Username;
        private System.Windows.Forms.ToolTip toolTip_UserName;
        private System.Windows.Forms.ToolTip toolTip_Account;
        private System.Windows.Forms.ToolTip toolTip_PassWord;
        private System.Windows.Forms.ToolTip toolTip_CardID;
        private System.Windows.Forms.ToolTip toolTip_Role;
        private Sunny.UI.UILabel Lab_UserName;
        private Sunny.UI.UILabel Lab_CardID;
    }
}