using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using LG_Chem;
using System.Threading;

namespace LG_Chem.Device.Light
{
    public class Front
    {
        public enum enFrontCh : int { Top, Bottom, Left, Right };

        private string[] m_strChaneels = { "C1", "C2", "C3", "C4" };

        private SerialPort serialPort = new SerialPort();

        //private byte[] recvBuf = new byte[1024];
        private string strReceived = "";

        public bool SendValue(int index, int value)
        {
            string strHex = Convert.ToString(value, 16);
            int Hex = Convert.ToInt32(strHex, 16);
            string strCmd = Hex.ToString("X");
            string StrCmd = strCmd.PadLeft(2, (char)'0');

            return SendData(m_strChaneels[index] + StrCmd);
        }

        // 전면 개별
        public void SetValueTopBottomLeftRight(int top, int bottom, int left, int right)
        {
            // 커맨드 일단 한번 더 보내기.
            // TODO: 리시브 처리.
            //MyTimer timer = new MyTimer();

            //SendValue((int)enFrontCh.Top, top);
            //timer.Wait(10);
            //SendValue((int)enFrontCh.Top, top);
            //timer.Wait(10);
            //SendValue((int)enFrontCh.Bottom, bottom);
            //timer.Wait(10);
            //SendValue((int)enFrontCh.Bottom, bottom);
            //timer.Wait(10);
            //SendValue((int)enFrontCh.Left, left);
            //timer.Wait(10);
            //SendValue((int)enFrontCh.Left, left);
            //timer.Wait(10);
            //SendValue((int)enFrontCh.Right, right);
            //timer.Wait(10);
            //SendValue((int)enFrontCh.Right, right);
            //timer.Wait(10);
        }

        // 전면 개별
        public void SetValueTopBottomLeftRight(string top, string bottom, string left, string right)
        {
            SetValueTopBottomLeftRight(
                Convert.ToInt32(top),
                Convert.ToInt32(bottom),
                Convert.ToInt32(left),
                Convert.ToInt32(right));
        }

        // 전면 4개 모드 동일 값으로 설정
        public void SetValueAll(int front)
        {
            for (int i = 0; i < 4; i++)
            {
                SendValue(i, front);
            }
        }

        public void Init(string sPortName)
        {
            string PortName = sPortName;
            int PortSpeed = 9600;

            Init_Device(PortName, PortSpeed, 8, Parity.None, StopBits.One, 2000);
        }

        private void Init_Device(string strPortName, int iBundRate, int idataBit, Parity nParity, StopBits nStopBit, int iTimeOut)
        {
            try
            {
                if (serialPort.IsOpen == true) serialPort.Close();

                serialPort.ReadTimeout = iTimeOut;
                serialPort.BaudRate = iBundRate;
                serialPort.PortName = strPortName;
                serialPort.DataBits = idataBit;
                serialPort.Parity = nParity;
                serialPort.StopBits = nStopBit;
                serialPort.NewLine = "\r\n";
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            }
            catch
            {
                Machine._Logger.log("Front 조명 Device initialize 실패", LogType.ERROR, false);
            }
        }

        public bool PortOpen()
        {
            try
            {
                if (serialPort.IsOpen == true)
                    serialPort.Close();

                serialPort.Open();

                if (serialPort.IsOpen)
                {
                    ResetBuffer();
                    Machine._Logger.log("Front 조명 컨트롤러 오픈 성공 Port : " + serialPort.PortName, LogType.DEBUG, false);
                    return true;
                }
                else
                {
                    Machine._Logger.log("Front 조명 컨트롤러 오픈 실패 Port : " + serialPort.PortName, LogType.DEBUG, false);
                    return false;
                }
            }
            catch
            {
                Machine._Logger.log("Front 조명 컨트롤러 오픈 Exception Port : " + serialPort.PortName, LogType.ERROR, false);
                return false;
            }
        }

        public bool PortClose()
        {
            try
            {
                if (serialPort.IsOpen == true) serialPort.Close();

                if (!serialPort.IsOpen)
                {
                    serialPort.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Machine._Logger.log("Front 조명 컨트롤러 close Exception", LogType.ERROR, false);
                return false;
            }
        }

        public bool IsOpen()
        {
            return serialPort.IsOpen;
        }

        public bool TurnOn()
        {
            return SendData("HTON");
        }

        public bool TurnOff()
        {
            return SendData("HTOF");
        }

        private void ResetBuffer()
        {
            strReceived = "";
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
        }

        private bool SendData(string strSendData)
        {
            if (!serialPort.IsOpen)
                return false;

            strReceived = "";
            serialPort.DiscardOutBuffer();
            serialPort.WriteLine(strSendData);

            //Console.WriteLine("Light Send : " + strSendData);
            //this.mLogger.log(string.Format("Serial Com : Send Completed. [{0}]", strSendData), true);
            return true;
        }

        private bool Write(byte[] bySendData)
        {
            if (!serialPort.IsOpen)
                return false;

            strReceived = "";
            serialPort.DiscardOutBuffer();

            serialPort.Write(bySendData, 0, bySendData.Length);
            return true;
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int readcount = serialPort.BytesToRead;
                strReceived = serialPort.ReadLine();
                //#if DEBUG
                //                Console.WriteLine("Light recv : " + strReceived);
                //#endif
                //Machine.mLogger.log(string.Format("Serial Com : Received [{0}]", strReceived) ,true);

                ParseReceivedData(strReceived);
            }
            catch
            {
                Machine._Logger.log("Front 조명 Data Receive 실패", LogType.ERROR, false);
            }
        }

        public class RcvStatus
        {
            public bool TrgStart = false;
            public bool ModelChange = false;
            public string StartTime = null;
            public int NewModel = 0;

            public void Reset()
            {
                ModelChange = false; TrgStart = false;
            }
        }

        private RcvStatus rcvStatus = new RcvStatus();

        private void ParseReceivedData(string strReceived)
        {
            if (strReceived.Length == 4)
            {
                if (strReceived.Substring(0, 1) == "R")
                {
                    // 정상 수신.
                    return;
                }
            }
            // 비정상 수신일 가능성 높음.
            Machine._Logger.log("Light recv ( may not OK ) : " + strReceived, LogType.DEBUG, false);
        }
    }
}