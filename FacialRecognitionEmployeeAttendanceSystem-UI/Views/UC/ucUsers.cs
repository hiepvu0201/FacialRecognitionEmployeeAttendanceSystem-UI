using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacialRecognitionEmployeeAttendanceSystem_UI.Views.AttendanceSystem;
using FacialRecognitionEmployeeAttendanceSystem_UI.Models;
using FacialRecognitionEmployeeAttendanceSystem_UI.Repository;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.UC
{
    public partial class ucUsers : UserControl
    {
        RolesRepository _rolesRepository = new RolesRepository();
        DepartmentsRepository _departmentsRepository = new DepartmentsRepository();
        ShiftsRepository _shiftsRepository = new ShiftsRepository();

        public ucUsers()
        {
            InitializeComponent();
        }

        private void btnTrainingForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTraining frmTraining = new frmTraining(txtFullName.Text);
            frmTraining.Show();
        }

        private void ucUsers_Load(object sender, EventArgs e)
        {
            LoadRoleComboBoxAsysnc();
            LoadDepartmentComboBoxAsysnc();
            LoadShiftComboBoxAsysnc();
        }

        public async Task LoadRoleComboBoxAsysnc()
        {
            List<Roles> listRole = await _rolesRepository.GetList();
            foreach (Roles item in listRole)
            {
                cbbRole.Items.Add(item.id + "." + item.roleName);
            }
        }

        public async Task LoadDepartmentComboBoxAsysnc()
        {
            List<Departments> listDepartment = await _departmentsRepository.GetList();
            foreach (Departments item in listDepartment)
            {
                cbbDepartment.Items.Add(item.id + "." + item.departmentName);
            }
        }

        public async Task LoadShiftComboBoxAsysnc()
        {
            List<Shifts> listShift = await _shiftsRepository.GetList();
            foreach (Shifts item in listShift)
            {
                cbbShift.Items.Add(item.id + "." + item.shiftName);
            }
        }

        private void txtDob_Click(object sender, EventArgs e)
        {
            txtDob.Text = "";
        }
    }
}
