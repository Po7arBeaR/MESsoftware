namespace MESsoftware1.From
{
    partial class Form_ChangePassWord
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
            this.Lab_CurrentUserName = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.Lab_Role = new Sunny.UI.UILabel();
            this.tb_NewCardID = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.Btn_ChangeCardID = new Sunny.UI.UIButton();
            this.toolTip_NewCard = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_NewPassWord = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // Lab_CurrentUserName
            // 
            this.Lab_CurrentUserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_CurrentUserName.ForeColor = System.Drawing.Color.Aqua;
            this.Lab_CurrentUserName.Location = new System.Drawing.Point(96, 24);
            this.Lab_CurrentUserName.Name = "Lab_CurrentUserName";
            this.Lab_CurrentUserName.Size = new System.Drawing.Size(180, 23);
            this.Lab_CurrentUserName.Style = Sunny.UI.UIStyle.Custom;
            this.Lab_CurrentUserName.TabIndex = 0;
            this.Lab_CurrentUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(12, 24);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(78, 23);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "用户名:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(0, 68);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(96, 23);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "用户权限：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lab_Role
            // 
            this.Lab_Role.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_Role.ForeColor = System.Drawing.Color.Aqua;
            this.Lab_Role.Location = new System.Drawing.Point(102, 68);
            this.Lab_Role.Name = "Lab_Role";
            this.Lab_Role.Size = new System.Drawing.Size(180, 23);
            this.Lab_Role.Style = Sunny.UI.UIStyle.Custom;
            this.Lab_Role.TabIndex = 3;
            this.Lab_Role.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_NewCardID
            // 
            this.tb_NewCardID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_NewCardID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_NewCardID.Location = new System.Drawing.Point(95, 120);
            this.tb_NewCardID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_NewCardID.MaxLength = 10;
            this.tb_NewCardID.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_NewCardID.Name = "tb_NewCardID";
            this.tb_NewCardID.Padding = new System.Windows.Forms.Padding(5);
            this.tb_NewCardID.PasswordChar = '*';
            this.tb_NewCardID.ShowText = false;
            this.tb_NewCardID.Size = new System.Drawing.Size(150, 29);
            this.tb_NewCardID.TabIndex = 5;
            this.tb_NewCardID.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_NewCardID.Watermark = "";
            this.tb_NewCardID.TextChanged += new System.EventHandler(this.tb_NewCardID_TextChanged);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(16, 121);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(78, 23);
            this.uiLabel4.TabIndex = 7;
            this.uiLabel4.Text = "新卡号：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_ChangeCardID
            // 
            this.Btn_ChangeCardID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_ChangeCardID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_ChangeCardID.Location = new System.Drawing.Point(253, 117);
            this.Btn_ChangeCardID.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_ChangeCardID.Name = "Btn_ChangeCardID";
            this.Btn_ChangeCardID.Size = new System.Drawing.Size(83, 35);
            this.Btn_ChangeCardID.TabIndex = 9;
            this.Btn_ChangeCardID.Text = "保存";
            this.Btn_ChangeCardID.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_ChangeCardID.Click += new System.EventHandler(this.Btn_ChangeCardID_Click);
            // 
            // Form_ChangePassWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 179);
            this.Controls.Add(this.Btn_ChangeCardID);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.tb_NewCardID);
            this.Controls.Add(this.Lab_Role);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.Lab_CurrentUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_ChangePassWord";
            this.Text = "Form_ChangePassWord";
            this.Load += new System.EventHandler(this.Form_ChangePassWord_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel Lab_CurrentUserName;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel Lab_Role;
        private Sunny.UI.UITextBox tb_NewCardID;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIButton Btn_ChangeCardID;
        private System.Windows.Forms.ToolTip toolTip_NewCard;
        private System.Windows.Forms.ToolTip toolTip_NewPassWord;
    }
}