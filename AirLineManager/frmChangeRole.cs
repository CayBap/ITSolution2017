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
    public partial class frmChangeRole : Form
    {
        static string email = null;
        OfficeBUS officeBUS = new OfficeBUS();
        public frmChangeRole()
        {
            InitializeComponent();
        }
        public frmChangeRole(User user)
        {
            InitializeComponent();
            LoadCombobox();
            LoadUser(user);
            email = user.Email;
        }
        private void frmChangeRole_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
        private void LoadUser(User user)
        {
            if (user != null)
            {
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtEmail.Text = user.Email;
                //    cbbOffices.SelectedIndex = Convert.ToInt32(user.OfficeID);
                List<Office> office = officeBUS.getOffices();
                for (int  i= 0; i < office.Count; i++)
                {
                    if(office[i].ID == Convert.ToInt32(user.OfficeID))
                    {
                        cbbOffices.SelectedIndex = i;
                    }
                }
                if (user.RoleID == 1)
                {
                    rdoAdmin.Checked = true;
                }
                if (user.RoleID == 2)
                {
                    rdoUser.Checked = true;
                }
            }
        }
        private void LoadCombobox()
        {
            cbbOffices.DataSource =  officeBUS.getOffices();
            cbbOffices.DisplayMember = "Title";
            cbbOffices.ValueMember = "ID";
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            UserBUS userBUS = new UserBUS();
            int roleID = 2;
            int userID = 0;
            List<User> users = userBUS.getUsers(0);
            //MessageBox.Show(email);
            for(int i = 0; i <=users.Count; i++)
            {
                if (users[i].Email == email)
                {
                    userID = users[i].ID;
                    break;
                }
            }
            if (rdoAdmin.Checked == true)
            {
                roleID = 1;
            }

            User user = new User()
            {
                ID = userID,
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                RoleID = roleID,
                OfficeID = Convert.ToInt32(cbbOffices.SelectedValue)
            };
            try
            {
                userBUS.editUser(user, userID);
                MessageBox.Show("Edit Role Success!!");
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Edit Role is not Success.");
            }
        }
    }
}
