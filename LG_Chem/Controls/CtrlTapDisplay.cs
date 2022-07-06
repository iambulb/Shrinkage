using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Cognex.VisionPro;
using LG_Chem.Device.Camera;
using System.Threading;
using LG_Chem.Device.DIO;
using System.Drawing.Imaging;

namespace LG_Chem
{
    public partial class CtrlTapDispaly : UserControl
    {

        public SubSequence subSequence = new SubSequence();
        public delegate void WriteLogDele(string message);
        public string hisPath;
        public WriteLogDele writeLog;

        private static CtrlTapDispaly _instance = null;
        public static CtrlTapDispaly Instance()
        {
            if (_instance == null)
                _instance = new CtrlTapDispaly();

            return _instance;
        }
        public CtrlTapDispaly()
        {
            InitializeComponent();

            InitializeCameraProperty();
        }

        public delegate void InvokeApplyDataGridViewDele(double left, double right, double total);
        public void ApplyDataGridView(double left,double right,double total)
        {
            if (this.InvokeRequired)
            {
                InvokeApplyDataGridViewDele callback = ApplyDataGridView;
                BeginInvoke(callback, left, right, total);
                return;
            }

            if(dgvResult.RowCount > 9)
            {
                dgvResult.Rows.Clear();
                
            }
            string csvPath = string.Format(@"{0}\{1:00}\{2:00}\{3:00}", System.IO.Directory.GetCurrentDirectory() + "\\Csv", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            int csvlinecount = File.ReadLines(csvPath + "\\ResultData.csv").Count() - 1;

            if(total == 0)
            {
                string[] row = { csvlinecount.ToString(), "0", "0", "0", DateTime.Now.ToString("yy-MM-dd HH:mm:ss") };
                
                dgvResult.Rows.Add(row);
                dgvResult.Rows[dgvResult.RowCount-1].DefaultCellStyle.BackColor = Color.Red;
            }
            else
            {
                string[] row = { csvlinecount.ToString(), Math.Round(left, 3, MidpointRounding.AwayFromZero).ToString(), Math.Round(right, 3, MidpointRounding.AwayFromZero).ToString(), Math.Round(total, 3, MidpointRounding.AwayFromZero).ToString(), DateTime.Now.ToString("yy-MM-dd HH:mm:ss") };
                dgvResult.Rows.Add(row);

            }

            
            dgvResult.CurrentCell = dgvResult.Rows[dgvResult.RowCount - 1].Cells[0];

        }
        public delegate void InvokeCalibrationDele(double total);
        public void CalibrationDele(double total)
        {
            if (this.InvokeRequired)
            {
                InvokeCalibrationDele callback = CalibrationDele;
                BeginInvoke(callback,total);
                return;
            }

            txtMiddleValue.Text = total.ToString();

        }
        private void ReadCsv(string path)
        {
            try
            {
                DataTable dt = new DataTable();

                using (StreamReader sr = new StreamReader(path))
                {
                    string[] headers = sr.ReadLine().Split(',');

                    //foreach (string header in headers)
                    //{
                    //    dt.Columns.Add(header);
                    //}
                    dt.Columns.Add("No");
                    dt.Columns.Add("Left");
                    dt.Columns.Add("Right");
                    dt.Columns.Add("Total");
                    dt.Columns.Add("Date");

                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();

                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }

                        dt.Rows.Add(dr);
                    }
                    dgvHistory.DataSource = dt;
                }
                dgvHistory.CurrentCell = null;

                
            }
            catch (Exception ex)
            {
            }

        }

