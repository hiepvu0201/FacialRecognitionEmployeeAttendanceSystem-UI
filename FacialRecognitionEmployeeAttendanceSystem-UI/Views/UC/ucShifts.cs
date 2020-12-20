using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.UC
{
    public partial class ucShifts : UserControl
    {
        public ucShifts()
        {
            InitializeComponent();
        }

        private void txtTimeStart_Click(object sender, EventArgs e)
        {
            txtTimeStart.Text = "";
        }

        private void txtTimeEnd_Click(object sender, EventArgs e)
        {
            txtTimeEnd.Text = "";
        }
    }
}
