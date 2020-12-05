using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using FacialRecognitionEmployeeAttendanceSystem_UI.Models;
using FacialRecognitionEmployeeAttendanceSystem_UI.Repository;
using FacialRecognitionEmployeeAttendanceSystem_UI.Views.AttendanceSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views
{
    public partial class frmAttendanceSystem : Form, INotifyPropertyChanged
    {
        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;
        private VideoCapture videoCapture;
        private CascadeClassifier cascadeClassifier;
        private Image<Bgr, Byte> bgrFrame = null;
        private Image<Gray, Byte> detectedFace = null;
        private List<FaceData> faceList = new List<FaceData>();
        private VectorOfMat imageList = new VectorOfMat();
        private List<string> nameList = new List<string>();
        private VectorOfInt labelList = new VectorOfInt();
        private EigenFaceRecognizer recognizer;
        private System.Timers.Timer captureTimer;

        UsersRepository _usersRepository = new UsersRepository();
        bool isFaceRecognition = true;
        #endregion

        #region CameraCaptureImage
        private Bitmap cameraCapture;
        public Bitmap CameraCapture
        {
            get { return cameraCapture; }
            set
            {
                cameraCapture = value;
                pbCamera.Invoke(new Action(() => { pbCamera.Image = BitmapToImageSource(cameraCapture); }));
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region CameraCaptureFaceImage
        private Bitmap cameraCaptureFace;
        public Bitmap CameraCaptureFace
        {
            get { return cameraCaptureFace; }
            set
            {
                cameraCaptureFace = value;
                pbFaceCapture.Invoke(new Action(() => { pbFaceCapture.Image = BitmapToImageSource(cameraCaptureFace); }));
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region FaceName
        private string faceName;
        public string FaceName
        {
            get { return faceName; }
            set
            {
                faceName = value.ToUpper();
                lblFaceName.Invoke(new Action(() => { lblFaceName.Text = faceName; }));
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public frmAttendanceSystem()
        {
            InitializeComponent();
            captureTimer = new System.Timers.Timer()
            {
                Interval = Config.TimerResponseValue
            };
            captureTimer.Elapsed += CaptureTimer_Elapsed;
        }
        #endregion

        #region Event
        private void frmAttendanceSystem_Load(object sender, EventArgs e)
        {
            StartFaceRecognition();
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CaptureTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ProcessFrame();
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
            StartFaceRecognition();
        }

        private void btnCheckAttendanceHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCheckAttendanceHistory frmCheckAttendanceHistory = new frmCheckAttendanceHistory();
            frmCheckAttendanceHistory.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (detectedFace == null)
            {
                MessageBox.Show("No face detected.");
                return;
            }
            //Save detected face
            detectedFace = detectedFace.Resize(100, 100, Inter.Cubic);
            detectedFace.Save(Config.FacePhotosPath + "face" + (faceList.Count + 1) + Config.ImageFileExtension);
            StreamWriter writer = new StreamWriter(Config.FaceListTextFile, true);
            string personName = txtName.Text;
            writer.WriteLine(String.Format("face{0}:{1}", (faceList.Count + 1), personName));
            writer.Close();
            GetFacesList();
            MessageBox.Show("Successful.");
        }
        #endregion

        #region Method
        private void StartFaceRecognition()
        {
            GetFacesList();
            videoCapture = new VideoCapture(Config.ActiveCameraIndex);
            videoCapture.SetCaptureProperty(CapProp.Fps, 30);
            videoCapture.SetCaptureProperty(CapProp.FrameHeight, 422);
            videoCapture.SetCaptureProperty(CapProp.FrameWidth, 628);
            captureTimer.Start();
        }

        private void ProcessFrame()
        {
            bgrFrame = videoCapture.QueryFrame().ToImage<Bgr, Byte>();
            
            if (bgrFrame != null)
            {
                try
                {//for emgu cv bug
                    Image<Gray, byte> grayframe = bgrFrame.Convert<Gray, byte>();

                    Rectangle[] faces = cascadeClassifier.DetectMultiScale(grayframe, 1.2, 10, new System.Drawing.Size(50, 50), new System.Drawing.Size(200, 200));

                    //detect face
                    FaceName = "No face detected";
                    foreach (Rectangle face in faces)
                    {
                        bgrFrame.Draw(face, new Bgr(255, 255, 0), 2);

                        detectedFace = bgrFrame.Copy(face).Convert<Gray, Byte>();

                        FaceRecognition();
                        break;
                    }
                    CameraCapture = bgrFrame.ToBitmap(pbCamera.Width, pbCamera.Height);
                }
                catch (Exception ex)
                {
                    //todo log
                }

            }
        }

        private void FaceRecognition()
        {
            if (imageList.Size != 0)
            {
                //Eigen Face Algorithm
                FaceRecognizer.PredictionResult result = recognizer.Predict(detectedFace.Resize(100, 100, Inter.Cubic));

                if (result.Label==0)
                {
                    FaceName = "Unknown";
                }
                else
                {
                    FaceName = nameList[result.Label];
                }
                CameraCaptureFace = detectedFace.ToBitmap(pbFaceCapture.Width, pbFaceCapture.Height);
            }
            else
            {
                FaceName = "Please add new face!";
            }
        }

        private void GetFacesList()
        {
            if (!File.Exists(Config.HaarCascadePath))
            {
                string message = "Can't find Harr Cascade file! \n";
                message += Config.HaarCascadePath;
                DialogResult results = MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cascadeClassifier = new CascadeClassifier(Config.HaarCascadePath);
            faceList.Clear();
            string line;

            // create file to store face data if neccessary
            if (!Directory.Exists(Config.FacePhotosPath))
            {
                Directory.CreateDirectory(Config.FacePhotosPath);
            }

            if (!File.Exists(Config.FaceListTextFile))
            {
                string message = "Can't find face data file!";
                message += Config.FaceListTextFile;
                message += "An empty file will be create if this is your first time running the application!";
                DialogResult results = MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (results == DialogResult.OK)
                {
                    String dirName = Path.GetDirectoryName(Config.FaceListTextFile);
                    Directory.CreateDirectory(dirName);
                    File.Create(Config.FaceListTextFile).Close();
                }
            }

            FaceData faceDataInstance = null;
            StreamReader reader = new StreamReader(Config.FaceListTextFile);
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string[] lineParts = line.Split(':');
                faceDataInstance = new FaceData();
                faceDataInstance.FaceImage = new Image<Gray, byte>(Config.FacePhotosPath + lineParts[0] + Config.ImageFileExtension);
                faceDataInstance.PersonName = lineParts[1];
                faceList.Add(faceDataInstance);
            }

            foreach (FaceData face in faceList)
            {
                imageList.Push(face.FaceImage.Mat);
                nameList.Add(face.PersonName);
                labelList.Push(new[] { i++ });
            }
            reader.Close();

            //Train recognizer
            if (imageList.Size > 0)
            {
                recognizer = new EigenFaceRecognizer(imageList.Size);
                recognizer.Train(imageList, labelList);
            }
        }

        private Bitmap BitmapToImageSource(Bitmap bitmap)
        {
            return bitmap;
        }
        #endregion
    }
}
