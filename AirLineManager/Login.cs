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
using AirLineManager.Helper;
namespace AirLineManager
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            
        }
        private UserBUS userBUS = new UserBUS();
        private Bcrypt bcrypt = new Bcrypt();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = null;
            try
            {
                string passs = bcrypt.MD5Hash(txtPassword.Text);
                
                user = userBUS.getUser(txtUserName.Text);
                if (user != null&& user.Password == passs)
                {
                    
                    if (user.RoleID == 1)
                    {
                        frmMainAdmin mainAdmin = new frmMainAdmin();
                        this.Hide();
                        mainAdmin.Show();
                    }
                    else
                    {
                        UserLogBUS userLog = new UserLogBUS();

                        this.Hide();
                        if(userLog.getUserLog(user).ToList().Count() > 0){
                            if (userLog.getUserLog(user).ToList()[userLog.getUserLog(user).ToList().Count() - 1].LogOutTime == null)
                            {

                                AswLog aswLog = new AswLog(userLog.getUserLog(user).ToList()[userLog.getUserLog(user).ToList().Count() - 1], user);
                                aswLog.Show();

                            }
                            else
                            {
                                frmMainUser mainUser = new frmMainUser(user);
                                mainUser.Show();
                            }
                        }
                        else
                        {
                            frmMainUser mainUser = new frmMainUser(user);
                            mainUser.Show();
                        }

                    }
                }
                else
                {
                    this.txtPassword.Text = "";
                    this.txtUserName.Text = "";
                    MessageBox.Show("User Name or Password incorrect.");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
