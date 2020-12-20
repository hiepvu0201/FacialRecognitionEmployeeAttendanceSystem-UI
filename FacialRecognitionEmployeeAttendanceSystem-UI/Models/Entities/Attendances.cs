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

        [System.ComponentModel.DisplayName("Id")]
        public long id { get; set; }

        [System.ComponentModel.DisplayName("Checking Date")]
        public string dateCheck { get; set; }

        [System.ComponentModel.DisplayName("Present")]
        public bool status { get; set; } = true;

        [System.ComponentModel.DisplayName("Note")]
        public string note { get; set; } = "";

        [System.ComponentModel.DisplayName("Total Woking Hours")]
        public double workingHours { get; set; }

        [System.ComponentModel.DisplayName("Time Checked In")]
        public DateTime checkinAt { get; set; } = new DateTime(DateTime.Now.Ticks);

        [System.ComponentModel.DisplayName("Time Checked Out")]
        public DateTime checkoutAt { get; set; } = new DateTime(DateTime.Now.Ticks);

        public Users users { get; set; }

        [System.ComponentModel.DisplayName("Belong To User Who Has Id")]
        public long userId { get; set; }

        public Shifts shifts { get; set; }

        [System.ComponentModel.DisplayName("Belong To Shift Who Has Id")]
        public long shiftId { get; set; }

        public static Attendances GetInstance()
        {
            if (_instance == null)
                _instance = new Attendances();
            return _instance;
        }
    }
}
