using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirLineManager.BUS;
namespace AirLineManager
{
    public partial class frmAdduser : Form
    {
        UserBUS userBUS = new UserBUS();
        frmMainAdmin mainAdmin = new frmMainAdmin();
        OfficeBUS officeBUS = new OfficeBUS();
        public frmAdduser()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            User user = null;
            if (txtEmail != null || txtFirstName != null || txtLastName != null || txtPassword != null || dtpBirthDate != null)
            {
               
                int count = userBUS.countUser();
                int id = count + 1;
               // string pass = encrypt.MD5Hash(txtPassword.Text);
                user = new User()
                {
                    ID = id,
                    Email = txtEmail.Text,
                    LastName = txtLastName.Text,
                    FirstName = txtFirstName.Text,
                    Password = txtPassword.Text,
                    Birthdate = dtpBirthDate.Value,
                    RoleID = 2,
                    Active = true,
                    OfficeID = Convert.ToInt32(cbbOffice.SelectedValue)
                };
                try
                {
                    userBUS.addUser(user);
                    this.Hide();
                    MessageBox.Show("Insert new User is Suscces.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Insert new User is not Suscces.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdduser_Load(object sender, EventArgs e)
        {
            cbbOffice.DataSource = officeBUS.getOffices();
            cbbOffice.DisplayMember = "Title";
            cbbOffice.ValueMember = "ID";
            cbbOffice.SelectedIndex = 0;
        }
    }
}
