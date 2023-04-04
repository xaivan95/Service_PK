using MaterialSkin;
using MaterialSkin.Controls;
using Service_PK.Control;
using Service_PK.View;

namespace Service_PK
{
    public partial class LoginForm : MaterialForm
    {
        ApplicationContext db;
        public LoginForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            var emp = Authorization.Authorizations(Login.Text, Password.Text);
            if (emp != null)
            {
                db = new ApplicationContext();
                if (emp.Post_ID == 1) { var adm = new AdminForm(emp, db); adm.Show(); }
                if (emp.Post_ID == 2) { var adm = new UserForm(emp, db); adm.Show(); }
                this.Hide();
            }
            else
                ErrorLabel.Visible = true;
            ErrorLabel.ForeColor = Color.Red;
            Login.Text = "¬ведите логин";
            Password.Text = "¬ведите пароль";
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (Login.Text.Equals("¬ведите логин")) Login.Text = "";
        }

        private void Password_Click(object sender, EventArgs e)
        {
            if (Password.Text.Equals("¬ведите пароль")) Password.Text = "";
        }
    }
}