using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace LG_Chem.Device.Light
{
    public class L_Light_RS232 : ILight
    {
        public string Received = "";
        private SerialPort _serialPort = new SerialPort();
        private bool _lightOn = false;
        
        // 조명 On/Off
        public override void LightOn(bool bOn)
        {
            _lightOn = bOn;
            string _onoff = bOn ? "HTON" : "HTOF";
            SendData(_onoff);
        }

        public override bool IsLightOn()
        {
            return _lightOn;
        }

        #region Receive Parsing
        public class RecvStatus
        {
            public bool TrgStart = false;
            public bool ModelChange = false;
            public string StartTime = null;
            public int NewModel = 0;
            public void Reset() { ModelChange = false; TrgStart = false; }
        }

        public RecvStatus rcevStatus = new RecvStatus();

        public void ParseReceivedData(string recvData)
        {
            try
            {
                if (recvData == "*IDN?")
                {
                    SendData("PROGRAM Ver1.0");
                }
                // TRG,20170904 121122[CRLF]
                if (recvData.Substring(0, 3) == "TRG")
                {
                    rcevStatus.TrgStart = true;
                    rcevStatus.StartTime = recvData.Substring(4, 22);
                    SendData("TRG");
                }
                // MODEL,01[CRLF]
                if (recvData.Substring(0, 5) == "MODEL")
                {
                    rcevStatus.ModelChange = true;
                    rcevStatus.NewModel = Convert.ToInt32(recvData.Substring(6, 2));
                    SendData("MODEL");
                }
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
                _serialPort.ReadTimeout = 500;
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
            _serialPort.WriteLine(sendData);
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
        }
    }
}
