using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using enumType;
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
using LG_Chem.Device.Camera;
using System.Drawing.Imaging;
using LG_Chem.Device.DIO;

namespace LG_Chem
{
    public class Sequence
    {
        private Thread _seqThread = null;
        private Thread _PMhread = null;
        public static bool _isStop = false;
        public static bool _isEMO = false;
        private bool _isLoadFiles = false;
        private double pos = 86000;

        public SubSequence subSequence = new SubSequence();
        public CtrlTapDispaly ctrlTapDispaly = new CtrlTapDispaly();
        public Device.DIO.SERVO Servo = new SERVO();
        Setup setup = Machine._Cfg.mSetup;
        double dCmdPos = 0.0, dCmdVel = 0.0, dActPos = 0.0;
        public double caliDistance = 0;
        private int count = 0;
        private int rotacount = 0;
        public static eSeqStep _seqStep = eSeqStep.SEQ_STOP;
        private Bitmap bmp = null;
        private Bitmap _inspBitmap = null;
        public Bitmap InspBitmap
        {
            get { return _inspBitmap; }
            set { _inspBitmap = value; }
        }
        public static eSeqStep SeqStep
        {
            get { return _seqStep; }
            set { _seqStep = value; }
        }
        private static Sequence _instance;
        public static Sequence Instance()
        {
            if (_instance == null)
                _instance = new Sequence();

            return _instance;
        }

        public void StartSequence()
        {
            if(!_isEMO)
            {
                _isStop = false;
                _seqThread = new Thread(ThreadFunc);
                //_PMhread = new Thread(subSequence.PMRun);
                _seqThread.Start();
            }

        }

        private void ThreadFunc()
        {
            
            //Servo.AbsMove(400000);
            //_seqStep = eSeqStep.SEQ_INSPECTION;
            //pos = 89000;
            CAXM.AxmStatusSetPosMatch(0, 0.0);
            _seqStep = eSeqStep.SEQ_START;
            while (!_isStop)
            {
                SeqSteps();
                Thread.Sleep(500);
            }
        }

        private void SeqSteps()
        {
            try
            {
                switch (_seqStep)
                {
                    case eSeqStep.SEQ_STOP:
                        //조명 Off
                        //카메라 그랩 Stop
                        count = 0;
                        //pos = 86000;
                        DIO.OutputIndex(7, (uint)0);
                        DIO.OutputIndex(6, (uint)1);
                        Sequence._isEMO = true;
                        //CAXM.AxmStatusSetPosMatch(0, 0.0);
                        _isStop = true;
                        MessageBox.Show("Reset를 누른 후 Start를 눌러주세요");
                        break;

                    case eSeqStep.SEQ_START:
                        //CAXM.AxmStatusGetActPos(0, ref dActPos);
                        
                        Servo.AbsMove(400000);
                        pos = 89000;
                        
                        _seqStep = eSeqStep.SEQ_INIT;

                        break;

                    case eSeqStep.SEQ_INIT:
                        Thread.Sleep(100);
                        
                        if (!Servo.Limit())
                        {
                            CAXM.AxmStatusSetPosMatch(0, 0.0);
                            _seqStep = eSeqStep.SEQ_INSPECTION;
                        }

                        //else if (dActPos < -370000)
                        //{
                        //    CAXM.AxmStatusSetPosMatch(0, 0.0);
                        //    _seqStep = eSeqStep.SEQ_INSPECTION;
                        //}
                        break;


                    case eSeqStep.SEQ_INSPECTION:

                        if (SERVO.dActPos < 500)
                        {
                            DIO.OutputIndex(0, (uint)0);
                            DIO.OutputIndex(1, (uint)0);
                            DIO.OutputIndex(2, (uint)1);
                            subSequence.count = -1;
                            Servo.Move(-90000);
                            //Thread.Sleep(1000);
                        }
                        if (SERVO.dActPos > pos)
                        {
                            Machine._Light.LightOnOffEN(true);
                            DIO.OutputIndex(6, (uint)0);
                            DIO.OutputIndex(7, (uint)1);
                            

                            if (DIO.bDown)
                            {
                                Machine._cameraManager._cameraList[0]._acquisitionType = eAcquisitionMode.Single;
                                Machine._cameraManager._cameraList[1]._acquisitionType = eAcquisitionMode.Single;
                                Machine._cameraManager.StartGrab();
                                
                                subSequence.PMRun();
                                Thread.Sleep(300);
                                

                                FormMain.Instance().TotalData.ReadCsv();
                                DIO.OutputIndex(7, (uint)0);
                                DIO.OutputIndex(6, (uint)1);
                                Machine._Light.LightOnOffEN(false);

                                SaveImage();
                                Thread.Sleep(200);

                                count++;

                                if (count != setup.count)
                                {
                                    Servo.Move(-29000);
                                    pos = pos + 29000;
                                }

                                if (count == setup.count)
                                {
                                    count = 0;
                                    _seqStep = eSeqStep.SEQ_END;
                                }


                                //갯수 횟수 기능 구상중
                                //rotacount++;

                                //if (count != 0)
                                //{
                                //    Servo.Move(-29000);
                                //    pos = pos + 29000;

                                //    count++;
                                //}
                                ////else
                                ////{
                                ////    Servo.Move((29000 * (count - 1)));
                                ////    pos = pos - (29000 * (count - 1));

                                ////    count = 0;
                                ////}

                                //if (rotacount == 100)
                                //{
                                //    count = 0;
                                //    rotacount = 0;
                                //    _seqStep = eSeqStep.SEQ_END;
                                //}
                            }
                        }
                        
                        
                        //if (dActPos == 347500)
                        //{
                        //    if (SERVO.dActPos > pos)
                        //    {
                        //        _seqStep = eSeqStep.SEQ_END;
                        //    }
                        //}
                            
                        break;
                   

                    case eSeqStep.SEQ_END:
                        //조명 OFF
                        count = 0;
                        DIO.OutputIndex(2, (uint)0);
                        DIO.OutputIndex(1, (uint)0);
                        DIO.OutputIndex(0, (uint)1);
                        Machine._Light.LightOnOffEN(false);
                        //if(SERVO.dActPos == 347500)
                        
                         Servo.AbsMove(400000);
                        
                        _isStop = true;
                        break;
                  
                }

            }
            catch (Exception ex)
            {
                //에러출력
                MessageBox.Show(ex.ToString());

                _seqStep = eSeqStep.SEQ_ERROR;
                _isStop = true;
                _isLoadFiles = false;
            }
            


        }
        public void SaveImage()
        {
            try
            {
                string strFilePath = string.Format(@"{0}\{1:00}\{2:00}\{3:00}", System.IO.Directory.GetCurrentDirectory() + "\\Image", DateTime.Now.Year,DateTime.Now.Month, DateTime.Now.Day);
                //string ImagePath = string.Format(@"{0}\{1:00}\{2:00}\Image_{3:0000}{4:00}{5:00}_", strFilePath, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                string csvPath = string.Format(@"{0}\{1:00}\{2:00}\{3:00}", System.IO.Directory.GetCurrentDirectory() + "\\Csv", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                int csvlinecount = File.ReadLines(csvPath + "\\ResultData.csv").Count() - 1;
                if (Directory.Exists(strFilePath) == false)
                {
                    Directory.CreateDirectory(strFilePath);
                }
                
                for (int camIdx = 0; camIdx < Machine._cameraManager._cameraList.Count; camIdx++)
                {
                    bmp = Machine._cameraManager._cameraList[camIdx].Getbmp();
                    
                    if(camIdx%2 == 0)
                    {
                        bmp.Save(strFilePath + "\\" + csvlinecount + "_L" + ".bmp", ImageFormat.Bmp);

                        FileInfo fi = new FileInfo(strFilePath + "\\" + csvlinecount + "_L" + ".bmp");
                        bool d = fi.Exists;
                        while (!d)
                        {
                            d = Directory.Exists(strFilePath + "\\" + csvlinecount + "_L" + ".bmp");
                        }
                        bmp.Dispose();
                        GC.Collect();
                    }
                    else
                    {
                        bmp.Save(strFilePath + "\\" + csvlinecount + "_R" + ".bmp", ImageFormat.Bmp);

                        FileInfo fi = new FileInfo(strFilePath + "\\" + csvlinecount + "_R" + ".bmp");
                        bool d = fi.Exists;
                        while (!d)
                        {
                            d = Directory.Exists(strFilePath + "\\" + csvlinecount + "_R" + ".bmp");
                        }
                        bmp.Dispose();
                        GC.Collect();
                    }


                }
                Machine._Logger.log("Save SubImage success.", LogType.DEBUG, true);

            }
            catch (Exception ex)
            {
                //에러출력
                MessageBox.Show(ex.ToString());
                Machine._Logger.log("Save SubImage fail.", LogType.DEBUG, true);
            }
        }
        public void StartCalibration()
        {
            if (!_isEMO)
            {
                _isStop = false;
                _seqThread = new Thread(ThreadCal);
                _seqThread.Start();
            }

        }

