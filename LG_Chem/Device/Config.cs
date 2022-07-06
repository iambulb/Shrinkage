using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;

namespace LG_Chem
{
    public enum EImagetype
    { JPG, BMP, PNG };

    [Serializable]
    public class Setup
    {
        // system setup
        public string LineID = "LG"; // 라인ID

        public string Oper = "Hanmech"; // 공정

        public string CurrentModel = "Default";

        //0 = pass,  1 = inspection
        public bool IsPassMode = false;

        public List<CameraProp> CamProp = new List<CameraProp>();

        ///Sindo_RYU_20210805
        public List<Device.Camera.CameraProperty> _camProperty = new List<Device.Camera.CameraProperty>();

        //LightSerialCom
        public int lightValue = 150;

        public double middleValue = 0;

        public double servospeed = 100000;

        public int count = 10;


        //Light
        public List<LightProp> lightProp = new List<LightProp>();

        //PLC
        public PlcProp PlcProp = new PlcProp();

        //0 = pass,  1 = inspection
        public MesProp MesProp = new MesProp();

        // 조명 관리 추가
        //public List<LightLuxProp> LightLux = new List<LightLuxProp>();

        public EImagetype eimgtype = EImagetype.PNG;

        public string ImageFolderPath = Logger.ImageDir;

        public string ResultFolderPath = Logger.ResultDir;
        public int ConnectorDay = 180;

        public string UsedDiskPercentage = "80";

        public string plcFilePath = string.Empty;

        public string Alaram_Status_Path = string.Empty;
    }

    public class Config
    {
        public Setup mSetup = new Setup();

        public void LoadConfig()
        {
            try
            {
                Load<Setup>(ref mSetup);
                //if (mSetup.LightLux.Count != CameraInterface.CAM_COUNT)
                //{
                //    for (int iCam = 0; iCam < CameraInterface.CAM_COUNT; iCam++)
                //    {
                        //LightLuxProp camInsp = new LightLuxProp();
                        //mSetup.LightLux.Add(camInsp);
                    //}
                    SaveConfig();
                //}
            }
            catch
            {
                Machine._Logger.log("Config Data 로드 실패", LogType.ERROR, false);
            }
        }

        public bool SaveConfig()
        {
            return Save<Setup>(mSetup, true);
        }

        public static bool Load<T>(ref T obj)
        {
            //string strDir = Program.VERSION + ".Setup\\Config";
            string strDir = System.Environment.CurrentDirectory + "\\Config";
            string strPath = strDir + "\\LG_Chem.Setup.cfg";

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));

                if (!Directory.Exists(strDir))
                    Directory.CreateDirectory(strDir);

                if (!File.Exists(strPath))
                {
                    using (TextWriter w = new StreamWriter(strPath))
                    {
                        xml.Serialize(w, obj);
                    }
                }

                using (TextReader r = new StreamReader(strPath))
                {
                    obj = (T)xml.Deserialize(r);
                }
                return true;
            }
            catch
            {
                Machine._Logger.log("Config Data Xml 로드 실패", LogType.ERROR, false);
                return false;
            }
        }

        public static bool Save<T>(T obj, bool bBackup)
        {
            try
            {
                //string strDir = Program.VERSION + ".Setup" +"\\Config";
                string strDir = System.Environment.CurrentDirectory + "\\Config";
                string strPath = strDir + "\\LG_Chem.Setup.cfg";

                if (bBackup)
                {
                    string strBackupPath = strPath + ".bak";
                    if (File.Exists(strBackupPath))
                    {
                        File.Delete(strBackupPath);
                    }
                    File.Move(strPath, strBackupPath);
                }

                XmlSerializer xml = new XmlSerializer(typeof(T));
                using (TextWriter w = new StreamWriter(strPath))
                {
                    xml.Serialize(w, obj);
                }
            }
            catch
            {
                Machine._Logger.log("Config Data Xml 세이브 실패", LogType.ERROR, false);
                return false;
            }

            return true;
        }
    }

    public class CameraProp
    {
        public string SerialNumber;
        public double dExposure;
    }

    public class PlcProp
    {
        public string ipAddress = "100.100.100.20";
        public int port = 4100;
        public int alaram_port = 1000;
    }

    public class MesProp
    {
        public bool bUseMes = true;
        public string ipAddress = "127.0.0.1";
        public int port = 9000;
    }

    public class LightProp
    {
        public string LightFrontPort = "COM5";
        public string LightTopRealPort = "COM4";
    }

    // 조명 관리 추가.
    //public class LightLuxProp
    //{
    //    [XmlAttribute]
    //    public int No;

    //    // 조명
    //    public int LightFrontTop;

    //    public int LightFrontBottom;
    //    public int LightFrontLeft;
    //    public int LightFrontRight;

    //    public int LightTop;

    //    //(2020-08-24 수정)
    //    public int LightRearTop;

    //    public int LightRearBottom;

    //    // 카메라 노출
    //    public double CamExposure = 20;

    //    //조명 Lux값 측정
    //    public double LightLux = 0;

    //    public Rectangle roi = new Rectangle();

    //    public LightLuxProp()
    //    {
    //        InitLight();
    //    }

    //    public LightLuxProp(int iNo)
    //    {
    //        No = iNo;
    //        InitLight();
    //    }

    //    public void InitLight()
    //    {
    //        if (No == 0 || No == 1)
    //        {
    //            LightFrontTop = 20;
    //            LightFrontBottom = 20;
    //            LightFrontLeft = 20;
    //            LightFrontRight = 20;

    //            LightTop = 0;
    //            LightRearTop = 0;
    //            LightRearBottom = 0;
    //        }
    //        else if (No == 2)
    //        {
    //            LightFrontTop = 0;
    //            LightFrontBottom = 0;
    //            LightFrontLeft = 0;
    //            LightFrontRight = 0;

    //            LightTop = 30;
    //            LightRearTop = 0;
    //            LightRearBottom = 0;
    //        }
    //    }
    //}
}