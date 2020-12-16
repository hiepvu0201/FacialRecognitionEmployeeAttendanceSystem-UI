using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAttendanceSystem_Click(object sender, EventArgs e)
        {
            frmAttendanceSystem frmAttendanceSystem = new frmAttendanceSystem();
            frmAttendanceSystem.Show();
            this.Hide();
        }

        private void btnManagementSystem_Click(object sender, EventArgs e)
        {
            frmManagementSystem frmManagementSystem = new frmManagementSystem();
            frmManagementSystem.Show();
            this.Hide();
        }
    }
}
