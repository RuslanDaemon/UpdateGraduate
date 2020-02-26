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
    public partial class OrderFreeWork : MetroForm
    {
        int idUser = 0;
        public int idOreder = 0;
        string connectionString = "Server=192.168.250.25;Database=graduatesZ;user=Rupit;password=Grib04ek:";
        string LogDelOrder;
        public OrderFreeWork(int idUser)
        {
            InitializeComponent();
            this.idUser = idUser;
        }

        #region Заполнение таблицы
        public void funDGV()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                dgv_freeWork.Columns.Clear();
                dgv_freeWork.Rows.Clear();
                dgv_freeWork.Columns.Add("id", "id"); // 0
                dgv_freeWork.Columns.Add("nameFreeWork", "Название приказа"); // 1
                dgv_freeWork.Columns[0].Visible = false; // id не видим

                SqlCommand command = null;
                SqlDataReader reader = null;
                int count_pers = 0;

                string query = "SELECT id, nameFreeWork from freeWork";
                connection.Open();
                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dgv_freeWork.Rows.Add();
                    dgv_freeWork["id", count_pers].Value = reader.GetValue(0);
                    dgv_freeWork["nameFreeWork", count_pers].Value = reader.GetValue(1);
                    count_pers++;
                }
               // countOrders.Text = "Всего записей: " + dgv_freeWork.Rows.Count.ToString();
            }
            dgv_freeWork.Rows[0].Visible = false;
        }
        #endregion

        #region Load
        private void OrderFreeWork_Load(object sender, EventArgs e)
        {
            funDGV();
            mTextB_editFreeWork.Visible = false;
            mBut_editFreeWork.Visible = false;
        }
        #endregion

        #region Del
        private void Dgv_freeWork_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { contextDVG_freeWork.Show(Cursor.Position.X, Cursor.Position.Y); }
        }

        private void Dgv_freeWork_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    dgv_freeWork.CurrentCell = dgv_freeWork.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgv_freeWork.Rows[e.RowIndex].Selected = true;
                    dgv_freeWork.Focus();
                    idOreder = (int)dgv_freeWork["id", e.RowIndex].Value;
                    Click += new EventHandler(Menu_delFreeWork_Click);
                    LogDelOrder = "id:" + dgv_freeWork["id", e.RowIndex].Value.ToString() + " nameFreeWork: " + dgv_freeWork["nameFreeWork", e.RowIndex].Value.ToString();
                }
                catch (ArgumentOutOfRangeException) { MessageBox.Show("Выберите ячейку"); }
            }
        }

        private void Menu_delFreeWork_Click(object sender, EventArgs e)
        {
            //ToolStripItem clickedItem = sender as ToolStripItem;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var Result = MessageBox.Show("Вы уверены что хотите удалить данную запись?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string queryDellOrder = "DELETE FROM freeWork WHERE id = " + idOreder;
                try
                {
                    if (Result == DialogResult.Yes)
                    {
                        using (SqlCommand command = new SqlCommand(queryDellOrder, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                            funDGV();
                            MessageBox.Show("Запись удалена");
                            mTextB_editFreeWork.Clear();
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
                            command.Parameters.AddWithValue("@fielTable", "all");
                            command.Parameters.AddWithValue("@oldValue", LogDelOrder);
                            command.Parameters.AddWithValue("@dateCrt", DateTime.Now);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                }
                catch { MessageBox.Show("Данного приказа уже нет"); }
            }
        }

     
        #endregion

        #region INSERT UPDATE
        private void MBut_addFreeWork_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (idOreder == 0)
                    {
                        string queryPerson = "INSERT INTO freeWork (nameFreeWork) Values(@nameFreeWork)";
                        using (SqlCommand command = new SqlCommand(queryPerson, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@nameFreeWork", mTextB_addFreeWork.Text.Trim());
                            command.ExecuteNonQuery();
                            connection.Close();
                            funDGV();
                            MessageBox.Show("Запись добавлена");
                            mTextB_addFreeWork.Clear();
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void MBut_editFreeWork_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (idOreder != 0)
                    {
                        string queryPerson = "UPDATE freeWork set nameFreeWork = @nameFreeWork Where id = " + idOreder;
                        using (SqlCommand command = new SqlCommand(queryPerson, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@nameFreeWork", mTextB_editFreeWork.Text.Trim());
                            command.ExecuteNonQuery();
                            connection.Close();
                            funDGV();
                            MessageBox.Show("Запись изменина");
                        }
                    }
                }
                catch { MessageBox.Show("Данного приказа уже нет"); }
            }
        }
        #endregion

        private void Dgv_freeWork_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand command = null;
            SqlConnection connection = null;

            int idOreders = (int)dgv_freeWork["id", e.RowIndex].Value;
            string query_fwid = "select d.nameFreeWork from freeWork d where d.id = " + idOreders;
            mTextB_editFreeWork.Visible = true;

            if (query_fwid != null)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(query_fwid, connection);
                SqlDataReader read = command.ExecuteReader();
                if (read.Read())
                {
                    mTextB_editFreeWork.Text = read.GetValue(0).ToString();
                }
                read.Close();
                mBut_editFreeWork.Visible = true;
                idOreder = idOreders;
            }
        }
    }
}
