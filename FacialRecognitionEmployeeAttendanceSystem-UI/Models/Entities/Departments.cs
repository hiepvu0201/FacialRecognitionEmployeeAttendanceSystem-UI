using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Models
{
    class Departments
    {
        private static Departments _instance;
        public static Departments GetInstance()
        {
            if (_instance == null)
                _instance = new Departments();
            return _instance;
        }

        [System.ComponentModel.DisplayName("Id")]
        public long id { get; set; }

        [System.ComponentModel.DisplayName("Department Name")]
        public string departmentName { get; set; }

        [System.ComponentModel.DisplayName("Shift Id")]
        public long shiftId { get; set; }
        public Shifts shifts { get; set; }

        [System.ComponentModel.DisplayName("Created At")]
        public DateTime createdAt { get; set; }

        [System.ComponentModel.DisplayName("Is Disabled")]
        public bool isDisabled { get; set; }
    }
}
