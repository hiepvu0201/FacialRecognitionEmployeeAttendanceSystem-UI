using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Models
{
    class Attendances
    {
        public long id { get; set; }
        public DateTime dateCheck { get; set; }
        public bool status { get; set; }
    }
}
