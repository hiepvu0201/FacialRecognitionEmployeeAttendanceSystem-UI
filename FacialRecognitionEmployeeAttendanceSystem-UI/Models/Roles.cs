using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Models
{
    class Roles
    {
        public long id { get; set; }
        public string roleName { get; set; }
        public string note { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public bool isDisabled { get; set; }
    }
}
