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
        Image<Bgr, Byte> bgrFrame = null;
        private CascadeClassifier cascadeClassifier;
        private Image<Gray, Byte> detectedFace = null;
        private List<FaceData> faceList = new List<FaceData>();
        private VectorOfMat imageList = new VectorOfMat();
        private List<string> nameList = new List<string>();
        private VectorOfInt labelList = new VectorOfInt();
        private EigenFaceRecognizer recognizer;
        private System.Timers.Timer captureTimer;
        public static string recognitionName = "";

        UsersRepository _userRepository = new UsersRepository();
        AttendancesRepository _attendanceRepository = new AttendancesRepository();
        bool isPinMode = false;
        #endregion

        #region CameraCaptureImage
        private Bitmap cameraCapture;
        public Bitmap CameraCapture
        {
            get { return cameraCapture; }
            set
            {
                cameraCapture = value;
                pbCamera.Invoke(new Action(() => { pbCamera.Image = cameraCapture; }));
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
                pbFaceCapture.Invoke(new Action(() => { pbFaceCapture.Image = cameraCaptureFace; }));
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
                lblFaceName.Invoke(new Action(async () => { 
                    lblFaceName.Text = faceName;
                    Users userResult = await _userRepository.GetByFullNameAsync(recognitionName);

                    if (userResult!=null)
                    {
                        await GetAttendanceForRequestAsync(userResult);
                    }
                    txtNameToCheck.Text = recognitionName;
                }));
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
            GetFacesList();
            videoCapture = ConfigCamera(videoCapture);
            captureTimer.Start();
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CaptureTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CameraCapture = ProcessFrame(bgrFrame);
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (isPinMode == true && txtPin.Text != null && txtPin.Text != "")
            {
                Users userResult = await _userRepository.GetByPinAsync(txtPin.Text);

                Attendances attendance = await GetAttendanceForRequestAsync(userResult);

                // Time <= 0 when check-in meanwhile > 0 when checkout
                if (CalculateWorkingTime(attendance) == 0)
                {
                    MessageBox.Show($"Check in success! Welcome {userResult.fullName}!");
                }
                else
                {
                    MessageBox.Show($"Check out success! Good bye {userResult.fullName}!");
                }
            }
            else MessageBox.Show("Please choose PIN Mode!!!");
            isPinMode = false;
        }

        private async System.Threading.Tasks.Task<Attendances> GetAttendanceForRequestAsync(Users userResult)
        {
            //Attendance for json request
            Attendances attendanceRq = new Attendances();
            attendanceRq.dateCheck = DateTime.Now.ToString("yyyy-MM-dd");

            //Attendance from db
            Attendances attendanceDB = await _attendanceRepository.GetByDateTimeAsync(attendanceRq.dateCheck);

            attendanceRq.workingHours = CalculateWorkingTime(attendanceDB);
            attendanceRq.userId = userResult.id;

            if (attendanceRq.workingHours <= 0)
            {
                attendanceRq.workingHours = 0;
                attendanceRq.checkinAt = new DateTime(DateTime.Now.Ticks);

                _attendanceRepository.CheckIn(attendanceRq);

                FaceName = $"Check in success! Welcome {userResult.fullName}!";
            }
            else
            {
                attendanceRq.checkoutAt = new DateTime(DateTime.Now.Ticks);

                _attendanceRepository.CheckOut(attendanceDB.id, attendanceRq);

                FaceName = $"Check out success! Good bye {userResult.fullName}!";
            }
            return attendanceRq;
        }

        private void btnPinMode_Click(object sender, EventArgs e)
        {
            isPinMode = true;
            pbCamera.Image = null;
            MessageBox.Show("Now you're in PIN mode!");
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmMain = new frmMain();
            frmMain.Show();
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
        private VideoCapture ConfigCamera(VideoCapture video)
        {
            video = new VideoCapture(Config.ActiveCameraIndex);
            video.SetCaptureProperty(CapProp.Fps, 30);
            video.SetCaptureProperty(CapProp.FrameHeight, 422);
            video.SetCaptureProperty(CapProp.FrameWidth, 628);
            return video;
        }

        private Bitmap ProcessFrame(Image<Bgr, Byte> bgrFrame)
        {
            bgrFrame = videoCapture.QueryFrame().ToImage<Bgr, Byte>();

            if (bgrFrame != null)
            {
                try
                {
                    //for emgu cv bug
                    Image<Gray, byte> grayframe = bgrFrame.Convert<Gray, byte>();

                    Rectangle[] faces = cascadeClassifier.DetectMultiScale(grayframe, 1.2, 10, new System.Drawing.Size(50, 50), new System.Drawing.Size(200, 200));

                    //detect face
                    foreach (Rectangle face in faces)
                    {
                        bgrFrame.Draw(face, new Bgr(255, 255, 0), 2);

                        detectedFace = bgrFrame.Copy(face).Convert<Gray, Byte>();
                        CameraCaptureFace = detectedFace.ToBitmap(pbFaceCapture.Width, pbFaceCapture.Height);

                        recognitionName = FaceRecognition("");
                        FaceName = lblFaceName.Text;

                        bgrFrame.Draw(recognitionName, new Point(face.X - 4, face.Y - 4), FontFace.HersheyTriplex, 0.5, new Bgr(255, 255, 0));

                        break;
                    }

                }
                catch (Exception ex)
                {
                    
                }

            }
            return bgrFrame.ToBitmap(pbCamera.Width, pbCamera.Height);
        }

        private string FaceRecognition(string recognitionName)
        {
            if (imageList.Size != 0)
            {
                //Eigen Face Algorithm
                FaceRecognizer.PredictionResult result = recognizer.Predict(detectedFace.Resize(100, 100, Inter.Cubic));

                if (result.Label == 0)
                {
                    recognitionName = "Unknown";
                }
                else
                {
                    recognitionName = nameList[result.Label];       
                }

            }
            else
            {
                recognitionName = "Unknown";
            }
            return recognitionName;
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

        private double CalculateWorkingTime(Attendances attendance)
        {
            if (attendance == null || attendance.checkinAt == DateTime.MinValue)
            {
                return -1;
            }

            double time = (DateTime.Now - attendance.checkinAt).TotalHours;

            return time;
        }
        #endregion
    }
}