        //버튼 누름 표시
        private void cbMain_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            cbSetting.CheckState = CheckState.Unchecked;
            cbHistory.CheckState = CheckState.Unchecked;
            if (cbMain.Checked)
            {
                cbMain.BackColor = Color.LightBlue;
                cbHistory.BackColor = Color.LightSteelBlue;
                cbSetting.BackColor = Color.LightSteelBlue;
            }
        }

        private void cbHistory_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            cbMain.CheckState = CheckState.Unchecked;
            cbSetting.CheckState = CheckState.Unchecked;
            if (cbHistory.Checked)
            {
                cbHistory.BackColor = Color.LightBlue;
                cbMain.BackColor = Color.LightSteelBlue;
                cbSetting.BackColor = Color.LightSteelBlue;
            }
        }

        private void cbSetting_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            cbMain.CheckState = CheckState.Unchecked;
            cbHistory.CheckState = CheckState.Unchecked;
            if (cbSetting.Checked)
            {
                cbSetting.BackColor = Color.LightBlue;
                cbMain.BackColor = Color.LightSteelBlue;
                cbHistory.BackColor = Color.LightSteelBlue;
            }
        }

        private void btnDateSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No");
            dt.Columns.Add("Left");
            dt.Columns.Add("Right");
            dt.Columns.Add("Total");
            dt.Columns.Add("Date");
            dt.Columns.Add("비고");

            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;

            for(int month = date1.Month; month <= date2.Month; month++)
            {
                if (date1.Month == date2.Month)
                {
                    for (int day = date1.Day; day <= date2.Day; day++)
                    {
                        string strFile = string.Format(@"{0}\{1:00}\{2:00}\{3:00}", System.IO.Directory.GetCurrentDirectory() + "\\Csv",date1.Year,month, day) + "\\ResultData.csv";
                        FileInfo fileInfo = new FileInfo(strFile);
                        //파일 있는지 확인 있을때(true), 없으면(false)
                        if (fileInfo.Exists)
                        {
                            using (StreamReader sr = new StreamReader(strFile, System.Text.Encoding.Default))
                            {
                                string[] headers = sr.ReadLine().Split(',');

                                while (!sr.EndOfStream)
                                {
                                    string[] rows = sr.ReadLine().Split(',');
                                    DataRow dr = dt.NewRow();

                                    for (int i = 0; i < headers.Length; i++)
                                    {
                                        dr[i] = rows[i];
                                    }

                                    dt.Rows.Add(dr);
                                }  
                            }    
                        }
                    }
                }

                else
                {
                    for (int day = date1.Day; day <= 31; day++)
                    {
                        string strFile = string.Format(@"{0}\{1:00}\{2:00}\{3:00}", System.IO.Directory.GetCurrentDirectory() + "\\Csv", date1.Year, month, day) + "\\ResultData.csv";
                        FileInfo fileInfo = new FileInfo(strFile);
                        //파일 있는지 확인 있을때(true), 없으면(false)
                        if (fileInfo.Exists)
                        {
                            using (StreamReader sr = new StreamReader(strFile, System.Text.Encoding.Default))
                            {
                                string[] headers = sr.ReadLine().Split(',');

                                while (!sr.EndOfStream)
                                {
                                    string[] rows = sr.ReadLine().Split(',');
                                    DataRow dr = dt.NewRow();

                                    for (int i = 0; i < headers.Length; i++)
                                    {
                                        dr[i] = rows[i];
                                    }

                                    dt.Rows.Add(dr);
                                }
                            }
                        }           
                            //ReadCsv(string.Format(@"{0}\{1:00}\{2:00}", System.IO.Directory.GetCurrentDirectory() + "\\Csv", month, day) + "\\ResultData.csv");
                    }

                    for (int day = 1; day <= date2.Day; day++)
                    {
                        string strFile = string.Format(@"{0}\{1:00}\{2:00}\{3:00}", System.IO.Directory.GetCurrentDirectory() + "\\Csv",date2.Year,month, day) + "\\ResultData.csv";
                        FileInfo fileInfo = new FileInfo(strFile);
                        //파일 있는지 확인 있을때(true), 없으면(false)
                        if (fileInfo.Exists)
                        {
                            using (StreamReader sr = new StreamReader(strFile, System.Text.Encoding.Default))
                            {
                                string[] headers = sr.ReadLine().Split(',');

                                while (!sr.EndOfStream)
                                {
                                    string[] rows = sr.ReadLine().Split(',');
                                    DataRow dr = dt.NewRow();

                                    for (int i = 0; i < headers.Length; i++)
                                    {
                                        dr[i] = rows[i];
                                    }

                                    dt.Rows.Add(dr);
                                }
                            }
                        }
                            //ReadCsv(string.Format(@"{0}\{1:00}\{2:00}", System.IO.Directory.GetCurrentDirectory() + "\\Csv", month, day) + "\\ResultData.csv");
                    }
                }

                dgvHistory.DataSource = dt;

                dgvHistory.CurrentCell = null;

            }

            //ReadCsv(string.Format(@"{0}\{1:00}\{2:00}", System.IO.Directory.GetCurrentDirectory() + "\\Csv", DateTime.Now.Month, DateTime.Now.Day) + "\\ResultData.csv");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //BindingSource bs = (BindingSource)dgvHistory.DataSource;

            DataGridViewRow row = dgvHistory.SelectedRows[0];
            string no = row.Cells[0].Value.ToString();
            string l = row.Cells[1].Value.ToString();
            string r = row.Cells[2].Value.ToString();
            string total = row.Cells[3].Value.ToString();
            string date = row.Cells[4].Value.ToString();
            string memo = row.Cells[5].Value.ToString();
            string[] day = date.Split('-');

            string csvPath = string.Format(@"{0}\{1:00}\{2:00}\{3:00}\\ResultData.csv", System.IO.Directory.GetCurrentDirectory() + "\\csv", "20"+ date.Substring(0, 2), day[1],day[2].Substring(0, 2));
            string key;
            string[] keyNO;
            //FileStream fs = new FileStream(csvPath, FileMode.Open, FileAccess.ReadWrite);

            StreamReader sr = new StreamReader(csvPath, System.Text.Encoding.Default);
            string buf = sr.ReadToEnd();
            sr.BaseStream.Position = 0;

            while(sr.EndOfStream == false)
            {
                key = sr.ReadLine();
                keyNO = key.Split(new string[] { "," },StringSplitOptions.None);
                if(no == keyNO[0])
                {
                    int offset = buf.IndexOf(key,0);
                    buf = buf.Remove(offset, key.Length);
                    key = key.Replace(key, string.Format("{0},{1},{2},{3},{4},{5}", no, l, r, total, date, memo));
                    buf = buf.Insert(offset, key);
                }
            }
            sr.Close();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(csvPath, false, System.Text.Encoding.Default))
            {

                //file.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", no, 0, 0, 0, date, memo));
                file.Write(buf);

                file.Close();
            }

        }

        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow row = dgvHistory.SelectedRows[0]; //선택된 Row 값 가져옴.
            string date = row.Cells[4].Value.ToString(); 
            string no = row.Cells[0].Value.ToString();
            string total = row.Cells[3].Value.ToString();
            string imagePath = string.Format(@"{0}\{1:00}\{2:00}\{3:00}", System.IO.Directory.GetCurrentDirectory() + "\\Image", "20"+date.Substring(0, 2),date.Substring(3, 2), date.Substring(6, 2));

            
            string imageL = imagePath + "\\" + no + "_L.bmp";
            string imageR = imagePath + "\\" + no + "_R.bmp";

            if (hisPath != imageL)
                hisPath = imageL;
            else
                return;

            FormMain.Instance().lbTotal.Text = total + " mm";

            FileInfo fiL = new FileInfo(imageL);
            bool l = fiL.Exists;

            FileInfo fiR = new FileInfo(imageR);
            bool r = fiR.Exists;
            if (l && r)
            {
                subSequence.PMAlign(new Bitmap(imageL), new Bitmap(imageR));
                //FormMain.Instance().DisplayControl.LoadImage(new Bitmap(imageL), new Bitmap(imageR));
                //FormMain.Instance().DisplayControl.LoadImage(new Bitmap(imageL), new Bitmap(imageR));
                GC.Collect();
            }
            else
            {
                MessageBox.Show("이미지가 없습니다.");
            }
            
            
        }
        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvResult.SelectedRows[0]; //선택된 Row 값 가져옴.
                string date = row.Cells[4].Value.ToString();
                string no = row.Cells[0].Value.ToString();
                string total = row.Cells[3].Value.ToString();

                string imagePath = string.Format(@"{0}\{1:00}\{2:00}\{3:00}", System.IO.Directory.GetCurrentDirectory() + "\\Image", "20" + date.Substring(0, 2), date.Substring(3, 2), date.Substring(6, 2));
                string imageL = imagePath + "\\" + no + "_L.bmp";
                string imageR = imagePath + "\\" + no + "_R.bmp";

                FormMain.Instance().lbTotal.Text = total + " mm";

                FileInfo fiL = new FileInfo(imageL);
                bool l = fiL.Exists;

                FileInfo fiR = new FileInfo(imageR);
                bool r = fiR.Exists;
                if (l && r)
                {
                    FormMain.Instance().DisplayControl.DisplayResultImage(new Bitmap(imageL), new Bitmap(imageR)/*SubSequence.leftimagelist[e.RowIndex],SubSequence.rightimagelist[e.RowIndex]*/,
                    SubSequence._leftTrainRect[e.RowIndex], SubSequence._rightTrainRect[e.RowIndex], SubSequence._leftSegmentTool[e.RowIndex].GetOutputSegment(),
                    SubSequence._rightSegmentTool[e.RowIndex].GetOutputSegment(), SubSequence._leftCogDistanceLabel[e.RowIndex], SubSequence._rightCogDistanceLabel[e.RowIndex],
                    SubSequence._totalCogDistanceLabel[e.RowIndex], Math.Round(SubSequence.totalDistance[e.RowIndex], 3));
                    GC.Collect();
                }
                else
                {
                    MessageBox.Show("이미지가 없습니다.");
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }



        // Setting

        private void InitializeCameraProperty()
        {
            List<CameraProperty> _cameraPropList = Machine._Cfg.mSetup._camProperty;

            if (_cameraPropList == null) return;

            for (int i = 0; i < _cameraPropList.Count; i++)
            {
                cbxCamNo.Items.Add(i.ToString());
            }

            if (_cameraPropList.Count != 0)
                cbxCamNo.SelectedIndex = 0;
        }

        private void btnApplyCameraParameter_Click(object sender, EventArgs e)
        {
            Setup setup = Machine._Cfg.mSetup;
            int camIdx = cbxCamNo.SelectedIndex;
            setup.lightValue = Convert.ToInt32(txtLightValue.Text);
            setup.middleValue = Convert.ToDouble(txtMiddleValue.Text);
            setup.count = Convert.ToInt32(txtCount.Text);
            setup.servospeed = Convert.ToDouble(txtServoSpeed.Text);
            Machine._Light.LightOnOffEN(Machine._Light.LightOk);

            if (SaveParameter(camIdx) == false)
            {
                Machine._Logger.log(string.Format("카메라 파라미터 적용 실패"), LogType.DEBUG, false);
                //writeLog("카메라 파라미터 적용 실패");
            }
            else
            {
                Machine._Logger.log(string.Format("카메라 파라미터 적용 완료"), LogType.DEBUG, false);
                //writeLog("카메라 파라미터 적용 완료");
            }

            if (Machine._Cfg.SaveConfig() == true)
            {
                Machine._Logger.log(string.Format("카메라 파라미터 저장 완료"), LogType.DEBUG, false);
                //writeLog("카메라 파라미터 저장 완료");
            }
            else
            {
                Machine._Logger.log(string.Format("카메라 파라미터 저장 실패"), LogType.DEBUG, false);
                //writeLog("카메라 파라미터 저장 실패");
            }
            
        }

        private void cbxCamNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int camIdx = cbxCamNo.SelectedIndex;

            LoadParameter(camIdx);
        }

        private bool SaveParameter(int camIdx)
        {
            try
            {
                CameraProperty _cameraProperty = new CameraProperty();

                //_cameraProperty.CamName = txtCamName.Text;
                _cameraProperty.CamAddress = lbCamAddress.Text;
                _cameraProperty.SerialNumber = lbSerialNumber.Text;
                _cameraProperty.Exposure = Convert.ToInt32(txtExposureTime.Text);
                _cameraProperty.Height = Convert.ToInt32(lbCamHeight.Text);
                _cameraProperty.Width = Convert.ToInt32(lbCamWidth.Text);
                //_cameraProperty.OffsetX = Convert.ToInt32(txtOffsetX.Text);
                //_cameraProperty.OffsetY = Convert.ToInt32(txtOffsetY.Text);

                Machine._Cfg.mSetup._camProperty[camIdx] = _cameraProperty;
                return Machine._cameraManager.SetProperty(camIdx, _cameraProperty);
            }
            catch
            {
                return false;
            }
        }

        // offset 값이 4의 배수로만 적용이된다.
        //private void SetOFfsetX()
        //{
        //    int offsetX = Convert.ToInt32(txtOffsetX.Text);
        //    int width = Convert.ToInt32(lbCamWidth.Text);

        //    int remainder = offsetX % 4;
        //    int quotient = offsetX / 4;

        //    if (remainder < 2)
        //    {
        //        offsetX = 4 * quotient;
        //        width += remainder;
        //    }
        //    else
        //    {
        //        offsetX = 4 * (quotient + 1);
        //        width -= remainder;
        //    }

        //    txtOffsetX.Text = offsetX.ToString();
        //    lbCamWidth.Text = width.ToString();
        //}

        private void LoadParameter(int camIdx)
        {
            Setup setup = Machine._Cfg.mSetup;
            try
            {
                CameraProperty _cameraProp = Machine._Cfg.mSetup._camProperty[camIdx];

                //txtCamName.Text = _cameraProp.CamName;
                lbCamAddress.Text = _cameraProp.CamAddress;
                lbSerialNumber.Text = _cameraProp.SerialNumber;
                txtExposureTime.Text = _cameraProp.Exposure.ToString();
                lbCamHeight.Text = _cameraProp.Height.ToString();
                lbCamWidth.Text = _cameraProp.Width.ToString();
                //txtOffsetX.Text = _cameraProp.OffsetX.ToString();
                //txtOffsetY.Text = _cameraProp.OffsetY.ToString();
                txtLightValue.Text = setup.lightValue.ToString();
                txtServoSpeed.Text = setup.servospeed.ToString();
                txtMiddleValue.Text = setup.middleValue.ToString();
                txtCount.Text = setup.count.ToString();

                //lblSubImageCount.Text = "SubImage : " + Machine._cameraManager.GetSubImageCnt(cbxCamNo.SelectedIndex);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EnableControls(bool enable)
        {
            lbCamAddress.Enabled = enable;
            //txtCamName.Enabled = enable;
            lbSerialNumber.Enabled = enable;
            lbCamHeight.Enabled = enable;
            lbCamWidth.Enabled = enable;
            //txtOffsetX.Enabled = enable;
            //txtOffsetY.Enabled = enable;
        }

        private void btnGrabStart_Click(object sender, EventArgs e)
        {
            chbxLiveMode.Checked = false;

            Machine._cameraManager.SetSaveMode(true);
            Machine._cameraManager._cameraList[0]._acquisitionType = eAcquisitionMode.Continuous;
            Machine._cameraManager._cameraList[1]._acquisitionType = eAcquisitionMode.Continuous;
            Machine._cameraManager.StartGrab();

            Thread thread = new Thread(StopGrab);
            thread.Start();
        }

        private void StopGrab()
        {
            List<CameraHik> cameraList = Machine._cameraManager.GetCameraList();
            while (true)
            {
                if (cameraList[0].IsGrabCompleted() &&
                    cameraList[1].IsGrabCompleted())
                {
                    break;
                }

                Thread.Sleep(100);
            }

            Machine._cameraManager.StopGrab();

            //for (int i = 0; i < Machine._cameraManager.GetConnectedCount(); i++)
            //{
            //    writeLog("Cam Num : " + i.ToString() + " , Sub Num : " + Machine._cameraManager.GetSubImageCnt(i));
            //}

            //UpdataeSubImageCount();
        }

        //private void UpdataeSubImageCount()
        //{
        //    if (this.InvokeRequired)
        //    {
        //        Action callback = UpdataeSubImageCount;
        //        this.Invoke(callback);
        //    }
        //    else
        //    {
        //        lblSubImageCount.Text = "SubImage : " + Machine._cameraManager.GetSubImageCnt(cbxCamNo.SelectedIndex);
        //    }

        //}


        private void txtExposureTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double exposure = Convert.ToDouble(txtExposureTime.Text);

                Machine._cameraManager.SetExpose(cbxCamNo.SelectedIndex, exposure);

                Machine._Cfg.mSetup._camProperty[cbxCamNo.SelectedIndex].Exposure = (int)exposure;

                Machine._Cfg.SaveConfig();
            }
        }

        //카메라 연결안되어있을때 재연결버튼으로 재연결하였을경우 그랩테스트는 되는데 라이브가안댐. 버그수정해야함 21-12-03
        private void chbxLiveMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxLiveMode.Checked == true)
            {
                //writeLog("Live Mode ON");
                if (Machine._cameraManager.IsGrabbing() == true)
                    Machine._cameraManager.StopGrab();

                EnableControls(false);

                //Machine._cameraManager.SetSaveMode(false);
                Machine._cameraManager._cameraList[0]._acquisitionType = eAcquisitionMode.Continuous;
                Machine._cameraManager._cameraList[1]._acquisitionType = eAcquisitionMode.Continuous;
                Machine._Light.LightOnOffEN(true);
                Machine._cameraManager.StartGrab();
            }
            else
            {
                //writeLog("Live Mode OFF");
                Machine._Light.LightOnOffEN(false);
                Machine._cameraManager.StopGrab();
                
                //Machine._cameraManager._cameraList[0]._acquisitionType = eAcquisitionMode.Single;
                //Machine._cameraManager._cameraList[1]._acquisitionType = eAcquisitionMode.Single;
                EnableControls(true);
            }
        }

        //private void btnClearSubImage_Click(object sender, EventArgs e)
        //{
        //    Machine._cameraManager.ClearSubImageList();

        //    writeLog("Clear SubImageList");
        //    lblSubImageCount.Text = "SubImage : " + Machine._cameraManager.GetSubImageCnt(0);
        //}

        public void Terminate()
        {
            chbxLiveMode.Checked = false;
        }

        private void btnCalibration_Click(object sender, EventArgs e)
        {
            CtrlTapDispaly ResultDataControl = new CtrlTapDispaly();
            ResultDataControl.chbxLiveMode.Checked = false;
            
            Sequence.Instance().StartCalibration();

            //Sequence.Instance().StartSequence();

            //Machine._Light.LightOnOffEN(true);
            //DIO.OutputIndex(6, (uint)0);
            //DIO.OutputIndex(7, (uint)1);

            //Machine._cameraManager._cameraList[0]._acquisitionType = eAcquisitionMode.Single;
            //Machine._cameraManager._cameraList[1]._acquisitionType = eAcquisitionMode.Single;
            //Machine._cameraManager.StartGrab();

            //subSequence.PMAlignCalibration();

            //Machine._Light.LightOnOffEN(false);

            //DIO.OutputIndex(7, (uint)0);
            //DIO.OutputIndex(6, (uint)1);
        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            
            Bitmap bmp = CameraHik.Livebmp;
            try
            {
                string strFilePath = string.Format(@"{0}\{1:00}\{2:00}\{3:00}", System.IO.Directory.GetCurrentDirectory() + "\\Image", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                string ImagePath = string.Format(@"{0}\{1:00}\{2:00}\Image_{3:0000}{4:00}{5:00}_", strFilePath, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                //string csvPath = string.Format(@"{0}\{1:00}\{2:00}\{3:00}", System.IO.Directory.GetCurrentDirectory() + "\\Csv", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                //int csvlinecount = File.ReadLines(csvPath + "\\ResultData.csv").Count() - 1;
                if (Directory.Exists(strFilePath) == false)
                {
                    Directory.CreateDirectory(strFilePath);
                }


                for (int camIdx = 0; camIdx < Machine._cameraManager._cameraList.Count; camIdx++)
                {
                    bmp = Machine._cameraManager._cameraList[camIdx].Getbmp();

                    if (camIdx % 2 == 0)
                    {
                        bmp.Save(strFilePath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss")  + "_L" + ".bmp", ImageFormat.Bmp);

                        FileInfo fi = new FileInfo(strFilePath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_L" + ".bmp");
                        bool d = fi.Exists;
                        while (!d)
                        {
                            d = Directory.Exists(strFilePath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss")  + "_L" + ".bmp");
                        }
                        bmp.Dispose();
                        GC.Collect();
                    }
                    else
                    {
                        bmp.Save(strFilePath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_R" + ".bmp", ImageFormat.Bmp);

                        FileInfo fi = new FileInfo(strFilePath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_R" + ".bmp");
                        bool d = fi.Exists;
                        while (!d)
                        {
                            d = Directory.Exists(strFilePath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_R" + ".bmp");
                        }
                        bmp.Dispose();
                        GC.Collect();
                    }


                }
                Machine._Logger.log("Save SubImage success.", LogType.DEBUG, true);

            }
            catch (Exception ex)
            {
                //에러출력
                MessageBox.Show(ex.ToString());
                Machine._Logger.log("Save SubImage fail.", LogType.DEBUG, true);
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory());
        }

        private void btnJogLeft_MouseUp(object sender, MouseEventArgs e)
        {
            CAXM.AxmMoveSStop(0);
        }


        private void btnJogRight_MouseUp(object sender, MouseEventArgs e)
        {
            CAXM.AxmMoveSStop(0);
        }

        private void btnJogLeft_MouseDown(object sender, MouseEventArgs e)
        {
            double dVelocity = Math.Abs(double.Parse(Machine._Cfg.mSetup.servospeed.ToString()));
            double dAccel = Math.Abs(double.Parse(Machine._Cfg.mSetup.servospeed.ToString()));
            double dDecel = Math.Abs(double.Parse(Machine._Cfg.mSetup.servospeed.ToString()));

            //++ 지정한 축을 (-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
            CAXM.AxmMoveVel(0, -dVelocity, dAccel, dDecel);
        }

        private void btnJogRight_MouseDown(object sender, MouseEventArgs e)
        {
            double dVelocity = Math.Abs(double.Parse(Machine._Cfg.mSetup.servospeed.ToString()));
            double dAccel = Math.Abs(double.Parse(Machine._Cfg.mSetup.servospeed.ToString()));
            double dDecel = Math.Abs(double.Parse(Machine._Cfg.mSetup.servospeed.ToString()));

            //++ 지정한 축을 (-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
            CAXM.AxmMoveVel(0, dVelocity, dAccel, dDecel);
        }

        



        //private void btnSaveSubImage_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int idx = cbxCamNo.SelectedIndex;

        //        if (Machine._cameraManager.GetSubImageCnt(idx) > 0)
        //        {
        //            string fileName;
        //            SaveFileDialog FileDialog = new SaveFileDialog();
        //            FileDialog.Title = "저장경로 지정하세요.";
        //            FileDialog.OverwritePrompt = true;
        //            FileDialog.Filter = "Bitmap File(*.bmp) | *.bmp | JPEG FILE(*.jpg) | *.jpg | PNG File (*.png) | *.png";


        //            if (FileDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                fileName = FileDialog.FileName;

        //                for (int camNo = 0; camNo < Machine._cameraManager._cameraList.Count; camNo++)
        //                {
        //                    int subCnt = Machine._cameraManager._cameraList[camNo].GetSubImageCount();
        //                    for (int subNo = 0; subNo < subCnt; subNo++)
        //                    {
        //                        string imgName = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName), "_camNo_", camNo.ToString() + "_subNo_" + subNo.ToString(), Path.GetExtension(fileName));
        //                        Machine._cameraManager.GetGrabImage(camNo, subNo).Save(imgName);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch { }
        //}
    }
}
