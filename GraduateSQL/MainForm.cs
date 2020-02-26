using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection; // Missing для Excel

namespace GraduateSQL
{
    public partial class MainForm : MetroForm
    {
        string connectionString = "Server=192.168.250.25;Database=graduatesZ;user=Rupit;password=Grib04ek:";
        string sqlGrid = String.Empty;
        string LogDel;
        int idUser = 0;
        int idDell = 0;
        int ideRowIndex = 0;
        int ExcelClickOk = 0; // Закрытие процесса Excel используеться в Экпорте

        public MainForm(int idUser)
        {
            InitializeComponent();
            this.idUser = idUser;
        }

        #region Load
        private void MainForm_Load(object sender, EventArgs e)
        {
            countPersons.Text = "Всего записей: " + dgv_persons.Rows.Count.ToString();
            mTextB_Search.Visible = false;// поле поиска
            mButSerch.Visible = false; // кнопка поиска

            label_excele.Visible = false;// Прогресс заполнения Excele
            progressBar1.Visible = false;// Прогресс заполнения Excele
            MenuAdmin.Visible = false;
        }
        #endregion

        #region INSERT новую персону
        private void Menu_addPerson_Click(object sender, EventArgs e)
        {
            new PersonalCards(idUser).ShowDialog();
        }
        #endregion

