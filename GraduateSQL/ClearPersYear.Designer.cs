namespace GraduateSQL
{
    partial class ClearPersYear
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
            this.label1 = new System.Windows.Forms.Label();
            this.mTextB_yearIssue = new MetroFramework.Controls.MetroTextBox();
            this.mBut_delPersYear = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Удалить всех студентов с годом выпуска";
            // 
            // mTextB_yearIssue
            // 
            this.mTextB_yearIssue.BackColor = System.Drawing.Color.SpringGreen;
            // 
            // 
            // 
            this.mTextB_yearIssue.CustomButton.Image = null;
            this.mTextB_yearIssue.CustomButton.Location = new System.Drawing.Point(76, 1);
            this.mTextB_yearIssue.CustomButton.Name = "";
            this.mTextB_yearIssue.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mTextB_yearIssue.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTextB_yearIssue.CustomButton.TabIndex = 1;
            this.mTextB_yearIssue.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTextB_yearIssue.CustomButton.UseSelectable = true;
            this.mTextB_yearIssue.CustomButton.Visible = false;
            this.mTextB_yearIssue.Lines = new string[0];
            this.mTextB_yearIssue.Location = new System.Drawing.Point(79, 52);
            this.mTextB_yearIssue.MaxLength = 32767;
            this.mTextB_yearIssue.Name = "mTextB_yearIssue";
            this.mTextB_yearIssue.PasswordChar = '\0';
            this.mTextB_yearIssue.PromptText = "Год выпуска";
            this.mTextB_yearIssue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTextB_yearIssue.SelectedText = "";
            this.mTextB_yearIssue.SelectionLength = 0;
            this.mTextB_yearIssue.SelectionStart = 0;
            this.mTextB_yearIssue.ShortcutsEnabled = true;
            this.mTextB_yearIssue.ShowClearButton = true;
            this.mTextB_yearIssue.Size = new System.Drawing.Size(100, 25);
            this.mTextB_yearIssue.TabIndex = 34;
            this.mTextB_yearIssue.UseSelectable = true;
            this.mTextB_yearIssue.WaterMark = "Год выпуска";
            this.mTextB_yearIssue.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTextB_yearIssue.WaterMarkFont = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // mBut_delPersYear
            // 
            this.mBut_delPersYear.BackColor = System.Drawing.Color.SeaGreen;
            this.mBut_delPersYear.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.mBut_delPersYear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.mBut_delPersYear.Location = new System.Drawing.Point(79, 83);
            this.mBut_delPersYear.Name = "mBut_delPersYear";
            this.mBut_delPersYear.Size = new System.Drawing.Size(100, 43);
            this.mBut_delPersYear.TabIndex = 33;
            this.mBut_delPersYear.Text = "Удалить";
            this.mBut_delPersYear.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mBut_delPersYear.UseCustomBackColor = true;
            this.mBut_delPersYear.UseCustomForeColor = true;
            this.mBut_delPersYear.UseSelectable = true;
            this.mBut_delPersYear.Click += new System.EventHandler(this.MBut_delPersYear_Click);
            // 
            // ClearPersYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 146);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mTextB_yearIssue);
            this.Controls.Add(this.mBut_delPersYear);
            this.Name = "ClearPersYear";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTextBox mTextB_yearIssue;
        private MetroFramework.Controls.MetroButton mBut_delPersYear;
    }
}