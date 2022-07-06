using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LG_Chem
{
    public class Machine
    {
        public LG_Chem.Device.Camera.CameraHik _Camera = new Device.Camera.CameraHik();
        public static Device.Camera.CameraManager _cameraManager = null;
        public static Logger _Logger = null;
        public static Config _Cfg = null;
        public static Device.Light.LightSerialCom _Light = null;

        private static FormErrorInfomation mFormErrorInfomation = new FormErrorInfomation();
        private static Thread formErrInfoThread = null;
        private static bool isFormErrInfoOpen = false;

        private static Machine _instance;

        public static Machine Instance()
        {
            if (_instance == null)
                _instance = new Machine();

            return _instance;
        }

        public static void Initialize()
        {
            //_Camera.FindCamera();       // 카메라 하드하게 설정 추후 Config Class 만들고 교체 예정
            //_Camera.camIdx = 0;
            //_Camera.ConnectCamera();
            _Cfg = new Config();
            _Cfg.LoadConfig();

            _Logger = new Logger();
            _Logger.Init();

            _Light = new Device.Light.LightSerialCom();
            _Light.Init();
            //_Light.LightSetLevelEn(_Cfg.mSetup.lightValue);

            _cameraManager = new Device.Camera.CameraManager();
            _cameraManager.Initialize(_Cfg.mSetup._camProperty);


        }
        public static void Terminate()
        {
            if (_cameraManager != null)
                _cameraManager.Terminate();
        }
        public void reconnect()
        {
            _cameraManager.Initialize(_Cfg.mSetup._camProperty);
        }
        public static void ShowErrorInfoDlg(string msg/*, bool viewBtn*/)
        {
            if (isFormErrInfoOpen)
            {
                formErrInfoThread.Abort();
                formErrInfoThread = null;

                mFormErrorInfomation = new FormErrorInfomation();
            }

            mFormErrorInfomation.SetMessage(msg);
            mFormErrorInfomation.FormClosed += FormErrorInfomation_FormClosed;
            isFormErrInfoOpen = true;

            //Machine.mLogger.log("Show Error Information Dialog. " + msg, LogType.ERROR);

            formErrInfoThread = new Thread(() => mFormErrorInfomation.ShowDialog());
            formErrInfoThread.Start();
        }

        private static void FormErrorInfomation_FormClosed(object sender, FormClosedEventArgs e)
        {
            isFormErrInfoOpen = false;
            mFormErrorInfomation.FormClosed -= FormErrorInfomation_FormClosed;
        }


    }
}
