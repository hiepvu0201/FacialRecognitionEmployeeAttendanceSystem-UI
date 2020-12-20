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

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.ManagementSystem
{
    public partial class frmMonthlyAttendanceAndSalary : Form
    {
        AttendancesRepository _attendancesRepository = new AttendancesRepository();
        UsersRepository _usersRepository = new UsersRepository();
        PayslipsRepository _payslipsRepository = new PayslipsRepository();
        public frmMonthlyAttendanceAndSalary()
        {
            InitializeComponent();
        }

        private void frmTableOfAttendance_Load(object sender, EventArgs e)
        {
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmManagementSystem frm = new frmManagementSystem();
            frm.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDataAttendanceAsync();
        }

        private async Task LoadDataAttendanceAsync()
        {
            dgvTableOfAttendance.ColumnCount = DateTime.DaysInMonth(dtpAttendanceDate.Value.Year, dtpAttendanceDate.Value.Month) + 1;
            dgvTableOfAttendance.Columns[0].Name = $"User Name";
            for (int i = 1; i < dgvTableOfAttendance.ColumnCount; i++)
            {
                dgvTableOfAttendance.Columns[i].Name = $"Day {i}";
            }
            List<Users> listUsers = await _usersRepository.GetList();
            List<Attendances> listAttendance = await _attendancesRepository.GetList();
            foreach (Attendances item in listAttendance)
            {
                int month = Convert.ToInt32((item.dateCheck.Substring(item.dateCheck.IndexOf("-") + 1, item.dateCheck.LastIndexOf("-") - item.dateCheck.IndexOf("-") - 1)));
                int year = Convert.ToInt32((item.dateCheck.Substring(0, item.dateCheck.IndexOf("-"))));
                if (month != dtpAttendanceDate.Value.Month||year!=dtpAttendanceDate.Value.Year)
                {
                    listAttendance.Remove(item);
                }
            }
            foreach (Users item in listUsers)
            {
                DataGridViewRow row = (DataGridViewRow)dgvTableOfAttendance.Rows[0].Clone();
                row.Cells[0].Value = item.fullName;

                foreach (Attendances attendanItem in listAttendance)
                {
                    if (attendanItem.users.fullName==item.fullName)
                    {
                        int index = Convert.ToInt32(attendanItem.dateCheck.Substring(attendanItem.dateCheck.Length - 2));
                        if (attendanItem.note != null && attendanItem.note != "")
                        {
                            row.Cells[index].Style.BackColor = Color.Yellow;
                            row.Cells[index].Value = "P";
                        }
                        else
                        {
                            row.Cells[index].Style.BackColor = Color.Green;
                            row.Cells[index].Value = "X";
                        }
                    }
                }
                dgvTableOfAttendance.Rows.Add(row);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvTableOfAttendance.Rows.Count > 0)
            {
                try
                {
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = $"Attendance History {dtpAttendanceDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)}";

                    for (int i = 1; i < dgvTableOfAttendance.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = dgvTableOfAttendance.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvTableOfAttendance.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvTableOfAttendance.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvTableOfAttendance.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = $"AttendanceHistory{dtpAttendanceDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)}";
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

        private void btnSearchSpecificAttendance_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchAttendance.Text;

            dgvTableOfAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dgvTableOfAttendance.Rows)
                {
                    if (row.Cells[2].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnSearchSpecificSalary_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchSpecificNameForSalary.Text;

            dgvMonthlySalary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dgvMonthlySalary.Rows)
                {
                    if (row.Cells[2].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnExportSalary_Click(object sender, EventArgs e)
        {
            if (dgvMonthlySalary.Rows.Count > 0)
            {
                try
                {
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = $"Attendance History {dtpMonthlySalary.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)}";

                    for (int i = 1; i < dgvMonthlySalary.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = dgvMonthlySalary.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvMonthlySalary.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvMonthlySalary.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvMonthlySalary.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = $"AttendanceHistory{dtpAttendanceDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)}";
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

        

        private void btnSearchSalary_Click(object sender, EventArgs e)
        {
            LoadDataSalaryAsync();
        }

        private async Task LoadDataSalaryAsync()
        {
            //Last +1 for total salary
            dgvMonthlySalary.ColumnCount = DateTime.DaysInMonth(dtpMonthlySalary.Value.Year, dtpMonthlySalary.Value.Month) + 1 + 1;
            dgvMonthlySalary.Columns[0].Name = "User Name";
            for (int i = 1; i < dgvMonthlySalary.ColumnCount - 1; i++)
            {
                dgvMonthlySalary.Columns[i].Name = $"Day {i}";
            }
            dgvMonthlySalary.Columns[dgvMonthlySalary.ColumnCount-1].Name = "Total";
            List<Users> listUsers = await _usersRepository.GetList();
            List<Payslips> listPayslips = await _payslipsRepository.GetList();
            foreach (Payslips item in listPayslips)
            {
                int month = Convert.ToInt32(item.payDate.Month);
                int year = Convert.ToInt32((item.payDate.Year));
                if (month != dtpMonthlySalary.Value.Month || year != dtpMonthlySalary.Value.Year)
                {
                    listPayslips.Remove(item);
                }
            }
            foreach (Users item in listUsers)
            {
                DataGridViewRow row = (DataGridViewRow)dgvMonthlySalary.Rows[0].Clone();
                row.Cells[0].Value = item.fullName;

                foreach (Payslips payslipItem in listPayslips)
                {
                    if (payslipItem.users.fullName == item.fullName)
                    {
                        int index = Convert.ToInt32(payslipItem.payDate.Day);

                        row.Cells[index].Value = payslipItem.publicSalary.ToString();
                    }
                }
                dgvMonthlySalary.Rows.Add(row);
            }
        }
    }
}
