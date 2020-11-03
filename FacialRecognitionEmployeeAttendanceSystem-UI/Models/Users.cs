using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Models
{
    class Users
    {
        public long id { get; set; }
        public string fullName { get; set; }
        public string imgPath { get; set; }
        public string pin { get; set; }
        public DateTime dob { get; set; }
        public string homeAddress { get; set; }
        public double grossSalary { get; set; }
        public double netSalary { get; set; }
        public string note { get; set; }
        public DateTime createdAt { get; set; }
        public bool isDisabled { get; set; }
        public long departmentId { get; set; }
        public Departments departments { get; set; }
        public long roleId { get; set; }
        public Roles roles { get; set; }
    }
}
