using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS1
{
    public partial class LoginForm : Form
    {
        DS1Entities db = new DS1Entities();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateLogin() == true)
            {
                DoLogin();
            }
        }

        bool ValidateLogin() 
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("El Usuario es Requerido.");
                result = false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("La Contraseña es Requerida");
                result = false;
            }

            return result;
        }

        void DoLogin()
        {
            var user = db.User.FirstOrDefault(x => x.Username == txtUsername.Text && x.Password == txtPassword.Text);
            if (user == null)
            {
                MessageBox.Show("CREDENCIALES INVALIDAS");
                return;
            }

            MainForm mainForm = new MainForm();
            mainForm.Show();

            this.Hide();
        }
    }
}
