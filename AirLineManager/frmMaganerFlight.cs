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
using Excel = Microsoft.Office.Interop.Excel;


namespace AirLineManager
{
    public partial class frmMaganerFlight : Form
    {
        public frmMaganerFlight()
        {
           
            InitializeComponent();
            this.CenterToScreen();
        }
        AirportBUS airportBUS = new AirportBUS();
        ScheduleBUS scheduleBUS = new ScheduleBUS();
        RouterBUS routerBUS = new RouterBUS();
        private void frmMaganerFlight_Load(object sender, EventArgs e)
        {
            setComboboxAirport(cbxFrom);
            setComboboxAirport(cbxTo);
            setDataGirdView();
            loadSortBy();
        }
        void setComboboxAirport( ComboBox cbx)
        {

            var listAirprot = airportBUS.getAirports();
            listAirprot.Insert(0,new Airport()
            {
                ID = 0,
                Name = "All ..."
            });
            cbx.DataSource = listAirprot;
            cbx.DisplayMember = "Name";
            cbx.ValueMember = "ID";

        }
        private void  loadSortBy()
        {
            cbbSortBy.DisplayMember = "Text";
            cbbSortBy.ValueMember = "Value";

            cbbSortBy.Items.Add(new { Text = "DateTime", Value = "1" });
            cbbSortBy.Items.Add(new { Text = "Price", Value = "2" });
            cbbSortBy.SelectedIndex = 0;
            
        }
        void setDataGirdView()
        {
            AirLineEntities context = new AirLineEntities();
            var list = context.VD3.ToList().Join(context.VD4.ToList(), VD3 => VD3.ID, VD4 => VD4.ID, (VD3, VD4) => new { VD3, VD4 }).OrderByDescending(a => a.VD3.Date).ToList();
            for(int i = 0; i < list.Count(); i++)
            {
               
                dgvMaganerFlight.Rows.Add();
                dgvMaganerFlight.Rows[i].Cells[0].Value = list.ToList()[i].VD3.Date.ToString("dd/MM/yyyy");
                dgvMaganerFlight.Rows[i].Cells[1].Value = list.ToList()[i].VD3.Time;
                dgvMaganerFlight.Rows[i].Cells[2].Value = list.ToList()[i].VD3.To;
                dgvMaganerFlight.Rows[i].Cells[3].Value = list.ToList()[i].VD4.From;
                dgvMaganerFlight.Rows[i].Cells[4].Value = list.ToList()[i].VD3.FlightNumber.ToString() ;
                dgvMaganerFlight.Rows[i].Cells[5].Value = list.ToList()[i].VD3.AircraftID.ToString();
                dgvMaganerFlight.Rows[i].Cells[6].Value = list.ToList()[i].VD3.EconomyPrice.ToString() + "$";
                dgvMaganerFlight.Rows[i].Cells[7].Value = (Convert.ToDouble( list.ToList()[i].VD3.EconomyPrice)*1.3).ToString() + "$";
                dgvMaganerFlight.Rows[i].Cells[8].Value = (Convert.ToDouble(list.ToList()[i].VD3.EconomyPrice) * 1.35).ToString() + "$";
                dgvMaganerFlight.Rows[i].Cells[9].Value = list.ToList()[i].VD3.ID;
                if (list.ToList()[i].VD3.Confirmed == false)
                {
                    dgvMaganerFlight.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            
            AirLineEntities context = new AirLineEntities();
            MessageBox.Show(dtpOUtBound.Value.Day.ToString());
            int from = Convert.ToInt32(cbxFrom.SelectedValue.ToString());
            int to = Convert.ToInt32(cbxTo.SelectedValue.ToString());
            var list = context.VD3.ToList().Join(context.VD4.ToList(), VD3 => VD3.ID, VD4 => VD4.ID, (VD3, VD4) => new { VD3, VD4 }).OrderByDescending(a => a.VD3.Date); ;
            if (cbbSortBy.SelectedIndex == 0)
            {
                 list = context.VD3.ToList().Join(context.VD4.ToList(), VD3 => VD3.ID, VD4 => VD4.ID, (VD3, VD4) => new { VD3, VD4 }).OrderByDescending(a => a.VD3.Date);
            }
            else
            {
                 list = context.VD3.ToList().Join(context.VD4.ToList(), VD3 => VD3.ID, VD4 => VD4.ID, (VD3, VD4) => new { VD3, VD4 }).OrderBy(a => a.VD3.EconomyPrice);
            }

            var listSub = list.Where(l => l.VD3.DepartureAirportID == from && l.VD3.ArrivalAirportID == to && l.VD3.Date.ToString("ddMMyyyy") == dtpOUtBound.Value.ToString("ddMMyyyy") && l.VD3.FlightNumber.ToString() == txtFlightNumber.Text).ToList();
            //var listSub = list.Where(l => l.VD3.DepartureAirportID == from && l.VD3.ArrivalAirportID == to && l.VD3.Date.ToString("ddMMyyyy") == dtpOUtBound.Value.ToString("ddMMyyyy")&&l.VD3.FlightNumber.ToString()==txtFlightNumber.Text).ToList();
            if (listSub.Count()>0)
            {
                dgvMaganerFlight.Rows.Clear();
                //dgvMaganerFlight.Columns[9].Visible = false;
                for (int i = 0; i < listSub.Count(); i++)
                {
                    dgvMaganerFlight.Rows.Add();
                    
                    dgvMaganerFlight.Rows[i].Cells[0].Value = listSub.ToList()[i].VD3.Date.ToString("dd/MM/yyyy");
                    dgvMaganerFlight.Rows[i].Cells[1].Value = listSub.ToList()[i].VD3.Time;
                    dgvMaganerFlight.Rows[i].Cells[2].Value = listSub.ToList()[i].VD4.From;
                    dgvMaganerFlight.Rows[i].Cells[3].Value = listSub.ToList()[i].VD3.To;
                    dgvMaganerFlight.Rows[i].Cells[4].Value = listSub.ToList()[i].VD3.FlightNumber.ToString();
                    dgvMaganerFlight.Rows[i].Cells[5].Value = listSub.ToList()[i].VD3.AircraftID.ToString();
                    dgvMaganerFlight.Rows[i].Cells[6].Value = listSub.ToList()[i].VD3.EconomyPrice.ToString() + "$";
                    dgvMaganerFlight.Rows[i].Cells[7].Value = (Convert.ToDouble(listSub.ToList()[i].VD3.EconomyPrice) * 1.3).ToString() + "$";
                    dgvMaganerFlight.Rows[i].Cells[8].Value = (Convert.ToDouble(listSub.ToList()[i].VD3.EconomyPrice) * 1.35).ToString() + "$";
                    dgvMaganerFlight.Rows[i].Cells[9].Value = listSub.ToList()[i].VD3.ID;
                    

                    if (listSub.ToList()[i].VD3.Confirmed == false)
                    {
                        dgvMaganerFlight.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("No search Schedule");
                dgvMaganerFlight.Rows.Clear();
            }
        }

        private void cbbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelFlight_Click(object sender, EventArgs e)
        {
            int index = dgvMaganerFlight.SelectedRows[0].Index;
            if(dgvMaganerFlight.Rows[index].DefaultCellStyle.BackColor == Color.Red)
            {
                dgvMaganerFlight.Rows[index].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                dgvMaganerFlight.Rows[index].DefaultCellStyle.BackColor = Color.Red;
            }
            scheduleBUS.setComfirm(Convert.ToInt32(dgvMaganerFlight.Rows[index].Cells[9].Value));
        }

        private void btnEditFlight_Click(object sender, EventArgs e)
        {
            int index = dgvMaganerFlight.SelectedRows[0].Index;
            ScheduleEdit scheduleEdit = new ScheduleEdit(Convert.ToInt32(dgvMaganerFlight.Rows[index].Cells[9].Value), dgvMaganerFlight.Rows[index].Cells[2].Value.ToString(), dgvMaganerFlight.Rows[index].Cells[3].Value.ToString(), Convert.ToInt32(dgvMaganerFlight.Rows[index].Cells[5].Value));
            scheduleEdit.ShowDialog(this);
            dgvMaganerFlight.Rows.Clear();
            this.setDataGirdView();

        }

        private void btnImportChange_Click(object sender, EventArgs e)
        {
            frmScheduleChange scheduleChange = new frmScheduleChange();
            scheduleChange.ShowDialog(this);
            dgvMaganerFlight.Rows.Clear();
            setDataGirdView();
        }
    }
}
