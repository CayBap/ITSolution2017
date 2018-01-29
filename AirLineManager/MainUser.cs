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
    public partial class frmMainUser : Form
    {
        public frmMainUser()
        {
            InitializeComponent();
        }
        public frmMainUser(User user)
        {
            InitializeComponent();
            userStatic = user;
            LoadDataGirdView(user);
            LoadDetailUser(user);
            setLoginUser(user);
        }
        UserLogBUS userLogBus = new UserLogBUS();
        static User userStatic = null;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuTripExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMainUser_Load(object sender, EventArgs e)
        {

        }
        
        private void LoadDetailUser(User user)
        {
            List<Log> logs = userLogBus.getLogs(user);
            lblFirstName.Text = user.FirstName;
            lblCrash.Text = logs.Where(log => log.LoginReason != null).Count().ToString();
        }
        private void LoadDataGirdView(User user)
        {
           
            dgvListLog.DataSource = userLogBus.getLogs(user);
           
        }
        private void setLoginUser(User user)
        {

            
            List<Log> logs = userLogBus.getLogs(user);
            int id = userLogBus.countLogAll() + 1;
          //  MessageBox.Show(id.ToString());
           // MessageBox.Show(id.ToString());
            Log log = new Log()
            {
                ID =id ,
                DateA = DateTime.Now,
                LoginTime = DateTime.Now,
                IDUser = user.ID
            };
        
            userLogBus.setLogUser(log);
        }

        private void frmMainUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log log = userLogBus.getUserLog(userStatic).Last() ;
            TimeSpan t = DateTime.Now - log.LoginTime.Value;
            double time = Convert.ToDouble(t.TotalHours);
            Log newLog = new Log() {
                ID = log.ID,
                LogOutTime = DateTime.Now,
                LoginTime = log.LoginTime,
                IDUser = log.IDUser,
                
            };
             DialogResult dr =  MessageBox.Show("Exit", "Are you exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr == DialogResult.OK)
            {
                userLogBus.updateLog(newLog);
                frmMainUser mainUser = new frmMainUser();
                mainUser.Close();
            }
        }
    }
}
