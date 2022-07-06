using enumType;
using LG_Chem.Device.DIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LG_Chem
{
    public partial class FormMain : Form
    {
        public Device.Camera.CameraHik camerahik = new Device.Camera.CameraHik();
        public CtrlDisplay DisplayControl = null;
        public CtrlTapDispaly ResultDataControl = null;
        public CtrlTotalData TotalData = null;
        public CtrlPcStatus PcStatus = null;
        public Device.DIO.DIO Dio = null;
        public Device.DIO.SERVO Servo = null;
        public SubSequence subSequence = null;
        public Sequence sequence = null;
        private static FormMain _instance = null;

        public static FormMain Instance()
        {
            if (_instance == null)
            {
                _instance = new FormMain();
            }

            return _instance;
        }

        public FormMain()
        {
              InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                AddControls();
                FormMain.Instance().TotalData.ReadCsv();
            }
            catch (Exception ex)
            {

            }
        }

        private void AddControls()
        {
            try
            {
                //Display
                DisplayControl = new CtrlDisplay();
                DisplayControl.Dock = DockStyle.Fill;
                this.pnlDisplay.Controls.Add(DisplayControl);

                //ResultData & StartButton
                ResultDataControl = new CtrlTapDispaly();
                ResultDataControl.Dock = DockStyle.Fill;
                this.pnlReustData.Controls.Add(ResultDataControl);

                //Total Data
                TotalData = new CtrlTotalData();
                TotalData.Dock = DockStyle.Fill;
                this.pnlTotalData.Controls.Add(TotalData);

                //Pc Status
                PcStatus = new CtrlPcStatus();
                PcStatus.TopLevel = false;
                PcStatus.Dock = DockStyle.Fill;
                this.pnlPcStatus.Controls.Add(PcStatus);
                PcStatus.Show();

                Dio = new Device.DIO.DIO();
                Servo = new Device.DIO.SERVO();
                subSequence = new SubSequence();
                Dio.OpenDevice();
                DIO.OutputIndex(7, (uint)0);
                DIO.OutputIndex(6, (uint)1);
                DIO.OutputIndex(0, (uint)1);
                DIO.OutputIndex(1, (uint)0);
                DIO.OutputIndex(2, (uint)0);
                Servo.initLibrary();
                Servo.AddAxisInfo();
                
                Servo.UpdateState();
                Servo.ServoOn(1);
                lbServo.BackColor = Color.Green;
                CAXM.AxmSignalSetServoAlarm(0, 2);
                //Servo Home Start
                //CAXM.AxmHomeSetVel(0, 50000, 50000, 50000, 50000, 50000, 50000);
                //CAXM.AxmHomeSetStart(0);
                Servo.AbsMove(400000);

                timerSensor.Enabled = true;
                subSequence.AdaptCogPMAlignTool(subSequence.trainImagePath);
            }
            catch(Exception ex)
            {

            }
          }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ResultDataControl.chbxLiveMode.Checked = false;
            Sequence.Instance().StartSequence();

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            
            Machine.Instance().reconnect();
            if(camerahik._isConnected)
            {
                lbconnected.Text = "Connected";
                lbconnected.BackColor = Color.Green;
            }
            else
            {
                lbconnected.Text = "DisConnected";
                lbconnected.BackColor = Color.Red;
            }
                
            //DisplayControl.Addhandler();
        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Machine.Terminate();
            DIO.OutputIndex(7, (uint)0);
            DIO.OutputIndex(6, (uint)1);
            //Servo.AbsMove(400000);
            Machine._Light.LightOnOffEN(false);
        }


        private void chbLedonoff_CheckedChanged(object sender, EventArgs e)
        {
            if(chbLedonoff.Checked == true)
            {
                Machine._Light.LightOnOffEN(true);
                //chbLedonoff.BackColor = Color.Green;
            }
            else
            {
                Machine._Light.LightOnOffEN(false);
                //chbLedonoff.BackColor = Color.Red;
            }
        }

        private void timerSensor_Tick(object sender, System.EventArgs e)
        {
            Dio.TimerSensor();
            Servo.Timer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Servo.Move(Double.Parse(tbxServo.Text));

        }

        private void chbServoonoff_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chbServoonoff.Checked == true)
            {
                Servo.ServoOn(0);
                lbServo.BackColor = Color.Red;
                lbServo.Text = "OFF";
            }
            else
            {
                Servo.ServoOn(1);
                lbServo.BackColor = Color.Green;
                lbServo.Text = "ON";

            }
        }
        
        private void btnStop_Click(object sender, EventArgs e)
        {

            Sequence.SeqStep = eSeqStep.SEQ_STOP;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
            if(!DIO.bInput[0])
            {
                Sequence._isEMO = false;
            }
            
            DIO.OutputIndex(3, (uint)0);
            DIO.OutputIndex(0, (uint)1);
            DIO.OutputIndex(1, (uint)0);
            DIO.OutputIndex(2, (uint)0);
            //Servo.initLibrary();
            CAXM.AxmSignalSetServoAlarm(0, 0);
            CAXM.AxmSignalServoAlarmReset(0, 1);
            Servo.initLibrary();
            Servo.AddAxisInfo();
            Servo.UpdateState();
            CAXM.AxmSignalSetServoAlarm(0, 0);
            ResultDataControl.dgvResult.Rows.Clear();
            Thread.Sleep(2000);
            CAXM.AxmSignalServoAlarmReset(0, 0);
            //Servo.initLibrary();
            //Servo.AddAxisInfo();

            //Servo.UpdateState();
            //CAXM.AxmSignalSetServoAlarmResetLevel(0, 1);

            Sequence.SeqStep = eSeqStep.SEQ_STOP;
            Thread.Sleep(500);
            CAXM.AxmStatusSetPosMatch(0, 0);
            Servo.AbsMove(400000);
            //CAXM.AxmHomeSetVel(0, 50000, 50000, 50000, 50000, 50000, 50000);
            //CAXM.AxmHomeSetStart(0);


        }

    }
}