        #region Фильтр поиска
        private void MButSerch_Click_1(object sender, EventArgs e)
        {
            dgv_persons.Visible = true;
            dgv_persons.Columns.Clear();
            dgv_persons.Rows.Clear();
            int count_pers = 0;

                    dgv_persons.Columns.Add("id", "id"); // 0 
                    dgv_persons.Columns.Add("FIO", "ФИО"); // 1
                    dgv_persons.Columns.Add("birthday", "Дата рождения"); // 2
                    dgv_persons.Columns.Add("gender", "Пол"); // 3
                    dgv_persons.Columns.Add("addressCountry", "Адрес проживания"); // 4
                    dgv_persons.Columns.Add("nameQualification", "Квалификационный уровень"); // 5
                    dgv_persons.Columns.Add("trainingDirection", "Направление подготовки"); // 6
                    dgv_persons.Columns.Add("profile", "Профиль"); // 7
                    dgv_persons.Columns.Add("yearIssue", "Год выпуска"); // 8
                    dgv_persons.Columns.Add("nameStateOrg", "Название государственной организации"); // 9
                    dgv_persons.Columns.Add("educational", "Образовательное учреждение"); // 10
                    dgv_persons.Columns.Add("nameOrg", "Название организации(предприятия)"); // 11
                    dgv_persons.Columns.Add("post", "Должность"); //  12
                    dgv_persons.Columns.Add("cityOrg", "Город организации"); // 13
                    dgv_persons.Columns.Add("numCertificate", "№ свидетельства");  // 14
                    dgv_persons.Columns.Add("nameFreeWork", "Самостоятельное трудоустройство");  // 15
                    dgv_persons.Columns.Add("numReference", "№ справки"); // 16
                    dgv_persons.Columns.Add("verificationArrival", "Подтверждение прибытия");  // 17
                    dgv_persons.Columns.Add("commentary", "Дополнительная информация"); // 18 
                    dgv_persons.Columns[0].Visible = false; // id не видим

                if (mRadio_Surname.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                   "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                   "FROM persToWork AS pw " +
                                   "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                   "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                   "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                   "WHERE per.surname LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";
                }
                if (mRadio_Birthday.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                           "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                           "FROM persToWork AS pw " +
                                           "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                           "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                           "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                           "WHERE per.birthday LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";
                    // else { MessageBox.Show("Человека с такой датой нет"); mTextB_Search.Text = ""; }
                }
                if (mRadio_gender.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                           "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                           "FROM persToWork AS pw " +
                                           "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                           "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                           "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                           "WHERE per.gender LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";
                }// else { MessageBox.Show("Человек данного пола отсутсвуют. Правильно вводить 'муж' или 'жен' в строку поиска");  mTextB_Search.Text = ""; }
                if (mRadio_addressCity.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                           "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                           "FROM persToWork AS pw " +
                                           "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                           "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                           "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                           "WHERE per.addressCity LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";
                } //else { MessageBox.Show("Данного города нет или в базе отсутсвуют людей, которые в нем проживают"); mTextB_Search.Text = ""; }

                if (mRadio_qualification.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                           "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                           "FROM persToWork AS pw " +
                                           "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                           "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                           "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                           "WHERE tq.nameQualification LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";
                } //else { MessageBox.Show("Человека с такой датой нет"); mTextB_Search.Text = ""; }
                if (mRadio_TrainingDirection.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT per.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                           "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                           "FROM persToWork AS pw " +
                                           "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                           "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                           "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                           "WHERE per.trainingDirection LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";
                } //else { MessageBox.Show("Человека с такой датой нет");  mTextB_Search.Text = ""; }
                if (mRadio_profile.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                           "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                           "FROM persToWork AS pw " +
                                           "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                           "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                           "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                           "WHERE per.profile LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";
                } //else { MessageBox.Show("Человека с таким профилем нет"); mTextB_Search.Text = ""; }
                if (mRadio_YearIssue.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                           "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                           "FROM persToWork AS pw " +
                                           "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                           "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                           "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                           "WHERE per.yearIssue LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";
                } //else { MessageBox.Show("В этом году нет выпускников"); mTextB_Search.Text = ""; }

                if (mRadio_nameStateOrg.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                           "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                           "FROM persToWork AS pw " +
                                           "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                           "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                           "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                           "WHERE pw.nameStateOrg LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";
                } //else { MessageBox.Show("Человека с таким профилем нет"); mTextB_Search.Text = ""; }
                if (mRadio_educational.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                              "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                              "FROM persToWork AS pw " +
                                              "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                              "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                              "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                              "WHERE pw.educational LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";

                } //else { MessageBox.Show("Данного образовательного учреждения нет или в базе отсутсвуют людей, которые в нем работают"); mTextB_Search.Text = ""; }
                if (mRadio_NumOrg.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                           "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                           "FROM persToWork AS pw " +
                                           "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                           "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                           "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                           "WHERE pw.nameOrg LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";
                }// else { MessageBox.Show("Человека с таким профилем нет"); mTextB_Search.Text = ""; }
                if (mRadio_Post.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                           "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                           "FROM persToWork AS pw " +
                                           "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                           "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                           "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                           "WHERE pw.post LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";
                }// else { MessageBox.Show("Человека с таким профилем нет"); mTextB_Search.Text = ""; }
                if (mRadio_cityOrg.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                           "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                           "FROM persToWork AS pw " +
                                           "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                           "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                           "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                           "WHERE pw.cityOrg LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";
                }// else { MessageBox.Show("Данного горда нет или в базе отсутсвуют людей, которые в нем проживают"); mTextB_Search.Text = ""; }

                if (mRadio_FreeWork.Checked == true && mTextB_Search.Text != "")
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                           "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                           "FROM persToWork AS pw " +
                                           "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                           "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                           "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id " +
                                           "WHERE fw.nameFreeWork LIKE '" + "%" + mTextB_Search.Text + "%" + "'; ";
                }// else { MessageBox.Show("Человека с таким самоустройством нет"); mTextB_Search.Text = ""; }
                if (mRadio_all.Checked == true)
                {
                    sqlGrid = "SELECT pw.id, per.surname, per.name, per.patronymic, per.birthday, per.gender, per.addressCountry, per.addressCity, per.addressStreet, per.addressHome, tq.nameQualification, per.trainingDirection, per.profile, per.yearIssue, " +
                                           "pw.nameStateOrg, pw.educational, pw.nameOrg, pw.post, pw.cityOrg, pw.numCertificate, fw.nameFreeWork, pw.numReference, pw.verificationArrival, pw.commentary " +
                                           "FROM persToWork AS pw " +
                                           "LEFT OUTER JOIN persons AS per ON pw.idPers = per.id " +
                                           "LEFT OUTER JOIN typeQualification AS tq ON per.idTypeQualification = tq.id " +
                                           "LEFT OUTER JOIN freeWork AS fw ON pw.idFreeWork = fw.id ";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlGrid, connection))
                    {
                    if (sqlGrid != "")
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                dgv_persons.Rows.Add();
                                dgv_persons["id", count_pers].Value = reader.GetValue(0);
                                dgv_persons["FIO", count_pers].Value = reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3);
                                dgv_persons["birthday", count_pers].Value = reader.GetDateTime(4).ToShortDateString();
                                dgv_persons["gender", count_pers].Value = reader.GetValue(5);
                                dgv_persons["addressCountry", count_pers].Value = reader.GetValue(6) + " " + reader.GetValue(7) + " " + reader.GetValue(8) + " " + reader.GetValue(9);
                                dgv_persons["nameQualification", count_pers].Value = reader.GetValue(10);
                                dgv_persons["trainingDirection", count_pers].Value = reader.GetValue(11);
                                dgv_persons["profile", count_pers].Value = reader.GetValue(12);
                                dgv_persons["yearIssue", count_pers].Value = reader.GetValue(13);
                                dgv_persons["nameStateOrg", count_pers].Value = reader.GetValue(14);
                                dgv_persons["educational", count_pers].Value = reader.GetValue(15);
                                dgv_persons["nameOrg", count_pers].Value = reader.GetValue(16);
                                dgv_persons["post", count_pers].Value = reader.GetValue(17);
                                dgv_persons["cityOrg", count_pers].Value = reader.GetValue(18);
                                dgv_persons["numCertificate", count_pers].Value = reader.GetValue(19);
                                dgv_persons["nameFreeWork", count_pers].Value = reader.GetValue(20);
                                dgv_persons["numReference", count_pers].Value = reader.GetValue(21);
                                dgv_persons["verificationArrival", count_pers].Value = reader.GetValue(22).ToString() == "T" ? "В наличии" : "отсутствует";
                                dgv_persons["commentary", count_pers].Value = reader.GetValue(23);
                                count_pers++;
                            }
                            countPersons.Text = "Всего записей: " + dgv_persons.Rows.Count.ToString();
                            reader.Close();
                        }

                    }
                    else
                    {
                        dgv_persons.Visible = false;
                        MessageBox.Show("Строка поиска не заполнена");
                    }  
                    }
                    connection.Close();
                }
        }
        private void Menu_filter_Click(object sender, EventArgs e)
        {
            if (group_Search.Visible == true)
                group_Search.Visible = false;
            else
                group_Search.Visible = true;
            return;
        }
        #endregion
        #region Выбор 1 RadioButton из фильтра поиска
        public void funRadio()
        {
            dgv_persons.Columns.Clear();
            dgv_persons.Rows.Clear();
            mTextB_Search.Enabled = true;
            mButSerch.Visible = true;
            mTextB_Search.Visible = true;
            countPersons.Text = "";
            //mTextB_Search.Text = "";
        }

        public void MRadio_Surname_CheckedChanged_1(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
                switch (radio.Name)
                {
                    case "mRadio_Surname": funRadio(); break;
                    case "mRadio_Birthday": funRadio(); break;
                    case "mRadio_gender": funRadio(); break;
                    case "mRadio_addressCity": funRadio(); break;

                    case "mRadio_qualification": funRadio(); break;
                    case "mRadio_TrainingDirection": funRadio(); break;
                    case "mRadio_profile": funRadio(); break;
                    case "mRadio_YearIssue": funRadio(); break;

                    case "mRadio_nameStateOrg": funRadio(); break;
                    case "mRadio_educational": funRadio(); break;
                    case "mRadio_NumOrg": funRadio(); break;
                    case "mRadio_Post": funRadio(); break;
                    case "mRadio_cityOrg": funRadio(); break;

                    case "mRadio_FreeWork": funRadio(); break;
                    case "mRadio_all":
                        dgv_persons.Columns.Clear();
                        dgv_persons.Rows.Clear();
                        mTextB_Search.Text = "";
                        mTextB_Search.Enabled = false;
                        mTextB_Search.Visible = false;
                        mButSerch.Visible = true;
                        break;
                    default: break;
                }
            }
        }
        #endregion

        #region Приказ Свободное трудоустройство
        private void Menu_FreeWork_Click(object sender, EventArgs e)
        {
            new OrderFreeWork(idUser).ShowDialog();
        }
        #endregion

        #region Экспорт из таблицы в Excel
        private void Menu_exportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_persons.Rows.Count != 0)
                {
                    label_excele.Visible = true;
                    progressBar1.Visible = true;
                    progressBar1.Minimum = 1;
                    progressBar1.Maximum = dgv_persons.Rows.Count;
                    progressBar1.Step = 1;

                    Excel.Application excel = new Excel.Application();
                    Excel.Workbook workbook = excel.Workbooks.Add(Missing.Value);
                    Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];
                    Excel.Range ExcelRange;
                    int StartCol = 0;
                    int StartRow = 1;// Скрыть 1 колонку где id
                    int j = 0, i = 0;

                    //Шапка в Excel. Начинаю с 1, что бы не видно было i                    
                    for (j = 1; j < dgv_persons.Columns.Count; j++)
                    {
                        ExcelRange = (Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                        sheet1.Cells[StartRow, StartCol + j].EntireRow.Font.Bold = true; // Жирная первая строка
                        ExcelRange.Value2 = dgv_persons.Columns[j].HeaderText;
                    }
                    StartRow++;

                    // Данные с таблицы.
                    for (i = 0; i < dgv_persons.Rows.Count; i++)
                    {
                        for (j = 1; j < dgv_persons.Columns.Count; j++)
                        {
                            ExcelRange = (Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            ExcelRange.Value2 = dgv_persons[j, i].Value == null ? "" : dgv_persons[j, i].Value;
                            ExcelRange = sheet1.UsedRange;
                        }
                        progressBar1.PerformStep();
                    }

                    excel.Visible = true; // Открыть сам Excel
                    workbook.Close();
                    excel.Quit();

                    progressBar1.Value = 1;
                    progressBar1.Visible = false;
                    label_excele.Visible = false;// Прогресс заполнения Excele
                }
                else { MessageBox.Show("Таблица пустая"); }
            }
            catch { MessageBox.Show("Ошибка импорта"); }
            ExcelClickOk = 1;// Если Excel открывали, передает переменную в F_main_FormClosing для ликвидации процесса
        }

        #endregion

        #region 2Клик по таблице, открывает личную карту с информацие о выбранном студенте
        private void dgv_persons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                new PersonalCards(idUser, (int)dgv_persons["id", e.RowIndex].Value).ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion

        #region DELETE Правый клик по таблице вызывает Контексное меню - удалить
        private void Dgv_persons_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { contextDVG.Show(Cursor.Position.X, Cursor.Position.Y); }
        }

        private void Dgv_persons_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    dgv_persons.CurrentCell = dgv_persons.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgv_persons.Rows[e.RowIndex].Selected = true;
                    dgv_persons.Focus();
                    idDell = (int)dgv_persons["id", e.RowIndex].Value;
                    //Click += new EventHandler(ToolStripMenuItem_Click);

                    ideRowIndex = e.RowIndex;
                    LogDel = "id:" + dgv_persons["id", e.RowIndex].Value.ToString()+ " ФИО: " + dgv_persons["FIO", e.RowIndex].Value.ToString();
                }
                catch (ArgumentOutOfRangeException) { MessageBox.Show("Выберите ячейку"); }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ToolStripItem clickedItem = sender as ToolStripItem;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var Result = MessageBox.Show("Вы уверены что хотите удалить данную запись?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string queryDellPTW = "DELETE FROM persons " + $"WHERE id = (select ptw.idPers from persToWork ptw  where ptw.id = { idDell })";
                string queryDellPTWLog = "INSERT INTO logs " +
                            "(idUser, typeSql, nameTable, fielTable, oldValue, dateCrt) " +
                            "Values(@idUser, @typeSql, @nameTable, @fielTable, @oldValue, @dateCrt)";
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
                      
                        using (SqlCommand command = new SqlCommand(queryDellPTWLog, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@idUser", idUser);
                            command.Parameters.AddWithValue("@typeSql", "Delete");
                            command.Parameters.AddWithValue("@nameTable", "perstToWork, persons");
                            command.Parameters.AddWithValue("@fielTable", "all");
                            command.Parameters.AddWithValue("@oldValue", LogDel);
                            command.Parameters.AddWithValue("@dateCrt", DateTime.Now);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                        MessageBox.Show("Запись удалена");
                    }
                    dgv_persons.Rows.RemoveAt(ideRowIndex);
                    dgv_persons.Refresh();
                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        #endregion
        #region DELETE всех студентов за определенный год
        private void Menu_delYearIssue_Click(object sender, EventArgs e)
        {
            new ClearPersYear(idUser).ShowDialog();
        }
        #endregion

        #region Нумерация строк
            private void Dgv_persons_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dgv_persons.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dgv_persons.Rows[index].HeaderCell.Value = indexStr;
        }
        #endregion

        #region О Программе
        private void Menu_aboutProg_Click(object sender, EventArgs e)
        {
            string path = /* Path.GetFullPath(@"TextFile1.txt");*/ //"E:\\Projects\\C#\\Graduate\\Graduate\\TextFile1.txt";
            "AboutGraduate.pdf";
            System.Diagnostics.Process.Start(path);
        }
        #endregion

        #region exit
        private void Menu_exit_Click(object sender, EventArgs e) { Close(); }
        #endregion
        #region FormClosed
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (ExcelClickOk == 1)
                {
                    System.Diagnostics.Process excelProc = System.Diagnostics.Process.GetProcessesByName("EXCEL").Last();
                    if (excelProc != null)
                    {
                        excelProc.Kill();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Application.Exit();
        }
        #endregion
    }
}


