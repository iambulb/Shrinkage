using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace LG_Chem.Device.Light
{
    public class TopRear
    {
        //(2020-08-24 수정 및 현장 채널 확인 필요 : RearBottom)
        public enum enChannel : int { Top, RearTop, RearBottom };

        private string[] m_strChaneels = { "C1", "C3", "C2" };

        private SerialPort serialPort = new SerialPort();

        //private byte[] recvBuf = new byte[1024];
        private string strReceived = "";

        public bool SendValue(enChannel channel, int value)
        {
            string strHex = Convert.ToString(value, 16);
            int Hex = Convert.ToInt32(strHex, 16);
            string strCmd = Hex.ToString("X");
            string StrCmd = strCmd.PadLeft(2, (char)'0');

            return SendData(m_strChaneels[(int)channel] + StrCmd);
        }

        public void SetValueAll(int top, int rearTop, int rearBottom)
        {
            //MyTimer timer = new MyTimer();

            //SendValue(enChannel.Top, top);
            //timer.Wait(10);
            //SendValue(enChannel.Top, top);
            //timer.Wait(10);
            //SendValue(enChannel.RearTop, rearTop);
            //timer.Wait(10);
            //SendValue(enChannel.RearTop, rearTop);
            //timer.Wait(10);
            //SendValue(enChannel.RearBottom, rearBottom);
            //timer.Wait(10);
            //SendValue(enChannel.RearBottom, rearBottom);
            //timer.Wait(10);
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
                Machine._Logger.log("TopRear 조명 Device initialize 실패", LogType.ERROR, false);
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
                    Machine._Logger.log("TopRear 컨트롤러 오픈 성공 Port : " + serialPort.PortName, LogType.DEBUG, false);
                    return true;
                }
                else
                {
                    Machine._Logger.log("TopRear 컨트롤러 오픈 실패 Port : " + serialPort.PortName, LogType.DEBUG, false);
                    return false;
                }
            }
            catch
            {
                Machine._Logger.log("TopRear 컨트롤러 오픈 Exception Port : " + serialPort.PortName, LogType.ERROR, false);
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
                Machine._Logger.log("TopRear 조명 컨트롤러 Close Exception", LogType.ERROR, false);
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
            Thread.Sleep(10);

            //Console.WriteLine("Light Send : " + strSendData);
            //this.mLogger.log(string.Format("Serial Com : Send Completed. [{0}]", strSendData), true);
            return true;
        }

        private bool Write(byte[] bySendData)
        {
            if (!serialPort.IsOpen)
                return false;

            strReceived = "";
            serialPort.DiscardInBuffer();
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
                Machine._Logger.log("TopRear 조명 Data Receive 실패", LogType.ERROR, false);
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