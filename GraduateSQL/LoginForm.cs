using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Data.SqlClient;
using SharpUpdate;
using System.Reflection;

namespace GraduateSQL
{
    public partial class LoginForm : MetroForm
    {
        public LoginForm()
        {
            InitializeComponent();
            TopMost = true;
        }
        int idUser = 0;
        DataSet ds;
        SqlDataAdapter adapter;
        string connectionString = "Server=192.168.250.25;Database=graduatesZ;user=Rupit;password=Grib04ek:";
        SqlDataReader sqlReader = null;
        private SharpUpdater updater;

        private void Logger(string login, string password)
        {
            //Заглушка на пустоту 
            if (mtxt_Login == null) throw new ArgumentNullException("login");
            if (mtxt_Password == null) throw new ArgumentNullException("password");
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter("SELECT us.id, us.login, us.password " +
                                                 "FROM usersRole ur " +
                                                 "INNER JOIN users AS us ON ur.idUser = us.id  " +
                                                 "INNER JOIN role AS ro ON ur.idRole = ro.id " +
                                                 "WHERE login = '" + login + "' and password = '" + password + "'", connectionString);
                    // Извлекаб id пользоывателя
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "userRole");
                    foreach (DataRow row in ds.Tables["userRole"].Rows)
                    {
                        idUser = int.Parse(row["id"].ToString());
                    }

                    DataTable dtb1 = new DataTable();
                    adapter.Fill(dtb1);
                    if (dtb1.Rows.Count == 1)
                    {
                        new MainForm(idUser).Show();
                        this.Hide();
                    }
                    else { MessageBox.Show("Не верно введен логин или пароль"); }
                    connection.Close();
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { if (sqlReader != null) sqlReader.Close(); }
        }

        private void MbtnLogin_Click_1(object sender, EventArgs e)
        {
            Logger(mtxt_Login.Text, mtxt_Password.Text);
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
        
            updater = new SharpUpdater(Assembly.GetExecutingAssembly(), this, new Uri("https://raw.githubusercontent.com/RuslanDaemon/UpdateGraduate/master/vesrion.xml"));

            mtxt_Login.Text = Properties.Settings.Default.login;
            mtxt_Password.Text = Properties.Settings.Default.password;
        }

        private void MetroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                Properties.Settings.Default.ISResult = metroCheckBox1.Checked;
                Properties.Settings.Default.login = mtxt_Login.Text;
                Properties.Settings.Default.password = mtxt_Password.Text;
                Properties.Settings.Default.Save();
            }
        }

      
    }
}
