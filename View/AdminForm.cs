using MaterialSkin;
using MaterialSkin.Controls;
using Service_PK.Control;
using Service_PK.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Service_PK.View
{
    public partial class AdminForm : MaterialForm
    {
        employee NowEmployee;

        readonly MaterialSkinManager skinManager;
        ApplicationContext db;
        public AdminForm(employee e, ApplicationContext db)
        {
            InitializeComponent();
            this.db = db;
            NowEmployee = e;
            this.Text = "Добро пожаловать в систему администрирования, " + e.FIO;
            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue500, Accent.LightBlue200, TextShade.WHITE);


            GetClient("");

            GetEmployer("");

            GetPK("");
            GetWarehouse("");
            GetOrder();
        }

        public void GetOrder()
        {
            dataGridView3.AutoGenerateColumns = false;

            dataGridView3.DataSource = db.Orders.ToList();

            dataGridView3.Columns[0].DataPropertyName = "ID";
            dataGridView3.Columns[1].DataPropertyName = "Note";
            dataGridView3.Columns[2].DataPropertyName = "Start_date";
            dataGridView3.Columns[3].DataPropertyName = "End_date";
            dataGridView3.Columns[4].DataPropertyName = "Pay_type_ID";
            dataGridView3.Columns[5].DataPropertyName = "Price";

            (dataGridView3.Columns[4] as DataGridViewComboBoxColumn).DisplayMember = "Name";
            (dataGridView3.Columns[4] as DataGridViewComboBoxColumn).ValueMember = "ID";
            (dataGridView3.Columns[4] as DataGridViewComboBoxColumn).DataSource = db.Pay_Types.ToList();
        }

        public void GetClient(string s)
        {
            dataGridView4.AutoGenerateColumns = false;
            dataGridView4.DataSource = db.Clients.Where(x => x.FIO.Contains(s) || x.Phone.Contains(s)).ToList();
            dataGridView4.Columns[0].DataPropertyName = "ID";
            dataGridView4.Columns[1].DataPropertyName = "FIO";
            dataGridView4.Columns[2].DataPropertyName = "Phone";
        }

        public void GetWarehouse(string s)
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = db.warehouses.Where(x => x.Name.Contains(s)).ToList();
            dataGridView2.Columns[0].DataPropertyName = "ID";
            dataGridView2.Columns[1].DataPropertyName = "Name";
        }

        public void GetPK(string s)
        {
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = db.PKs.Where(x => x.Name.Contains(s)).ToList();
            dataGridView1.Columns[0].DataPropertyName = "ID";
            dataGridView1.Columns[1].DataPropertyName = "Name";
            dataGridView1.Columns[2].DataPropertyName = "Type_pk_ID";
            dataGridView1.Columns[3].DataPropertyName = "Client_ID";

            (dataGridView1.Columns[2] as DataGridViewComboBoxColumn).DisplayMember = "Name";
            (dataGridView1.Columns[2] as DataGridViewComboBoxColumn).ValueMember = "ID";
            (dataGridView1.Columns[2] as DataGridViewComboBoxColumn).DataSource = db.type_pks.ToList();

            (dataGridView1.Columns[3] as DataGridViewComboBoxColumn).DisplayMember = "FIO";
            (dataGridView1.Columns[3] as DataGridViewComboBoxColumn).ValueMember = "ID";
            (dataGridView1.Columns[3] as DataGridViewComboBoxColumn).DataSource = db.Clients.ToList();
        }

        public void GetEmployer(string s)
        {
            dataGridView5.AutoGenerateColumns = false;
            dataGridView5.DataSource = db.employees.ToList();
            dataGridView5.Columns[0].DataPropertyName = "Service_number";
            dataGridView5.Columns[1].DataPropertyName = "FIO";
            dataGridView5.Columns[2].DataPropertyName = "Adress";
            dataGridView5.Columns[3].DataPropertyName = "Phone";
            dataGridView5.Columns[4].DataPropertyName = "Post_ID";
            dataGridView5.Columns[5].DataPropertyName = "Login";
            dataGridView5.Columns[6].DataPropertyName = "Password";

            (dataGridView5.Columns[4] as DataGridViewComboBoxColumn).DisplayMember = "Name";
            (dataGridView5.Columns[4] as DataGridViewComboBoxColumn).ValueMember = "ID";
            (dataGridView5.Columns[4] as DataGridViewComboBoxColumn).DataSource = db.Posts.ToList();
        }

        #region устройства
        private void materialButton2_Click(object sender, EventArgs e)
        {
            db.PKs.Remove(db.PKs.Where(x => x.ID == (int)dataGridView1.SelectedRows[0].Cells[0].Value).FirstOrDefault());
            db.SaveChanges();
            dataGridView1.DataSource = db.PKs.ToList();

        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            db.PKs.Add(new PK(db.Clients.First().ID));
            db.SaveChanges();
            dataGridView1.DataSource = db.PKs.ToList();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            db.SaveChanges();
        }
        #endregion


        #region склады
        private void materialButton7_Click(object sender, EventArgs e)
        {
            db.warehouses.Remove(db.warehouses.Where(x => x.ID == (int)dataGridView2.SelectedRows[0].Cells[0].Value).FirstOrDefault());
            db.SaveChanges();
            dataGridView2.DataSource = db.warehouses.ToList();
            GetWarehouse("");
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            db.warehouses.Add(new warehouse());
            db.SaveChanges();
            dataGridView2.DataSource = db.warehouses.ToList();
            GetWarehouse("");
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            dataGridView2.EndEdit();
            db.SaveChanges();
        }
        #endregion


        #region клиенты

        private void materialButton13_Click(object sender, EventArgs e)
        {
            db.Clients.Remove(db.Clients.Where(x => x.ID == (int)dataGridView4.SelectedRows[0].Cells[0].Value).FirstOrDefault());
            db.SaveChanges();
            dataGridView4.DataSource = db.Clients.ToList();
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            var a = new Client();
            db.Clients.Add(a);
            db.SaveChanges();
            dataGridView4.DataSource = db.Clients.ToList();
        }

        private void materialButton14_Click(object sender, EventArgs e)
        {
            dataGridView4.EndEdit();
            db.SaveChanges();
        }



        #endregion
        #region услуги

        private void materialButton17_Click(object sender, EventArgs e)
        {
            db.employees.Remove(db.employees.Where(x => x.Service_number == (int)dataGridView5.SelectedRows[0].Cells[0].Value).FirstOrDefault());
            db.SaveChanges();
            dataGridView5.DataSource = db.employees.ToList();
        }

        private void materialButton15_Click(object sender, EventArgs e)
        {
            db.employees.Add(new employee());
            db.SaveChanges();
            dataGridView5.DataSource = db.employees.ToList();
        }

        private void materialButton18_Click(object sender, EventArgs e)
        {
            dataGridView5.EndEdit();
            db.SaveChanges();
        }
        #endregion



        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditOrder edit = new EditOrder(db, (int)dataGridView3.SelectedRows[0].Cells[0].Value);
            edit.ShowDialog();
        }


        private void materialButton10_Click(object sender, EventArgs e)
        {
            ExcelExport.SaveOrder(db);
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            ExcelExport.SaveClient(db);
        }

        private void materialButton16_Click(object sender, EventArgs e)
        {
            ExcelExport.SaveEmpl(db);
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            WordExport.SaveUstr(db);
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            WordExport.Saveworh(db);//экспорт по складам
        }

        private void materialTextBox21_TextChanged(object sender, EventArgs e)
        {
            GetWarehouse(materialTextBox21.Text);//поиск склада
        }

        private void materialTextBox22_TextChanged(object sender, EventArgs e)
        {
            GetPK(materialTextBox22.Text);
        }

        private void materialTextBox23_TextChanged(object sender, EventArgs e)
        {
            string s = materialTextBox23.Text.ToLower();
            //поиск 
            bool flag = false; //состояние поиска
            dataGridView3.CurrentCell = null; //снимаем выделения строк с таблицы
            if (s.Equals("")) //если ничего не введено
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    row.Visible = true;//делаем все строчки видимыми
                }
            }
            else //если что-то ввели
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    flag = false;//состояние поиска - не найдено
                    if (row.Cells[1].Value != null)
                        if (row.Cells[1].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[2].Value != null)
                        if (row.Cells[2].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[3].Value != null)
                        if (row.Cells[3].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[5].Value != null)
                        if (row.Cells[5].Value.ToString().ToLower().Contains(s)) flag = true;//поиск  
                    if (flag) row.Visible = true;//если нашли совпадение строчка видна
                    else row.Visible = false;//иначе скрываем
                }
            }
        }

        private void materialTextBox24_TextChanged(object sender, EventArgs e)
        {
            string s = materialTextBox24.Text.ToLower();
            //поиск 
            bool flag = false; //состояние поиска
            dataGridView4.CurrentCell = null; //снимаем выделения строк с таблицы
            if (s.Equals("")) //если ничего не введено
            {
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    row.Visible = true;//делаем все строчки видимыми
                }
            }
            else //если что-то ввели
            {
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    flag = false;//состояние поиска - не найдено
                    if (row.Cells[1].Value != null)
                        if (row.Cells[1].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[2].Value != null)
                        if (row.Cells[2].Value.ToString().ToLower().Contains(s)) flag = true;//поиск


                    if (flag) row.Visible = true;//если нашли совпадение строчка видна
                    else row.Visible = false;//иначе скрываем
                }
            }
        }

        private void materialTextBox25_TextChanged(object sender, EventArgs e)
        {
            string s = materialTextBox25.Text.ToLower();
            //поиск 
            bool flag = false; //состояние поиска
            dataGridView5.CurrentCell = null; //снимаем выделения строк с таблицы
            if (s.Equals("")) //если ничего не введено
            {
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    row.Visible = true;//делаем все строчки видимыми
                }
            }
            else //если что-то ввели
            {
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    flag = false;//состояние поиска - не найдено
                    if (row.Cells[1].Value != null)
                        if (row.Cells[1].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[2].Value != null)
                        if (row.Cells[2].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[3].Value != null)
                        if (row.Cells[3].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (flag) row.Visible = true;//если нашли совпадение строчка видна
                    else row.Visible = false;//иначе скрываем
                }
            }
        }

        private void materialButton19_Click(object sender, EventArgs e)
        {
            db.Orders.Remove(db.Orders.Where(x => x.ID == (int)dataGridView3.SelectedRows[0].Cells[0].Value).FirstOrDefault());
            db.SaveChanges();
            GetOrder();
        }

        private void materialButton12_Click(object sender, EventArgs e)
        {
            db.Orders.Add(new Order());
            db.SaveChanges();
            GetOrder();
        }

        private void materialButton20_Click(object sender, EventArgs e)
        {
            dataGridView3.EndEdit();
            db.SaveChanges();
        }

        private void materialButton21_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            this.Hide();
            lf.Show();
        }
    }
}
