using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Models
{
    class Payslips
    {
        public long id { get; set; }
        public DateTime payDate { get; set; }
        public double workingSalary { get; set; }
        public double publicSalary { get; set; }
        public double otherSalary { get; set; }
        public double annualLeaveSalary { get; set; }
        public double overtimeSalary { get; set; }
        public double allowance { get; set; }
        public double bonus { get; set; }
        public double tax { get; set; }
        public long userId { get; set; }
        public double deductionSalary { get; set; }
        public DateTime createdAt { get; set; }
        public bool isDisabled { get; set; }
    }
}
