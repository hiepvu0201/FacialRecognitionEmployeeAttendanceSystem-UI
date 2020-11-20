using Emgu.CV;
using Emgu.CV.Structure;
using FacialRecognitionEmployeeAttendanceSystem_UI.Models;
using FacialRecognitionEmployeeAttendanceSystem_UI.Repository;
using FacialRecognitionEmployeeAttendanceSystem_UI.Views.AttendanceSystem;
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
    public partial class frmAttendanceSystem : Form
    {
        UsersRepository _usersRepository = new UsersRepository();
        bool isFaceRecognition = true;
        private Capture _capture;

        public frmAttendanceSystem()
        {
            InitializeComponent();
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (isFaceRecognition == false && txtPin.Text != null && txtPin.Text != "")
            {
                Users user = await _usersRepository.GetByPinAsync(txtPin.Text);
                MessageBox.Show($"Welcome {user.fullName}! Have a good day!");
            }
            else MessageBox.Show("Please choose PIN Mode!!!");
            isFaceRecognition = true;
        }

        private void btnPinMode_Click(object sender, EventArgs e)
        {
            isFaceRecognition = false;
            Application.Idle -= StartLiveWebcam;
            pbCamera.Image = null;
            MessageBox.Show("Now you're in PIN mode!");
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmMain = new frmMain();
            frmMain.Show();
        }

        private void btnFacialRecognitionMode_Click(object sender, EventArgs e)
        {
            isFaceRecognition = true;
            Application.Idle += StartLiveWebcam;
        }
        private void StartLiveWebcam(object sender, System.EventArgs e)
        {
            var img = _capture.QueryFrame().ToImage<Bgr, byte>();
            var bmp = img.Bitmap;
            pbCamera.Image = bmp;
        }

        private void frmAttendanceSystem_Load(object sender, EventArgs e)
        {
            _capture = new Capture();
            Application.Idle += StartLiveWebcam;
        }

        private void btnCheckAttendanceHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCheckAttendanceHistory frmCheckAttendanceHistory = new frmCheckAttendanceHistory();
            frmCheckAttendanceHistory.Show();
        }
    }
}
