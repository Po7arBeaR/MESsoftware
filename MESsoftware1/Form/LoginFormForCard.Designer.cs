namespace MESsoftware1
{
    partial class Form_LoginForCard
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
            this.lable_Login_tips = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lable_Login_tips
            // 
            this.lable_Login_tips.AutoSize = true;
            this.lable_Login_tips.Location = new System.Drawing.Point(66, 96);
            this.lable_Login_tips.Name = "lable_Login_tips";
            this.lable_Login_tips.Size = new System.Drawing.Size(135, 19);
            this.lable_Login_tips.TabIndex = 1;
            this.lable_Login_tips.Text = "请使用刷卡器登录：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 2;
            // 
            // Form_LoginForCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(508, 228);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lable_Login_tips);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_LoginForCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_LoginForCard_FormClosing);
            this.Load += new System.EventHandler(this.Form_LoginForCard_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_LoginForCard_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lable_Login_tips;
        private System.Windows.Forms.Label label1;
    }
}