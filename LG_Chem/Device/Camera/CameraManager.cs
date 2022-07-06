using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace LG_Chem.Device.Camera
{
    public class CameraManager
    {
        private MyCamera.MV_CC_DEVICE_INFO_LIST _stDevList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
        public List<CameraHik> _cameraList = new List<CameraHik>();

        public DelBmp UpdateMergeImg = null;
        private bool _isGrabMode = false;

        public void Initialize(List<CameraProperty> camProList)
        {
            try
            {
                if (_cameraList.Count != 0)
                {
                    foreach (CameraHik camera in _cameraList)
                    {
                        camera.Terminate();
                    }
                    _cameraList.Clear();
                }

                int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref _stDevList);
                if (nRet != MyCamera.MV_OK)
                    return;
                //_cameraList에 add되는걸 막아야함.
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < _stDevList.nDeviceNum; j++)
                    {
                        MyCamera.MV_CC_DEVICE_INFO stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(_stDevList.pDeviceInfo[j], typeof(MyCamera.MV_CC_DEVICE_INFO));
                        string n = GetSerialNumber(stDevInfo);
                        if (camProList[i].SerialNumber == GetSerialNumber(stDevInfo))
                        {
                            camProList[i].CamName = SetCamProperty(stDevInfo).CamName;
                            camProList[i].CamAddress = SetCamProperty(stDevInfo).CamAddress;
                            _cameraList.Add(new CameraHik());
                            if (nRet != MyCamera.MV_OK)
                            {
                                Console.WriteLine("HIK Camera Create Device Failed.");
                            }

                            _cameraList[i].SetCamNo(i);
                            _cameraList[i].SetProperty(camProList[i]);
                            _cameraList[i].ConnectCamera(stDevInfo);
                            _cameraList[i].ActiveProperty();

                            break;
                        }

                    }
                }
                //for (int j = 0; j < _stDevList.nDeviceNum; j++)
                //    {
                //        MyCamera.MV_CC_DEVICE_INFO stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(_stDevList.pDeviceInfo[j], typeof(MyCamera.MV_CC_DEVICE_INFO));
                //        camProList[j].CamName = SetCamProperty(stDevInfo).CamName;
                //        camProList[j].CamAddress = SetCamProperty(stDevInfo).CamAddress;
                //        _cameraList.Add(new CameraHik());
                //        if (nRet != MyCamera.MV_OK)
                //        {
                //            Console.WriteLine("HIK Camera Create Device Failed.");
                //        }
                //        _cameraList[j].SetProperty(camProList[j]);
                //        _cameraList[j].SetCamNo(j);
                //        _cameraList[j].ConnectCamera(stDevInfo);
                //    }
            
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error Occured!", ex.Message);
                System.Windows.Forms.MessageBox.Show("Camera Not Found!");
            }
        }

        public bool StartGrab()
        {
            bool ret = true;
            _isGrabMode = true;
            Console.WriteLine("Start Grab");

            foreach (CameraHik camera in _cameraList)
            {
                ret |= camera.StartGrab();
                Thread.Sleep(10);
            }

            return ret;
        }
        public bool StopGrab()
        {
            bool ret = true;
            foreach (CameraHik camera in _cameraList)
            {
                ret |= camera.StopGrab();
            }
            _isGrabMode = false;
            return ret;
        }

        public bool IsGrabbing()
        {
            bool ret = true;
            foreach (CameraHik camera in _cameraList)
            {
                bool te = camera.IsGrabbing();
                ret &= camera.IsGrabbing();
            }
            return ret;
        }
        public void Terminate()
        {
            if (_cameraList == null)
                return;

            foreach (CameraHik camera in this._cameraList)
            {
                camera.Terminate();
            }
        }
        public bool SetProperty(int camNum, CameraProperty _property)
        {
            if (_cameraList != null && _cameraList[camNum].IsOpen() == false)
                return false;

            _cameraList[camNum].SetProperty(_property);
            return _cameraList[camNum].ActiveProperty();
        }
        public void SetSaveMode(bool isSaveMode)
        {
            if (_cameraList.Count == 0) return;

            foreach (CameraHik item in _cameraList)
            {
                item.IsSaveMode = isSaveMode;
            }
        }
        public void SetExpose(int camNo, double expose)
        {
            if (expose <= 0.002 || _cameraList.Count == 0)
                expose = 0.002;

            _cameraList[camNo].SetExpose(expose);
        }
        public void SetAcquisitionMode(eAcquisitionMode mode, bool useTriggerMode = false)
        {
            MyCamera.MV_CAM_ACQUISITION_MODE HIKMode = MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS;

            switch (mode)
            {
                case eAcquisitionMode.Single:
                    HIKMode = MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_SINGLE;
                    break;
                case eAcquisitionMode.Multi:
                    HIKMode = MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_MUTLI;
                    break;
                case eAcquisitionMode.Continuous:
                    HIKMode = MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS;
                    break;
            }

            foreach (CameraHik camera in _cameraList)
            {
                camera.Camera.MV_CC_SetAcquisitionMode_NET((uint)HIKMode);

                if (!useTriggerMode)
                    camera.Camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
                else
                    camera.Camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
            }
        }
        public List<CameraHik> GetCameraList()
        {
            return _cameraList;
        }
        private CameraProperty SetCamProperty(MyCamera.MV_CC_DEVICE_INFO stDevInfo)
        {
            MyCamera.MV_GIGE_DEVICE_INFO stGigEDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

            CameraProperty camPropety = new CameraProperty();
            camPropety.CamName = stGigEDeviceInfo.chModelName + "#" + stGigEDeviceInfo.chSerialNumber;
            uint nIp1 = ((stGigEDeviceInfo.nCurrentIp & 0xff000000) >> 24);
            uint nIp2 = ((stGigEDeviceInfo.nCurrentIp & 0x00ff0000) >> 16);
            uint nIp3 = ((stGigEDeviceInfo.nCurrentIp & 0x0000ff00) >> 8);
            uint nIp4 = (stGigEDeviceInfo.nCurrentIp & 0x000000ff);
            camPropety.CamAddress = nIp1 + "." + nIp2 + "." + nIp3 + "." + nIp4;
            return camPropety;
        }

        private string GetSerialNumber(MyCamera.MV_CC_DEVICE_INFO stDevInfo)
        {
            if (MyCamera.MV_GIGE_DEVICE == stDevInfo.nTLayerType)
            {
                MyCamera.MV_GIGE_DEVICE_INFO stGigeDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                return stGigeDeviceInfo.chSerialNumber;
            }
            return "";
        }

    }
}
