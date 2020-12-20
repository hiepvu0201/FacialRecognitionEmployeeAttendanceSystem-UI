using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Models
{
    class Roles
    {
        private static Roles _instance;
        public static Roles GetInstance()
        {
            if (_instance == null)
                _instance = new Roles();
            return _instance;
        }

        [System.ComponentModel.DisplayName("Id")]
        public long id { get; set; }

        [System.ComponentModel.DisplayName("Role Name")]
        public string roleName { get; set; }

        [System.ComponentModel.DisplayName("Note")]
        public string note { get; set; }

        [System.ComponentModel.DisplayName("Description")]
        public string description { get; set; }

        [System.ComponentModel.DisplayName("Salary Rate")]
        public double salaryRate { get; set; }

        [System.ComponentModel.DisplayName("Created At")]
        public DateTime createdAt { get; set; }

        [System.ComponentModel.DisplayName("Is Disabled")]
        public bool isDisabled { get; set; }
    }
}
