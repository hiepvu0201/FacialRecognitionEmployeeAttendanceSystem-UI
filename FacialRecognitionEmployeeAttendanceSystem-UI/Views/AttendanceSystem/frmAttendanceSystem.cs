using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using FacialRecognitionEmployeeAttendanceSystem_UI.Models;
using FacialRecognitionEmployeeAttendanceSystem_UI.Repository;
using FacialRecognitionEmployeeAttendanceSystem_UI.Views.AttendanceSystem;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        //Initial Event
        public event PropertyChangedEventHandler PropertyChanged;
        private System.Timers.Timer captureTimer;

        //Camera Properties
        private VideoCapture videoCapture;
        Image<Bgr, Byte> bgrFrame = null;
        private Image<Gray, Byte> detectedFace = null;

        //Initial Algorithm
        private CascadeClassifier cascadeClassifier;    //For xml haarcascade file loading
        private EigenFaceRecognizer recognizer;         //Using eigen face recognizer algorithm to predict user



        //List Of Face, Name and Label Name
        private List<FaceData> faceList = new List<FaceData>();
        private VectorOfMat imageList = new VectorOfMat();
        private List<string> nameList = new List<string>();
        private VectorOfInt labelList = new VectorOfInt();

        //Variable that store name to set in frame
        public static string recognitionName = "";
        string previousName = "";

        //Repository
        UsersRepository _userRepository = new UsersRepository();
        AttendancesRepository _attendanceRepository = new AttendancesRepository();
        PayslipsRepository _payslipsRepository = new PayslipsRepository();
        ShiftsRepository _shiftsRepository = new ShiftsRepository();


        //Flag
        int count = 0;
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
                faceName = value;
                faceName = value.ToUpper();
                lblInfo.Invoke(new Action(async () =>
                {
                    Users userResult = await _userRepository.GetByFullNameAsync(faceName);

                    if (userResult != null)
                    {
                        Attendances attendance = await GetAttendanceForRequestAsync(userResult);
                        Shifts shifts = await _shiftsRepository.GetByIdAsync(userResult.shiftId);

                        if (attendance != null)
                        {
                            if (attendance.workingHours <= 0)
                            {
                                lblInfo.Text = $"Check in success! Welcome {userResult.fullName}!".ToUpper();
                            }
                            else
                            {
                                lblInfo.Text = $"Check out success! Good bye {userResult.fullName}!!".ToUpper();
                                JObject json = JObject.Parse(File.ReadAllText(Config.ConfigFile));
                                ConfigSalary configSalary = JsonConvert.DeserializeObject<ConfigSalary>(json.ToString());

                                _payslipsRepository.Add(CalcualteTodayPayslips(attendance, shifts, userResult.roles.fixedSalary, new DateTime(DateTime.Now.Ticks), configSalary, userResult.id));
                            }
                        }
                        lblInfo.Text = faceName;
                    }
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
            videoCapture = ConfigCamera(videoCapture);
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

                if (userResult != null)
                {
                    Attendances attendance = await GetAttendanceForRequestAsync(userResult);
                    Shifts shifts = await _shiftsRepository.GetByIdAsync(userResult.shiftId);

                    if (attendance != null)
                    {
                        // Time <= 0 when check-in meanwhile > 0 when checkout
                        if (attendance.workingHours <= 0)
                        {
                            MessageBox.Show($"Check in success! Welcome {userResult.fullName}!");
                        }
                        else
                        {
                            MessageBox.Show($"Check out success! Good bye {userResult.fullName}!");

                            JObject json = JObject.Parse(File.ReadAllText(Config.ConfigFile));
                            ConfigSalary configSalary = JsonConvert.DeserializeObject<ConfigSalary>(json.ToString());

                            _payslipsRepository.Add(CalcualteTodayPayslips(attendance, shifts, userResult.roles.fixedSalary, new DateTime(DateTime.Now.Ticks), configSalary, userResult.id));
                        }
                    }
                }
            }
            else MessageBox.Show("Please choose PIN Mode!!!");
            isPinMode = false;
        }

        private Payslips CalcualteTodayPayslips(Attendances attendances, Shifts shifts, double salaryRate, DateTime today, ConfigSalary configSalary, long userId)
        {
            Payslips payslips = new Payslips();
            payslips.payDate = today;
            payslips.allowance = configSalary.allowance;
            payslips.bonus = configSalary.bonusPerDay;
            payslips.otherSalary = 0;
            payslips.overtimeSalary = 0;
            payslips.annualLeaveSalary = 0;
            payslips.userId = userId;
            payslips.workingSalary = configSalary.salaryPerHour * CalculateWorkingTime(attendances) * salaryRate;
            payslips.tax = configSalary.taxRate / 100 * (configSalary.salaryPerHour * CalculateWorkingTime(attendances));
            payslips.deductionSalary = payslips.tax + configSalary.lateFeePerMinute * ((attendances.checkinAt - Convert.ToDateTime(shifts.timeStart)).TotalMinutes 
                                        + (attendances.checkoutAt - Convert.ToDateTime(shifts.timeEnd)).TotalMinutes);
            payslips.publicSalary = payslips.workingSalary - payslips.deductionSalary + configSalary.allowance;
            
            return payslips;
        }

        private void btnPinMode_Click(object sender, EventArgs e)
        {
            isPinMode = true;
            pbCamera.Image = null;
            MessageBox.Show("Now you're in PIN mode!");
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            captureTimer.Stop();
            this.Close();
            frmMain frmMain = new frmMain();
            frmMain.Show();
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

                    Rectangle[] faces = cascadeClassifier.DetectMultiScale(grayframe, 1.2, 2, new Size(50, 50), Size.Empty);

                    //detect face
                    for (int i = 0; i < faces.Length; i++)// (Rectangle face_found in facesDetected)
                    {
                        //This will focus in on the face from the haar results its not perfect but it will remove a majoriy
                        //of the background noise
                        faces[i].X += (int)(faces[i].Height * 0.15);
                        faces[i].Y += (int)(faces[i].Width * 0.22);
                        faces[i].Height -= (int)(faces[i].Height * 0.3);
                        faces[i].Width -= (int)(faces[i].Width * 0.35);

                        detectedFace = bgrFrame.Copy(faces[i]).Convert<Gray, Byte>().Resize(100, 100, Inter.Cubic);
                        detectedFace._EqualizeHist();

                        bgrFrame.Draw(faces[i], new Bgr(255, 255, 0), 2);

                        CameraCaptureFace = detectedFace.ToBitmap(pbFaceCapture.Width, pbFaceCapture.Height);

                        recognitionName = FaceRecognition(detectedFace);

                        //Draw only if current recognition name is repeat 15 times
                        if (previousName == "")
                        {
                            previousName = recognitionName;
                        }
                        if (previousName==recognitionName && previousName!="")
                        {
                            count++;
                        }
                        if (previousName!=recognitionName)
                        {
                            count = 0;
                        }
                        if (count>=15)
                        {
                            bgrFrame.Draw(recognitionName, new Point(faces[i].X - 4, faces[i].Y - 4), FontFace.HersheyTriplex, 0.5, new Bgr(255, 255, 0));
                            previousName = "";
                            FaceName = recognitionName;
                        }

                        break;
                    }

                }
                catch
                {
                    
                }

            }
            return bgrFrame.ToBitmap(pbCamera.Width, pbCamera.Height);
        }

        private string FaceRecognition(Image<Gray, Byte> image, int Eigen_Thresh = -1)
        {
            if (imageList.Size != 0)
            {
                //Eigen Face Algorithm
                FaceRecognizer.PredictionResult result = recognizer.Predict(image);

                if (result.Label == -1)
                {
                    recognitionName = "Unknown";
                    Config.Eigen_Distance = 0;
                    return recognitionName;
                }
                else
                {
                    recognitionName = nameList[result.Label];
                    Config.Eigen_Distance = (float)result.Distance;
                    if (Eigen_Thresh > -1) Config.Threshold = Eigen_Thresh;

                    if (Config.Eigen_Distance < Config.Threshold) return recognitionName;
                    else return "Unknown";
                }

            }
            
            return "";
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
                recognizer = new EigenFaceRecognizer(imageList.Size, double.PositiveInfinity);
                recognizer.Train(imageList, labelList);
            }
        }

        private double CalculateWorkingTime(Attendances attendance)
        {
            if (attendance == null)
            {
                return -1;
            }

            double time = (attendance.checkoutAt - attendance.checkinAt).TotalHours;

            return time;
        }

        private async System.Threading.Tasks.Task<Attendances> GetAttendanceForRequestAsync(Users userResult)
        {
            List<Attendances> listAttendance = await _attendanceRepository.GetByDateTimeAndUserNameAsync(DateTime.Now.ToString("yyyy-MM-dd"), userResult.id);

            Attendances attendance = new Attendances();
            attendance.dateCheck = DateTime.Now.ToString("yyyy-MM-dd");
            attendance.note = "";
            attendance.userId = userResult.id;
            attendance.status = true;

            if (listAttendance == null||CalculateWorkingTime(listAttendance[listAttendance.Count-1])!=0)
            {
                
                attendance.workingHours = 0;
                attendance.checkinAt = new DateTime(DateTime.Now.Ticks);

                _attendanceRepository.CheckIn(attendance);
                FaceName = $"Check in success! Welcome {userResult.fullName}!";
                return attendance;
            }
            else
            {
                Attendances attendancesDetail = listAttendance[listAttendance.Count - 1];
                attendancesDetail.checkoutAt = new DateTime(DateTime.Now.Ticks);
                attendancesDetail.workingHours = (attendancesDetail.checkoutAt - attendancesDetail.checkinAt).TotalHours;

                _attendanceRepository.CheckOut(attendancesDetail.id, attendancesDetail);

                FaceName = $"Check out success! Good bye {userResult.fullName}!";
                return attendancesDetail;
            }
        }
        #endregion
        private void frmAttendanceSystem_FormClosed(object sender, FormClosedEventArgs e)
        {
            captureTimer.Stop();
        }

        private void frmAttendanceSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            captureTimer.Stop();
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            GetFacesList();
            captureTimer.Start();
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            captureTimer.Stop();
        }
    }
}
