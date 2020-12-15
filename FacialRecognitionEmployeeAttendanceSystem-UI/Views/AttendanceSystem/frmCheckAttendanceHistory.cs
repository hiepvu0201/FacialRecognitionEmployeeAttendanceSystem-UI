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
        #region Properties
        AttendancesRepository _attendancesRepository = new AttendancesRepository();
        #endregion

        #region Constructor
        public frmCheckAttendanceHistory()
        {
            InitializeComponent();
        }
        #endregion

        #region Event
        private void frmCheckAttendanceHistory_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvCheckAttendanceHistory.Rows.Count > 0)
            {
                try
                {
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = $"Attendance History {dtpHistory.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)}";

                    for (int i = 1; i < dgvCheckAttendanceHistory.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = dgvCheckAttendanceHistory.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvCheckAttendanceHistory.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvCheckAttendanceHistory.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvCheckAttendanceHistory.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = $"AttendanceHistory{dtpHistory.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)}";
                    saveFileDialog.DefaultExt = ".xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing);
                    }
                    app.Quit();
                    MessageBox.Show("Export successfully!");
                }
                catch
                {
                    MessageBox.Show("Export fail! Please check and try later!");
                }
            }
        }
        private void btnCalculateTodaySalary_Click(object sender, EventArgs e)
        {
            MessageBox.Show(frmAttendanceSystem.todaySalary.ToString());
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAttendanceSystem frmAttendanceSystem = new frmAttendanceSystem();
            frmAttendanceSystem.Show();
        }
        #endregion

        #region Method
        private async void LoadData()
        {
            /*string date = dtpHistory.Value.ToShortDateString();*/
            Attendances attendances = await _attendancesRepository.GetByDateTimeAsync(dtpHistory.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat));

            if (attendances != null && attendances.users.fullName == frmAttendanceSystem.recognitionName)
            {
                List<Attendances> listAttendances = new List<Attendances>();
                listAttendances.Add(attendances);
                dgvCheckAttendanceHistory.DataSource = listAttendances;
            }
        }
        #endregion

        private void btnOptionalCalculate_Click(object sender, EventArgs e)
        {

        }
    }
}
