using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.ViewModel
{
    class AttendancesViewModel
    {
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

        public long userId { get; set; }

        [System.ComponentModel.DisplayName("User Name")]
        public string userName { get; set; }
    }
}
