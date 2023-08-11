namespace MESsoftware1.Form_EX
{
    partial class Form_DEBUG
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
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.Lable1 = new Sunny.UI.UILabel();
            this.tb_Batch = new Sunny.UI.UITextBox();
            this.tb_BranchFirst = new Sunny.UI.UITextBox();
            this.Btn_DEBUG_MODE = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(559, 174);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(116, 23);
            this.uiLabel3.TabIndex = 12;
            this.uiLabel3.Text = "打包接口调用";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lable1
            // 
            this.Lable1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lable1.Location = new System.Drawing.Point(559, 96);
            this.Lable1.Name = "Lable1";
            this.Lable1.Size = new System.Drawing.Size(124, 23);
            this.Lable1.TabIndex = 11;
            this.Lable1.Text = "分流接口调用";
            this.Lable1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_Batch
            // 
            this.tb_Batch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Batch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Batch.Location = new System.Drawing.Point(686, 173);
            this.tb_Batch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Batch.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_Batch.Name = "tb_Batch";
            this.tb_Batch.Padding = new System.Windows.Forms.Padding(5);
            this.tb_Batch.ShowText = false;
            this.tb_Batch.Size = new System.Drawing.Size(94, 29);
            this.tb_Batch.TabIndex = 10;
            this.tb_Batch.Text = "0";
            this.tb_Batch.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_Batch.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.tb_Batch.Watermark = "";
            // 
            // tb_BranchFirst
            // 
            this.tb_BranchFirst.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_BranchFirst.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_BranchFirst.Location = new System.Drawing.Point(686, 95);
            this.tb_BranchFirst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_BranchFirst.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_BranchFirst.Name = "tb_BranchFirst";
            this.tb_BranchFirst.Padding = new System.Windows.Forms.Padding(5);
            this.tb_BranchFirst.ShowText = false;
            this.tb_BranchFirst.Size = new System.Drawing.Size(94, 29);
            this.tb_BranchFirst.TabIndex = 9;
            this.tb_BranchFirst.Text = "0";
            this.tb_BranchFirst.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_BranchFirst.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.tb_BranchFirst.Watermark = "";
            // 
            // Btn_DEBUG_MODE
            // 
            this.Btn_DEBUG_MODE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DEBUG_MODE.FillColor = System.Drawing.Color.Green;
            this.Btn_DEBUG_MODE.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_DEBUG_MODE.Location = new System.Drawing.Point(627, 35);
            this.Btn_DEBUG_MODE.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_DEBUG_MODE.Name = "Btn_DEBUG_MODE";
            this.Btn_DEBUG_MODE.Size = new System.Drawing.Size(161, 35);
            this.Btn_DEBUG_MODE.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_DEBUG_MODE.TabIndex = 8;
            this.Btn_DEBUG_MODE.Text = "调试模式";
            this.Btn_DEBUG_MODE.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_DEBUG_MODE.Click += new System.EventHandler(this.Btn_DEBUG_MODE_Click);
            // 
            // Form_DEBUG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.Lable1);
            this.Controls.Add(this.tb_Batch);
            this.Controls.Add(this.tb_BranchFirst);
            this.Controls.Add(this.Btn_DEBUG_MODE);
            this.Name = "Form_DEBUG";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel Lable1;
        private Sunny.UI.UITextBox tb_Batch;
        private Sunny.UI.UITextBox tb_BranchFirst;
        private Sunny.UI.UIButton Btn_DEBUG_MODE;
    }
}