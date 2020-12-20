using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Models
{
    class Shifts
    {
        [System.ComponentModel.DisplayName("Id")]
        public long id { get; set; }

        [System.ComponentModel.DisplayName("Shift Name")]
        public string shiftName { get; set; }

        [System.ComponentModel.DisplayName("Start At")]
        public string timeStart { get; set; }

        [System.ComponentModel.DisplayName("End At")]
        public string timeEnd { get; set; }

        [System.ComponentModel.DisplayName("Created At")]
        public DateTime createdAt { get; set; }

        private static Shifts _instance;
        public static Shifts GetInstance()
        {
            if (_instance == null)
                _instance = new Shifts();
            return _instance;
        }
    }
}
