using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvCamCtrl.NET;


namespace LG_Chem.Device.Camera
{
    public delegate void DelBmp(int camNo, Bitmap bitmap);
    public delegate void DelSendErrMsg(string msg);

    public class CameraHik
    {
        private CameraProperty _property = new CameraProperty();

        public Action<int> DeleDisConnected;
        private bool _isConnectedError = false;
        private bool _isGrabbing = false;
        public bool _isConnected = false;
        private bool _isopen = false;
        public bool Accessible = false; // 끊김 체크
        private bool _IsGrabCompleted = true;

        private int _camNo = 0;
        public int camIdx = -1;
        public DelBmp handler;
        public List<Bitmap> _grabImageList = new List<Bitmap>();
        public Bitmap _bmp = null;
        public static Bitmap Livebmp = null;
        public bool GrabOk = false;
        private List<CameraHik> _cameraList = new List<CameraHik>();
        public eAcquisitionMode _acquisitionType = eAcquisitionMode.Single;
        private MyCamera.MV_CC_DEVICE_INFO _stDevInfo = new MyCamera.MV_CC_DEVICE_INFO();
        private MyCamera.MV_CC_DEVICE_INFO_LIST _stDevList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
        private MyCamera _camera = null;
        private MyCamera.cbOutputExdelegate _imageCallbackDele;
        MyCamera.MVCC_INTVALUE_EX _intExValue = new MyCamera.MVCC_INTVALUE_EX();
        MyCamera.MVCC_FLOATVALUE _floatValue = new MyCamera.MVCC_FLOATVALUE();
        MyCamera.MVCC_INTVALUE _intValue = new MyCamera.MVCC_INTVALUE();
        MyCamera.MVCC_FLOATVALUE _frameRateAbsValue = new MyCamera.MVCC_FLOATVALUE();
        public bool IsSaveMode = false;
        public DelSendErrMsg sendCamErrMsg;
        public MyCamera Camera { get => _camera; set => _camera = value; }
        private void ImageCallbackFunc(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX FrameInfo, IntPtr pUser)
        {
            int nRet = -1;

            try
            {
                if (pData == null)
                    return;

                int size = FrameInfo.nWidth * FrameInfo.nHeight;
                byte[] buffer = new byte[size];

                Marshal.Copy(pData, buffer, 0, size);

                Bitmap grabBitmap = ConvertToGray8BitBitmap(buffer, FrameInfo.nWidth, FrameInfo.nHeight);

                //_grabImageList.Add((Bitmap)grabBitmap.Clone());

                _bmp = (Bitmap)grabBitmap.Clone();
                

                if (_acquisitionType == eAcquisitionMode.Single)
                {
                    nRet = _camera.MV_CC_StopGrabbing_NET();
                }
                else if (_acquisitionType == eAcquisitionMode.Continuous)
                {
                    handler(_camNo, (Bitmap)grabBitmap.Clone());
                    Livebmp= (Bitmap)grabBitmap.Clone();
                }
                nRet = _camera.MV_CC_GetFloatValue_NET("ResultingFrameRate", ref _frameRateAbsValue);

                grabBitmap.Dispose();
            }
            catch (Exception ex)
            {
                //에러출력
                MessageBox.Show("카메라 연결을 확인해주세요!");
            }
        }

        private Bitmap ConvertToGray8BitBitmap(byte[] buffer, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            ColorPalette palette = bmp.Palette;
            Color[] _entries = palette.Entries;

            for (int i = 0; i < 256; i++)
            {
                Color b = new Color();
                b = Color.FromArgb((byte)i, (byte)i, (byte)i);
                _entries[i] = b;
            }

            bmp.Palette = palette;
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            Marshal.Copy(buffer, 0, bmpData.Scan0, buffer.Length);
            bmp.UnlockBits(bmpData);

            return bmp;
        }

        public List<string> FindCamera()
        {
            List<string> cameraNameList = new List<string>();
            int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref _stDevList);

            for (Int32 i = 0; i < _stDevList.nDeviceNum; i++)
            {
                string temp = "";
                _stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(_stDevList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));

