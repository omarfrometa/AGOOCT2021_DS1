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
    public partial class UserForm : Form
    {
        DS1Entities db = new DS1Entities();
        List<string> msg = new List<string>();

        public UserForm()
        {
            InitializeComponent();

            GetRecords();

            GetRoles();
        }

        void GetRoles()
        {
            var roles = db.Role.ToList();

            cbRole.ValueMember = "Id";
            cbRole.DisplayMember = "Title";
            cbRole.DataSource = roles;

            cbRoleEdit.ValueMember = "Id";
            cbRoleEdit.DisplayMember = "Title";
            cbRoleEdit.DataSource = roles;
        }

        void GetRecords()
        {
            //var users = from a in db.User select new { a.Seq, a.Username, a.DisplayName, a.Email, a.CreatedDate, RoleName = a.Role.Title };

            var users = db.sp_get_users().ToList();

            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                users = users.Where(x => x.Username.Contains(txtUsername.Text)).ToList();
            }

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                users = users.Where(x => x.Email == txtEmail.Text).ToList();
            }

            if (!string.IsNullOrEmpty(txtDisplayName.Text))
            {
                users = users.Where(x => x.DisplayName == txtDisplayName.Text).ToList();
            }

            dgvRecords.DataSource = users.ToList();
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (ValidateSaving() == true)
            {
                Save();
            }
            else
            {
                var list = string.Empty;
                foreach (var item in msg)
                {
                    list += item + "\n";               
                }

                MessageBox.Show(list, "INTEC");
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        bool ValidateSaving()
        {
            msg = new List<string>();
            bool result = true;

            if (string.IsNullOrEmpty(txtUserNameEdit.Text))
            {
                msg.Add("El Usuario es Requerido.");
                result = false;
            }

            if (string.IsNullOrEmpty(txtPasswordEdit.Text))
            {
                msg.Add("La Contraseña es Requerida");
                result = false;
            }

            if (string.IsNullOrEmpty(txtDisplayNameEdit.Text))
            {
                msg.Add("El Nombre a Mostrar es Requerido.");
                result = false;
            }

            if (string.IsNullOrEmpty(txtEmailEdit.Text))
            {
                msg.Add("El Correo Electronico es Requerido");
                result = false;
            }

            //Validations in DB
            if (CheckUsername(txtUserNameEdit.Text))
            {
                msg.Add($"El Nombre de Usuario ({txtUserNameEdit.Text.ToUpper()}) ya esta registrado");
                result = false;
            }

            if (CheckEmail(txtEmailEdit.Text))
            {
                msg.Add($"El Correo Electronico ({txtEmailEdit.Text.ToUpper()}) ya esta registrado");
                result = false;
            }

            return result;
        }

        bool CheckUsername(string username)
        {
            return db.User.Count(x => x.Username == username) > 0;
        }

        bool CheckEmail(string email)
        {
            return db.User.Count(x => x.Email == email) > 0;
        }

        void Save()
        {
            try
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Username = txtUserNameEdit.Text,
                    Password = txtPasswordEdit.Text,
                    Email = txtEmailEdit.Text,
                    DisplayName = txtDisplayNameEdit.Text,
                    RolId = Convert.ToInt32(cbRoleEdit.SelectedValue),
                    Enabled = rbEnabled.Checked,
                    CreatedDate = DateTime.Now
                };

                db.User.Add(user);
                bool result = db.SaveChanges() > 0;

                if (result)
                {
                    GetRecords();

                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Saving User");
                Console.WriteLine(ex);
            }
        }

        void ClearForm()
        {
            txtUserNameEdit.Text = string.Empty;
            txtPasswordEdit.Text = string.Empty;
            txtEmailEdit.Text = string.Empty;
            txtDisplayNameEdit.Text = string.Empty;
            cbRoleEdit.SelectedIndex = 0;
            rbEnabled.Checked = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GetRecords();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = string.Empty;
            txtDisplayName.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }
    }
}
