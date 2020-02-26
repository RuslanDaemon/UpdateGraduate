using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Data.SqlClient;

namespace GraduateSQL
{
    public partial class PersonalCards : MetroForm
    {
        string connectionString = "Server=192.168.250.25;Database=graduatesZ;user=Rupit;password=Grib04ek:";
        int idUser = 0;
        int idPersToWork = 0;
        int lastIdPersosn = 0;
        int fwid = 0;
        string fw2; //id freeWork
        string qid; //id qualification
        string sqlGrid = String.Empty;
        string LogNewValue;

        public PersonalCards(int idUser, int idPersToWork)
        {
            InitializeComponent();
            this.idUser = idUser;
            this.idPersToWork = idPersToWork;
        }

        public PersonalCards(int idUser)
        {
            InitializeComponent();
            this.idUser = idUser;
        }

        #region Размер GroupBox адресс проживания
        private void autoSizeGroupB_address()/////////////////////////////////////////////////////////////////////////////////
        {
            groupBox3.Height = 175; //95
            foreach (MetroTextBox textBox in groupBox3.Controls.OfType<MetroTextBox>())
                groupBox3.Height -= textBox.Visible ? 0 : 25;
        }
        #endregion

        #region loadFreeWork
        private void loadFreeWork()
        {
            mComboB_freeWork.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryDepartments = "select d.nameFreeWork from freeWork d";
                using (var sql = new SqlDataAdapter(queryDepartments, connectionString))
                {
                    DataSet ds = new DataSet();
                    sql.Fill(ds, "freeWork");
                    foreach (DataRow row in ds.Tables["freeWork"].Rows)
                    {
                        mComboB_freeWork.Items.Add(
                        row[0].ToString()
                        );
                    }
                    connection.Close();
                }
            }
        }
        #endregion

        #region Load
        
        private void PersonalCards_Load(object sender, EventArgs e)
        {
            mTextB_addressRegion.Visible = false; // В БД есть, но не используються в программе по желанию заказчика
            mTextB_addressArea.Visible = false; // В БД есть, но не используються в программе по желанию заказчика
            mTextB_addressFlat.Visible = false; // В БД есть, но не используються в программе по желанию заказчика

            mTextB_numCertificate.Enabled = true; // Свидетельство
            mTextB_numReference.Enabled = false; // Спрака
            loadFreeWork(); // Заполнение комбобокса Самостоятельное трудоустройство
            autoSizeGroupB_address();
            if (idPersToWork != 0) loadPersons();
            mTextB_yearIssue.MaxLength = 4; // Ограничение на вввод, придумать лучше
        }
        #endregion

