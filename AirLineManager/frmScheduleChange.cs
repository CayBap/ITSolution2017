using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using AirLineManager.BUS;
namespace AirLineManager
{
    public partial class frmScheduleChange : Form
    {
        public frmScheduleChange()
        {
            InitializeComponent();
            this.CenterToParent();
        }

      
        private void frmScheduleChange_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sussces = 0;
            int missing = 0;
            int douplicate = 0;
            ScheduleBUS scheduleBUS = new ScheduleBUS();
            AirportBUS airportBUS = new AirportBUS();
            OpenFileDialog freo = new OpenFileDialog();
            RouterBUS routerBUS = new RouterBUS();
            freo.Filter = "(Tat ca cac tep)|*.*|(Cac tep excel)|*.csv";
            freo.ShowDialog();
            txtFileName.Text = freo.FileName;
            int rows = 0;
            if (freo.FileName != "")
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Open(freo.FileName);
                try
                {
                    Excel.Worksheet sheet = wb.Sheets[1];
                    Excel.Range range = sheet.UsedRange;
                     rows = range.Rows.Count;
                    int colum = range.Cells.Count;

                    // MessageBox.Show(range.Rows[1].Cells[3].Text.ToString());

                    for (int i = 1; i <= rows; i++)
                    {
                        if (range.Cells[i, 1].value == "EDIT")
                        {
                            int idFrom = airportBUS.getID(range.Cells[i, 5].value.ToString());
                            int idTo = airportBUS.getID(range.Cells[i, 6].value.ToString());
                            DateTime Date = DateTime.Parse(range.Rows[i].Cells[2].value.ToString());
                            TimeSpan Time = TimeSpan.Parse(range.Rows[i].Cells[3].Text.ToString());
                            int flightNumber = int.Parse(range.Cells[i, 4].value.ToString());
                            int idAircraft = int.Parse(range.Cells[i, 7].value.ToString());
                            bool comfirm = true;
                            int ecomnomyPrice = int.Parse(range.Cells[i, 8].value.ToString());
                            if (range.Cells[i, 9].value.ToString() == "OK")
                            {
                                comfirm = true;
                            }
                            else
                            {
                                comfirm = false;
                            }
                            try
                            {
                                scheduleBUS.EditSchedule(Date, Time, flightNumber, idAircraft, comfirm, ecomnomyPrice);
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            int idFrom = airportBUS.getID(range.Cells[i, 5].value.ToString());
                            int idTo = airportBUS.getID(range.Cells[i, 6].value.ToString());
                            int idRouter = routerBUS.getRouterID(idFrom, idTo);
                            DateTime Date = DateTime.Parse(range.Rows[i].Cells[2].value.ToString());
                            TimeSpan Time = TimeSpan.Parse(range.Rows[i].Cells[3].Text.ToString());
                            int flightNumber = int.Parse(range.Cells[i, 4].value.ToString());
                            int idAircraft = int.Parse(range.Cells[i, 7].value.ToString());
                            bool comfirm = true;
                            int ecomnomyPrice = int.Parse(range.Cells[i, 8].value.ToString());
                            if (range.Cells[i, 9].value.ToString() == "OK")
                            {
                                comfirm = true;
                            }
                            else
                            {
                                comfirm = false;
                            }
                            if (scheduleBUS.getScheduleOneinAll(Date, Time, flightNumber, idAircraft, comfirm, ecomnomyPrice, idRouter)==new Schedule())
                            {
                                douplicate++;
                            }
                            else
                            {
                                scheduleBUS.AddSchedule(Date, Time, flightNumber, idAircraft, comfirm, ecomnomyPrice, idRouter);
                                sussces++;
                            }
                            frmMaganerFlight maganerFlight = new frmMaganerFlight();
                            //MessageBox.Show("Upload sussces!");
                           
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    //throw ex;
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    missing++;
                }
            }
            else
            {
                MessageBox.Show("No input file,please input file.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            douplicate = rows - missing - sussces;
            lblDuplicate.Text = douplicate.ToString();
            lblMissing.Text = missing.ToString();
            lblSussces.Text = sussces.ToString();
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
