namespace GraduateSQL
{
    partial class OrderFreeWork
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mBut_editFreeWork = new MetroFramework.Controls.MetroButton();
            this.mTextB_editFreeWork = new MetroFramework.Controls.MetroTextBox();
            this.mBut_addFreeWork = new MetroFramework.Controls.MetroButton();
            this.mTextB_addFreeWork = new MetroFramework.Controls.MetroTextBox();
            this.contextDVG_freeWork = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_delFreeWork = new System.Windows.Forms.ToolStripMenuItem();
            this.countOrders = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dgv_freeWork = new MetroFramework.Controls.MetroGrid();
            this.contextDVG_freeWork.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_freeWork)).BeginInit();
            this.SuspendLayout();
            // 
            // mBut_editFreeWork
            // 
            this.mBut_editFreeWork.BackColor = System.Drawing.Color.SeaGreen;
            this.mBut_editFreeWork.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.mBut_editFreeWork.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.mBut_editFreeWork.Location = new System.Drawing.Point(340, 91);
            this.mBut_editFreeWork.Name = "mBut_editFreeWork";
            this.mBut_editFreeWork.Size = new System.Drawing.Size(153, 32);
            this.mBut_editFreeWork.TabIndex = 37;
            this.mBut_editFreeWork.Text = "Редактировать";
            this.mBut_editFreeWork.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mBut_editFreeWork.UseCustomBackColor = true;
            this.mBut_editFreeWork.UseCustomForeColor = true;
            this.mBut_editFreeWork.UseSelectable = true;
            this.mBut_editFreeWork.Click += new System.EventHandler(this.MBut_editFreeWork_Click);
            // 
            // mTextB_editFreeWork
            // 
            this.mTextB_editFreeWork.BackColor = System.Drawing.Color.SpringGreen;
            // 
            // 
            // 
            this.mTextB_editFreeWork.CustomButton.Image = null;
            this.mTextB_editFreeWork.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.mTextB_editFreeWork.CustomButton.Name = "";
            this.mTextB_editFreeWork.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mTextB_editFreeWork.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTextB_editFreeWork.CustomButton.TabIndex = 1;
            this.mTextB_editFreeWork.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTextB_editFreeWork.CustomButton.UseSelectable = true;
            this.mTextB_editFreeWork.Lines = new string[0];
            this.mTextB_editFreeWork.Location = new System.Drawing.Point(340, 60);
            this.mTextB_editFreeWork.MaxLength = 32767;
            this.mTextB_editFreeWork.Name = "mTextB_editFreeWork";
            this.mTextB_editFreeWork.PasswordChar = '\0';
            this.mTextB_editFreeWork.PromptText = "Название приказа";
            this.mTextB_editFreeWork.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTextB_editFreeWork.SelectedText = "";
            this.mTextB_editFreeWork.SelectionLength = 0;
            this.mTextB_editFreeWork.SelectionStart = 0;
            this.mTextB_editFreeWork.ShortcutsEnabled = true;
            this.mTextB_editFreeWork.ShowButton = true;
            this.mTextB_editFreeWork.ShowClearButton = true;
            this.mTextB_editFreeWork.Size = new System.Drawing.Size(153, 25);
            this.mTextB_editFreeWork.TabIndex = 36;
            this.mTextB_editFreeWork.UseSelectable = true;
            this.mTextB_editFreeWork.WaterMark = "Название приказа";
            this.mTextB_editFreeWork.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTextB_editFreeWork.WaterMarkFont = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // mBut_addFreeWork
            // 
            this.mBut_addFreeWork.BackColor = System.Drawing.Color.SeaGreen;
            this.mBut_addFreeWork.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.mBut_addFreeWork.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.mBut_addFreeWork.Location = new System.Drawing.Point(168, 91);
            this.mBut_addFreeWork.Name = "mBut_addFreeWork";
            this.mBut_addFreeWork.Size = new System.Drawing.Size(153, 32);
            this.mBut_addFreeWork.TabIndex = 35;
            this.mBut_addFreeWork.Text = "Новый приказ";
            this.mBut_addFreeWork.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mBut_addFreeWork.UseCustomBackColor = true;
            this.mBut_addFreeWork.UseCustomForeColor = true;
            this.mBut_addFreeWork.UseSelectable = true;
            this.mBut_addFreeWork.Click += new System.EventHandler(this.MBut_addFreeWork_Click);
            // 
            // mTextB_addFreeWork
            // 
            this.mTextB_addFreeWork.BackColor = System.Drawing.Color.SpringGreen;
            // 
            // 
            // 
            this.mTextB_addFreeWork.CustomButton.Image = null;
            this.mTextB_addFreeWork.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.mTextB_addFreeWork.CustomButton.Name = "";
            this.mTextB_addFreeWork.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mTextB_addFreeWork.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTextB_addFreeWork.CustomButton.TabIndex = 1;
            this.mTextB_addFreeWork.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTextB_addFreeWork.CustomButton.UseSelectable = true;
            this.mTextB_addFreeWork.Lines = new string[0];
            this.mTextB_addFreeWork.Location = new System.Drawing.Point(168, 60);
            this.mTextB_addFreeWork.MaxLength = 32767;
            this.mTextB_addFreeWork.Name = "mTextB_addFreeWork";
            this.mTextB_addFreeWork.PasswordChar = '\0';
            this.mTextB_addFreeWork.PromptText = "Название приказа";
            this.mTextB_addFreeWork.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTextB_addFreeWork.SelectedText = "";
            this.mTextB_addFreeWork.SelectionLength = 0;
            this.mTextB_addFreeWork.SelectionStart = 0;
            this.mTextB_addFreeWork.ShortcutsEnabled = true;
            this.mTextB_addFreeWork.ShowButton = true;
            this.mTextB_addFreeWork.ShowClearButton = true;
            this.mTextB_addFreeWork.Size = new System.Drawing.Size(153, 25);
            this.mTextB_addFreeWork.TabIndex = 34;
            this.mTextB_addFreeWork.UseSelectable = true;
            this.mTextB_addFreeWork.WaterMark = "Название приказа";
            this.mTextB_addFreeWork.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTextB_addFreeWork.WaterMarkFont = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // contextDVG_freeWork
            // 
            this.contextDVG_freeWork.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_delFreeWork});
            this.contextDVG_freeWork.Name = "contextDVG_freeWork";
            this.contextDVG_freeWork.Size = new System.Drawing.Size(115, 26);
            // 
            // Menu_delFreeWork
            // 
            this.Menu_delFreeWork.Name = "Menu_delFreeWork";
            this.Menu_delFreeWork.Size = new System.Drawing.Size(114, 22);
            this.Menu_delFreeWork.Text = "удалить";
            this.Menu_delFreeWork.Click += new System.EventHandler(this.Menu_delFreeWork_Click);
            // 
            // countOrders
            // 
            this.countOrders.Name = "countOrders";
            this.countOrders.Size = new System.Drawing.Size(10, 17);
            this.countOrders.Text = ".";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countOrders});
            this.statusStrip1.Location = new System.Drawing.Point(20, 408);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(476, 22);
            this.statusStrip1.TabIndex = 38;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dgv_freeWork
            // 
            this.dgv_freeWork.AllowUserToAddRows = false;
            this.dgv_freeWork.AllowUserToDeleteRows = false;
            this.dgv_freeWork.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_freeWork.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_freeWork.BackgroundColor = System.Drawing.Color.White;
            this.dgv_freeWork.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_freeWork.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_freeWork.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_freeWork.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_freeWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_freeWork.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_freeWork.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv_freeWork.EnableHeadersVisualStyles = false;
            this.dgv_freeWork.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgv_freeWork.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv_freeWork.Location = new System.Drawing.Point(20, 60);
            this.dgv_freeWork.MultiSelect = false;
            this.dgv_freeWork.Name = "dgv_freeWork";
            this.dgv_freeWork.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_freeWork.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_freeWork.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_freeWork.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_freeWork.Size = new System.Drawing.Size(142, 348);
            this.dgv_freeWork.TabIndex = 67;
            this.dgv_freeWork.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_freeWork_CellDoubleClick);
            this.dgv_freeWork.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_freeWork_CellMouseDown);
            this.dgv_freeWork.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Dgv_freeWork_MouseClick);
            // 
            // OrderFreeWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 450);
            this.Controls.Add(this.dgv_freeWork);
            this.Controls.Add(this.mBut_editFreeWork);
            this.Controls.Add(this.mTextB_editFreeWork);
            this.Controls.Add(this.mBut_addFreeWork);
            this.Controls.Add(this.mTextB_addFreeWork);
            this.Controls.Add(this.statusStrip1);
            this.Name = "OrderFreeWork";
            this.Text = "Самостоятельное трудоустройство";
            this.Load += new System.EventHandler(this.OrderFreeWork_Load);
            this.contextDVG_freeWork.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_freeWork)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton mBut_editFreeWork;
        private MetroFramework.Controls.MetroTextBox mTextB_editFreeWork;
        private MetroFramework.Controls.MetroButton mBut_addFreeWork;
        private MetroFramework.Controls.MetroTextBox mTextB_addFreeWork;
        private System.Windows.Forms.ContextMenuStrip contextDVG_freeWork;
        private System.Windows.Forms.ToolStripMenuItem Menu_delFreeWork;
        private System.Windows.Forms.ToolStripStatusLabel countOrders;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private MetroFramework.Controls.MetroGrid dgv_freeWork;
    }
}