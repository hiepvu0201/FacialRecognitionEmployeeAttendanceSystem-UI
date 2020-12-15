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
using FacialRecognitionEmployeeAttendanceSystem_UI.Views.ManagementSystem;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views
{
    public partial class frmManagementSystem : Form
    {
        public static int flag = 0;
        /*1. Departments
        2. Roles
        3. Users
        4. Shifts
        5. Attendances
        6. Payslips*/

        //Id to update or delete
        public static int selectedId;
        bool isUpdate = false;
        bool isAdd = false;

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
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnEnable.Enabled = false;
            btnDisable.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnDel.Enabled = true;
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
                    ucView1.dgvManagement.DataSource = listDepartments;
                    break;
                case 2:
                    ucView1.dgvManagement.DataSource = listRoles;
                    break;
                case 3:
                    ucView1.dgvManagement.DataSource = listUsers;
                    break;
                case 4:
                    ucView1.dgvManagement.DataSource = listShifts;
                    break;
                case 5:
                    ucView1.dgvManagement.DataSource = listAttendances;
                    break;
                case 6:
                    ucView1.dgvManagement.DataSource = listPayslips;
                    break;
                default:
                    break;
            }
            
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            flag = 1;
            LoadData();
            InitialInput(flag);
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            flag = 2;
            LoadData();
            InitialInput(flag);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            flag = 3;
            LoadData();
            InitialInput(flag);
        }

        private void btnShifts_Click(object sender, EventArgs e)
        {
            flag = 4;
            LoadData();
            InitialInput(flag);
        }

        private void btnAttendances_Click(object sender, EventArgs e)
        {
            flag = 5;
            LoadData();
            InitialInput(flag);
        }

        private void btnPayslips_Click(object sender, EventArgs e)
        {
            flag = 6;
            LoadData();
            InitialInput(flag);
        }

        private void InitialInput(int flag)
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnUpdate.Enabled = false;
            btnEnable.Enabled = false;
            btnDisable.Enabled = false;
            btnDel.Enabled = false;

            // Flag to recognize add or update
            isAdd = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (flag)
            {
                case 1:
                    {
                        // Department
                        SaveDepartment();
                    }
                    break;
                case 2:
                    {
                        // Role
                        SaveRoleInfo();
                    }
                    break;
                case 3:
                    {
                        // User
                        SaveUserInfo();
                    }
                    break;
                case 4:
                    {
                        // Shift
                        SaveShiftInfo();
                    }
                    break;
                case 5:
                    {
                        // Attendance
                        SaveAttendanceInfo();
                    }
                    break;
                case 6:
                    {
                        // Payslip
                        SavePayslipInfo();
                    }
                    break;
                default:
                    break;
            }
        }

        private void SavePayslipInfo()
        {
            try
            {
                Payslips payslip = new Payslips();
                payslip.payDate = DateTime.Parse(ucPayslips1.txtPayDate.Text);
                payslip.workingSalary = Double.Parse(ucPayslips1.txtWorkingSalary.Text);
                payslip.publicSalary = Double.Parse(ucPayslips1.txtPublicSalary.Text);
                payslip.otherSalary = Double.Parse(ucPayslips1.txtOtherSalary.Text);
                payslip.annualLeaveSalary = Double.Parse(ucPayslips1.txtAnualLeaveSalary.Text);
                payslip.overtimeSalary = Double.Parse(ucPayslips1.txtOvertimeSalary.Text);
                payslip.allowance = Double.Parse(ucPayslips1.txtAllowance.Text);
                payslip.bonus = Double.Parse(ucPayslips1.txtBonus.Text);
                payslip.tax = Double.Parse(ucPayslips1.txtTax.Text);
                payslip.deductionSalary = Double.Parse(ucPayslips1.txtDeductionSalary.Text);

                _payslipsRepository.Add(payslip);
                MessageBox.Show("Successful added!");
                LoadData();
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveAttendanceInfo()
        {
            try
            {
                Attendances attendance = new Attendances();
                attendance.dateCheck = ucAttendances1.txtDateCheck.Text;
                attendance.status = Boolean.Parse(ucAttendances1.txtStatus.Text);
                attendance.note = ucAttendances1.txtNote.Text;
                attendance.workingHours = Double.Parse(ucAttendances1.txtWorkingHours.Text);

                _attendancesRepository.Add(attendance);
                MessageBox.Show("Successful added!");
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveShiftInfo()
        {
            try
            {
                Shifts shift = new Shifts();
                shift.shiftName = ucShifts1.txtShiftName.Text;
                shift.timeStart = DateTime.Parse(ucShifts1.txtTimeStart.Text);
                shift.timeEnd = DateTime.Parse(ucShifts1.txtTimeEnd.Text);

                _shiftsRepository.Add(shift);
                MessageBox.Show("Successful added!");
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveUserInfo()
        {
            try
            {
                Users user = new Users();
                user.fullName = ucUsers1.txtFullName.Text;
                user.imgPath = ucUsers1.txtImgPath.Text;
                user.pin = ucUsers1.txtPIN.Text;
                user.dob = DateTime.Parse(ucUsers1.txtDob.Text);
                user.homeAddress = ucUsers1.txtHomeAddress.Text;
                user.grossSalary = Double.Parse(ucUsers1.txtGrossSalary.Text);
                user.netSalary = Double.Parse(ucUsers1.txtNetSalary.Text);
                user.note = ucUsers1.txtNote.Text;
                user.departmentId = Convert.ToInt32(ucUsers1.txtDepartmentId.Text);
                user.roleId = Convert.ToInt32(ucUsers1.txtRoleId.Text);

                _usersRepository.Add(user);
                MessageBox.Show("Successful added!");
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveRoleInfo()
        {
            try
            {
                Roles role = new Roles();
                role.roleName = ucRoles1.txtRoleName.Text;
                role.note = ucRoles1.txtNote.Text;
                role.description = ucRoles1.txtDescription.Text;

                _rolesRepository.Add(role);
                MessageBox.Show("Successful added!");
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveDepartment()
        {
            try
            {
                Departments department = new Departments();
                department.departmentName = ucDepartments1.txtDepartmentName.Text;
                department.shiftId = Convert.ToInt32(ucDepartments1.txtShiftId.Text);

                if (isAdd==true)
                {
                    _departmentRepository.Add(department);
                    MessageBox.Show("Successful added!");
                    isAdd = false;
                    LoadData();
                    Init();
                }
                else if (isUpdate == true)
                {
                    _departmentRepository.Update(selectedId, department);
                    MessageBox.Show("Successful updated!");
                    isUpdate = false;
                    LoadData();
                    Init();
                }
                
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Reset flag
            isUpdate = false;
            isAdd = false;

            // Reset button CRUD
            Init();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnCancel.Enabled = true;
            switch (flag)
            {
                case 1:
                    {
                        // Department
                        UpdateSelectedDepartment();
                    }
                    break;
                case 2:
                    {
                        // Role
                        UpdateSelectedRole();

                    }
                    break;
                case 3:
                    {
                        // User
                        UpdateSelectedUser();
                    }
                    break;
                case 4:
                    {
                        // Shift
                        UpdateSelectedShift();
                    }
                    break;
                case 5:
                    {
                        // Attendance
                        UpdateSelectedAttendance();
                    }
                    break;
                case 6:
                    {
                        // Payslip
                        UpdateSelectedAttendance();
                    }
                    break;
                default:
                    break;
            }
            isUpdate = true;
        }

        private void UpdateSelectedRole()
        {
            ucRoles1.txtRoleName.Text = Roles.GetInstance().roleName;
            ucRoles1.txtNote.Text = Roles.GetInstance().note;
            ucRoles1.txtDescription.Text = Roles.GetInstance().description;
        }

        private void UpdateSelectedAttendance()
        {
            ucAttendances1.txtDateCheck.Text = Attendances.GetInstance().dateCheck.ToString();
            ucAttendances1.txtNote.Text = Attendances.GetInstance().note;
            ucAttendances1.txtStatus.Text = Attendances.GetInstance().status.ToString();
            ucAttendances1.txtWorkingHours.Text = Attendances.GetInstance().workingHours.ToString();
        }

        private void UpdateSelectedShift()
        {
            ucShifts1.txtShiftName.Text = Shifts.GetInstance().shiftName;
            ucShifts1.txtTimeStart.Text = Shifts.GetInstance().timeStart.ToString();
            ucShifts1.txtTimeEnd.Text = Shifts.GetInstance().timeEnd.ToString();
        }

        private void UpdateSelectedUser()
        {
            ucUsers1.txtFullName.Text = Users.GetInstance().fullName;
            ucUsers1.txtImgPath.Text = Users.GetInstance().imgPath;
            ucUsers1.txtGrossSalary.Text = Users.GetInstance().grossSalary.ToString();
            ucUsers1.txtNetSalary.Text = Users.GetInstance().netSalary.ToString();
            ucUsers1.txtDob.Text = Users.GetInstance().dob.ToString();
            ucUsers1.txtHomeAddress.Text = Users.GetInstance().homeAddress;
            ucUsers1.txtNote.Text = Users.GetInstance().note;
            ucUsers1.txtPIN.Text = Users.GetInstance().pin;
            ucUsers1.txtDepartmentId.Text = Users.GetInstance().departmentId.ToString();
            ucUsers1.txtRoleId.Text = Users.GetInstance().roleId.ToString();
        }

        private void UpdateSelectedDepartment()
        {
            ucDepartments1.txtDepartmentName.Text = Departments.GetInstance().departmentName;
            ucDepartments1.txtShiftId.Text = Departments.GetInstance().shiftId.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            switch (flag)
            {
                case 1:
                    {
                        // Department
                        _departmentRepository.Delete(selectedId);
                    }
                    break;
                case 2:
                    {
                        // Role
                        _rolesRepository.Delete(selectedId);
                    }
                    break;
                case 3:
                    {
                        // User
                        _usersRepository.Delete(selectedId);
                    }
                    break;
                case 4:
                    {
                        // Shift
                        _shiftsRepository.Delete(selectedId);
                    }
                    break;
                case 5:
                    {
                        // Attendance
                        _attendancesRepository.Delete(selectedId);
                    }
                    break;
                case 6:
                    {
                        // Payslip
                        _payslipsRepository.Delete(selectedId);
                    }
                    break;
                default:
                    break;
            }
            MessageBox.Show("Delete successfully!");
            LoadData();
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {

        }

        private void btnEnable_Click(object sender, EventArgs e)
        {

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain frmMain = new frmMain();
            frmMain.Show();
        }
        private void btnModifySalary_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmModifySalaryRules frmModifySalaryRules = new frmModifySalaryRules();
            frmModifySalaryRules.Show();
        }
    }
}
