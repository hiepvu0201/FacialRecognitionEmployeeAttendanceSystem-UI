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
        public long id { get; set; }
        public string roleName { get; set; }
        public string note { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public bool isDisabled { get; set; }
    }
}
