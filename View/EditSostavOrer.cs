using MaterialSkin;
using MaterialSkin.Controls;
using Service_PK.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service_PK.View
{
    public partial class EditSostavOrer : MaterialForm
    {
        ApplicationContext db;
        public List<autopart> addAP = new List<autopart>();
        public List<services> addSer = new List<services>();
        public int id;
        UserForm us;
        public EditSostavOrer(ApplicationContext d, int id, UserForm us)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue500, Accent.LightBlue200, TextShade.WHITE);
            db = d;
            this.id = id;
            GetAutopart();
            GetService();

            materialComboBox1.DataSource = db.autoparts.Where(x => x.Count == 1).ToList();
            materialComboBox1.DisplayMember = "Name";
            materialComboBox1.ValueMember = "ID";

            materialComboBox2.DataSource = db.Services.ToList();
            materialComboBox2.DisplayMember = "Note";
            materialComboBox2.ValueMember = "ID";
            this.us = us;
        }

        public void GetAutopart()
        {
            materialListView1.Items.Clear();
            addAP = (from APinOr in db.Autopartinorder
                     join ap in db.autoparts on APinOr.Autopart_Id equals ap.ID
                     where APinOr.Order_ID == id
                     select new autopart
                     {
                         ID = ap.ID,
                         Name = ap.Name + " - " + APinOr.Count
                     }).ToList();

            foreach (var s in addAP.Select(x => x.Name).ToArray<string>())
                materialListView1.Items.Add(s);
        }

        public void GetService()
        {
            materialListView2.Items.Clear();
            addSer = (from SerinOr in db.Serviceinorder
                      join ser in db.Services on SerinOr.services_ID equals ser.ID
                      where SerinOr.Order_ID == id
                      select new services
                      {
                          ID = ser.ID,
                          Note = ser.Note
                      }).ToList();

            foreach (var s in addSer.Select(x => x.Note).ToArray<string>())
                materialListView2.Items.Add(s);
        }

        private void materialButton19_Click(object sender, EventArgs e)
        {
            if (db.Autopartinorder.Where(x => x.Order_ID == id).Where(x => x.Autopart_Id == (int)materialComboBox1.SelectedValue).Count() == 0)
            {
                db.Autopartinorder.Add(new autopartinorder(id, (int)materialComboBox1.SelectedValue, 1));
                db.SaveChanges();
                var pricae = db.autoparts.First(x => x.ID == (int)materialComboBox1.SelectedValue).Price;
                db.Orders.First(x => x.ID == id).Price += pricae;
                db.SaveChanges();
                GetAutopart();
                us.GetOrder();
            }
            else
                MessageBox.Show("Выбранный компонент уже применяется");
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            db.Serviceinorder.Add(new serviceinorder(id, (int)materialComboBox2.SelectedValue));
            db.SaveChanges();
            var pricae = db.Services.First(x => x.ID == (int)materialComboBox2.SelectedValue).Price;
            db.Orders.First(x => x.ID == id).Price += pricae;
            db.SaveChanges();
            GetService();
            us.GetOrder();
        }

        private void EditSostavOrer_FormClosed(object sender, FormClosedEventArgs e)
        {
            us.GetOrder();
        }
    }
}
