using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.Dimensioning;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Implementation;
using Cognex.VisionPro.PMAlign;
using System.Windows.Forms;
using System.IO;
using Cognex.VisionPro.Display;
using System.Data;



namespace LG_Chem
{
    public class SubSequence
    {
        //private static SubSequence _instance;
        //public static SubSequence Instance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new SubSequence();
        //    }

        //    return _instance;
        //}
        public static List<CogRectangle> _leftTrainRect = new List<CogRectangle>();
        public static List<CogRectangle> _rightTrainRect = new List<CogRectangle>();
        public static List<CogGraphicLabel> _leftCogDistanceLabel = new List<CogGraphicLabel>();
        public static List<CogGraphicLabel> _rightCogDistanceLabel = new List<CogGraphicLabel>();
        public static List<CogGraphicLabel> _totalCogDistanceLabel = new List<CogGraphicLabel>();
        public static List<CogCreateSegmentTool> _leftSegmentTool = new List<CogCreateSegmentTool>();
        public static List<CogCreateSegmentTool> _rightSegmentTool = new List<CogCreateSegmentTool>();
        private CogImageFileTool _leftImageFileTool = null;
        private CogImageFileTool _rightImageFileTool = null;
        private CogGraphicCollection _leftCogDisplay = null;
        private CogGraphicCollection _rightCogDisplay = null;

        private CogRectangle leftTrainRect = new CogRectangle();
        private CogRectangle rightTrainRect = new CogRectangle();
        private CogGraphicLabel leftCogDistanceLabel = new CogGraphicLabel();
        private CogGraphicLabel rightCogDistanceLabel = new CogGraphicLabel();
        private CogGraphicLabel totalCogDistanceLabel = new CogGraphicLabel();
        private CogCreateSegmentTool leftSegmentTool = new CogCreateSegmentTool();
        private CogCreateSegmentTool rightSegmentTool = new CogCreateSegmentTool();

        private CogImageConvertTool _leftConvertTool = null;
        private CogImageConvertTool _rightConvertTool = null;
        private CogIPOneImageTool _leftEqualTool = null;
        private CogIPOneImageTool _rightEqualTool = null;
        private CogIPOneImageEqualize _EqualTool = null;
        private CogPMAlignTool _leftPMAlignTool = new CogPMAlignTool();
        private CogPMAlignTool _rightPMAlignTool = new CogPMAlignTool();

        //private FormMain formmain = null;
        public static List<Bitmap> leftimagelist = new List<Bitmap>();
        public static List<Bitmap> rightimagelist = new List<Bitmap>();
        //테스트 이미지 경로
       
