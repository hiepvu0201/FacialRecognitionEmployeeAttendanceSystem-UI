using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.ViewModel
{
    class UserViewModel
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

        public long departmentId { get; set; }

        [System.ComponentModel.DisplayName("Department Name")]
        public string departmentName { get; set; }

        public long roleId { get; set; }

        [System.ComponentModel.DisplayName("Role Name")]
        public string roleName { get; set; }

        [System.ComponentModel.DisplayName("Shift Name")]
        public string shiftName { get; set; }

        public long shiftId { get; set; }
    }
}
