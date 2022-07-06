using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LG_Chem
{
    public enum LogType
    {
        DEBUG,
        ERROR,
        RELEASE,
        USER,
        PLC
    }

    public class Logger
    {
        // static
        public static string LogDir = string.Empty;

        public static string ResultDir = string.Empty;
        public static string ImageDir = string.Empty;

        //(20-08-23 수정)
        //public static string ConnectorDir = string.Empty;
        private object objLock_1 = new object();

        public void Init()
        {
            try
            {
                string strDir = System.IO.Directory.GetCurrentDirectory() + "\\Log";
                if (!Directory.Exists(strDir))
                    Directory.CreateDirectory(strDir);
                LogDir = strDir;

                //(20-06-24 수정)
                strDir = Machine._Cfg.mSetup.ResultFolderPath;
                if (!Directory.Exists(strDir) && strDir != "")
                    Directory.CreateDirectory(strDir);
                ResultDir = strDir;

                //(20-06-24 수정)
                strDir = Machine._Cfg.mSetup.ImageFolderPath;
                if (!Directory.Exists(strDir) && strDir != "")
                    Directory.CreateDirectory(strDir);
                ImageDir = strDir;

                //(20-08-23 수정)
                //strDir = Machine.mCfg.mSetup.ConnectorFolderPath;
                //if (!Directory.Exists(strDir) && strDir != "")
                //    Directory.CreateDirectory(strDir);
                //ConnectorDir = strDir;
            }
            catch
            {
                // throw;
            }
        }

        public Logger()
        {
        }

        private string getLogPath(LogType logType)
        {
            string logPath = string.Format(@"{0}\{1:00}\{2:00}\{3:00}\log_{4:0000}{5:00}{6:00}_" + logType.ToString() + ".log", LogDir, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            return logPath;
        }

        private string makeFileNameWithTime()
        {
            string strTime = string.Format(@"{0:00}:{1:00}:{2:00}.{3:000}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
            return strTime;
        }

        public static void DeleteFilesInDir(string dir, string searchPattern, int day)
        {
            DirectoryInfo path = new DirectoryInfo(dir);
            dirs(path, searchPattern, day);
        }

        private static void dirs(DirectoryInfo path, string searchPattern, int day)
        {
            DirectoryInfo[] di = path.GetDirectories();

            if (di.Length < 1)
            {
                return;
            }

            for (int i = 0; i < di.Length; i++)
            {
                if (di[i].GetFiles().Count<FileInfo>() < 1 && di[i].GetDirectories().Count<DirectoryInfo>() < 1) // 하위 폴더가 빈 폴더면 삭제
                {
                    di[i].Delete();
                }
                else
                {
                    Files(di[i], searchPattern, day);
                    dirs(di[i], searchPattern, day);
                }
            }
        }

        private static void Files(DirectoryInfo di, string searchPattern, int day)
        {
            try
            {
                //DateTime dayAgoTime = DateTime.Today.AddDays(-day);
                DateTime dayAgoTime = DateTime.Now.AddSeconds(-(day * 86400)); // LogDays 를 -day로 해놓을경우 오전 12시기준으로 맞춰져 버리므로, 현재시간에서 초단위까지 맞추도록 설정하여 그때그때 지워지도록.

                foreach (FileInfo fileName in di.GetFiles())
                {
                    if (searchPattern.Equals(".*"))
                    {
                        DateTime dt = fileName.CreationTime;
                        if (dayAgoTime > dt) //반대로 바꾸고 확장자 바꿔야함
                        {
                            fileName.Delete();
                        }
                    }
                    else if (fileName.Extension.Equals(searchPattern))
                    {
                        DateTime dt = fileName.CreationTime;
                        if (dayAgoTime > dt) //반대로 바꾸고 확장자 바꿔야함
                        {
                            fileName.Delete();
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                Machine._Logger.log("디렉토리 찾기 실패", LogType.ERROR, false);
            }
        }

        //public void loguser(string logMessage)
        //{
        //    logMessage = "[" + Machine.mUserSession.m_userName + "] " + logMessage;
        //    log(logMessage, LogType.RELEASE, false);
        //}

        public void log(string logMassage, LogType logType, bool bUpdateUI)
        {
            string logpath = getLogPath(logType);
            string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));
            string fname = makeFileNameWithTime();

            string str = str = "[" + fname + "] " + logMassage;
            //Console.WriteLine(str);

            try
            {
                lock (objLock_1)
                {
                    if (!Directory.Exists(strDir))
                        Directory.CreateDirectory(strDir);

                    using (StreamWriter sw = new StreamWriter(logpath, true))
                    {
                        sw.WriteLine(str);
                    }
                }

                //if (bUpdateUI)
                //{
                //    if (Program.MainForm.instance().mFrmMain != null)
                //        Program.MainForm.mFrmMain.UpdateLogMsg(str);
                //}
            }
            catch(Exception ex)
            {
                log("log 남기기 실패", LogType.ERROR, false);
            }
        }

        ////기본 Log저장
        //public void log(string strlog, LogType logType)
        //{
        //    string strTime = string.Format(@"{0:00}:{1:00}:{2:00}.{3:000}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
        //    string logpath = string.Format(@"{0}\{1:00}\{2:00}\log_{3:0000}{4:00}{5:00}_"+ logType.ToString() +".log",LogDir, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        //    string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));
        //    try
        //    {
        //        if (!Directory.Exists(strDir))
        //            Directory.CreateDirectory(strDir);

        //        StreamWriter sw = new StreamWriter(logpath, true);
        //        string str = "";
        //        using (sw)
        //        {
        //            str = "[" + strTime + "] " + strlog;
        //            sw.WriteLine(str);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(this.ToString() + ":" + Utility.GetCurrentMethod() + ", " + ex.Message);
        //    }
        //}

        ////지정 폴더 Log저장
        //public void log(string logpath, string strlog)
        //{
        //    string strTime = string.Format(@"{0:00}:{1:00}:{2:00}.{3:000}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
        //    //string logpath = string.Format(@"{0}\{1:00}\{2:00}\log_{3:0000}{4:00}{5:00}.log", LogDir, DateTime.Now.Month, DateTime.Now.Date, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Date);
        //    string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));
        //    try
        //    {
        //        if (!Directory.Exists(strDir))
        //            Directory.CreateDirectory(strDir);

        //        StreamWriter sw = new StreamWriter(logpath, true);
        //        string str = "";
        //        using (sw)
        //        {
        //            str = "[" + strTime + "] " + strlog;
        //            sw.WriteLine(str);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(this.ToString() + ":" + Utility.GetCurrentMethod() + ", " + ex.Message);
        //    }
        //}

        ////Log저장 및 UpdateUI
        //public void log(string strlog, bool bUpdateUI)
        //{
        //    string strTime = string.Format(@"{0:00}:{1:00}:{2:00}.{3:000}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
        //    string logpath = string.Format(@"{0}\{1:00}\{2:00}\log_{3:0000}{4:00}{5:00}.log", LogDir, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Date);
        //    string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));
        //    try
        //    {
        //        if (!Directory.Exists(strDir))
        //            Directory.CreateDirectory(strDir);

        //        StreamWriter sw = new StreamWriter(logpath, true);
        //        string str = "";
        //        using (sw)
        //        {
        //            str = "[" + strTime + "] " + strlog;
        //            sw.WriteLine(str);
        //        }

        //        if (bUpdateUI)
        //        {
        //            if(GECD.MainForm != null)
        //            GECD.MainForm.UpdateLogMsg(str);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(this.ToString() + ":" + Utility.GetCurrentMethod() + ", " + ex.Message);
        //    }
        //}
    }
}