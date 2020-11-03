using FacialRecognitionEmployeeAttendanceSystem_UI.Models;
using FacialRecognitionEmployeeAttendanceSystem_UI.Repository;
using FacialRecognitionEmployeeAttendanceSystem_UI.Views.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views
{
    public partial class frmManagementSystem : Form
    {
        int flag = 0;
        /*1. Departments
        2. Roles
        3. Users
        4. Shifts
        5. Attendances
        6. Payslips*/

        DepartmentsRepository _departmentRepository = new DepartmentsRepository();
        ShiftsRepository _shiftsRepository = new ShiftsRepository();
        RolesRepository _rolesRepository = new RolesRepository();
        UsersRepository _usersRepository = new UsersRepository();
        AttendancesRepository _attendancesRepository = new AttendancesRepository();
        PayslipsRepository _payslipsRepository = new PayslipsRepository();

        public frmManagementSystem()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            //UC init
            ucView1.Show();
            ucDepartments1.Hide();
            ucAttendances1.Hide();
            ucShifts1.Hide();
            ucPayslips1.Hide();
            ucRoles1.Hide();
            ucUsers1.Hide();

            //Button CRUD init
            btnUpdate.Enabled = false;
            btnEnable.Enabled = false;
            btnDisable.Enabled = false;
            btnSave.Enabled = false;
        }

        private async void LoadData()
        {
            List<Departments> listDepartments = await _departmentRepository.GetList();
            List<Shifts> listShifts = await _shiftsRepository.GetList();
            List<Attendances> listAttendances = await _attendancesRepository.GetList();
            List<Roles> listRoles = await _rolesRepository.GetList();
            List<Payslips> listPayslips = await _payslipsRepository.GetList();
            List<Users> listUsers = await _usersRepository.GetList();

            switch (flag)
            {
                case 1:
                    ucView1.dataGridView1.DataSource = listDepartments;
                    break;
                case 2:
                    ucView1.dataGridView1.DataSource = listRoles;
                    break;
                case 3:
                    ucView1.dataGridView1.DataSource = listUsers;
                    break;
                case 4:
                    ucView1.dataGridView1.DataSource = listShifts;
                    break;
                case 5:
                    ucView1.dataGridView1.DataSource = listAttendances;
                    break;
                case 6:
                    ucView1.dataGridView1.DataSource = listPayslips;
                    break;
                default:
                    break;
            }
            
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            flag = 1;
            LoadData();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            flag = 2;
            LoadData();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            flag = 3;
            LoadData();
        }

        private void btnShifts_Click(object sender, EventArgs e)
        {
            flag = 4;
            LoadData();
        }

        private void btnAttendances_Click(object sender, EventArgs e)
        {
            flag = 5;
            LoadData();
        }

        private void btnPayslips_Click(object sender, EventArgs e)
        {
            flag = 6;
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (flag)
            {
                case 1:
                    {
                        ucDepartments1.Show();
                        ucAttendances1.Hide();
                        ucShifts1.Hide();
                        ucPayslips1.Hide();
                        ucRoles1.Hide();
                        ucUsers1.Hide();
                    }
                    break;
                case 2:
                    {
                        ucDepartments1.Hide();
                        ucAttendances1.Hide();
                        ucShifts1.Hide();
                        ucPayslips1.Hide();
                        ucRoles1.Show();
                        ucUsers1.Hide();
                    }
                    break;
                case 3:
                    {
                        ucDepartments1.Hide();
                        ucAttendances1.Hide();
                        ucShifts1.Hide();
                        ucPayslips1.Hide();
                        ucRoles1.Hide();
                        ucUsers1.Show();
                    }
                    break;
                case 4:
                    {
                        ucDepartments1.Hide();
                        ucAttendances1.Hide();
                        ucShifts1.Show();
                        ucPayslips1.Hide();
                        ucRoles1.Hide();
                        ucUsers1.Hide();
                    }
                    break;
                case 5:
                    {
                        ucDepartments1.Hide();
                        ucAttendances1.Show();
                        ucShifts1.Hide();
                        ucPayslips1.Hide();
                        ucRoles1.Hide();
                        ucUsers1.Hide();
                    }
                    break;
                case 6:
                    {
                        ucDepartments1.Hide();
                        ucAttendances1.Hide();
                        ucShifts1.Hide();
                        ucPayslips1.Show();
                        ucRoles1.Hide();
                        ucUsers1.Hide();
                    }
                    break;
                default:
                    break;
            }
            btnSave.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
