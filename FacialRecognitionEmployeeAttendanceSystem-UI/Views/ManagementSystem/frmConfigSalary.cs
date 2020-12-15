using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacialRecognitionEmployeeAttendanceSystem_UI.Models;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.ManagementSystem
{
    public partial class frmConfigSalary : Form
    {
        public frmConfigSalary()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ConfigSalary.GetInstance().allowance = Convert.ToDouble(nubAllowance);
            ConfigSalary.GetInstance().bonus = Convert.ToDouble(nubBonus);
            ConfigSalary.GetInstance().overtimeSalary = Convert.ToDouble(nubOVT);
            ConfigSalary.GetInstance().tax = Convert.ToInt32(nubTax);
            ConfigSalary.GetInstance().salaryPerHour = Convert.ToDouble(nubSalaryPerHour);
            ConfigSalary.GetInstance().deduction = Convert.ToDouble(nubDeduction);     
            DateTime dayPalidHoliday =  Convert.ToDateTime(dtpToPalid.Value.Date - dtpFromPalid.Value.Date);
            DateTime dayAnnualLeave = Convert.ToDateTime(dtpToAnnual.Value.Date - dtpFromPalid.Value.Date);

            ConfigSalary.GetInstance().daysAnnualLeave = dayAnnualLeave;
            ConfigSalary.GetInstance().daysPalidHoliday = dayPalidHoliday;
        }

        private void frmConfigSalary_Load(object sender, EventArgs e)
        {

        }
    }
}
