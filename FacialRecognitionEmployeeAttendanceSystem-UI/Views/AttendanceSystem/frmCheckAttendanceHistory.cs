using FacialRecognitionEmployeeAttendanceSystem_UI.Models;
using FacialRecognitionEmployeeAttendanceSystem_UI.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.AttendanceSystem
{
    public partial class frmCheckAttendanceHistory : Form
    {
        AttendancesRepository _attendancesRepository = new AttendancesRepository();
        public frmCheckAttendanceHistory()
        {
            InitializeComponent();
        }

        private void frmCheckAttendanceHistory_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            /*string date = dtpHistory.Value.ToShortDateString();*/
            Attendances attendances = await _attendancesRepository.GetByDateTimeAsync(dtpHistory.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat));

            List<Attendances> listAttendances = new List<Attendances>();
            listAttendances.Add(attendances);
            dgvCheckAttendanceHistory.DataSource = listAttendances;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
           
        }
    }
}
