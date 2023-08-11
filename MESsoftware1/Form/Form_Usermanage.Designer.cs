using System.Windows.Forms;

namespace MESsoftware1.From
{
    partial class From_Usermanage
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
            this.DGV_UserInfo = new Sunny.UI.UIDataGridView();
            this.Btn_CreatUser = new Sunny.UI.UIButton();
            this.Btn_DeleteUser = new Sunny.UI.UIButton();
            this.btn_ChangePassWord = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_UserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_UserInfo
            // 
            this.DGV_UserInfo.AllowUserToAddRows = false;
            this.DGV_UserInfo.AllowUserToDeleteRows = false;
            this.DGV_UserInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DGV_UserInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_UserInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_UserInfo.BackgroundColor = System.Drawing.Color.White;
            this.DGV_UserInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_UserInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_UserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_UserInfo.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_UserInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_UserInfo.EnableHeadersVisualStyles = false;
            this.DGV_UserInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DGV_UserInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DGV_UserInfo.Location = new System.Drawing.Point(82, 0);
            this.DGV_UserInfo.MultiSelect = false;
            this.DGV_UserInfo.Name = "DGV_UserInfo";
            this.DGV_UserInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_UserInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_UserInfo.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DGV_UserInfo.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_UserInfo.RowTemplate.Height = 23;
            this.DGV_UserInfo.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DGV_UserInfo.SelectedIndex = -1;
            this.DGV_UserInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_UserInfo.Size = new System.Drawing.Size(992, 533);
            this.DGV_UserInfo.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DGV_UserInfo.Style = Sunny.UI.UIStyle.Custom;
            this.DGV_UserInfo.TabIndex = 0;
            this.DGV_UserInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiDataGridView1_CellContentClick);
            this.DGV_UserInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_UserInfo_CellFormatting);
            this.DGV_UserInfo.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_UserInfo_EditingControlShowing);
            this.DGV_UserInfo.SelectionChanged += new System.EventHandler(this.DGV_UserInfo_SelectionChanged);
            // 
            // Btn_CreatUser
            // 
            this.Btn_CreatUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_CreatUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_CreatUser.Location = new System.Drawing.Point(-1, 0);
            this.Btn_CreatUser.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_CreatUser.Name = "Btn_CreatUser";
            this.Btn_CreatUser.Size = new System.Drawing.Size(84, 35);
            this.Btn_CreatUser.TabIndex = 1;
            this.Btn_CreatUser.Text = "创建用户";
            this.Btn_CreatUser.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_CreatUser.Click += new System.EventHandler(this.Btn_CreateUser_Click);
            // 
            // Btn_DeleteUser
            // 
            this.Btn_DeleteUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DeleteUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_DeleteUser.Location = new System.Drawing.Point(-1, 36);
            this.Btn_DeleteUser.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_DeleteUser.Name = "Btn_DeleteUser";
            this.Btn_DeleteUser.Size = new System.Drawing.Size(84, 35);
            this.Btn_DeleteUser.TabIndex = 2;
            this.Btn_DeleteUser.Text = "删除用户";
            this.Btn_DeleteUser.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_DeleteUser.Click += new System.EventHandler(this.Btn_DeleteUser_Click);
            // 
            // btn_ChangePassWord
            // 
            this.btn_ChangePassWord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ChangePassWord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ChangePassWord.Location = new System.Drawing.Point(-1, 72);
            this.btn_ChangePassWord.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ChangePassWord.Name = "btn_ChangePassWord";
            this.btn_ChangePassWord.Size = new System.Drawing.Size(84, 35);
            this.btn_ChangePassWord.TabIndex = 4;
            this.btn_ChangePassWord.Text = "修改密码";
            this.btn_ChangePassWord.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ChangePassWord.Click += new System.EventHandler(this.ChangePassWord_Click);
            // 
            // From_Usermanage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1073, 530);
            this.Controls.Add(this.btn_ChangePassWord);
            this.Controls.Add(this.Btn_DeleteUser);
            this.Controls.Add(this.Btn_CreatUser);
            this.Controls.Add(this.DGV_UserInfo);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "From_Usermanage";
            this.Text = "From_Usermanage";
            this.Load += new System.EventHandler(this.From_Usermanage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_UserInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDataGridView DGV_UserInfo;
        private Sunny.UI.UIButton Btn_CreatUser;
        private Sunny.UI.UIButton Btn_DeleteUser;
        private Sunny.UI.UIButton btn_ChangePassWord;
    }
}