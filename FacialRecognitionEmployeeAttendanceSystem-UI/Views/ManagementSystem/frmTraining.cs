using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using FacialRecognitionEmployeeAttendanceSystem_UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.AttendanceSystem
{
    public partial class frmTraining : Form
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

        //Flag
        int count = 0;
        bool isTrained = false;

        //Current salary
        public static double todaySalary = 0;
        #endregion

        #region CameraCaptureImage
        private Bitmap cameraCapture;
        public Bitmap CameraCapture
        {
            get { return cameraCapture; }
            set
            {
                cameraCapture = value;
                pbCameraCapture.Invoke(new Action(() => { pbCameraCapture.Image = cameraCapture; }));
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
                pbCameraCaptureFace.Invoke(new Action(() => { pbCameraCaptureFace.Image = cameraCaptureFace; }));
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public frmTraining()
        {
            InitializeComponent();

            captureTimer = new System.Timers.Timer()
            {
                Interval = Config.TimerResponseValue
            };
            captureTimer.Elapsed += CaptureTimer_Elapsed;
        }

        
        public frmTraining(string name)
        {
            InitializeComponent();

            lblUserName.Text = name;

            captureTimer = new System.Timers.Timer()
            {
                Interval = Config.TimerResponseValue
            };
            captureTimer.Elapsed += CaptureTimer_Elapsed;
        }
        #endregion

        #region Event
        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private void CaptureTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CameraCapture = ProcessFrame(bgrFrame);
        }
        private void btnStartCapture_Click(object sender, EventArgs e)
        {
            GetFacesList();
            videoCapture = ConfigCamera(videoCapture);
            captureTimer.Start();
        }
        #endregion
        #region Method
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

                        CameraCaptureFace = detectedFace.ToBitmap(pbCameraCaptureFace.Width, pbCameraCaptureFace.Height);

                        recognitionName = FaceRecognition(detectedFace);

                        //Draw only if current recognition name is repeat 15 times
                        if (previousName == "")
                        {
                            previousName = recognitionName;
                        }
                        if (previousName == recognitionName && previousName != "")
                        {
                            count++;
                        }
                        if (previousName != recognitionName)
                        {
                            count = 0;
                        }
                        if (count >= 15)
                        {
                            bgrFrame.Draw(recognitionName, new Point(faces[i].X - 4, faces[i].Y - 4), FontFace.HersheyTriplex, 0.5, new Bgr(255, 255, 0));
                            previousName = "";
                        }

                        break;
                    }

                }
                catch (Exception ex)
                {

                }

            }
            return bgrFrame.ToBitmap(pbCameraCapture.Width, pbCameraCapture.Height);
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
            if (isTrained==true)
            {
                recognizer.Read(Config.TrainingFile);
                return;
            }

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
            if (imageList.Size > 0 && isTrained == false)
            {
                recognizer = new EigenFaceRecognizer(imageList.Size, double.PositiveInfinity);
                recognizer.Train(imageList, labelList);
                recognizer.Write(Config.TrainingFile);
                isTrained = true;
            }
        }
        private VideoCapture ConfigCamera(VideoCapture video)
        {
            video = new VideoCapture(Config.ActiveCameraIndex);
            video.SetCaptureProperty(CapProp.Fps, 30);
            video.SetCaptureProperty(CapProp.FrameHeight, 422);
            video.SetCaptureProperty(CapProp.FrameWidth, 628);
            return video;
        }

        #endregion

        private void btnStopCapture_Click(object sender, EventArgs e)
        {
            captureTimer.Stop();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            captureTimer.Stop();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
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
            string personName = lblUserName.Text;
            writer.WriteLine(String.Format("face{0}:{1}", (faceList.Count + 1), personName));
            writer.Close();
            isTrained = false;
            GetFacesList();
            MessageBox.Show("Successful.");
        }

        private void frmTraining_FormClosed(object sender, FormClosedEventArgs e)
        {
            captureTimer.Stop();
        }
    }
}
