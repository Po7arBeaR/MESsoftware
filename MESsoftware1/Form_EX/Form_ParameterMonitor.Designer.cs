namespace MESsoftware1.Form_EX
{
    partial class Form_ParameterMonitor
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
            this.DGV_PLCParaMap = new Sunny.UI.UIDataGridView();
            this.Btn_Add = new Sunny.UI.UIButton();
            this.Btn_Delete = new Sunny.UI.UIButton();
            this.Btn_Updata = new Sunny.UI.UIButton();
            this.btn_Flash = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PLCParaMap)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_PLCParaMap
            // 
            this.DGV_PLCParaMap.AllowUserToAddRows = false;
            this.DGV_PLCParaMap.AllowUserToDeleteRows = false;
            this.DGV_PLCParaMap.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DGV_PLCParaMap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_PLCParaMap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_PLCParaMap.BackgroundColor = System.Drawing.Color.White;
            this.DGV_PLCParaMap.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_PLCParaMap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_PLCParaMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_PLCParaMap.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_PLCParaMap.EnableHeadersVisualStyles = false;
            this.DGV_PLCParaMap.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DGV_PLCParaMap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DGV_PLCParaMap.Location = new System.Drawing.Point(133, 2);
            this.DGV_PLCParaMap.Name = "DGV_PLCParaMap";
            this.DGV_PLCParaMap.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_PLCParaMap.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_PLCParaMap.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DGV_PLCParaMap.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_PLCParaMap.RowTemplate.Height = 23;
            this.DGV_PLCParaMap.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DGV_PLCParaMap.SelectedIndex = -1;
            this.DGV_PLCParaMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_PLCParaMap.Size = new System.Drawing.Size(942, 529);
            this.DGV_PLCParaMap.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DGV_PLCParaMap.Style = Sunny.UI.UIStyle.Custom;
            this.DGV_PLCParaMap.TabIndex = 1;
            // 
            // Btn_Add
            // 
            this.Btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Add.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Add.Location = new System.Drawing.Point(1, 2);
            this.Btn_Add.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(126, 35);
            this.Btn_Add.TabIndex = 2;
            this.Btn_Add.Text = "添加";
            this.Btn_Add.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Delete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Delete.Location = new System.Drawing.Point(1, 38);
            this.Btn_Delete.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(127, 35);
            this.Btn_Delete.TabIndex = 3;
            this.Btn_Delete.Text = "删除";
            this.Btn_Delete.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // Btn_Updata
            // 
            this.Btn_Updata.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Updata.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Updata.Location = new System.Drawing.Point(1, 75);
            this.Btn_Updata.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Updata.Name = "Btn_Updata";
            this.Btn_Updata.Size = new System.Drawing.Size(126, 35);
            this.Btn_Updata.TabIndex = 4;
            this.Btn_Updata.Text = "修改";
            this.Btn_Updata.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Updata.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // btn_Flash
            // 
            this.btn_Flash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Flash.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Flash.Location = new System.Drawing.Point(1, 112);
            this.btn_Flash.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Flash.Name = "btn_Flash";
            this.btn_Flash.Size = new System.Drawing.Size(126, 35);
            this.btn_Flash.TabIndex = 5;
            this.btn_Flash.Text = "刷新";
            this.btn_Flash.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Flash.Click += new System.EventHandler(this.btn_Flash_Click);
            // 
            // Form_ParameterMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 530);
            this.Controls.Add(this.btn_Flash);
            this.Controls.Add(this.Btn_Updata);
            this.Controls.Add(this.Btn_Delete);
            this.Controls.Add(this.Btn_Add);
            this.Controls.Add(this.DGV_PLCParaMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_ParameterMonitor";
            this.Text = "Form_ParameterMonitor";
            this.Load += new System.EventHandler(this.Form_ParameterMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PLCParaMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDataGridView DGV_PLCParaMap;
        private Sunny.UI.UIButton Btn_Add;
        private Sunny.UI.UIButton Btn_Delete;
        private Sunny.UI.UIButton Btn_Updata;
        private Sunny.UI.UIButton btn_Flash;
    }
}