using FacialRecognitionEmployeeAttendanceSystem_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.ViewModel
{
    class DepartmentViewModel
    {
        public long id { get; set; }

        [System.ComponentModel.DisplayName("Department Name")]
        public string departmentName { get; set; }

        [System.ComponentModel.DisplayName("Shift Id")]
        public long shiftId { get; set; }
        public Shifts shifts { get; set; }

        [System.ComponentModel.DisplayName("Shift Name")]
        public string shiftName { get; set; }

        [System.ComponentModel.DisplayName("Created At")]
        public DateTime createdAt { get; set; }

        [System.ComponentModel.DisplayName("Is Disabled")]
        public bool isDisabled { get; set; }
    }
}
