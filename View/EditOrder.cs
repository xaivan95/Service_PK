using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service_PK.Model;

namespace Service_PK.View
{
    public partial class EditOrder : MaterialForm
    {
        ApplicationContext db;
        public List<PK> addCar = new List<PK>();
        public List<employee> addEmp = new List<employee>();
        public int id;
        public EditOrder(ApplicationContext d, int id)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue500, Accent.LightBlue200, TextShade.WHITE);
            db = d;
            this.id = id;
            GetCar();
            GetEmpl();


            materialComboBox1.DataSource = db.PKs.Join(db.Clients,
                u => u.Client_ID,
                c => c.ID,
                (u, c) => new PK
                {
                    ID = u.ID,
                    Name = u.Name + " - " + c.FIO
                }
                ).ToList();
            materialComboBox1.DisplayMember = "Name";
            materialComboBox1.ValueMember = "ID";

            materialComboBox2.DataSource = db.employees.Where(x => x.Post_ID == 2).ToList();
            materialComboBox2.DisplayMember = "FIO";
            materialComboBox2.ValueMember = "Service_number";


        }

        public void GetCar()
        {
            materialListView1.Items.Clear();
            addCar = (from carinor in db.carinorders
                      join ca in db.PKs on carinor.Car_ID equals ca.ID
                      join us in db.Clients on ca.Client_ID equals us.ID
                      where carinor.Order_ID == id
                      select new PK
                      {
                          ID = ca.ID,
                          Name = ca.Name + " - " + us.FIO
                      }).ToList();

            foreach (var s in addCar.Select(x => x.Name).ToArray<string>())
                materialListView1.Items.Add(s);
        }

        public void GetEmpl()
        {
            materialListView2.Items.Clear();
            addEmp = (from empinor in db.employeeinorders
                      join ca in db.employees on empinor.Employee_Service_number equals ca.Service_number
                      where empinor.Order_ID == id

                      select new employee
                      {
                          Service_number = ca.Service_number,
                          FIO = ca.FIO
                      }).ToList();

            foreach (var s in addEmp.Select(x => x.FIO).ToArray<string>())
                materialListView2.Items.Add(s);
        }

        private void materialButton19_Click(object sender, EventArgs e)
        {
            if (addCar.Where(x => x.ID == (int)materialComboBox1.SelectedValue).Count() == 0)
            {
                db.carinorders.Add(new carinorder(id, (int)materialComboBox1.SelectedValue));
                db.SaveChanges();
                GetCar();
            }
            else
                MessageBox.Show("Машина уже есть в заказе");
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (addEmp.Where(x => x.Service_number == (int)materialComboBox2.SelectedValue).Count() == 0)
            {
                db.employeeinorders.Add(new employeeinorder(id, (int)materialComboBox2.SelectedValue));
                db.SaveChanges();
                GetEmpl();
            }
            else
                MessageBox.Show("Сотрудник уже есть в заказе");
        }
    }
}
