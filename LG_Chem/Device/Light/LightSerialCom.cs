using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Drawing;

namespace LG_Chem.Device.Light
{
    public class LightSerialCom
    {

        public SerialPort serialPort = new SerialPort();
        public Action<string> deleLog = null;
        public bool LightOk = false;
        //byte[] recvBuf = new byte[1024];
        public string strReceived = "";

        public void Init(string sPortName = "COM3", int sPortSpeed = 9600)
        {
            string PortName = sPortName;
            int PortSpeed = sPortSpeed;

            Init_Device(PortName, PortSpeed, 8, Parity.None, StopBits.One, 2000);

            PortOpen();
        }

        public void Terminate()
        {
            PortClose();
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
                FormMain.Instance().lbLed.Text = "Connected";
                FormMain.Instance().lbLed.BackColor = Color.Green;
#if LIGHT_TEST
#else
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
#endif
            }
            catch (Exception ex)
            {
                Machine._Logger.log("Failed to Init_Device. : " + ex.ToString(), LogType.DEBUG, true);
            }
        }

        private bool PortOpen()
        {
            try
            {
#if LIGHT_TEST
                return true;
#else
                if (serialPort.IsOpen == true)
                    serialPort.Close();

                serialPort.Open();

                if (serialPort.IsOpen)
                {
                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                    //Machine._Logger.log("Port is open.", LogType.DEBUG, true);
                    return true;
                }
                else
                {
                   // Machine._Logger.log("Port is already open.", LogType.DEBUG, true);
                    return false;
                }
#endif
            }
            catch (Exception ex)
            {
                Machine._Logger.log("Failed to open the port. : " + ex.ToString(), LogType.DEBUG, true);
                return false;
            }
        }

        private bool PortClose()
        {
            try
            {
#if LIGHT_TEST
                return true;
#else
                if (serialPort.IsOpen == true) serialPort.Close();

                if (!serialPort.IsOpen)
                {
                    serialPort.Dispose();
                    //Machine._Logger.log("Port is Close.", LogType.DEBUG, true);
                    return true;
                }
                else
                {
                    return false;
                }
#endif
            }
            catch (Exception ex)
            {
                Machine._Logger.log("Failed to PortClose. : " + ex.ToString(), LogType.DEBUG, true);
                return false;
            }
        }

        public bool IsOpen()
        {
#if LIGHT_TEST          
            //return serialPort.IsOpen;
            return true;
#else
            return serialPort.IsOpen;
#endif
        }

        public void ResetBuffer()
        {
            strReceived = "";
            //recvBuf = new byte[1024];
            //if (!serialPort.IsOpen) return;

            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
        }

        public bool SendData(string strSendData)
        {
            if (!IsOpen())
            {
                Machine._Logger.log(string.Format("Serial Com {0} not open.", serialPort.PortName), LogType.DEBUG, true);
                return false;
            }
            strReceived = "";
#if LIGHT_TEST
#else
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();

            serialPort.WriteLine(strSendData);
#endif
            //Machine._Logger.log(string.Format("Serial Com[{0}] : Send Completed. [{1}]", serialPort.PortName, strSendData), LogType.DEBUG, false);

            return true;
        }

        public bool SendData(byte[] bySendData)
        {
            if (!serialPort.IsOpen)
                return false;

            strReceived = "";

            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();

            serialPort.Write(Encoding.Default.GetString(bySendData));
            string d = Encoding.Default.GetString(bySendData);
            //Machine._Logger.log(string.Format("Serial Com [{0}] : Send [{1}]", serialPort.PortName, Encoding.Default.GetString(bySendData)), LogType.DEBUG, false);
            return true;
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(500);
                int readcount = serialPort.BytesToRead;
                if (readcount > 0)
                {
                    string b = serialPort.ReadByte().ToString();

                    //Machine._Logger.log(string.Format("Serial Com [{0}] : Received [{1}]", serialPort.PortName, b), LogType.DEBUG, false);
                    ParseReceivedData(b.ToString());
                }

            }
            catch (Exception ex)
            {

                string str = "";
                str = this.ToString() + ": serialPort_DataReceived, " + ex.Message;
                Machine._Logger.log(string.Format("Serial Com [{0}] : ERR [{1}]", serialPort.PortName, str), LogType.DEBUG, false);
            }
        }

        public void ParseReceivedData(string strReceived)
        {
            try
            {

            }
            catch (Exception ex)
            {
                string str = "";
                str = this.ToString() + ": ParseReceivedData, " + ex.Message;
                Machine._Logger.log(str, LogType.DEBUG, false);
            }
        }

        private void ModelChange(int Model)
        {
            //레시피 변경***********************************************************************************************************************************************   
        }


        public int ReadCount()
        {
            return strReceived.Length;
        }

        public void SaveLight()
        {
            byte[] bData = new byte[6];
            bData[0] = 0x01;        // SOH
            bData[1] = 0x00;        // OP code(Packet의 동작 모드를 알려주는 data (Write:0x0, Read:0x1) )
            bData[2] = 0x01;        // Data Length
            bData[3] = 0x2C;        // Addr (Access하고자 하는 Register의 주소값, On,Off 주소 0x34(COR))
            bData[4] = 0x10;       // Data (해당 Register의 data값)
            bData[5] = 0x04;        // EOT

            SendData(bData);
        }

        public void LightOnOffEN(bool bOn)
        {
            string send;
            int light = Int32.Parse(FormMain.Instance().ResultDataControl.txtLightValue.Text);
            
            if (bOn)
            {
                if (light < 100)
                {
                    send = "L1" + "0" + light.ToString() + "\r\n";
                    SendData(send);
                    send = "L2" + "0" + light.ToString() + "\r\n";
                    SendData(send);
                    LightOk = true;
                }
                else
                {
                    send = "L1" + light + "\r\n";
                    SendData(send);
                    send = "L2" + light + "\r\n";
                    SendData(send);
                    LightOk = true;
                }
                
            }
            else
            {
                send = "E1\r\n";
                SendData(send);
                send = "E2\r\n";
                SendData(send);
                LightOk = false;
            }     
        }

        public void LightSetLevelEn(int level)
        {
 
        }

        /// <summary>
        /// 채널 선택하기
        /// </summary>
        /// <param name="bChannel">0x01 : 1번, 0x02 : 2번, 0x03 : 전체</param>
        /// <returns></returns>
        public void LightSetChannelEn(byte bChannel)
        {
            if (bChannel == 0 && bChannel > 3)
                return;

            byte[] bData = new byte[6];
            bData[0] = 0x01;        // SOH
            bData[1] = 0x00;        // OP code(Packet의 동작 모드를 알려주는 data (Write:0x0, Read:0x1) )
            bData[2] = 0x01;        // Data Length
            bData[3] = 0x20;        // Addr (Access하고자 하는 Register의 주소값, csr)
            bData[4] = bChannel;        // Data (해당 Register의 data값)
            bData[5] = 0x04;        // EOT

            SendData(bData);
        }
    }
}
