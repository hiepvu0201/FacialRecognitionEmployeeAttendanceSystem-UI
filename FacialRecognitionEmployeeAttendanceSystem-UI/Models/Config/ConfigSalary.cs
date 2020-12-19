using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Models
{
    class ConfigSalary
    {
        public double salaryPerHour { get; set; } = 0;
        public double bonusPerDay { get; set; } = 0;
        public double overTimeSalaryRate { get; set; } = 1;
        public double allowance { get; set; } = 0;
        public double taxRate { get; set; } = 1;
    }
}
