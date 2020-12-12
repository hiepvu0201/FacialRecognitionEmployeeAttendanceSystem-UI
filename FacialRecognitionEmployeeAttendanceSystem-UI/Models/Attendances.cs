using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Models
{
    class Attendances
    {
        private static Attendances _instance;

        public long id { get; set; }
        public string dateCheck { get; set; }
        public bool status { get; set; } = true;
        public string note { get; set; }
        public double workingHours { get; set; }
        public DateTime checkinAt { get; set; } = new DateTime(DateTime.Now.Ticks);
        public DateTime checkoutAt { get; set; } = new DateTime(DateTime.Now.Ticks);
        public Users users { get; set; }

        public long userId { get; set; }

        public static Attendances GetInstance()
        {
            if (_instance == null)
                _instance = new Attendances();
            return _instance;
        }
    }
}
