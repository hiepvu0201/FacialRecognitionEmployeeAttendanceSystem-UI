using Emgu.CV;
using Emgu.CV.Structure;
using FacialRecognitionEmployeeAttendanceSystem_UI.Models;
using FacialRecognitionEmployeeAttendanceSystem_UI.Models.AWS_S3;
using FacialRecognitionEmployeeAttendanceSystem_UI.Repository;
using FacialRecognitionEmployeeAttendanceSystem_UI.Views.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.ImageHandler
{
    public partial class frmImageHandler : Form
    {
        private bool _liveWebcam;
        private VideoCapture _capture;
        BucketRepository _bucketRepository = new BucketRepository();

        public frmImageHandler()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            pbCaptureImg.Image = pbLiveWebcam.Image;
        }

        private void ImageHandler_Load(object sender, EventArgs e)
        {
            _liveWebcam = false;
            _capture = new VideoCapture();
        }

        private void btnStartWebcam_Click(object sender, EventArgs e)
        {
            if (!_liveWebcam)
            {
                Application.Idle += StartLiveWebcam;
                btnStartWebcam.Text = @"Stop Streaming";
            }
            else
            {
                Application.Idle -= StartLiveWebcam;
                btnStartWebcam.Text = @"Start Streaming";
            }
            _liveWebcam = !_liveWebcam;
        }
        private void StartLiveWebcam(object sender, System.EventArgs e)
        {
            var img = _capture.QueryFrame().ToImage<Bgr, byte>();
            var bmp = img.ToBitmap(pbLiveWebcam.Width, pbLiveWebcam.Height);
            pbLiveWebcam.Image = bmp;
        }

        private void btnReCapture_Click(object sender, EventArgs e)
        {
            pbCaptureImg.Image = null;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                /*MemoryStream stream = new MemoryStream();

                int width = Convert.ToInt32(pbCaptureImg.Width);
                int height = Convert.ToInt32(pbCaptureImg.Height);
                Bitmap bmp = new Bitmap(width, height);
                pbCaptureImg.DrawToBitmap(bmp, new Rectangle(0, 0, Width, Height));

                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] pic = stream.ToArray();

                Buckets buckets = new Buckets();
                buckets.Image = pic;

                _bucketRepository.SaveImage(buckets);
                MessageBox.Show(@"Saved!");*/


                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = @"Save Your Photo";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbCaptureImg.Image.Save(saveFileDialog.FileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    Users.GetInstance().imgPath = saveFileDialog.FileName;
                    MessageBox.Show(@"Saved!");
                    this.Hide();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
