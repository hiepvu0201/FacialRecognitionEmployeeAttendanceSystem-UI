using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacialRecognitionEmployeeAttendanceSystem_UI.Models;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.UC
{
    public partial class ucView : UserControl
    {
        int numrow;
        public ucView()
        {
            InitializeComponent();
        }

        private void dgvManagement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                numrow = e.RowIndex;
                DataGridViewRow data = dgvManagement.Rows[numrow];
                frmManagementSystem.selectedId = Convert.ToInt32(data.Cells[0].Value);

                switch (frmManagementSystem.flag)
                {
                    case 1:
                        {
                            // Department
                            Departments.GetInstance().departmentName = data.Cells[1].Value.ToString();
                            Departments.GetInstance().shiftId = Convert.ToInt32(data.Cells[2].Value.ToString());
                        }
                        break;
                    case 2:
                        {
                            // Role
                            Roles.GetInstance().roleName = data.Cells[1].Value.ToString();
                            Roles.GetInstance().note = data.Cells[2].Value.ToString();
                            Roles.GetInstance().description = data.Cells[3].Value.ToString();
                            Roles.GetInstance().salaryRate = Convert.ToDouble(data.Cells[4].Value);
                        }
                        break;
                    case 3:
                        {
                            // User
                            Users.GetInstance().fullName = data.Cells[1].Value.ToString();
                            Users.GetInstance().imgPath = data.Cells[2].Value.ToString();
                            Users.GetInstance().pin = data.Cells[3].ToString();
                            Users.GetInstance().dob = Convert.ToDateTime(data.Cells[4].Value);
                            Users.GetInstance().homeAddress = data.Cells[5].Value.ToString();
                            Users.GetInstance().grossSalary = Convert.ToDouble(data.Cells[6].Value);
                            Users.GetInstance().netSalary = Convert.ToDouble(data.Cells[7].Value);
                            Users.GetInstance().note = data.Cells[8].Value.ToString();
                            Users.GetInstance().departmentId = Convert.ToInt32(data.Cells[10].Value);
                            Users.GetInstance().roleId = Convert.ToInt32(data.Cells[13].Value);
                        }
                        break;
                    case 4:
                        {
                            // Shift
                            Shifts.GetInstance().shiftName = data.Cells[1].Value.ToString();
                            Shifts.GetInstance().timeStart = Convert.ToDateTime(data.Cells[2].Value);
                            Shifts.GetInstance().timeEnd = Convert.ToDateTime(data.Cells[3].Value);
                        }
                        break;
                    case 5:
                        {
                            // Attendance
                            Attendances.GetInstance().dateCheck = data.Cells[1].Value.ToString();
                            Attendances.GetInstance().status = Convert.ToBoolean(data.Cells[2].Value);
                            Attendances.GetInstance().note = data.Cells[3].Value.ToString();
                            Attendances.GetInstance().workingHours = Convert.ToInt32(data.Cells[4].Value);
                            Attendances.GetInstance().checkinAt = Convert.ToDateTime(data.Cells[5].Value);
                            Attendances.GetInstance().checkoutAt = Convert.ToDateTime(data.Cells[6].Value);
                            Attendances.GetInstance().userId = Convert.ToInt32(data.Cells[7].Value);
                            Attendances.GetInstance().shiftId = Convert.ToInt32(data.Cells[8].Value);
                        }
                        break;
                    case 6:
                        {
                            // Payslip
                            Payslips.GetInstance().payDate = Convert.ToDateTime(data.Cells[1].Value);
                            Payslips.GetInstance().workingSalary = Convert.ToDouble(data.Cells[2].Value);
                            Payslips.GetInstance().publicSalary = Convert.ToDouble(data.Cells[3].Value);
                            Payslips.GetInstance().otherSalary = Convert.ToDouble(data.Cells[4].Value);
                            Payslips.GetInstance().annualLeaveSalary = Convert.ToDouble(data.Cells[5].Value);
                            Payslips.GetInstance().overtimeSalary = Convert.ToDouble(data.Cells[6].Value);
                            Payslips.GetInstance().allowance = Convert.ToDouble(data.Cells[7].Value);
                            Payslips.GetInstance().bonus = Convert.ToDouble(data.Cells[8].Value);
                            Payslips.GetInstance().tax = Convert.ToDouble(data.Cells[9].Value);
                            Payslips.GetInstance().userId = Convert.ToInt64(data.Cells[10].Value);
                            Payslips.GetInstance().deductionSalary = Convert.ToDouble(data.Cells[11].Value);

                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }
            
        }
    }
}
