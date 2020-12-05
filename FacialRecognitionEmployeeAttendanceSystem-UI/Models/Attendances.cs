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
        public DateTime dateCheck { get; set; }
        public bool status { get; set; }
        public string note { get; set; }
        public double workingHours { get; set; }
        public int name { get; set; }

        public static Attendances GetInstance()
        {
            if (_instance == null)
                _instance = new Attendances();
            return _instance;
        }

        public static implicit operator List<object>(Attendances v)
        {
            throw new NotImplementedException();
        }
    }
}
