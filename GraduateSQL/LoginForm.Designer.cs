namespace GraduateSQL
{
    partial class LoginForm
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
            this.mbtnLogin = new MetroFramework.Controls.MetroButton();
            this.mtxt_Password = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_Login = new MetroFramework.Controls.MetroTextBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // mbtnLogin
            // 
            this.mbtnLogin.BackColor = System.Drawing.Color.SeaGreen;
            this.mbtnLogin.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.mbtnLogin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.mbtnLogin.Location = new System.Drawing.Point(23, 139);
            this.mbtnLogin.Name = "mbtnLogin";
            this.mbtnLogin.Size = new System.Drawing.Size(167, 32);
            this.mbtnLogin.TabIndex = 3;
            this.mbtnLogin.Text = "Войти";
            this.mbtnLogin.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mbtnLogin.UseCustomBackColor = true;
            this.mbtnLogin.UseCustomForeColor = true;
            this.mbtnLogin.UseSelectable = true;
            this.mbtnLogin.Click += new System.EventHandler(this.MbtnLogin_Click_1);
            // 
            // mtxt_Password
            // 
            this.mtxt_Password.BackColor = System.Drawing.Color.SpringGreen;
            // 
            // 
            // 
            this.mtxt_Password.CustomButton.Image = null;
            this.mtxt_Password.CustomButton.Location = new System.Drawing.Point(143, 1);
            this.mtxt_Password.CustomButton.Name = "";
            this.mtxt_Password.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_Password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_Password.CustomButton.TabIndex = 1;
            this.mtxt_Password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_Password.CustomButton.UseSelectable = true;
            this.mtxt_Password.CustomButton.Visible = false;
            this.mtxt_Password.Lines = new string[0];
            this.mtxt_Password.Location = new System.Drawing.Point(23, 89);
            this.mtxt_Password.MaxLength = 32767;
            this.mtxt_Password.Name = "mtxt_Password";
            this.mtxt_Password.PasswordChar = '●';
            this.mtxt_Password.PromptText = "Пароль";
            this.mtxt_Password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_Password.SelectedText = "";
            this.mtxt_Password.SelectionLength = 0;
            this.mtxt_Password.SelectionStart = 0;
            this.mtxt_Password.ShortcutsEnabled = true;
            this.mtxt_Password.ShowClearButton = true;
            this.mtxt_Password.Size = new System.Drawing.Size(167, 25);
            this.mtxt_Password.Style = MetroFramework.MetroColorStyle.Green;
            this.mtxt_Password.TabIndex = 2;
            this.mtxt_Password.UseSelectable = true;
            this.mtxt_Password.UseSystemPasswordChar = true;
            this.mtxt_Password.WaterMark = "Пароль";
            this.mtxt_Password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_Password.WaterMarkFont = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // mtxt_Login
            // 
            this.mtxt_Login.BackColor = System.Drawing.Color.SpringGreen;
            // 
            // 
            // 
            this.mtxt_Login.CustomButton.Image = null;
            this.mtxt_Login.CustomButton.Location = new System.Drawing.Point(143, 1);
            this.mtxt_Login.CustomButton.Name = "";
            this.mtxt_Login.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_Login.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_Login.CustomButton.TabIndex = 1;
            this.mtxt_Login.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_Login.CustomButton.UseSelectable = true;
            this.mtxt_Login.CustomButton.Visible = false;
            this.mtxt_Login.Lines = new string[0];
            this.mtxt_Login.Location = new System.Drawing.Point(23, 58);
            this.mtxt_Login.MaxLength = 32767;
            this.mtxt_Login.Name = "mtxt_Login";
            this.mtxt_Login.PasswordChar = '\0';
            this.mtxt_Login.PromptText = "Логин";
            this.mtxt_Login.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_Login.SelectedText = "";
            this.mtxt_Login.SelectionLength = 0;
            this.mtxt_Login.SelectionStart = 0;
            this.mtxt_Login.ShortcutsEnabled = true;
            this.mtxt_Login.ShowClearButton = true;
            this.mtxt_Login.Size = new System.Drawing.Size(167, 25);
            this.mtxt_Login.Style = MetroFramework.MetroColorStyle.Green;
            this.mtxt_Login.TabIndex = 1;
            this.mtxt_Login.UseSelectable = true;
            this.mtxt_Login.WaterMark = "Логин";
            this.mtxt_Login.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_Login.WaterMarkFont = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(23, 120);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(79, 13);
            this.metroCheckBox1.TabIndex = 4;
            this.metroCheckBox1.Text = "Запомнить";
            this.metroCheckBox1.UseSelectable = true;
            this.metroCheckBox1.CheckedChanged += new System.EventHandler(this.MetroCheckBox1_CheckedChanged);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(0, 0);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.UseSelectable = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 193);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.mbtnLogin);
            this.Controls.Add(this.mtxt_Password);
            this.Controls.Add(this.mtxt_Login);
            this.Name = "LoginForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton mbtnLogin;
        private MetroFramework.Controls.MetroTextBox mtxt_Password;
        private MetroFramework.Controls.MetroTextBox mtxt_Login;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}