        #region загрузка бд уже существующего студента по клике на основную таблицу
        private void loadPersons()
        {
            SqlCommand command = null;
            SqlConnection connection = null;
            sqlGrid = "SELECT per.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                       "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                       "FROM persToWork AS pw " +
                                       "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                       "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                       "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                       "WHERE pw.id = " + idPersToWork;
            if (sqlGrid != null)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(sqlGrid, connection);
                //    reader = command.ExecuteReader();
                SqlDataReader read = command.ExecuteReader();
                if (read.Read())
                {
                    mTextB_surname.Text = read.GetValue(1).ToString();
                    mTextB_name.Text = read.GetValue(2).ToString();
                    mTextB_patronymic.Text = read.GetValue(3).ToString();
                    dateTime_birthday.Value = Convert.ToDateTime(read.GetValue(4));
                    mComboB_gender.Text = read.GetValue(5).ToString();

                    mTextB_addressCountry.Text = read.GetValue(6).ToString();
                    //mTextB_addressRegion.Text = (read["Data_Important"].ToString());
                    // mTextB_addressArea.Text = (read["Landline"].ToString());
                    mTextB_addressCity.Text = read.GetValue(7).ToString();
                    mTextB_addressStreet.Text = read.GetValue(8).ToString();
                    mTextB_addressHome.Text = read.GetValue(9).ToString();
                    //mTextB_addressFlat.Text = (read["Fault_Report"].ToString());

                    mComboB_qualificationLevel.Text = read.GetValue(10).ToString();
                    mTextB_trainingDirection.Text = read.GetValue(11).ToString();
                    mTextB_profile.Text = read.GetValue(12).ToString();
                    mTextB_yearIssue.Text = read.GetValue(13).ToString();

                    mTextB_nameStateOrg.Text = read.GetValue(14).ToString();
                    mTextB_educational.Text = read.GetValue(15).ToString();
                    mTextB_nameOrg.Text = read.GetValue(16).ToString();
                    mTextB_post.Text = read.GetValue(17).ToString();
                    mTextB_cityOrg.Text = read.GetValue(18).ToString();

                    mTextB_numCertificate.Text = read.GetValue(19).ToString();
                    mComboB_freeWork.SelectedItem = read.GetValue(20).ToString();
                    mTextB_numReference.Text = read.GetValue(21).ToString();
                    mComboB_verificationArrival.Text = read.GetValue(22).ToString() == "T" ? "в наличии" : "отсутствует";
                    mTextB_commentary.Text = read.GetValue(23).ToString();

                }
                read.Close();

            }
            else MessageBox.Show("Ошибка открытития персоны");

        }
        #endregion

        #region UPDATE INSERT
        private void MBut_savePersCard_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (idPersToWork == 0 && idUser != 0)
                    {
                        #region INSERT новая персона

                        int qid = mComboB_qualificationLevel.Text == "бакалавр" ? 1 : 2;
                        string queryQualification = "select d.id from typeQualification d where d.id = '" + qid.ToString() + "'";
                        using (var sql = new SqlDataAdapter(queryQualification, connectionString))
                        {
                            DataSet ds = new DataSet();
                            sql.Fill(ds, "typeQualification");
                            foreach (DataRow row in ds.Tables["typeQualification"].Rows)
                            {
                                qid = int.Parse(row[0].ToString());
                            }
                            connection.Close();
                        }

                        string queryPerson = "INSERT INTO persons " +
                            "(idTypeQualification, surname, name, patronymic, birthday, gender, addressCountry, addressCity, addressStreet, addressHome, trainingDirection, profile, yearIssue) " +
                            "Values(@idTypeQualification, @surname, @name, @patronymic, @birthday, @gender, @addressCountry, @addressCity, @addressStreet, @addressHome, @trainingDirection, @profile, @yearIssue)";
                        using (SqlCommand command = new SqlCommand(queryPerson, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@idTypeQualification", qid);
                            command.Parameters.AddWithValue("@surname", mTextB_surname.Text.Trim());
                            command.Parameters.AddWithValue("@name", mTextB_name.Text.Trim());
                            command.Parameters.AddWithValue("@patronymic", mTextB_patronymic.Text.Trim());
                            command.Parameters.AddWithValue("@birthday", dateTime_birthday.Value);
                            command.Parameters.AddWithValue("@gender", mComboB_gender.Text.Trim());

                            command.Parameters.AddWithValue("@addressCountry", mTextB_addressCountry.Text.Trim());
                            // ps.addressRegion = mTextB_addressRegion.Text.Trim();
                            // ps.addressArea = mTextB_addressArea.Text.Trim();
                            command.Parameters.AddWithValue("@addressCity", mTextB_addressCity.Text.Trim());
                            command.Parameters.AddWithValue("@addressStreet", mTextB_addressStreet.Text.Trim());
                            command.Parameters.AddWithValue("@addressHome", mTextB_addressHome.Text.Trim());
                            // ps.addressFlat = mTextB_addressFlat.Text.Trim();
                            command.Parameters.AddWithValue("@trainingDirection", mTextB_trainingDirection.Text.Trim());
                            command.Parameters.AddWithValue("@profile", mTextB_profile.Text.Trim());
                            command.Parameters.AddWithValue("@yearIssue", mTextB_yearIssue.Text.Trim()); // ps.yearIssue = mTextB_yearIssue.Text == "" ? ps.yearIssue = 1970 : Convert.ToInt16(mTextB_yearIssue.Text.Trim());
                            command.Parameters.AddWithValue("@dateCrt", DateTime.Now);
                            command.ExecuteNonQuery();
                            command.CommandText = "SELECT @@IDENTITY";
                            lastIdPersosn = Convert.ToInt32(command.ExecuteScalar());
                            connection.Close();
                        }

                        string query_fwid = "select d.id  from freeWork d where d.nameFreeWork = '" + mComboB_freeWork.Text + "'";
                        using (var sql = new SqlDataAdapter(query_fwid, connectionString))
                        {
                            DataSet ds = new DataSet();
                            sql.Fill(ds, "freeWork");
                            foreach (DataRow row in ds.Tables["freeWork"].Rows)
                            {
                                fwid = int.Parse(row[0].ToString());
                            }
                            connection.Close();
                        }

                        string queryPerstoWork = "INSERT INTO persToWork " +
                            "(idPers, idFreeWork, nameStateOrg, educational, nameOrg, post, cityOrg, numCertificate, numReference, verificationArrival, commentary) " +
                       "Values(@idPers, @idFreeWork, @nameStateOrg, @educational, @nameOrg, @post, @cityOrg, @numCertificate, @numReference, @verificationArrival, @commentary)";
                        using (SqlCommand command = new SqlCommand(queryPerstoWork, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@idPers", lastIdPersosn);
                            command.Parameters.AddWithValue("@idFreeWork", fwid);
                            command.Parameters.AddWithValue("@nameStateOrg", mTextB_nameStateOrg.Text.Trim());
                            command.Parameters.AddWithValue("@educational", mTextB_educational.Text.Trim());
                            command.Parameters.AddWithValue("@nameOrg", mTextB_nameOrg.Text.Trim());

                            command.Parameters.AddWithValue("@post", mTextB_cityOrg.Text.Trim());
                            command.Parameters.AddWithValue("@cityOrg", mTextB_cityOrg.Text.Trim());
                            command.Parameters.AddWithValue("@numCertificate", mTextB_numCertificate.Text.Trim());
                            command.Parameters.AddWithValue("@numReference", mTextB_numReference.Text.Trim());

                            command.Parameters.AddWithValue("@verificationArrival", mComboB_verificationArrival.Text == "в наличии" ? "T" : "F");
                            command.Parameters.AddWithValue("@commentary", mTextB_commentary.Text.Trim());
                            command.ExecuteNonQuery();
                            // Получаю id добавленной записи
                            connection.Close();
                        }

                        LogNewValue = "idPersToWork:" + idPersToWork + " idPers:" + lastIdPersosn + " ФИО: " + mTextB_surname.Text.Trim()+ " " + mTextB_name.Text.Trim() + " " + mTextB_patronymic.Text.Trim();
                        string queryLogInsert = "INSERT INTO logs " +
                           "(idUser, typeSql, nameTable, fielTable, newValue, dateCrt) " +
                           "Values(@idUser, @typeSql, @newValue, @fielTable, @newValue, @dateCrt)";
                        using (SqlCommand command = new SqlCommand(queryLogInsert, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@idUser", idUser);
                            command.Parameters.AddWithValue("@typeSql", "Insert");
                            command.Parameters.AddWithValue("@nameTable", "perstToWork, persons");
                            command.Parameters.AddWithValue("@fielTable", "all");
                            command.Parameters.AddWithValue("@newValue", LogNewValue);
                            command.Parameters.AddWithValue("@dateCrt", DateTime.Now);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }

                        MessageBox.Show("Запись добавлена");
                        #endregion
                    }

                    else
                    {
                        #region UPDATE Изменение информации о персоне
                        string fw1 = mComboB_freeWork.SelectedItem.ToString();
                        string query_fwid = "select d.id from freeWork d where d.nameFreeWork = '" + fw1 + "'";
                        using (var sql = new SqlDataAdapter(query_fwid, connectionString))
                        {
                            DataSet ds = new DataSet();
                            sql.Fill(ds, "freeWork");
                            foreach (DataRow row in ds.Tables["freeWork"].Rows)
                            { fw2 = row[0].ToString(); }
                            connection.Close();
                        }

                        string queryPerstoWork = "Update persToWork set " +
                            "idFreeWork = @idFreeWork, nameStateOrg = @nameStateOrg, educational = @educational, nameOrg = @nameOrg, post = @post, cityOrg = @cityOrg, " +
                            "numCertificate = @numCertificate, numReference = @numReference, verificationArrival = @verificationArrival, commentary = @commentary " +
                            "WHERE id = " + idPersToWork;
                        using (SqlCommand command = new SqlCommand(queryPerstoWork, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@idFreeWork", fw2);
                            command.Parameters.AddWithValue("@nameStateOrg", mTextB_nameStateOrg.Text.Trim());
                            command.Parameters.AddWithValue("@educational", mTextB_educational.Text.Trim());
                            command.Parameters.AddWithValue("@nameOrg", mTextB_nameOrg.Text.Trim());

                            command.Parameters.AddWithValue("@post", mTextB_cityOrg.Text.Trim());
                            command.Parameters.AddWithValue("@cityOrg", mTextB_cityOrg.Text.Trim());
                            command.Parameters.AddWithValue("@numCertificate", mTextB_numCertificate.Text.Trim());
                            command.Parameters.AddWithValue("@numReference", mTextB_numReference.Text.Trim());

                            command.Parameters.AddWithValue("@verificationArrival", mComboB_verificationArrival.Text == "в наличии" ? "T" : "F");
                            command.Parameters.AddWithValue("@commentary", mTextB_commentary.Text.Trim());
                            command.ExecuteNonQuery();
                            // Получаю id добавленной записи
                            connection.Close();
                        }

                        string qidComboB = mComboB_qualificationLevel.SelectedItem.ToString();
                        string queryQualification = "select d.id from typeQualification d where d.nameQualification = '" + qidComboB + "'";
                        using (var sql = new SqlDataAdapter(queryQualification, connectionString))
                        {
                            DataSet ds = new DataSet();
                            sql.Fill(ds, "typeQualification");
                            foreach (DataRow row in ds.Tables["typeQualification"].Rows)
                            { qid = row[0].ToString(); }
                            connection.Close();
                        }

                        string queryUPPerson = "UPDATE persons set " +
                                   "idTypeQualification = @idTypeQualification, surname = @surname, name = @name, patronymic = @patronymic, birthday = @birthday, gender = @gender, " +
                                   "addressCountry = @addressCountry, addressCity = @addressCity, addressStreet = @addressStreet, addressHome = @addressHome, " +
                                   "trainingDirection = @trainingDirection, profile = @profile, yearIssue = @yearIssue " +
                            $"WHERE id = (select ptw.idPers from persToWork ptw  where ptw.id = {idPersToWork})";
                        using (SqlCommand command = new SqlCommand(queryUPPerson, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@idTypeQualification", qid);
                            command.Parameters.AddWithValue("@surname", mTextB_surname.Text.Trim());
                            command.Parameters.AddWithValue("@name", mTextB_name.Text.Trim());
                            command.Parameters.AddWithValue("@patronymic", mTextB_patronymic.Text.Trim());
                            command.Parameters.AddWithValue("@birthday", dateTime_birthday.Value);
                            command.Parameters.AddWithValue("@gender", mComboB_gender.Text.Trim());

                            command.Parameters.AddWithValue("@addressCountry", mTextB_addressCountry.Text.Trim());
                            // ps.addressRegion = mTextB_addressRegion.Text.Trim();
                            // ps.addressArea = mTextB_addressArea.Text.Trim();
                            command.Parameters.AddWithValue("@addressCity", mTextB_addressCity.Text.Trim());
                            command.Parameters.AddWithValue("@addressStreet", mTextB_addressStreet.Text.Trim());
                            command.Parameters.AddWithValue("@addressHome", mTextB_addressHome.Text.Trim());
                            // ps.addressFlat = mTextB_addressFlat.Text.Trim();
                            command.Parameters.AddWithValue("@trainingDirection", mTextB_trainingDirection.Text.Trim());
                            command.Parameters.AddWithValue("@profile", mTextB_profile.Text.Trim());
                            command.Parameters.AddWithValue("@yearIssue", mTextB_yearIssue.Text.Trim());
                            command.Parameters.AddWithValue("@dateCrt", DateTime.Now);
                            command.ExecuteNonQuery();
                            // Получаю id добавленной записи
                            connection.Close();
                        }

                        LogNewValue = "idPersToWork:" + idPersToWork + " ФИО: " + mTextB_surname.Text.Trim() + mTextB_name.Text.Trim() + mTextB_patronymic.Text.Trim();
                        string queryLogInsert = "INSERT INTO logs " +
                           "(idUser, typeSql, nameTable, fielTable, newValue, dateCrt) " +
                           "Values(@idUser, @typeSql, @newValue, @fielTable, @newValue, @dateCrt)";
                        using (SqlCommand command = new SqlCommand(queryLogInsert, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@idUser", idUser);
                            command.Parameters.AddWithValue("@typeSql", "Insert");
                            command.Parameters.AddWithValue("@nameTable", "perstToWork, persons");
                            command.Parameters.AddWithValue("@fielTable", "all");
                            command.Parameters.AddWithValue("@newValue", LogNewValue);
                            command.Parameters.AddWithValue("@dateCrt", DateTime.Now);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }

                        MessageBox.Show("Данные изменены");
                        #endregion
                    }
                    Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        #endregion

        #region Свидетельство и Спрака выбор
        private void MComboB_freeWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mComboB_freeWork.SelectedIndex == 0)
            {
                mTextB_numCertificate.Enabled = true; // Свидетельство
                mTextB_numReference.Enabled = false; // Спрака
                mTextB_numReference.Clear();
            }
            else
            {
                mTextB_numCertificate.Enabled = false; // Свидетельство
                mTextB_numCertificate.Clear();
                mTextB_numReference.Enabled = true; // Спрака
            }
        }
        #endregion
    }
}
