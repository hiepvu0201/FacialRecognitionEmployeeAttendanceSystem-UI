using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Models
{
    class Users
    {
        [System.ComponentModel.DisplayName("Id")]
        public long id { get; set; }

        [System.ComponentModel.DisplayName("Full Name")]
        public string fullName { get; set; } = "";

        [System.ComponentModel.DisplayName("PIN")]
        public string pin { get; set; }

        [System.ComponentModel.DisplayName("Date Of Birth")]
        public DateTime dob { get; set; }

        [System.ComponentModel.DisplayName("Home Address")]
        public string homeAddress { get; set; }

        [System.ComponentModel.DisplayName("Gross Salary")]
        public double grossSalary { get; set; }

        [System.ComponentModel.DisplayName("Net Salary")]
        public double netSalary { get; set; }

        [System.ComponentModel.DisplayName("Note")]
        public string note { get; set; }

        [System.ComponentModel.DisplayName("Created At")]
        public DateTime createdAt { get; set; }

        [System.ComponentModel.DisplayName("Is Disabled")]
        public bool isDisabled { get; set; }

        [System.ComponentModel.DisplayName("Department Id")]
        public long departmentId { get; set; }
        public Departments departments { get; set; }

        [System.ComponentModel.DisplayName("Role Id")]
        public long roleId { get; set; }
        public Roles roles { get; set; }

        public Shifts shifts { get; set; }

        [System.ComponentModel.DisplayName("Shift Id")]
        public long shiftId { get; set; }

        private static Users _instance;
        public static Users GetInstance()
        {
            if (_instance==null)
            {
                _instance = new Users();
            }
            return _instance;
        }
    }
}
