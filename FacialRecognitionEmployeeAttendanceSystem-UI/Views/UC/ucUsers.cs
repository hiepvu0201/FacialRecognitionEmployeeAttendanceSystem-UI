using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacialRecognitionEmployeeAttendanceSystem_UI.Views.ImageHandler;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.UC
{
    public partial class ucUsers : UserControl
    {
        public ucUsers()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            this.Hide();
            ImageHandler.frmImageHandler frmImageHandler = new frmImageHandler();
            frmImageHandler.Show();
        }
    }
}
