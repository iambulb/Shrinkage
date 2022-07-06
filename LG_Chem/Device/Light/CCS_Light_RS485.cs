using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace LG_Chem.Device.Light
{
    public class CCS_Light_RS485 : ILight
    {
        public string Received = "";
        private SerialPort _serialPort = new SerialPort();
        private bool _lightOn = false;
        private const string CRLF = "\r\n";
        // 조명 On/Off
        public override void LightOn(bool bOn)
        {
            _lightOn = bOn;
            string _onoff = bOn ? "@00L100" : "@00L000";
            SendData(_onoff);
        }

        public override bool IsLightOn()
        {
            return _lightOn;
        }
        #region Receive Parsing
        public class RecvStatus
        {
            public string Message = "";
        }

        public RecvStatus rcevStatus = new RecvStatus();

        public void ParseReceivedData(string recvData)
        {
            try
            {
                rcevStatus.Message = "";
                rcevStatus.Message = recvData;
            }
            catch (Exception)
            {
                //string str = "";
                //str = m_serialPort.ToString() + ":" + Utility.GetCurrentMethod() + ", " + ex.Message;
            }
        }
        #endregion
        public override void Init(string com, int baudRate)
        {
            string _comPort = com;
            int _baudRate = baudRate;
            Init_Device(_comPort, _baudRate, 8, Parity.None, StopBits.One, 2000);
            PortOpen();
        }

        private void Init_Device(string com, int baudRate, int dataBit, Parity parity, StopBits stopBit, int timeOut)
        {
            try
            {
                if (_serialPort.IsOpen == true)
                    _serialPort.Close();

                _serialPort.PortName = com;
                _serialPort.BaudRate = baudRate;
                _serialPort.DataBits = dataBit;
                _serialPort.Parity = parity;
                _serialPort.StopBits = stopBit;
                _serialPort.ReadTimeout = timeOut;
                _serialPort.NewLine = "\r\n";
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            }
            catch (Exception)
            {
            }
        }

        private bool PortOpen()
        {
            try
            {
                if (_serialPort.IsOpen == true)
                    _serialPort.Close();

                _serialPort.Open();
                if (_serialPort.IsOpen)
                {
                    ResetBuffer();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool PortClose()
        {
            try
            {
                if (_serialPort.IsOpen == true)
                    _serialPort.Close();

                if (!_serialPort.IsOpen)
                {
                    _serialPort.Dispose();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override void Terminate()
        {
            try
            {
                PortClose();
            }
            catch (Exception)
            { }
        }

        private void ResetBuffer()
        {
            Received = "";
            _serialPort.DiscardInBuffer();
            _serialPort.DiscardOutBuffer();
        }

        public override bool SendData(string sendData)
        {
            if (!_serialPort.IsOpen)
                return false;

            ResetBuffer();

            string strData = "";
            strData = sendData;
            strData += makeChecksum(strData);
            strData += CRLF;

            _serialPort.WriteLine(strData);
            return true;
        }

        public override bool SendData(byte[] sendData)
        {
            if (!_serialPort.IsOpen)
                return false;

            ResetBuffer();
            _serialPort.Write(sendData, 0, sendData.Length);

            return true;
        }

        private string makeChecksum(string strSendData)
        {
            string strData = "";
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(strSendData);

            byte[] data = new byte[temp.Length + 4];
            int sum = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                data[i] = temp[i];
                sum = sum + temp[i];
            }
            strData = string.Format("{0:X2}", sum);
            strData = strData.Substring(strData.Length - 2, 2);
            return strData;
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int readcount = _serialPort.BytesToRead;
                Received = _serialPort.ReadLine();
                //Logger.log(string.Format("Serial Com : Received [{0}]", Received), LogType.DEBUG, false);
                ParseReceivedData(Received);
            }
            catch (Exception)
            {
                //string str = "";
                //str = m_serialPort.ToString() + ":" + Utility.GetCurrentMethod() + ", " + ex.Message;
            }
        }

        public override void SetLightValue(int value)
        {
            if (!_serialPort.IsOpen)
                return;
            SendData("@00F" + value.ToString("D3") + "00");
        }
    }
}