                if (MyCamera.MV_GIGE_DEVICE == _stDevInfo.nTLayerType)
                {
                    MyCamera.MV_GIGE_DEVICE_INFO stGigEDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(_stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    uint nIp1 = ((stGigEDeviceInfo.nCurrentIp & 0xff000000) >> 24);
                    uint nIp2 = ((stGigEDeviceInfo.nCurrentIp & 0x00ff0000) >> 16);
                    uint nIp3 = ((stGigEDeviceInfo.nCurrentIp & 0x0000ff00) >> 8);
                    uint nIp4 = (stGigEDeviceInfo.nCurrentIp & 0x000000ff);
                    temp = i.ToString() + ": [GigE] User Define Name : " + stGigEDeviceInfo.chUserDefinedName + ", device IP :" + nIp1 + "." + nIp2 + "." + nIp3 + "." + nIp4 + ", " + stGigEDeviceInfo.chSerialNumber;
                }
                else if (MyCamera.MV_USB_DEVICE == _stDevInfo.nTLayerType)
                {
                    MyCamera.MV_USB3_DEVICE_INFO stUsb3DeviceInfo = (MyCamera.MV_USB3_DEVICE_INFO)MyCamera.ByteToStruct(_stDevInfo.SpecialInfo.stUsb3VInfo, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    temp = i.ToString() + ": [U3V] User Define Name : " + stUsb3DeviceInfo.chUserDefinedName + ", Serial Number : " + stUsb3DeviceInfo.chSerialNumber;
                }

                cameraNameList.Add(temp);
            }

            return cameraNameList;
        }
 
