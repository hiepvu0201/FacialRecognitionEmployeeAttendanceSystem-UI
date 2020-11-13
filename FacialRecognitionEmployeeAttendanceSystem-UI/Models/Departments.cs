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
        public long id { get; set; }
        public string departmentName { get; set; }
        public long shiftId { get; set; }
        public Shifts shifts { get; set; }
        public DateTime createdAt { get; set; }
        public bool isDisabled { get; set; }
    }
}
