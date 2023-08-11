namespace MESsoftware1.From
{
    partial class Form_LoginFormForPassWord
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
            this.Btn_Loggin = new System.Windows.Forms.Button();
            this.label_UserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Account = new System.Windows.Forms.TextBox();
            this.tb_Pwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Btn_Loggin
            // 
            this.Btn_Loggin.Location = new System.Drawing.Point(91, 124);
            this.Btn_Loggin.Name = "Btn_Loggin";
            this.Btn_Loggin.Size = new System.Drawing.Size(75, 23);
            this.Btn_Loggin.TabIndex = 0;
            this.Btn_Loggin.Text = "登录";
            this.Btn_Loggin.UseVisualStyleBackColor = true;
            this.Btn_Loggin.Click += new System.EventHandler(this.Btn_Loggin_Click);
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.Location = new System.Drawing.Point(77, 47);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(53, 12);
            this.label_UserName.TabIndex = 1;
            this.label_UserName.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // tb_Account
            // 
            this.tb_Account.Location = new System.Drawing.Point(131, 45);
            this.tb_Account.Name = "tb_Account";
            this.tb_Account.Size = new System.Drawing.Size(173, 21);
            this.tb_Account.TabIndex = 3;
            // 
            // tb_Pwd
            // 
            this.tb_Pwd.Location = new System.Drawing.Point(131, 80);
            this.tb_Pwd.Name = "tb_Pwd";
            this.tb_Pwd.PasswordChar = '*';
            this.tb_Pwd.Size = new System.Drawing.Size(173, 21);
            this.tb_Pwd.TabIndex = 4;
            this.tb_Pwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Pwd_KeyDown);
            // 
            // Form_LoginFormForPassWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 163);
            this.Controls.Add(this.tb_Pwd);
            this.Controls.Add(this.tb_Account);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_UserName);
            this.Controls.Add(this.Btn_Loggin);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_LoginFormForPassWord";
            this.Text = "登录";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_LoginFormForPassWord_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Loggin;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Account;
        private System.Windows.Forms.TextBox tb_Pwd;
    }
}