        public void ConnectCamera(MyCamera.MV_CC_DEVICE_INFO _stDevInfo)
        {
            try
            {
                if (_camera == null)
                {
                    _camera = new MyCamera();
                    int nRet = _camera.MV_CC_CreateDevice_NET(ref _stDevInfo);

                    if (OpenDevice())
                        _isConnected = true;
                    else
                        _isConnected = false;

                    _isopen = true;

                    if (!IsAccessible())


                    SetProperty(this._property);

                    if (MyCamera.MV_GIGE_DEVICE == _stDevInfo.nTLayerType)
                    {
                        MyCamera.MV_GIGE_DEVICE_INFO stGigeDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(_stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    }
           

                    _imageCallbackDele = new MyCamera.cbOutputExdelegate(ImageCallbackFunc);
                    nRet = _camera.MV_CC_RegisterImageCallBackEx_NET(_imageCallbackDele, IntPtr.Zero);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool OpenDevice()
        {
            int nRet;
            int nPacketSize;
            bool ret = false;
            nRet = _camera.MV_CC_OpenDevice_NET();

            if (_camera.MV_CC_IsDeviceConnected_NET())
            {
                FormMain.Instance().lbconnected.Text = "Connected";
                FormMain.Instance().lbconnected.BackColor = Color.Green;
            }

            if (nRet != MyCamera.MV_OK)
            {
                string msg = string.Format("Failed Open Device {0}", _camNo);
                if (sendCamErrMsg != null)
                    sendCamErrMsg(msg);
                Console.WriteLine(msg);
                ret = false;
            }
            else
                ret = true;

            nPacketSize = _camera.MV_CC_GetOptimalPacketSize_NET();
            if (nPacketSize > 0)
            {
                nRet = _camera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
                if (nRet != MyCamera.MV_OK)
                {
                    Console.WriteLine("Failed Set Packet Size");
                    ret = false;
                }
                else
                    ret = true;
            }

            return ret;
        }
        public bool ActiveProperty()
        {
            //_camera.MV_CC_SetAcquisitionMode_NET((uint)MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_SINGLE);

            int nRet;
            bool result = true;

            nRet = _camera.MV_CC_SetFloatValue_NET("ExposureTime", (float)this._property.Exposure);
            if (nRet != MyCamera.MV_OK)
            {
                result = false;
                string msg = string.Format("Set ExposureTime Failed {0}", this._camNo);
                if (sendCamErrMsg != null)
                    sendCamErrMsg(msg);

                Console.WriteLine(msg);
            }

            return result;
        }


        public void SetProperty()
        {
            throw new NotImplementedException();
        }
        public bool StartGrab()
        {
            try
            {
                //if (!IsAccessible())
                //    return false;

                if (!IsOpen())
                {
                    string message = "camera context is null. cam index : " + _camNo.ToString();
                    if (sendCamErrMsg != null)
                        sendCamErrMsg(message);
                    //Logger.Write(eLogType.ERROR, message, DateTime.Now);
                    return false;
                }

                if (!IsGrabbing())
                {
                    Console.WriteLine("CamNo : " + _camNo.ToString() + " Start Grab");
                    
                    //_acquisitionType = eAcquisitionMode.Continuous;

                    _camera.MV_CC_StartGrabbing_NET();
                    _IsGrabCompleted = false;
                    if (_acquisitionType == eAcquisitionMode.Continuous)
                    {
                        _isGrabbing = true;
                    }
                    
                }
                return true;
            }
            catch (Exception err)
            {
                //Logger.WriteException(eLogType.ERROR, err);
                return false;
            }
        }
        public void StartSingleGrab()
        {
            _acquisitionType = eAcquisitionMode.Single;

            int nRet = _camera.MV_CC_SetEnumValue_NET("AcquisitionMode", (uint)MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_SINGLE);
            nRet = _camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
            nRet = _camera.MV_CC_StartGrabbing_NET();

        }

        public void StartContinuousGrab()
        {
            if (_isGrabbing == false)
            {
                _acquisitionType = eAcquisitionMode.Continuous;

                int nRet = _camera.MV_CC_SetEnumValue_NET("AcquisitionMode", (uint)MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);
                nRet = _camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
                nRet = _camera.MV_CC_StartGrabbing_NET();
            }
        }
        public void Terminate()
        {
            try
            {
                int nRet;

                nRet = _camera.MV_CC_StopGrabbing_NET();
                _isGrabbing = false;
                nRet = _camera.MV_CC_CloseDevice_NET();
                _isopen = false;
                nRet = _camera.MV_CC_DestroyDevice_NET();
                if (nRet == MyCamera.MV_OK)
                {
                    string msg = string.Format("Destory Camera : Camnum {0}", _camNo);
                    if (sendCamErrMsg != null)
                        sendCamErrMsg(msg);
                    Console.WriteLine(msg);
                }
                _camera = null;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public bool IsOpen()
        {
            if (_camera == null)
            {
                this._isConnectedError = true;
                string message = "CamNo : " + _camNo.ToString() + " CameraContext = null ";
                //Logger.Write(eLogType.ERROR, message, DateTime.Now);
                return false;
            }

            _isopen = true;
            try
            {

                bool ret = _camera.MV_CC_IsDeviceConnected_NET();

                if (ret == false)
                {
                    string message = "CamNo : " + _camNo.ToString() + " IsOpen Error_Accessible : " + Accessible.ToString() + " IsConnected : "
                        + this._isConnected.ToString() + " IsOpen : " + this.IsOpen().ToString();

                    //Logger.Write(eLogType.ERROR, message, DateTime.Now);

                    this._isConnectedError = true;
                }
                else
                {
                    this._isConnectedError = false;
                }
                    

                if (!ret)
                {
                    if (DeleDisConnected != null)
                        DeleDisConnected(_camNo);
                }

                return ret;
            }
            catch
            {
                MessageBox.Show("카메라를 연결해주세요");
                return false;
            }
        }
        public void SetExpose(double expose)
        {
            int nRet = _camera.MV_CC_SetFloatValue_NET("ExposureTime", (float)expose);
            if (nRet != MyCamera.MV_OK)
            {
                string msg = string.Format("Set ExposureTime Failed {0}", this._camNo);
                Console.WriteLine(msg);
                if (sendCamErrMsg != null)
                    sendCamErrMsg(msg);
            }
        }

        public Bitmap Getbmp()
        {
            if (_bmp == null)
                return null;

            return _bmp;
        }

        public void SetProperty(CameraProperty param)
        {
            this._property = (CameraProperty)param;
        }
        public void SetCamNo(int camNo)
        {
            this._camNo = camNo;
        }

        public bool IsGrabbing()
        {
            return _isGrabbing;
        }
        public bool IsGrabCompleted()
        {
            return _IsGrabCompleted;
        }

        public bool StopGrab()
        {
            try
            {
                _camera.MV_CC_StopGrabbing_NET();

                _isGrabbing = false;
                string msg = "CamNo : " + _camNo.ToString() + " Stop Grab";
                Console.WriteLine(msg);
                if (sendCamErrMsg != null)
                    sendCamErrMsg(msg);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    
        private bool IsAccessible()
        {
            try
            {
                if (_camera == null)
                {
                    //Logger.Write(eLogType.ERROR, "Camera is not connected", DateTime.Now);
                    _isConnected = false;
                }

                return _camera.MV_CC_IsDeviceConnected_NET();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

                return false;
            }
        }
    }
}
