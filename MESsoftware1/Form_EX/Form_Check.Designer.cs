namespace MESsoftware1.Form_EX
{
    partial class Form_Check
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_DataTable = new Sunny.UI.UIDataGridView();
            this.Btn_Check = new Sunny.UI.UIButton();
            this.tb_CheckWithCode = new Sunny.UI.UITextBox();
            this.dtp_StartTime = new Sunny.UI.UIDatetimePicker();
            this.dtp_EndTime = new Sunny.UI.UIDatetimePicker();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.lab_Count = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DataTable
            // 
            this.dgv_DataTable.AllowUserToAddRows = false;
            this.dgv_DataTable.AllowUserToDeleteRows = false;
            this.dgv_DataTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgv_DataTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_DataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DataTable.BackgroundColor = System.Drawing.Color.White;
            this.dgv_DataTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DataTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DataTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_DataTable.EnableHeadersVisualStyles = false;
            this.dgv_DataTable.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_DataTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgv_DataTable.Location = new System.Drawing.Point(4, 84);
            this.dgv_DataTable.Name = "dgv_DataTable";
            this.dgv_DataTable.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DataTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_DataTable.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_DataTable.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_DataTable.RowTemplate.Height = 23;
            this.dgv_DataTable.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgv_DataTable.SelectedIndex = -1;
            this.dgv_DataTable.Size = new System.Drawing.Size(1071, 447);
            this.dgv_DataTable.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgv_DataTable.Style = Sunny.UI.UIStyle.Custom;
            this.dgv_DataTable.TabIndex = 0;
            // 
            // Btn_Check
            // 
            this.Btn_Check.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Check.Location = new System.Drawing.Point(952, 8);
            this.Btn_Check.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Check.Name = "Btn_Check";
            this.Btn_Check.Size = new System.Drawing.Size(100, 35);
            this.Btn_Check.TabIndex = 1;
            this.Btn_Check.Text = "查询";
            this.Btn_Check.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Check.Click += new System.EventHandler(this.Btn_Check_Click);
            // 
            // tb_CheckWithCode
            // 
            this.tb_CheckWithCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_CheckWithCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_CheckWithCode.Location = new System.Drawing.Point(96, 18);
            this.tb_CheckWithCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_CheckWithCode.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_CheckWithCode.Name = "tb_CheckWithCode";
            this.tb_CheckWithCode.Padding = new System.Windows.Forms.Padding(5);
            this.tb_CheckWithCode.ShowText = false;
            this.tb_CheckWithCode.Size = new System.Drawing.Size(294, 23);
            this.tb_CheckWithCode.TabIndex = 2;
            this.tb_CheckWithCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_CheckWithCode.Watermark = "";
            // 
            // dtp_StartTime
            // 
            this.dtp_StartTime.FillColor = System.Drawing.Color.White;
            this.dtp_StartTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_StartTime.Location = new System.Drawing.Point(496, 18);
            this.dtp_StartTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtp_StartTime.MaxLength = 19;
            this.dtp_StartTime.MinimumSize = new System.Drawing.Size(63, 0);
            this.dtp_StartTime.Name = "dtp_StartTime";
            this.dtp_StartTime.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dtp_StartTime.Size = new System.Drawing.Size(200, 23);
            this.dtp_StartTime.SymbolDropDown = 61555;
            this.dtp_StartTime.SymbolNormal = 61555;
            this.dtp_StartTime.TabIndex = 3;
            this.dtp_StartTime.Text = "2023-07-20 18:30:57";
            this.dtp_StartTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dtp_StartTime.Value = new System.DateTime(2023, 7, 20, 18, 30, 57, 726);
            this.dtp_StartTime.Watermark = "";
            // 
            // dtp_EndTime
            // 
            this.dtp_EndTime.FillColor = System.Drawing.Color.White;
            this.dtp_EndTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_EndTime.Location = new System.Drawing.Point(730, 18);
            this.dtp_EndTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtp_EndTime.MaxLength = 19;
            this.dtp_EndTime.MinimumSize = new System.Drawing.Size(63, 0);
            this.dtp_EndTime.Name = "dtp_EndTime";
            this.dtp_EndTime.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dtp_EndTime.Size = new System.Drawing.Size(200, 23);
            this.dtp_EndTime.SymbolDropDown = 61555;
            this.dtp_EndTime.SymbolNormal = 61555;
            this.dtp_EndTime.TabIndex = 4;
            this.dtp_EndTime.Text = "2023-07-20 18:31:08";
            this.dtp_EndTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dtp_EndTime.Value = new System.DateTime(2023, 7, 20, 18, 31, 8, 725);
            this.dtp_EndTime.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(395, 16);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(98, 23);
            this.uiLabel1.TabIndex = 5;
            this.uiLabel1.Text = "时间区间：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(701, 20);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(24, 23);
            this.uiLabel2.TabIndex = 6;
            this.uiLabel2.Text = "--";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(0, 16);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(91, 23);
            this.uiLabel3.TabIndex = 7;
            this.uiLabel3.Text = "模组条码：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(797, 55);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(80, 23);
            this.uiLabel4.TabIndex = 8;
            this.uiLabel4.Text = "条目：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_Count
            // 
            this.lab_Count.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Count.Location = new System.Drawing.Point(883, 55);
            this.lab_Count.Name = "lab_Count";
            this.lab_Count.Size = new System.Drawing.Size(192, 23);
            this.lab_Count.TabIndex = 9;
            this.lab_Count.Text = "0/0";
            this.lab_Count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 530);
            this.Controls.Add(this.lab_Count);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.dtp_EndTime);
            this.Controls.Add(this.dtp_StartTime);
            this.Controls.Add(this.tb_CheckWithCode);
            this.Controls.Add(this.Btn_Check);
            this.Controls.Add(this.dgv_DataTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Check";
            this.Text = "Form_Check";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDataGridView dgv_DataTable;
        private Sunny.UI.UIButton Btn_Check;
        private Sunny.UI.UITextBox tb_CheckWithCode;
        private Sunny.UI.UIDatetimePicker dtp_StartTime;
        private Sunny.UI.UIDatetimePicker dtp_EndTime;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel lab_Count;
    }
}