        private void ThreadCal()
        {
            int calicount = 0;
            
            Servo.AbsMove(400000);
            _seqStep = eSeqStep.SEQ_INSPECTION;
            pos = 89000;
            CAXM.AxmStatusSetPosMatch(0, 0.0);

            while (!_isStop)
            {
                if (SERVO.dActPos < 500)
                {
                    DIO.OutputIndex(0, (uint)0);
                    DIO.OutputIndex(1, (uint)0);
                    DIO.OutputIndex(2, (uint)1);
                    Servo.Move(-90000);
                    Thread.Sleep(1000);
                }
                if (SERVO.dActPos > pos)
                {
                    Machine._Light.LightOnOffEN(true);
                    DIO.OutputIndex(6, (uint)0);
                    DIO.OutputIndex(7, (uint)1);


                    if (DIO.bDown)
                    {
                        Machine._cameraManager._cameraList[0]._acquisitionType = eAcquisitionMode.Single;
                        Machine._cameraManager._cameraList[1]._acquisitionType = eAcquisitionMode.Single;
                        Machine._cameraManager.StartGrab();
                        Thread.Sleep(500);
                        subSequence.PMAlignCalibration();
                        Thread.Sleep(500);
                        DIO.OutputIndex(7, (uint)0);
                        DIO.OutputIndex(6, (uint)1);

                        Machine._Light.LightOnOffEN(false);

                        //SaveImage();
                        Thread.Sleep(500);

                        calicount++;
                        caliDistance += subSequence.CalibrationDistance;
                        if (calicount != 2)
                        {
                            Servo.Move(-261000);
                            pos = pos + 261000;
                        }


                        if (calicount == 2)
                        {
                            
                            caliDistance = caliDistance / 2;
                            
                            caliDistance = 0;
                            calicount = 0;
                            Servo.AbsMove(400000);
                            _isStop = true;
                        }

                    }
                }
                Thread.Sleep(500);
                
            }
            DIO.OutputIndex(0, (uint)1);
            DIO.OutputIndex(1, (uint)0);
            DIO.OutputIndex(2, (uint)0);
        }


    }
}
