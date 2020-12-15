using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Models
{
    class ConfigSalary
    {
        private static ConfigSalary _instance;
        public static ConfigSalary GetInstance()
        {
            if (_instance==null)
            {
                _instance = new ConfigSalary();
            }
            return _instance;
        }
        public double salaryPerHour { get; set; }
        public double allowance { get; set; }
        public double overtimeSalary { get; set; }
        public double bonus { get; set; }
        public double palidHoliday { get; set; }
        public double annualLeave { get; set; }
        public int tax { get; set; }
        public double deduction { get; set; }

        public DateTime daysPalidHoliday { get; set; }

        public DateTime daysAnnualLeave { get; set; }
    }
}
