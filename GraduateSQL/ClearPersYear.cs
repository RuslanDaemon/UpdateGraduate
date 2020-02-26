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

namespace GraduateSQL
{
    public partial class ClearPersYear : MetroForm
    {
        string connectionString = "Server=192.168.250.25;Database=graduatesZ;user=Rupit;password=Grib04ek:";
        int idUser = 0;
        int idDell = 0;
        public ClearPersYear(int idUser)
        {
            InitializeComponent();
            this.idUser = idUser;
        }

        private void MBut_delPersYear_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var Result = MessageBox.Show("Вы уверены что хотите удалить ВСЕХ студентов с годом выпуска " + mTextB_yearIssue.Text.Trim() + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string queryDellPTW = "DELETE FROM persons WHERE yearIssue = " + mTextB_yearIssue.Text.Trim();
               // string queryDellPers = "DELETE FROM persToWork WHERE id = " + idDell;
                try
                {
                    if (Result == DialogResult.Yes)
                    {
                        using (SqlCommand command = new SqlCommand(queryDellPTW, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }

                        string queryDellOrderLog = "INSERT INTO logs " +
                         "(idUser, typeSql, nameTable, fielTable, oldValue, dateCrt) " +
                         "Values(@idUser, @typeSql, @nameTable, @fielTable, @oldValue, @dateCrt)";
                        using (SqlCommand command = new SqlCommand(queryDellOrderLog, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@idUser", idUser);
                            command.Parameters.AddWithValue("@typeSql", "Delete");
                            command.Parameters.AddWithValue("@nameTable", "perstToWork, persons");
                            command.Parameters.AddWithValue("@fielTable", "ALL In a year");
                            command.Parameters.AddWithValue("@dateCrt", DateTime.Now);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                        
                        MessageBox.Show("Студенты удалены");
                    }
                }
                catch { MessageBox.Show("В этом году не было выпускников или в БД нет записей за этот год"); }
            }
        }
    }
}
