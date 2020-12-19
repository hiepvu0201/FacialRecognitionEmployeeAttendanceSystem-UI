using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacialRecognitionEmployeeAttendanceSystem_UI.Views.AttendanceSystem;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.UC
{
    public partial class ucUsers : UserControl
    {
        public ucUsers()
        {
            InitializeComponent();
        }

        private void btnTrainingForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTraining frmTraining = new frmTraining(txtFullName.Text);
            frmTraining.Show();
        }
    }
}
