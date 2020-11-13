using FacialRecognitionEmployeeAttendanceSystem_UI.Models;
using FacialRecognitionEmployeeAttendanceSystem_UI.Repository;
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
            MessageBox.Show("Now you're in PIN mode!");
        }
    }
}
