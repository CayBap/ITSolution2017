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
    public partial class frmMainAdmin : Form
    {
        public frmMainAdmin()
        {
            InitializeComponent();

        }
        public frmMainAdmin(User user)
        {
            InitializeComponent();
        }
        private OfficeBUS officeBUS = new OfficeBUS();
        private UserBUS userBUS = new UserBUS();
        public static int check = 0;
        private void MainAdmin_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            LoadDataGirdView(0);
            this.CenterToScreen();
        }
        public void LoadDataGirdView(int OfficeID)
        {
            
            List<User> data= null;
            
                data = userBUS.getUsers(OfficeID);
            for(int i = 0; i <= data.Count()-1; i++)
            {

                this.dgvUser.Rows.Add();
                this.dgvUser.Rows[i].Cells[0].Value = data[i].FirstName;
                this.dgvUser.Rows[i].Cells[1].Value = data[i].LastName;
                this.dgvUser.Rows[i].Cells[2].Value = (DateTime.Now.Year - Convert.ToDateTime(data[i].Birthdate).Year);
                this.dgvUser.Rows[i].Cells[3].Value = data[i].RoleID == 1 ? "Adminstrator" : "User in Office";
                this.dgvUser.Rows[i].Cells[4].Value = data[i].Email;
                this.dgvUser.Rows[i].Cells[5].Value = data[i].OfficeID;
                if (data[i].Active == false)
                {
                    this.dgvUser.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                if (data[i].RoleID == 1)
                {

                    this.dgvUser.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

        public void LoadCombobox()
        {
            var offices = officeBUS.getOffices();
            offices.Insert(0, new Office() { Title = "All Office", ID = 0 });
            cbxOffice.DataSource = offices;
            cbxOffice.DisplayMember = "Title";
            cbxOffice.ValueMember = "ID";
            cbxOffice.SelectedIndex = 0;
        }

        private void cbxOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvUser.Rows.Clear();
            if (check == 0)
            {
                LoadDataGirdView(0);
                check++;
            }
            else if(check == 1)
            {
               
                check++;

            }
            else
            {
                LoadDataGirdView(Convert.ToInt32(cbxOffice.SelectedValue.ToString()));
            }
        }

        private void menuTripAddUser_Click(object sender, EventArgs e)
        {
            frmAdduser adduser = new frmAdduser();
            adduser.ShowDialog(this);
            dgvUser.Refresh();
            dgvUser.Update();
            dgvUser.Rows.Clear();
            this.LoadDataGirdView(0);
         
        }

        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            User user = null;
            int index = dgvUser.SelectedRows[0].Index;
           // MessageBox.Show((dgvUser.Rows[index].Cells[3].Value.ToString() == "Adminstrator" ? 1 : 2).ToString());
            user = new User()
            {
                FirstName = dgvUser.Rows[index].Cells[0].Value.ToString(),
                LastName = dgvUser.Rows[index].Cells[1].Value.ToString(),
                RoleID = dgvUser.Rows[index].Cells[3].Value.ToString() == "Adminstrator" ? 1 : 2,
                Email = dgvUser.Rows[index].Cells[4].Value.ToString(),
                OfficeID = Convert.ToInt32(dgvUser.Rows[index].Cells[5].Value)
            };
            frmChangeRole editRole = new frmChangeRole(user);
            editRole.ShowDialog(this);
            
            dgvUser.Rows.Clear();
            this.LoadDataGirdView(0);
            dgvUser.Refresh();
            dgvUser.Update();
        }

        private void btnChangeLogin_Click(object sender, EventArgs e)
        {
            int userID = 0;
            List<User> users = userBUS.getUsers(0);
            
            int index = dgvUser.SelectedRows[0].Index;
            //MessageBox.Show(index.ToString());
            for (int i = 0; i <= users.Count; i++)
            {
                if (users[i].Email == dgvUser.Rows[index].Cells[4].Value.ToString())
                {
                    userID = i+1;
                    break;
                }
            }
            userBUS.changeLog(userID);
            dgvUser.Rows.Clear();
            this.LoadDataGirdView(0);
        }

        private void menuTripExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Exit", "Do you want to exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr == DialogResult.OK)
            {
                this.Close();
            }

        }
    }
}
