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
    public partial class ScheduleEdit : Form
    {
        public ScheduleEdit()
        {
            InitializeComponent();
        }
        AircraftBUS aircraftBUS = new AircraftBUS();
        ScheduleBUS scheduleBUS = new ScheduleBUS();
        int idSche = -1;
        public ScheduleEdit(int id,string From,string To,int Aircraft)
        {
           
            InitializeComponent();
            this.CenterToScreen();
            lblFrom.Text = From;
            idSche = id;
            lblTo.Text = To;
            lblAircraft.Text = aircraftBUS.getAircraft(Aircraft).Name.ToString();
            Schedule schedule = scheduleBUS.getSchedule(id);
           // dtpDate.Value = schedule.Date;
            txtPrice.Text = schedule.EconomyPrice.ToString() ;
            txtTime.Text = schedule.Time.ToString();
            dtpDate.Value = schedule.Date;
        }


        private void lblTo_Click(object sender, EventArgs e)
        {

        }

        private void ScheduleEdit_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Schedule sche = scheduleBUS.getSchedule(idSche);
            sche.Time = TimeSpan.Parse(txtTime.Text.ToString());
            sche.Date = dtpDate.Value;
            sche.EconomyPrice = decimal.Parse(txtPrice.Text.ToString());
            scheduleBUS.updateSchedule(sche);
            this.Close();
        }
       
    }
}
