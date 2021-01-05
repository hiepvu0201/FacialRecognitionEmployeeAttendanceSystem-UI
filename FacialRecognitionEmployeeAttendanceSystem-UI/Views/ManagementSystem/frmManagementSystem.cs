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
            btnEnable.Enabled = true;
            btnDisable.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnDel.Enabled = true;
        }

        private async void LoadData()
        {
            try
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
                        if (listDepartments == null)
                        {
                            return;
                        }
                        ucView1.dgvManagement.DataSource = listDepartments;
                        ucView1.dgvManagement.Columns["shifts"].Visible=false;
                        ucView1.dgvManagement.AutoResizeColumns();
                        ucView1.dgvManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        break;
                    case 2:
                        if (listRoles == null)
                        {
                            return;
                        }
                        ucView1.dgvManagement.DataSource = listRoles;
                        ucView1.dgvManagement.AutoResizeColumns();
                        ucView1.dgvManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        break;
                    case 3:
                        if (listUsers == null)
                        {
                            return;
                        }
                        ucView1.dgvManagement.DataSource = listUsers;
                        ucView1.dgvManagement.Columns["roles"].Visible = false;
                        ucView1.dgvManagement.Columns["departments"].Visible = false;
                        ucView1.dgvManagement.Columns["shifts"].Visible = false;
                        ucView1.dgvManagement.AutoResizeColumns();
                        ucView1.dgvManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        break;
                    case 4:
                        if (listShifts == null)
                        {
                            return;
                        }
                        ucView1.dgvManagement.DataSource = listShifts;
                        ucView1.dgvManagement.AutoResizeColumns();
                        ucView1.dgvManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        break;
                    case 5:
                        if (listAttendances == null)
                        {
                            return;
                        }
                        ucView1.dgvManagement.DataSource = listAttendances;
                        ucView1.dgvManagement.AutoResizeColumns();
                        ucView1.dgvManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        ucView1.dgvManagement.Columns["users"].Visible = false;

                        break;
                    case 6:
                        if (listPayslips == null)
                        {
                            return;
                        }
                        ucView1.dgvManagement.DataSource = listPayslips;
                        ucView1.dgvManagement.AutoResizeColumns();
                        ucView1.dgvManagement.Columns["users"].Visible = false;
                        ucView1.dgvManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
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
            LoadData();
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
                payslip.userId = Convert.ToInt64(ucPayslips1.cbbUser.Text.Substring(0, ucPayslips1.cbbUser.Text.IndexOf(".")));

                if (isAdd == true)
                {
                    _payslipsRepository.Add(payslip);
                    MessageBox.Show("Successful added!");
                    isAdd = false;
                    LoadData();
                    Init();
                }
                else if (isUpdate == true)
                {
                    _payslipsRepository.Update(selectedId, payslip);
                    MessageBox.Show("Successful updated!");
                    isUpdate = false;
                    LoadData();
                    Init();
                }
            }
            catch (Exception)
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
                attendance.checkinAt = DateTime.Parse(ucAttendances1.txtCheckInAt.Text);
                attendance.checkoutAt = DateTime.Parse(ucAttendances1.txtCheckOutAt.Text);
                attendance.userId = Convert.ToInt64(ucAttendances1.cbbUser.Text.Substring(0, ucAttendances1.cbbUser.Text.IndexOf(".")));
                

                if (isAdd == true)
                {
                    _attendancesRepository.Add(attendance);
                    MessageBox.Show("Successful added!");
                    isAdd = false;
                    LoadData();
                    Init();
                }
                else if (isUpdate == true)
                {
                    _attendancesRepository.Update(selectedId, attendance);
                    MessageBox.Show("Successful updated!");
                    isUpdate = false;
                    LoadData();
                    Init();
                }
            }
            catch (Exception)
            {

            }
        }

        private void SaveShiftInfo()
        {
            try
            {
                Shifts shift = new Shifts();
                shift.shiftName = ucShifts1.txtShiftName.Text;
                shift.timeStart = ucShifts1.txtTimeStart.Text;
                shift.timeEnd = ucShifts1.txtTimeEnd.Text;

                if (isAdd == true)
                {
                    _shiftsRepository.Add(shift);
                    MessageBox.Show("Successful added!");
                    isAdd = false;
                    LoadData();
                    Init();
                }
                else if (isUpdate == true)
                {
                    _shiftsRepository.Update(selectedId, shift);
                    MessageBox.Show("Successful updated!");
                    isUpdate = false;
                    LoadData();
                    Init();
                }
            }
            catch (Exception)
            {

            }
        }

        private void SaveUserInfo()
        {
            try
            {
                Users user = new Users();
                user.fullName = ucUsers1.txtFullName.Text;
                user.pin = ucUsers1.txtPIN.Text;
                user.dob = DateTime.Parse(ucUsers1.txtDob.Text);
                user.homeAddress = ucUsers1.txtHomeAddress.Text;
                user.grossSalary = Double.Parse(ucUsers1.txtGrossSalary.Text);
                user.netSalary = Double.Parse(ucUsers1.txtNetSalary.Text);
                user.note = ucUsers1.txtNote.Text;
                user.departmentId = Convert.ToInt64(ucUsers1.cbbDepartment.Text.Substring(0, ucUsers1.cbbDepartment.Text.IndexOf(".")));
                user.roleId = Convert.ToInt64(ucUsers1.cbbRole.Text.Substring(0, ucUsers1.cbbRole.Text.IndexOf(".")));
                user.shiftId = Convert.ToInt64(ucUsers1.cbbShift.Text.Substring(0, ucUsers1.cbbShift.Text.IndexOf(".")));

                if (isAdd == true)
                {
                    _usersRepository.Add(user);
                    MessageBox.Show("Successful added!");
                    isAdd = false;
                    LoadData();
                    Init();
                }
                else if (isUpdate == true)
                {
                    _usersRepository.Update(selectedId, user);
                    MessageBox.Show("Successful updated!");
                    isUpdate = false;
                    LoadData();
                    Init();
                }
            }
            catch (Exception)
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
                role.fixedSalary = Convert.ToDouble(ucRoles1.txtSalaryRate.Text);

                if (isAdd == true)
                {
                    _rolesRepository.Add(role);
                    MessageBox.Show("Successful added!");
                    isAdd = false;
                    LoadData();
                    Init();
                }
                else if (isUpdate == true)
                {
                    _rolesRepository.Update(selectedId, role);
                    MessageBox.Show("Successful updated!");
                    isUpdate = false;
                    LoadData();
                    Init();
                }
            }
            catch (Exception)
            {

            }
        }

        private void SaveDepartment()
        {
            try
            {
                Departments department = new Departments();
                department.departmentName = ucDepartments1.txtDepartmentName.Text;
                department.shiftId = Convert.ToInt64(ucDepartments1.cbbShift.Text.Substring(0, ucDepartments1.cbbShift.Text.IndexOf(".")));

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
            catch (Exception)
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
            btnSave.Enabled = true;
            switch (flag)
            {
                case 1:
                    {
                        // Department
                        UpdateSelectedDepartmentAsync();
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
                        UpdateSelectedUserAsync();
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
                        UpdateSelectedAttendanceAsync();
                    }
                    break;
                case 6:
                    {
                        // Payslip
                        UpdateSelectedPayslipAsync();
                    }
                    break;
                default:
                    break;
            }
            isUpdate = true;
        }

        private async Task UpdateSelectedPayslipAsync()
        {
            ucPayslips1.txtPayDate.Text = Convert.ToString(Payslips.GetInstance().payDate);
            ucPayslips1.txtPublicSalary.Text = Convert.ToString(Payslips.GetInstance().publicSalary);
            ucPayslips1.txtWorkingSalary.Text = Convert.ToString(Payslips.GetInstance().workingSalary);
            ucPayslips1.txtOvertimeSalary.Text = Convert.ToString(Payslips.GetInstance().overtimeSalary);
            ucPayslips1.txtOtherSalary.Text = Convert.ToString(Payslips.GetInstance().otherSalary);
            ucPayslips1.txtBonus.Text = Convert.ToString(Payslips.GetInstance().bonus);
            ucPayslips1.txtDeductionSalary.Text = Convert.ToString(Payslips.GetInstance().deductionSalary);
            ucPayslips1.txtAllowance.Text = Convert.ToString(Payslips.GetInstance().allowance);
            ucPayslips1.txtAnualLeaveSalary.Text = Convert.ToString(Payslips.GetInstance().annualLeaveSalary);
            ucPayslips1.txtTax.Text = Convert.ToString(Payslips.GetInstance().tax);

            Users tempUser = new Users();
            tempUser = await _usersRepository.GetByIdAsync(Payslips.GetInstance().userId);
            ucPayslips1.cbbUser.Items.Add(tempUser.id + "." + tempUser.fullName);
        }

        private void UpdateSelectedRole()
        {
            ucRoles1.txtRoleName.Text = Roles.GetInstance().roleName;
            ucRoles1.txtNote.Text = Roles.GetInstance().note;
            ucRoles1.txtDescription.Text = Roles.GetInstance().description;
            ucRoles1.txtSalaryRate.Text = Convert.ToString(Roles.GetInstance().fixedSalary);
        }

        private async Task UpdateSelectedAttendanceAsync()
        {
            ucAttendances1.txtDateCheck.Text = Convert.ToString(Attendances.GetInstance().dateCheck);
            ucAttendances1.txtNote.Text = Convert.ToString(Attendances.GetInstance().note);
            ucAttendances1.txtStatus.Text = Convert.ToString(Attendances.GetInstance().status);
            ucAttendances1.txtWorkingHours.Text = Convert.ToString(Attendances.GetInstance().workingHours);
            ucAttendances1.txtCheckInAt.Text = Convert.ToString(Attendances.GetInstance().checkinAt);
            ucAttendances1.txtCheckOutAt.Text = Convert.ToString(Attendances.GetInstance().dateCheck);

            Users tempUser = new Users();
            tempUser = await _usersRepository.GetByIdAsync(Attendances.GetInstance().userId);
            ucAttendances1.cbbUser.Items.Add(tempUser.id+"."+ tempUser.fullName);
        }

        private void UpdateSelectedShift()
        {
            ucShifts1.txtShiftName.Text = Shifts.GetInstance().shiftName;
            ucShifts1.txtTimeStart.Text = Shifts.GetInstance().timeStart.ToString();
            ucShifts1.txtTimeEnd.Text = Shifts.GetInstance().timeEnd.ToString();
        }

        private async Task UpdateSelectedUserAsync()
        {
            ucUsers1.txtFullName.Text = Users.GetInstance().fullName;
            ucUsers1.txtGrossSalary.Text = Users.GetInstance().grossSalary.ToString();
            ucUsers1.txtNetSalary.Text = Users.GetInstance().netSalary.ToString();
            ucUsers1.txtDob.Text = Users.GetInstance().dob.ToString();
            ucUsers1.txtHomeAddress.Text = Users.GetInstance().homeAddress;
            ucUsers1.txtNote.Text = Users.GetInstance().note;
            ucUsers1.txtPIN.Text = Users.GetInstance().pin;

            Departments tempDepartment = new Departments();
            tempDepartment = await _departmentRepository.GetByIdAsync(Users.GetInstance().departmentId);
            ucUsers1.cbbDepartment.Items.Add(tempDepartment.id + "." + tempDepartment.departmentName);

            Roles tempRole = new Roles();
            tempRole = await _rolesRepository.GetByIdAsync(Users.GetInstance().roleId);
            ucUsers1.cbbRole.Items.Add(tempRole.id + "." + tempRole.roleName);

            Shifts tempShift = new Shifts();
            tempShift = await _shiftsRepository.GetByIdAsync(Users.GetInstance().shiftId);
            ucUsers1.cbbShift.Items.Add(tempShift.id + "." + tempShift.shiftName);
        }

        private async Task UpdateSelectedDepartmentAsync()
        {
            ucDepartments1.txtDepartmentName.Text = Departments.GetInstance().departmentName;

            Shifts tempShift = new Shifts();
            tempShift = await _shiftsRepository.GetByIdAsync(Departments.GetInstance().shiftId);
            ucDepartments1.cbbShift.Items.Add(tempShift.id + "." + tempShift.shiftName);
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
            if (flag == 0)
            {
                MessageBox.Show("Please choose!");
                return;
            }
            Object dummyObject = new object();
            switch (flag)
            {
                case 1:
                    {
                        // Department
                        _departmentRepository.Disable(selectedId, dummyObject);
                    }
                    break;
                case 2:
                    {
                        // Role
                        _rolesRepository.Disable(selectedId, dummyObject);
                    }
                    break;
                case 3:
                    {
                        // User
                        _usersRepository.Disable(selectedId, dummyObject);
                    }
                    break;
                case 4:
                    {
                        // Shift
                        _shiftsRepository.Disable(selectedId, dummyObject);
                    }
                    break;
                case 5:
                    {
                        // Attendance
                        _attendancesRepository.Disable(selectedId, dummyObject);
                    }
                    break;
                case 6:
                    {
                        // Payslip
                        _payslipsRepository.Disable(selectedId, dummyObject);
                    }
                    break;
                default:
                    break;
            }
            MessageBox.Show("Disable successfully!");
            LoadData();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (flag==0)
            {
                MessageBox.Show("Please choose!");
                return;
            }
            Object dummyObject = new object();
            switch (flag)
            {
                case 1:
                    {
                        // Department
                        _departmentRepository.Enable(selectedId, dummyObject);
                    }
                    break;
                case 2:
                    {
                        // Role
                        _rolesRepository.Enable(selectedId, dummyObject);
                    }
                    break;
                case 3:
                    {
                        // User
                        _usersRepository.Enable(selectedId, dummyObject);
                    }
                    break;
                case 4:
                    {
                        // Shift
                        _shiftsRepository.Enable(selectedId, dummyObject);
                    }
                    break;
                case 5:
                    {
                        // Attendance
                        _attendancesRepository.Enable(selectedId, dummyObject);
                    }
                    break;
                case 6:
                    {
                        // Payslip
                        _payslipsRepository.Enable(selectedId, dummyObject);
                    }
                    break;
                default:
                    break;
            }
            MessageBox.Show("Enable successfully!");
            LoadData();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain frmMain = new frmMain();
            frmMain.Show();
        }
        private void btnModifySalary_Click(object sender, EventArgs e)
        {
            frmModifySalaryRules frmModifySalaryRules = new frmModifySalaryRules();
            frmModifySalaryRules.Show();
        }

        private void btnCheckSalary_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAttendanceAndSalary frmCheckAttendanceHistory = new frmAttendanceAndSalary();
            frmCheckAttendanceHistory.Show();
        }

        private void btnTableOfAttendance_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMonthlyAttendanceAndSalary frmTableOfAttendance = new frmMonthlyAttendanceAndSalary();
            frmTableOfAttendance.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;

            ucView1.dgvManagement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in ucView1.dgvManagement.Rows)
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
    }
}
