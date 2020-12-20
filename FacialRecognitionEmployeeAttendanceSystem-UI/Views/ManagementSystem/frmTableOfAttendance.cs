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
    public partial class frmTableOfAttendance : Form
    {
        AttendancesRepository _attendancesRepository = new AttendancesRepository();
        UsersRepository _usersRepository = new UsersRepository();
        public frmTableOfAttendance()
        {
            InitializeComponent();
        }

        private void frmTableOfAttendance_Load(object sender, EventArgs e)
        {
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAttendanceSystem frmAttendanceSystem = new frmAttendanceSystem();
            frmAttendanceSystem.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            dgvTableOfAttendance.ColumnCount = DateTime.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month) + 1;
            dgvTableOfAttendance.Columns[0].Name = $"User Name";
            for (int i = 1; i < dgvTableOfAttendance.ColumnCount; i++)
            {
                dgvTableOfAttendance.Columns[i].Name = $"Day {i}";
            }
            List<Users> listUsers = await _usersRepository.GetList();
            List<Attendances> listAttendance = await _attendancesRepository.GetList();
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
    }
}
