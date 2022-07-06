using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms;
using System.Diagnostics;


namespace LG_Chem
{
    public partial class FormErrorInfomation : Form
    {
        public FormErrorInfomation()
        {
            InitializeComponent();
        }
        public void SetMessage(string msg/*, bool isViewBtn*/)
        {
            rtbErrInfoMsg.Clear();
            rtbErrInfoMsg.Text = msg;

            //btnCamInitialize.Visible = isViewBtn;
        }

        //private void btnShowAreaInspForm_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        RulebaseInspMainForm rulebaseForm = new RulebaseInspMainForm();
        //        rulebaseForm.FormClosed += new FormClosedEventHandler(RulebaseDlgClosed);
        //        rulebaseForm.Location = new System.Drawing.Point(0, 0);
        //        rulebaseForm.WindowState = FormWindowState.Normal;
        //        rulebaseForm.m_inspManager = Machine.mRuleInspManager;
        //        rulebaseForm.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        StackTrace st = new StackTrace();
        //        StackFrame sf = st.GetFrame(1);

        //        MessageBox.Show(sf.GetMethod().Name + " " + ex.Message);
        //    }
        //}

        //private void RulebaseDlgClosed(object sender, FormClosedEventArgs e)
        //{
        //    //   string path = "";
        //    //    Machine.m_rulebaseInspManager.LoadInspFilterData(path);
        //    //    Machine.m_rulebaseInspManager.SettingInspectionFilter();
        //}

        //private void btnCamInitialize_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CameraInterface.Terminate();

        //        CameraStatus status = CameraInterface.Initialize(Machine.mConfig.mSetup);
        //        string statusMessage = status.ToString();
        //        if (status != CameraStatus.CAM_CONNECTION_SUCCESS)
        //        {
        //            Machine.mLogger.log(statusMessage, LogType.ERROR, true);
        //            MessageBox.Show("Cam Initialize Error. " + status.ToString());
        //            return;
        //        }

        //        string str = "";
        //        for (int camNo = 0; camNo < CameraInterface.Cam_Count; camNo++)
        //        {
        //            if (!CameraInterface.cameraList[camNo].IsOpen())
        //            {
        //                str += "#" + (camNo + 1) + " Camera" + "\n";
        //            }
        //        }
        //        if (str != "")//jskim 20210621
        //        {
        //            string msg = "Fail Connected.\n" + str;
        //            SetMessage(msg, true);
        //            return;
        //        }

        //        status = CameraInterface.SetCameraProperty(Machine.mConfig);
        //        statusMessage = status.ToString();
        //        if (status != CameraStatus.CAM_CONNECTION_SUCCESS)
        //        {
        //            Machine.mLogger.log(statusMessage, LogType.ERROR, true);
        //            SetMessage("Set Camera Property Error. " + status.ToString(), true);
        //            return;
        //        }

        //        Machine.mLogger.log("Cam Initialize Success", LogType.RELEASE, true);

        //        Machine.mMainForm.updateStatusUI();
        //        Machine.mMainForm.InitCamGrid();

        //        Machine.mLogger.log("Cam Initialize Sequence Complete", LogType.RELEASE, true);

        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        StackTrace st = new StackTrace();
        //        StackFrame sf = st.GetFrame(1);

        //        MessageBox.Show(sf.GetMethod().Name + " " + ex.Message);
        //    }
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
