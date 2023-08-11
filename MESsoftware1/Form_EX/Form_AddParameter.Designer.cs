namespace MESsoftware1.Form_EX
{
    partial class Form_AddParameter
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
            this.Btn_Add = new Sunny.UI.UIButton();
            this.tb_DB = new Sunny.UI.UITextBox();
            this.tb_Address = new Sunny.UI.UITextBox();
            this.tb_Discription = new Sunny.UI.UITextBox();
            this.cb_Type = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // Btn_Add
            // 
            this.Btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Add.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Add.Location = new System.Drawing.Point(160, 254);
            this.Btn_Add.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(100, 35);
            this.Btn_Add.TabIndex = 0;
            this.Btn_Add.Text = "添加";
            this.Btn_Add.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // tb_DB
            // 
            this.tb_DB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_DB.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_DB.Location = new System.Drawing.Point(138, 38);
            this.tb_DB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_DB.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_DB.Name = "tb_DB";
            this.tb_DB.Padding = new System.Windows.Forms.Padding(5);
            this.tb_DB.ShowText = false;
            this.tb_DB.Size = new System.Drawing.Size(150, 29);
            this.tb_DB.TabIndex = 1;
            this.tb_DB.Text = "0";
            this.tb_DB.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_DB.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.tb_DB.Watermark = "";
            // 
            // tb_Address
            // 
            this.tb_Address.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Address.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Address.Location = new System.Drawing.Point(138, 91);
            this.tb_Address.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Address.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_Address.Name = "tb_Address";
            this.tb_Address.Padding = new System.Windows.Forms.Padding(5);
            this.tb_Address.ShowText = false;
            this.tb_Address.Size = new System.Drawing.Size(150, 29);
            this.tb_Address.TabIndex = 2;
            this.tb_Address.Text = "0";
            this.tb_Address.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_Address.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.tb_Address.Watermark = "";
            // 
            // tb_Discription
            // 
            this.tb_Discription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Discription.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Discription.Location = new System.Drawing.Point(138, 197);
            this.tb_Discription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Discription.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_Discription.Name = "tb_Discription";
            this.tb_Discription.Padding = new System.Windows.Forms.Padding(5);
            this.tb_Discription.ShowText = false;
            this.tb_Discription.Size = new System.Drawing.Size(201, 29);
            this.tb_Discription.TabIndex = 3;
            this.tb_Discription.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_Discription.Watermark = "";
            // 
            // cb_Type
            // 
            this.cb_Type.DataSource = null;
            this.cb_Type.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cb_Type.FillColor = System.Drawing.Color.White;
            this.cb_Type.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Type.Location = new System.Drawing.Point(138, 144);
            this.cb_Type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_Type.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cb_Type.Size = new System.Drawing.Size(150, 29);
            this.cb_Type.TabIndex = 4;
            this.cb_Type.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb_Type.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(101, 40);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(36, 23);
            this.uiLabel1.TabIndex = 5;
            this.uiLabel1.Text = "DB:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(89, 93);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(48, 23);
            this.uiLabel2.TabIndex = 6;
            this.uiLabel2.Text = "地址:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(89, 146);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(48, 23);
            this.uiLabel3.TabIndex = 7;
            this.uiLabel3.Text = "类型:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(89, 199);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(48, 23);
            this.uiLabel4.TabIndex = 8;
            this.uiLabel4.Text = "描述:";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_AddParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 313);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.cb_Type);
            this.Controls.Add(this.tb_Discription);
            this.Controls.Add(this.tb_Address);
            this.Controls.Add(this.tb_DB);
            this.Controls.Add(this.Btn_Add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_AddParameter";
            this.Text = "添加";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton Btn_Add;
        private Sunny.UI.UITextBox tb_DB;
        private Sunny.UI.UITextBox tb_Address;
        private Sunny.UI.UITextBox tb_Discription;
        private Sunny.UI.UIComboBox cb_Type;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
    }
}