namespace MESsoftware1.Form_EX
{
    partial class Form_mainPage
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
            this.Btn_DEBUGPage = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // Btn_DEBUGPage
            // 
            this.Btn_DEBUGPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DEBUGPage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_DEBUGPage.Location = new System.Drawing.Point(948, 12);
            this.Btn_DEBUGPage.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_DEBUGPage.Name = "Btn_DEBUGPage";
            this.Btn_DEBUGPage.Size = new System.Drawing.Size(100, 35);
            this.Btn_DEBUGPage.TabIndex = 1;
            this.Btn_DEBUGPage.Text = "调试页面";
            this.Btn_DEBUGPage.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_DEBUGPage.Click += new System.EventHandler(this.Btn_DEBUGPage_Click);
            // 
            // Form_mainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 530);
            this.Controls.Add(this.Btn_DEBUGPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_mainPage";
            this.Text = "Form_mainPage";
            this.Load += new System.EventHandler(this.Form_mainPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton Btn_DEBUGPage;
    }
}