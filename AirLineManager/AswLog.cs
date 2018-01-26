using AirLineManager.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLineManager
{
    public partial class AswLog : Form
    {
        static User userStatic = null;
        static Log logStatic = null;
        public AswLog()
        {
            InitializeComponent();
        }
        public AswLog(Log log, User user)
        {
            InitializeComponent();
            userStatic = user;
            logStatic = log;
            
        }
        private void AswLog_Load(object sender, EventArgs e)
        {
            
        }
        private void lastOut(Log log)
        {
            lblLastLogin.Text = log.LoginTime.ToString();
        }

        private void btncomfirm_Click(object sender, EventArgs e)
        {
            UserLogBUS userLogBus = new UserLogBUS();
            TimeSpan t = DateTime.Now - logStatic.LoginTime.Value;
            double time = Convert.ToDouble(t.TotalHours);
            Log newLog = new Log()
            {
                ID = logStatic.ID,
                LogOutTime = DateTime.Now,
                LoginTime = logStatic.LoginTime,
                IDUser = logStatic.IDUser,
                LoginReason = txtLoginReason.Text
            };
            userLogBus.updateLog(newLog);
            frmMainUser mainUser = new frmMainUser(userStatic);
            this.Hide();
            mainUser.Show();
        }
    }
}
