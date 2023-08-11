namespace MESsoftware1
{
    partial class Form_Variable
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
            if(DGV_PLCVariableMap==null)
            {
                DGV_PLCVariableMap = new Sunny.UI.UIDataGridView();
            }
            this.Btn_Save = new Sunny.UI.UIButton();
            this.Btn_Show = new Sunny.UI.UIButton();
            this.Btn_CloseMonitor = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(DGV_PLCVariableMap)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_PLCVariableMap
            // 
            DGV_PLCVariableMap.AllowUserToAddRows = false;
            DGV_PLCVariableMap.AllowUserToDeleteRows = false;
            DGV_PLCVariableMap.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            DGV_PLCVariableMap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DGV_PLCVariableMap.BackgroundColor = System.Drawing.Color.White;
            DGV_PLCVariableMap.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           DGV_PLCVariableMap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
           DGV_PLCVariableMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            DGV_PLCVariableMap.DefaultCellStyle = dataGridViewCellStyle3;
            DGV_PLCVariableMap.EnableHeadersVisualStyles = false;
            DGV_PLCVariableMap.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            DGV_PLCVariableMap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            DGV_PLCVariableMap.Location = new System.Drawing.Point(0, 32);
            DGV_PLCVariableMap.Name = "DGV_PLCVariableMap";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            DGV_PLCVariableMap.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            DGV_PLCVariableMap.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            DGV_PLCVariableMap.RowsDefaultCellStyle = dataGridViewCellStyle5;
            DGV_PLCVariableMap.RowTemplate.Height = 23;
            DGV_PLCVariableMap.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            DGV_PLCVariableMap.SelectedIndex = -1;
            DGV_PLCVariableMap.Size = new System.Drawing.Size(1074, 500);
            DGV_PLCVariableMap.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            DGV_PLCVariableMap.Style = Sunny.UI.UIStyle.Custom;
            DGV_PLCVariableMap.TabIndex = 0;
            // 
            // Btn_Save
            // 
            this.Btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Save.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Save.Location = new System.Drawing.Point(957, 0);
            this.Btn_Save.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(100, 30);
            this.Btn_Save.TabIndex = 1;
            this.Btn_Save.Text = "保存";
            this.Btn_Save.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_Show
            // 
            this.Btn_Show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Show.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Show.Location = new System.Drawing.Point(816, 0);
            this.Btn_Show.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Show.Name = "Btn_Show";
            this.Btn_Show.Size = new System.Drawing.Size(134, 30);
            this.Btn_Show.TabIndex = 2;
            this.Btn_Show.Text = "监控实时值";
            this.Btn_Show.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Show.Click += new System.EventHandler(this.Btn_Show_Click);
            // 
            // Btn_CloseMonitor
            // 
            this.Btn_CloseMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_CloseMonitor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_CloseMonitor.Location = new System.Drawing.Point(676, 0);
            this.Btn_CloseMonitor.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_CloseMonitor.Name = "Btn_CloseMonitor";
            this.Btn_CloseMonitor.Size = new System.Drawing.Size(134, 30);
            this.Btn_CloseMonitor.TabIndex = 3;
            this.Btn_CloseMonitor.Text = "关闭实时值";
            this.Btn_CloseMonitor.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_CloseMonitor.Click += new System.EventHandler(this.Btn_CloseMonitor_Click);
            // 
            // Form_Variable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 530);
            this.Controls.Add(this.Btn_CloseMonitor);
            this.Controls.Add(this.Btn_Show);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add( DGV_PLCVariableMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Variable";
            this.Text = "Form_Variable";
            this.ParentChanged += new System.EventHandler(this.Form_Variable_ParentChanged);
            ((System.ComponentModel.ISupportInitialize)(DGV_PLCVariableMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        static private Sunny.UI.UIDataGridView DGV_PLCVariableMap;
        private Sunny.UI.UIButton Btn_Save;
        private Sunny.UI.UIButton Btn_Show;
        private Sunny.UI.UIButton Btn_CloseMonitor;
    }
}