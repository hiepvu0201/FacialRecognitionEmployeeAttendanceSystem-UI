using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Models
{
    class Shifts
    {
        public long id { get; set; }
        public string shiftName { get; set; }
        public DateTime timeStart { get; set; }
        public DateTime timeEnd { get; set; }
        public DateTime createdAt { get; set; }
    }
}