        public string trainImagePath = Directory.GetCurrentDirectory() + "\\" + "Config" + "\\" + "traincircle.vpp";
        string CalibrationtrainImagePath = Directory.GetCurrentDirectory() + "\\" + "Config" + "\\" + "traincali.vpp";
        public string strFilePath = string.Format(@"{0}\{1:00}\{2:00}\{3:00}", System.IO.Directory.GetCurrentDirectory() + "\\Csv", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        

        public CtrlTapDispaly ctrlresultdata = null;
        public int count = -1;
        public int calicount = 0;
        public double leftDistance;
        public double rightDistance;
        public double CalibrationDistance;

        public static List<double> totalDistance = new List<double>();
        public void Initialize()
        {
            ctrlresultdata = new CtrlTapDispaly();
            _EqualTool = new CogIPOneImageEqualize();
            _leftEqualTool = new CogIPOneImageTool();
            _rightEqualTool = new CogIPOneImageTool();
            _leftImageFileTool = new CogImageFileTool();
            _rightImageFileTool = new CogImageFileTool();
            //_leftCogDistanceLabel = new List<CogGraphicLabel>();
            //_rightCogDistanceLabel = new List<CogGraphicLabel>();
            //_totalCogDistanceLabel = new List<CogGraphicLabel>();
            //_leftSegmentTool = new List<CogCreateSegmentTool>();
            //_rightSegmentTool = new List<CogCreateSegmentTool>();
            _leftConvertTool = new CogImageConvertTool();
            _rightConvertTool = new CogImageConvertTool();
            //_leftTrainRect = new List<CogRectangle>();
            //_rightTrainRect = new List<CogRectangle>();
            //_leftPMAlignTool = new CogPMAlignTool();
            //_rightPMAlignTool = new CogPMAlignTool();
            //formmain = new FormMain();
            AdaptCogPMAlignTool(trainImagePath);
        }


        //저장된 이미지로 재검사
        public void PMAlign(Bitmap Leftimage, Bitmap Rightimage)
        {
            try
            {
                Initialize();

                double leftCenterX = 0;
                double leftCenterY = 0;
                double rightCenterX = 0;
                double rightCenterY = 0;
                double totalDistance = 0;
                
                _leftPMAlignTool.InputImage = new CogImage8Grey(Leftimage);
                _leftPMAlignTool.Run();
                _rightPMAlignTool.InputImage = new CogImage8Grey(Rightimage);
                _rightPMAlignTool.Run();
                leftSegmentTool.InputImage = new CogImage8Grey(Leftimage);
                rightSegmentTool.InputImage = new CogImage8Grey(Rightimage);



                leftTrainRect.X = _leftPMAlignTool.Results[0].GetPose().TranslationX - 750;
                leftTrainRect.Y = _leftPMAlignTool.Results[0].GetPose().TranslationY - 750;
                leftTrainRect.Width = 1500;
                leftTrainRect.Height = 1500;
                rightTrainRect.X = _rightPMAlignTool.Results[0].GetPose().TranslationX - 750;
                rightTrainRect.Y = _rightPMAlignTool.Results[0].GetPose().TranslationY - 750;
                rightTrainRect.Width = 1500;
                rightTrainRect.Height = 1500;

                leftCenterX = _leftPMAlignTool.Results[0].GetPose().TranslationX;
                leftCenterY = _leftPMAlignTool.Results[0].GetPose().TranslationY;
                rightCenterX = _rightPMAlignTool.Results[0].GetPose().TranslationX;
                rightCenterY = _rightPMAlignTool.Results[0].GetPose().TranslationY;

                leftSegmentTool.Segment.StartX = leftCenterX;
                leftSegmentTool.Segment.StartY = leftCenterY;
                leftSegmentTool.Segment.EndX = Leftimage.Width;
                leftSegmentTool.Segment.EndY = leftCenterY;
                leftSegmentTool.Run();
                leftSegmentTool.Segment.CreateLine();


                leftDistance = (leftSegmentTool.Segment.EndX - leftSegmentTool.Segment.StartX) / (double)429;
                string leftText = "Left Distance : " + Math.Round(leftDistance, 3).ToString() + "mm";
                ;
                leftCogDistanceLabel.Color = CogColorConstants.Red;
                leftCogDistanceLabel.SetXYText(900, 300, leftText);

                rightSegmentTool.Segment.StartX = 0;
                rightSegmentTool.Segment.StartY = rightCenterY;
                rightSegmentTool.Segment.EndX = rightCenterX;
                rightSegmentTool.Segment.EndY = rightCenterY;
                rightSegmentTool.Run();
                rightSegmentTool.Segment.CreateLine();

                rightDistance = (rightSegmentTool.Segment.EndX - rightSegmentTool.Segment.StartX) / (double)429;
                string rightText = "Right Distance : " + Math.Round(rightDistance, 3).ToString() + "mm";

                rightCogDistanceLabel.Color = CogColorConstants.Red;
                rightCogDistanceLabel.SetXYText(1000, 300, rightText);

                totalDistance = leftDistance + rightDistance;

                // 1mm당 429pixle / 1픽셀당 2.33마이크로
                totalDistance = totalDistance + double.Parse(Machine._Cfg.mSetup.middleValue.ToString());
                string totalText = "Total Distance : " + Math.Round(totalDistance, 3).ToString() + "mm";

                totalCogDistanceLabel.Color = CogColorConstants.Red;
                totalCogDistanceLabel.SetXYText(1000, 500, totalText);

                string total = Math.Round(totalDistance, 3).ToString() + "mm";

                //Result Image
                FormMain.Instance().DisplayControl.DisplayResultImage(Leftimage, Rightimage, leftTrainRect, rightTrainRect, leftSegmentTool.GetOutputSegment(), rightSegmentTool.GetOutputSegment(), leftCogDistanceLabel, rightCogDistanceLabel, totalCogDistanceLabel, Math.Round(totalDistance, 3));
            }


            
            catch (Exception ex)
            {
                FormMain.Instance().DisplayControl.UpdateImage(0, Leftimage);
                FormMain.Instance().DisplayControl.UpdateImage(1, Rightimage);
                MessageBox.Show(" 이미지 또는 시편을 확인해주세요");
                Machine._Logger.log("History Image Matching Fail", LogType.DEBUG, false);
            }

        }
        //Calibaration 검사
        public void PMAlignCalibration()
        {
            Bitmap Leftimage = Machine._cameraManager._cameraList[0]._bmp;
            Bitmap Rightimage = Machine._cameraManager._cameraList[1]._bmp;

            try
            {
                ctrlresultdata = new CtrlTapDispaly();
                _EqualTool = new CogIPOneImageEqualize();
                _leftEqualTool = new CogIPOneImageTool();
                _rightEqualTool = new CogIPOneImageTool();
                _leftImageFileTool = new CogImageFileTool();
                _rightImageFileTool = new CogImageFileTool();
                _leftConvertTool = new CogImageConvertTool();
                _rightConvertTool = new CogImageConvertTool();
                _leftPMAlignTool = new CogPMAlignTool();
                _rightPMAlignTool = new CogPMAlignTool();
                AdaptCogPMAlignTool(CalibrationtrainImagePath);

                double leftCenterX = 0;
                double leftCenterY = 0;
                double rightCenterX = 0;
                double rightCenterY = 0;
                double totalDistance = 0;
                
                _leftPMAlignTool.InputImage = new CogImage8Grey(Leftimage);
                _leftPMAlignTool.Run();
                _rightPMAlignTool.InputImage = new CogImage8Grey(Rightimage);
                _rightPMAlignTool.Run();
                leftSegmentTool.InputImage = new CogImage8Grey(Leftimage);
                rightSegmentTool.InputImage = new CogImage8Grey(Rightimage);



                leftTrainRect.X = _leftPMAlignTool.Results[0].GetPose().TranslationX - 750;
                leftTrainRect.Y = _leftPMAlignTool.Results[0].GetPose().TranslationY - 750;
                leftTrainRect.Width = 1500;
                leftTrainRect.Height = 1500;
                rightTrainRect.X = _rightPMAlignTool.Results[0].GetPose().TranslationX - 750;
                rightTrainRect.Y = _rightPMAlignTool.Results[0].GetPose().TranslationY - 750;
                rightTrainRect.Width = 1500;
                rightTrainRect.Height = 1500;

                leftCenterX = _leftPMAlignTool.Results[0].GetPose().TranslationX;
                leftCenterY = _leftPMAlignTool.Results[0].GetPose().TranslationY;
                rightCenterX = _rightPMAlignTool.Results[0].GetPose().TranslationX;
                rightCenterY = _rightPMAlignTool.Results[0].GetPose().TranslationY;

                leftSegmentTool.Segment.StartX = leftCenterX;
                leftSegmentTool.Segment.StartY = leftCenterY;
                leftSegmentTool.Segment.EndX = Leftimage.Width;
                leftSegmentTool.Segment.EndY = leftCenterY;
                leftSegmentTool.Run();
                leftSegmentTool.Segment.CreateLine();


                leftDistance = (leftSegmentTool.Segment.EndX - leftSegmentTool.Segment.StartX) / (double)429;
                string leftText = "Left Distance : " + Math.Round(leftDistance, 3).ToString() + "mm";
                
                leftCogDistanceLabel.Color = CogColorConstants.Red;
                leftCogDistanceLabel.SetXYText(900, 300, leftText);

                rightSegmentTool.Segment.StartX = 0;
                rightSegmentTool.Segment.StartY = rightCenterY;
                rightSegmentTool.Segment.EndX = rightCenterX;
                rightSegmentTool.Segment.EndY = rightCenterY;
                rightSegmentTool.Run();
                rightSegmentTool.Segment.CreateLine();

                rightDistance = (rightSegmentTool.Segment.EndX - rightSegmentTool.Segment.StartX) / (double)429;
                string rightText = "Right Distance : " + Math.Round(rightDistance, 3).ToString() + "mm";

                rightCogDistanceLabel.Color = CogColorConstants.Red;
                rightCogDistanceLabel.SetXYText(1000, 300, rightText);
                calicount++;
                totalDistance = leftDistance + rightDistance;
                if(calicount !=2)
                {
                    CalibrationDistance = Math.Round(130 - totalDistance,3);
                }
                else
                {
                    CalibrationDistance += CalibrationDistance;
                    CalibrationDistance = Math.Round(CalibrationDistance / 2,3);
                    //ctrlresultdata.CalibrationDele(CalibrationDistance);
                    FormMain.Instance().ResultDataControl.CalibrationDele(CalibrationDistance);

                }
                // 1mm당 429pixle / 1픽셀당 2.33마이크로
                totalDistance = totalDistance + CalibrationDistance;

                string totalText = "Total Distance : " + Math.Round(totalDistance, 3).ToString() + "mm";

                totalCogDistanceLabel.Color = CogColorConstants.Red;
                totalCogDistanceLabel.SetXYText(1000, 500, totalText);

                string total = Math.Round(totalDistance, 3).ToString() + "mm";

                //Result Image
                FormMain.Instance().DisplayControl.DisplayResultImage(Leftimage, Rightimage, leftTrainRect, rightTrainRect, leftSegmentTool.GetOutputSegment(), rightSegmentTool.GetOutputSegment(), leftCogDistanceLabel, rightCogDistanceLabel, totalCogDistanceLabel, Math.Round(totalDistance, 3));

      
            }



            catch (Exception ex)
            {
                FormMain.Instance().DisplayControl.UpdateImage(0, Leftimage);
                FormMain.Instance().DisplayControl.UpdateImage(1, Rightimage);
                MessageBox.Show(" 이미지 또는 시편을 확인해주세요");
                Machine._Logger.log("Calibration Fail", LogType.DEBUG, false);
            }

        }
        //이미지 그랩 후 검사
        public void PMRun()
        {
            
         
            Initialize();
            

            double leftCenterX = 0;
            double leftCenterY = 0;
            double rightCenterX = 0;
            double rightCenterY = 0;
            Bitmap leftimage = Machine._cameraManager._cameraList[0]._bmp;//leftimagelist[count];/*new Bitmap(leftImagePath)*/
            Bitmap rightimage = Machine._cameraManager._cameraList[1]._bmp;//rightimagelist[count];/*new Bitmap(leftImagePath)*/
            Setup setup = Machine._Cfg.mSetup;
            try
            {
                    
                count++;
                if (count == setup.count)
                {
                    _leftTrainRect.Clear();
                    _rightTrainRect.Clear();
                    _leftSegmentTool.Clear();
                    _rightSegmentTool.Clear();
                    _leftCogDistanceLabel.Clear();
                    _rightCogDistanceLabel.Clear();
                    _totalCogDistanceLabel.Clear();
                    totalDistance.Clear();
                    count = 0;
                }
                //leftimagelist.Add(Machine._cameraManager._cameraList[0]._bmp);/*new Bitmap(leftImagePath)*/
                //rightimagelist.Add(Machine._cameraManager._cameraList[1]._bmp);//new Bitmap(rightImagePath);

                //leftimage.Save(Directory.GetCurrentDirectory() + "\\" + "image" + "\\" + "Test_0.bmp");
                //rightimage.Save(Directory.GetCurrentDirectory() + "\\" + "image" + "\\" + "Test_1.bmp");


                //// Left
                //_leftImageFileTool.InputImage = new CogImage8Grey(leftimage);
                //_leftImageFileTool.Operator.Open(leftImagePath, CogImageFileModeConstants.Read);
                //_leftImageFileTool.Run();

                //_leftEqualTool.InputImage = _leftImageFileTool.OutputImage as CogImage8Grey;
                //_leftEqualTool.Operators.Add(_EqualTool);
                //_leftEqualTool.Run();

                //// Right
                //_rightImageFileTool.InputImage = new CogImage8Grey(rightimage);
                //_rightImageFileTool.Operator.Open(rightImagePath, CogImageFileModeConstants.Read);
                //_rightImageFileTool.Run();

                //_rightEqualTool.InputImage = _rightImageFileTool.OutputImage as CogImage8Grey;
                //_rightEqualTool.Operators.Add(_EqualTool);
                //_rightEqualTool.Run();


                _leftPMAlignTool.InputImage = new CogImage8Grey(leftimage);
                _leftPMAlignTool.Run();
                _rightPMAlignTool.InputImage = new CogImage8Grey(rightimage);
                _rightPMAlignTool.Run();

                _leftSegmentTool.Add(new CogCreateSegmentTool());
                _rightSegmentTool.Add(new CogCreateSegmentTool());
                _leftSegmentTool[count].InputImage = new CogImage8Grey(leftimage);
                _rightSegmentTool[count].InputImage = new CogImage8Grey(rightimage);
                _leftCogDistanceLabel.Add(new CogGraphicLabel());
                _rightCogDistanceLabel.Add(new CogGraphicLabel());
                totalDistance.Add(new double());
                _totalCogDistanceLabel.Add(new CogGraphicLabel());


                //PM Result
                _leftTrainRect.Add(_leftPMAlignTool.Results.GetTrainArea());
                _rightTrainRect.Add(_rightPMAlignTool.Results.GetTrainArea());



                _leftTrainRect[count].X = _leftPMAlignTool.Results[0].GetPose().TranslationX - 750;
                _leftTrainRect[count].Y = _leftPMAlignTool.Results[0].GetPose().TranslationY - 750;
                _leftTrainRect[count].Width = 1500;
                _leftTrainRect[count].Height = 1500;
                _rightTrainRect[count].X = _rightPMAlignTool.Results[0].GetPose().TranslationX - 750;
                _rightTrainRect[count].Y = _rightPMAlignTool.Results[0].GetPose().TranslationY - 750;
                _rightTrainRect[count].Width = 1500;
                _rightTrainRect[count].Height = 1500;

                leftCenterX = _leftPMAlignTool.Results[0].GetPose().TranslationX;
                //_leftTrainRect.X + (_leftTrainRect.Width / 2);
                leftCenterY = _leftPMAlignTool.Results[0].GetPose().TranslationY;
                //_leftTrainRect.Y + (_leftTrainRect.Height / 2);
                rightCenterX = _rightPMAlignTool.Results[0].GetPose().TranslationX;
                rightCenterY = _rightPMAlignTool.Results[0].GetPose().TranslationY;

                //(CogImage8Grey)_leftImageFileTool.OutputImage;
                _leftSegmentTool[count].Segment.StartX = leftCenterX;
                _leftSegmentTool[count].Segment.StartY = leftCenterY;
                _leftSegmentTool[count].Segment.EndX = leftimage.Width;//_leftImageFileTool.OutputImage.Width;
                _leftSegmentTool[count].Segment.EndY = leftCenterY; //임시
                _leftSegmentTool[count].Run();
                _leftSegmentTool[count].Segment.CreateLine();


                leftDistance = (_leftSegmentTool[count].Segment.EndX - _leftSegmentTool[count].Segment.StartX) / (double)429;
                string leftText = "Left Distance : " + Math.Round(leftDistance, 3).ToString() + "mm";
                ;
                _leftCogDistanceLabel[count].Color = CogColorConstants.Red;
                _leftCogDistanceLabel[count].SetXYText(900, 300, leftText);

                _rightSegmentTool[count].Segment.StartX = 0;
                _rightSegmentTool[count].Segment.StartY = rightCenterY;
                _rightSegmentTool[count].Segment.EndX = rightCenterX;
                _rightSegmentTool[count].Segment.EndY = rightCenterY; //임시
                _rightSegmentTool[count].Run();
                _rightSegmentTool[count].Segment.CreateLine();

                rightDistance = (_rightSegmentTool[count].Segment.EndX - _rightSegmentTool[count].Segment.StartX) / (double)429;
                string rightText = "Right Distance : " + Math.Round(rightDistance, 3).ToString() + "mm";
                    
                _rightCogDistanceLabel[count].Color = CogColorConstants.Red;
                _rightCogDistanceLabel[count].SetXYText(1000, 300, rightText);


                //leftTheta = (_leftPMAlignTool.Results[0].GetPose().Rotation)/* * 180 / Math.PI*/;  // 라디언 값을 각도로 변환
                //rightTheta = (_rightPMAlignTool.Results[0].GetPose().Rotation)/** 180 / Math.PI*/;  // 라디언 값을 각도로 변환
                //double leftx = Math.Cos(leftTheta) * leftDistance;
                //double rightx = Math.Cos(rightTheta) * rightDistance;
                    
                totalDistance[count] = leftDistance + rightDistance;
                // 1mm당 429pixle / 1픽셀당 2.33마이크로
                totalDistance[count] = totalDistance[count] + double.Parse(Machine._Cfg.mSetup.middleValue.ToString());
                string totalText = "Total Distance : " + Math.Round(totalDistance[count], 3).ToString() + "mm";
                    
                _totalCogDistanceLabel[count].Color = CogColorConstants.Red;
                _totalCogDistanceLabel[count].SetXYText(1000, 500, totalText);

                string total = Math.Round(totalDistance[count], 3).ToString() + "mm";

                //Result Image

                FormMain.Instance().DisplayControl.DisplayResultImage(leftimage, rightimage, _leftTrainRect[count], _rightTrainRect[count], _leftSegmentTool[count].GetOutputSegment(), _rightSegmentTool[count].GetOutputSegment(), _leftCogDistanceLabel[count], _rightCogDistanceLabel[count], _totalCogDistanceLabel[count], Math.Round(totalDistance[count], 3));
                MakeCsv();

                FormMain.Instance().ResultDataControl.ApplyDataGridView(leftDistance, rightDistance, totalDistance[count]);

                

            }

            catch (Exception ex)
            {
                FormMain.Instance().DisplayControl.UpdateImage(0, leftimage);
                FormMain.Instance().DisplayControl.UpdateImage(1, rightimage);
                MakeCsv();

                FormMain.Instance().ResultDataControl.ApplyDataGridView(0, 0, 0);
                Machine.ShowErrorInfoDlg(" 이미지 또는 시편을 확인해주세요");
                //MessageBox.Show("이미지or시료를 확인해주세요");
                Machine._Logger.log("Image Matching Fail", LogType.DEBUG, false);

            }


        }

        //public void DrawGraphics(ICogImage img)
        //{
        //    // Left
        //    // Draw Area
        //    //form1.pbLImage.Controls.Add(_leftCogDisplay2);

        //    //_leftCogDisplay2.Image = img;

        //    //_leftCogDisplay2.StaticGraphics.Add(_leftTrainRect, "");
        //    //_leftCogDisplay2.StaticGraphics.Add(_leftCogDistanceLabel, "");
        //    //_leftCogDisplay2.StaticGraphics.Add(_rightCogDistanceLabel, "");
        //    _leftCogDisplay2.StaticGraphics.Add(_totalCogDistanceLabel, "");
        //    _leftCogDisplay2.StaticGraphics.Add((ICogGraphic)_leftSegmentTool.GetOutputSegment(), "");

        //    // Draw String
        //    _leftCogDisplay.Add(_leftCogDistanceLabel);  // Left
        //    _leftCogDisplay.Add(_rightCogDistanceLabel); // Right
        //    _leftCogDisplay.Add(_totalCogDistanceLabel); // Total
        //                                                 // Draw Line
        //    _leftCogDisplay.Add((ICogGraphic)_leftSegmentTool.GetOutputSegment());

        //    // Right
        //    _rightCogDisplay.Add(_rightTrainRect);
        //    _rightCogDisplay.Add((ICogGraphic)_rightSegmentTool.GetOutputSegment());

        //    _leftCogDisplay2.StaticGraphics.Add((ICogGraphic)_rightCogDisplay, "");
        //}

        public void Display(ICogRecord lastRecord)
        {
            // Left
            CogRecord LEFT_RECORD_IMG = new CogRecord("LEFT_DISP", typeof(ICogImage), CogRecordUsageConstants.Result, false, _leftImageFileTool.OutputImage, "LEFT_DISP");
            lastRecord.SubRecords.Add(LEFT_RECORD_IMG);
            CogRecord LEFT_RECORD_CGC_DISP = new CogRecord("LEFT_CGC_DISP", typeof(CogGraphicCollection), CogRecordUsageConstants.Result, false, _leftCogDisplay, "LEFT_CGC_DISP");
            LEFT_RECORD_IMG.SubRecords.Add(LEFT_RECORD_CGC_DISP);

            // Right
            CogRecord RIGHT_RECORD_IMG = new CogRecord("RIGHT_DISP", typeof(ICogImage), CogRecordUsageConstants.Result, false, _rightImageFileTool.OutputImage, "RIGHT_DISP");
            lastRecord.SubRecords.Add(RIGHT_RECORD_IMG);
            CogRecord RIGHT_RECORD_CGC_DISP = new CogRecord("RIGHT_CGC_DISP", typeof(CogGraphicCollection), CogRecordUsageConstants.Result, false, _rightCogDisplay, "RIGHT_CGC_DISP");
            RIGHT_RECORD_IMG.SubRecords.Add(RIGHT_RECORD_CGC_DISP);
        }

        public void AdaptCogPMAlignTool(string strvpp)
        {
            

            if (_leftPMAlignTool != null)
            {
                _leftPMAlignTool.Pattern.Dispose();
            }

            if (_rightPMAlignTool != null)
            {
                _rightPMAlignTool.Pattern.Dispose();
            }

            try
            {
                _leftPMAlignTool.Pattern = ((CogPMAlignPattern)CogSerializer.LoadObjectFromFile(strvpp));
                _leftPMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
                _leftPMAlignTool.RunParams.ZoneAngle.High = Math.PI;
                _leftPMAlignTool.RunParams.ZoneAngle.Low = -Math.PI;
                _leftPMAlignTool.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatQuick;
                _leftPMAlignTool.RunParams.AcceptThreshold = 0.4;
                _leftPMAlignTool.RunParams.CoarseAcceptThreshold = 0.35;

                _rightPMAlignTool.Pattern = ((CogPMAlignPattern)CogSerializer.LoadObjectFromFile(strvpp));
                _rightPMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
                _rightPMAlignTool.RunParams.ZoneAngle.High = Math.PI;
                _rightPMAlignTool.RunParams.ZoneAngle.Low = -Math.PI;
                _rightPMAlignTool.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatQuick;
                _rightPMAlignTool.RunParams.AcceptThreshold = 0.4;
                _rightPMAlignTool.RunParams.CoarseAcceptThreshold = 0.35;
               
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MakeCsv()
        {
            try
            {
                string strCsvPath = strFilePath + "\\ResultData.csv";
                if (Directory.Exists(strFilePath) == false)
                {
                    Directory.CreateDirectory(strFilePath);
                }
                
                var lineCount = 0;
                // PositionTableParams Class의 변수이름 가져오는 함수
                List<string> paramNameList = new List<string>() { "No","Left","Right","Total Distance","Date","비고"};
                
                FileInfo fileinfo = new FileInfo(strCsvPath);
                bool boolfile = fileinfo.Exists;
                if (boolfile)
                {
                    lineCount = File.ReadLines(strCsvPath).Count();
                }
                    

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(strCsvPath, true, Encoding.UTF8))
                {
                    if(!boolfile)
                    { 
                        for (int i = 0; i < paramNameList.Count; i++)
                        {
                            if (paramNameList.Count == i + 1)
                                file.WriteLine(paramNameList[i]);
                            else
                                file.Write(paramNameList[i] + ",");
                        }
                        if(totalDistance[count] == 0)
                        {
                            file.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", lineCount + 1, 0, 0, 0, DateTime.Now.ToString("yy-MM-dd HH:mm:ss")," "));

                        }
                        else
                        {
                            file.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", lineCount + 1, Math.Round(leftDistance, 3, MidpointRounding.AwayFromZero), Math.Round(rightDistance, 3, MidpointRounding.AwayFromZero), Math.Round(totalDistance[count], 3, MidpointRounding.AwayFromZero), DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), " "));

                        }
                    }
                    else
                    {
                        if (totalDistance[count] == 0)
                        {
                            file.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", lineCount, 0, 0, 0, DateTime.Now.ToString("yy-MM-dd HH:mm:ss")," "));

                        }
                        else
                        {
                            file.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", lineCount, Math.Round(leftDistance, 3, MidpointRounding.AwayFromZero), Math.Round(rightDistance, 3, MidpointRounding.AwayFromZero), Math.Round(totalDistance[count], 3, MidpointRounding.AwayFromZero), DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), " "));

                        }
                    }
                    
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

    }
}