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
    public partial class UserForm : MaterialForm
    {
        employee NowEmployee;

        readonly MaterialSkinManager skinManager;
        ApplicationContext db;
        public UserForm(employee e, ApplicationContext db)
        {
            InitializeComponent();
            this.db = db;
            NowEmployee = e;
            this.Text = "Добро пожаловать, " + e.FIO;
            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue500, Accent.LightBlue200, TextShade.WHITE);

            GetOrder();
            GetTypeAutopert("");
            GetTypeService("");
            GetAutopart();
            GetService();
        }

        public void GetOrder()
        {
            dataGridView3.AutoGenerateColumns = false;
            var nowOrder = (from order in db.Orders
                            join orInEmp in db.employeeinorders on order.ID equals orInEmp.Order_ID
                            where orInEmp.Employee_Service_number == NowEmployee.Service_number
                            where order.End_date == null
                            select new Order
                            {
                                ID = order.ID,
                                Start_date = order.Start_date,
                                End_date = order.End_date,
                                Pay_type_ID = order.Pay_type_ID,
                                Price = order.Price,
                                Note = order.Note
                            }).ToList();


            dataGridView3.DataSource = nowOrder;

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

        public void GetTypeAutopert(string s)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = db.typeautoparts.Where(x => x.Name.Contains(s)).ToList();
            dataGridView1.Columns[0].DataPropertyName = "ID";
            dataGridView1.Columns[1].DataPropertyName = "Name";
        }

        public void GetTypeService(string s)
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = db.TypeServices.Where(x => x.Name.Contains(s)).ToList();
            dataGridView2.Columns[0].DataPropertyName = "ID";
            dataGridView2.Columns[1].DataPropertyName = "Name";
        }

        public void GetAutopart()
        {
            dataGridView4.AutoGenerateColumns = false;

            dataGridView4.DataSource = db.autoparts.Where(x => x.Count == 1).ToList();
            dataGridView4.Columns[0].DataPropertyName = "ID";
            dataGridView4.Columns[1].DataPropertyName = "Name";
            dataGridView4.Columns[2].DataPropertyName = "Serial_number";
            dataGridView4.Columns[3].DataPropertyName = "Price";
            dataGridView4.Columns[4].DataPropertyName = "TypeAutopart_ID";
            dataGridView4.Columns[5].DataPropertyName = "Warehouse_ID";
            dataGridView4.Columns[6].DataPropertyName = "Count";
            (dataGridView4.Columns[4] as DataGridViewComboBoxColumn).DisplayMember = "Name";
            (dataGridView4.Columns[4] as DataGridViewComboBoxColumn).ValueMember = "ID";
            (dataGridView4.Columns[4] as DataGridViewComboBoxColumn).DataSource = db.typeautoparts.ToList();

            (dataGridView4.Columns[5] as DataGridViewComboBoxColumn).DisplayMember = "Name";
            (dataGridView4.Columns[5] as DataGridViewComboBoxColumn).ValueMember = "ID";
            (dataGridView4.Columns[5] as DataGridViewComboBoxColumn).DataSource = db.warehouses.ToList();
        }

        public void GetService()
        {
            dataGridView5.AutoGenerateColumns = false;
            dataGridView5.DataSource = db.Services.ToList();
            dataGridView5.Columns[0].DataPropertyName = "ID";
            dataGridView5.Columns[1].DataPropertyName = "Note";
            dataGridView5.Columns[2].DataPropertyName = "Price";
            dataGridView5.Columns[3].DataPropertyName = "TypeServices_ID";


            (dataGridView5.Columns[3] as DataGridViewComboBoxColumn).DisplayMember = "Name";
            (dataGridView5.Columns[3] as DataGridViewComboBoxColumn).ValueMember = "ID";
            (dataGridView5.Columns[3] as DataGridViewComboBoxColumn).DataSource = db.TypeServices.ToList();
        }

        #region Типы запчастей
        private void materialButton2_Click(object sender, EventArgs e)
        {
            db.typeautoparts.Remove(db.typeautoparts.Where(x => x.ID == (int)dataGridView1.SelectedRows[0].Cells[0].Value).FirstOrDefault());
            db.SaveChanges();
            dataGridView1.DataSource = db.typeautoparts.ToList();
            GetAutopart();
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            db.typeautoparts.Add(new typeautopart());
            db.SaveChanges();
            dataGridView1.DataSource = db.typeautoparts.ToList();
            GetAutopart();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            db.SaveChanges();
        }
        #endregion
        #region Типы услуг
        private void materialButton7_Click(object sender, EventArgs e)
        {
            db.TypeServices.Remove(db.TypeServices.Where(x => x.ID == (int)dataGridView2.SelectedRows[0].Cells[0].Value).FirstOrDefault());
            db.SaveChanges();
            dataGridView2.DataSource = db.TypeServices.ToList();
            GetService();
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            db.TypeServices.Add(new typeservices());
            db.SaveChanges();
            dataGridView2.DataSource = db.TypeServices.ToList();
            GetService();
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            dataGridView2.EndEdit();
            db.SaveChanges();
        }
        #endregion
        #region запчасти

        private void materialButton13_Click(object sender, EventArgs e)
        {
            db.autoparts.Remove(db.autoparts.Where(x => x.ID == (int)dataGridView4.SelectedRows[0].Cells[0].Value).FirstOrDefault());
            db.SaveChanges();
            dataGridView4.DataSource = db.autoparts.ToList();
            GetAutopart();
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            var a = new autopart(db.typeautoparts.First().ID, db.warehouses.First().ID);
            db.autoparts.Add(a);
            db.SaveChanges();
            dataGridView4.DataSource = db.autoparts.ToList();
            GetAutopart();
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
            db.Services.Remove(db.Services.Where(x => x.ID == (int)dataGridView5.SelectedRows[0].Cells[0].Value).FirstOrDefault());
            db.SaveChanges();
            dataGridView5.DataSource = db.Services.ToList();
        }

        private void materialButton15_Click(object sender, EventArgs e)
        {
            db.Services.Add(new services(db.TypeServices.First().ID));
            db.SaveChanges();
            dataGridView5.DataSource = db.Services.ToList();
        }

        private void materialButton18_Click(object sender, EventArgs e)
        {
            dataGridView5.EndEdit();
            db.SaveChanges();
        }
        #endregion



        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditSostavOrer edit = new EditSostavOrer(db, (int)dataGridView3.SelectedRows[0].Cells[0].Value, this);
            edit.ShowDialog();
        }

        private void materialButton21_Click(object sender, EventArgs e)
        {
            db.Orders.First(x => x.ID == (int)dataGridView3.SelectedRows[0].Cells[0].Value).End_date = DateTime.Now.ToShortDateString();
            foreach (var s in db.Autopartinorder.Where(x => x.Order_ID == (int)dataGridView3.SelectedRows[0].Cells[0].Value).ToList())
            {
                var au = db.autoparts.Where(x => x.ID == s.Autopart_Id).First();
                au.Count = 0;
            }
            db.SaveChanges();
            GetOrder();
            GetAutopart();
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            ExcelExport.SaveOrder(db);
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            ExcelExport.SaveComplect(db);
        }

        private void materialButton16_Click(object sender, EventArgs e)
        {
            ExcelExport.SaveServ(db);
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            WordExport.SaveTypeCompl(db);
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            WordExport.SaveTypeServ(db);
        }

        private void materialTextBox21_TextChanged(object sender, EventArgs e)
        {
            GetTypeService(materialTextBox21.Text);
        }

        private void materialTextBox22_TextChanged(object sender, EventArgs e)
        {
            GetTypeAutopert(materialTextBox22.Text);
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
                    if (row.Cells[4].Value != null)
                        if (row.Cells[4].Value.ToString().ToLower().Contains(s)) flag = true;//поиск  
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
                    if (row.Cells[3].Value != null)
                        if (row.Cells[3].Value.ToString().ToLower().Contains(s)) flag = true;//поиск

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

                    if (flag) row.Visible = true;//если нашли совпадение строчка видна
                    else row.Visible = false;//иначе скрываем
                }
            }
        }

        private void materialButton12_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            this.Hide();
            lf.Show();
        }
    }
}
