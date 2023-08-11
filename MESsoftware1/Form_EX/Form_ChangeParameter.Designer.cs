namespace MESsoftware1.Form_EX
{
    partial class Form_ChangeParameter
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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.Lab_ID = new Sunny.UI.UILabel();
            this.lab_DB = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.cb_Type = new Sunny.UI.UIComboBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.tb_DB = new Sunny.UI.UITextBox();
            this.tb_Address = new Sunny.UI.UITextBox();
            this.tb_DIscription = new Sunny.UI.UITextBox();
            this.btn_Change = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(48, 50);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(73, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "序号：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lab_ID
            // 
            this.Lab_ID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_ID.Location = new System.Drawing.Point(124, 50);
            this.Lab_ID.Name = "Lab_ID";
            this.Lab_ID.Size = new System.Drawing.Size(119, 23);
            this.Lab_ID.TabIndex = 1;
            this.Lab_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_DB
            // 
            this.lab_DB.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_DB.Location = new System.Drawing.Point(49, 101);
            this.lab_DB.Name = "lab_DB";
            this.lab_DB.Size = new System.Drawing.Size(49, 23);
            this.lab_DB.TabIndex = 2;
            this.lab_DB.Text = "DB:";
            this.lab_DB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(48, 152);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(65, 23);
            this.uiLabel2.TabIndex = 3;
            this.uiLabel2.Text = "地址：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(48, 203);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(65, 23);
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "描述：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_Type
            // 
            this.cb_Type.DataSource = null;
            this.cb_Type.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cb_Type.FillColor = System.Drawing.Color.White;
            this.cb_Type.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Type.Location = new System.Drawing.Point(128, 260);
            this.cb_Type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_Type.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cb_Type.Size = new System.Drawing.Size(150, 29);
            this.cb_Type.TabIndex = 5;
            this.cb_Type.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb_Type.Watermark = "";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(48, 260);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(65, 23);
            this.uiLabel4.TabIndex = 6;
            this.uiLabel4.Text = "类型：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_DB
            // 
            this.tb_DB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_DB.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_DB.Location = new System.Drawing.Point(128, 101);
            this.tb_DB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_DB.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_DB.Name = "tb_DB";
            this.tb_DB.Padding = new System.Windows.Forms.Padding(5);
            this.tb_DB.ShowText = false;
            this.tb_DB.Size = new System.Drawing.Size(150, 29);
            this.tb_DB.TabIndex = 7;
            this.tb_DB.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_DB.Watermark = "";
            // 
            // tb_Address
            // 
            this.tb_Address.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Address.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Address.Location = new System.Drawing.Point(128, 154);
            this.tb_Address.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Address.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_Address.Name = "tb_Address";
            this.tb_Address.Padding = new System.Windows.Forms.Padding(5);
            this.tb_Address.ShowText = false;
            this.tb_Address.Size = new System.Drawing.Size(150, 29);
            this.tb_Address.TabIndex = 8;
            this.tb_Address.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_Address.Watermark = "";
            // 
            // tb_DIscription
            // 
            this.tb_DIscription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_DIscription.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_DIscription.Location = new System.Drawing.Point(128, 207);
            this.tb_DIscription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_DIscription.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_DIscription.Name = "tb_DIscription";
            this.tb_DIscription.Padding = new System.Windows.Forms.Padding(5);
            this.tb_DIscription.ShowText = false;
            this.tb_DIscription.Size = new System.Drawing.Size(150, 29);
            this.tb_DIscription.TabIndex = 9;
            this.tb_DIscription.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_DIscription.Watermark = "";
            // 
            // btn_Change
            // 
            this.btn_Change.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Change.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Change.Location = new System.Drawing.Point(152, 319);
            this.btn_Change.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Change.Name = "btn_Change";
            this.btn_Change.Size = new System.Drawing.Size(100, 35);
            this.btn_Change.TabIndex = 10;
            this.btn_Change.Text = "修改";
            this.btn_Change.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Change.Click += new System.EventHandler(this.btn_Change_Click);
            // 
            // Form_ChangeParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 389);
            this.Controls.Add(this.btn_Change);
            this.Controls.Add(this.tb_DIscription);
            this.Controls.Add(this.tb_Address);
            this.Controls.Add(this.tb_DB);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.cb_Type);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.lab_DB);
            this.Controls.Add(this.Lab_ID);
            this.Controls.Add(this.uiLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_ChangeParameter";
            this.Text = "修改";
            this.Load += new System.EventHandler(this.Form_ChangeParameter_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel Lab_ID;
        private Sunny.UI.UILabel lab_DB;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIComboBox cb_Type;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox tb_DB;
        private Sunny.UI.UITextBox tb_Address;
        private Sunny.UI.UITextBox tb_DIscription;
        private Sunny.UI.UIButton btn_Change;
    }
}