namespace LG_Chem
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPcStatus = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.pnlTotalData = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tbxServo = new System.Windows.Forms.TextBox();
            this.edtActPos = new System.Windows.Forms.TextBox();
            this.pnlConnectVIew = new System.Windows.Forms.Panel();
            this.lbServo = new System.Windows.Forms.Label();
            this.chbServoonoff = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbLedonoff = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lbLed = new System.Windows.Forms.Label();
            this.lbconnected = new System.Windows.Forms.Label();
            this.edtCmdPos = new System.Windows.Forms.TextBox();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlReustData = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.timerSensor = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlConnectVIew.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.67958F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.32042F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1517, 1035);
            this.tableLayoutPanel1.TabIndex = 176;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlTotalData, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 672);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1511, 360);
            this.tableLayoutPanel2.TabIndex = 177;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.pnlPcStatus, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbTotal, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1136, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(372, 354);
            this.tableLayoutPanel4.TabIndex = 175;
            // 
            // pnlPcStatus
            // 
            this.pnlPcStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPcStatus.Location = new System.Drawing.Point(3, 91);
            this.pnlPcStatus.Name = "pnlPcStatus";
            this.pnlPcStatus.Size = new System.Drawing.Size(366, 260);
            this.pnlPcStatus.TabIndex = 178;
            // 
            // lbTotal
            // 
            this.lbTotal.BackColor = System.Drawing.Color.White;
            this.lbTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(3, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(366, 88);
            this.lbTotal.TabIndex = 181;
            this.lbTotal.Text = "-";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTotalData
            // 
            this.pnlTotalData.BackColor = System.Drawing.Color.White;
            this.pnlTotalData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotalData.Location = new System.Drawing.Point(3, 3);
            this.pnlTotalData.Name = "pnlTotalData";
            this.pnlTotalData.Size = new System.Drawing.Size(1127, 354);
            this.pnlTotalData.TabIndex = 176;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.pnlLogo, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.pnlDisplay, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1511, 663);
            this.tableLayoutPanel5.TabIndex = 178;
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.White;
            this.pnlLogo.Controls.Add(this.pictureBox1);
            this.pnlLogo.Controls.Add(this.pictureBox2);
            this.pnlLogo.Controls.Add(this.button3);
            this.pnlLogo.Controls.Add(this.tbxServo);
            this.pnlLogo.Controls.Add(this.edtActPos);
            this.pnlLogo.Controls.Add(this.pnlConnectVIew);
            this.pnlLogo.Controls.Add(this.edtCmdPos);
            this.pnlLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlLogo.Location = new System.Drawing.Point(3, 3);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(1482, 74);
            this.pnlLogo.TabIndex = 177;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(349, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(474, 76);
            this.pictureBox1.TabIndex = 186;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LG_Chem.Properties.Resources.lg;
            this.pictureBox2.Location = new System.Drawing.Point(13, -4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(309, 77);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 179;
            this.pictureBox2.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(655, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 23);
            this.button3.TabIndex = 182;
            this.button3.Text = "MOVE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbxServo
            // 
            this.tbxServo.Location = new System.Drawing.Point(548, 9);
            this.tbxServo.Name = "tbxServo";
            this.tbxServo.Size = new System.Drawing.Size(100, 21);
            this.tbxServo.TabIndex = 183;
            this.tbxServo.Text = "20000";
            // 
            // edtActPos
            // 
            this.edtActPos.Location = new System.Drawing.Point(548, 41);
            this.edtActPos.Name = "edtActPos";
            this.edtActPos.Size = new System.Drawing.Size(100, 21);
            this.edtActPos.TabIndex = 185;
            // 
            // pnlConnectVIew
            // 
            this.pnlConnectVIew.Controls.Add(this.lbServo);
            this.pnlConnectVIew.Controls.Add(this.chbServoonoff);
            this.pnlConnectVIew.Controls.Add(this.label1);
            this.pnlConnectVIew.Controls.Add(this.chbLedonoff);
            this.pnlConnectVIew.Controls.Add(this.label5);
            this.pnlConnectVIew.Controls.Add(this.label4);
            this.pnlConnectVIew.Controls.Add(this.btnConnect);
            this.pnlConnectVIew.Controls.Add(this.lbLed);
            this.pnlConnectVIew.Controls.Add(this.lbconnected);
            this.pnlConnectVIew.Location = new System.Drawing.Point(829, 3);
            this.pnlConnectVIew.Name = "pnlConnectVIew";
            this.pnlConnectVIew.Size = new System.Drawing.Size(653, 74);
            this.pnlConnectVIew.TabIndex = 178;
            // 
            // lbServo
            // 
            this.lbServo.BackColor = System.Drawing.Color.Red;
            this.lbServo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbServo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbServo.Location = new System.Drawing.Point(411, 0);
            this.lbServo.Name = "lbServo";
            this.lbServo.Size = new System.Drawing.Size(158, 28);
            this.lbServo.TabIndex = 189;
            this.lbServo.Text = "ON";
            this.lbServo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbServoonoff
            // 
            this.chbServoonoff.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbServoonoff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chbServoonoff.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chbServoonoff.Location = new System.Drawing.Point(575, 1);
            this.chbServoonoff.Name = "chbServoonoff";
            this.chbServoonoff.Size = new System.Drawing.Size(75, 27);
            this.chbServoonoff.TabIndex = 188;
            this.chbServoonoff.Text = "ON/OFF";
            this.chbServoonoff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbServoonoff.UseVisualStyleBackColor = true;
            this.chbServoonoff.CheckedChanged += new System.EventHandler(this.chbServoonoff_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(331, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 28);
            this.label1.TabIndex = 186;
            this.label1.Text = "Servo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbLedonoff
            // 
            this.chbLedonoff.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbLedonoff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chbLedonoff.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chbLedonoff.Location = new System.Drawing.Point(575, 34);
            this.chbLedonoff.Name = "chbLedonoff";
            this.chbLedonoff.Size = new System.Drawing.Size(75, 27);
            this.chbLedonoff.TabIndex = 185;
            this.chbLedonoff.Text = "ON/OFF";
            this.chbLedonoff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbLedonoff.UseVisualStyleBackColor = true;
            this.chbLedonoff.CheckedChanged += new System.EventHandler(this.chbLedonoff_CheckedChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(331, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 28);
            this.label5.TabIndex = 180;
            this.label5.Text = "LED";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 62);
            this.label4.TabIndex = 179;
            this.label4.Text = "Camera";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConnect.Location = new System.Drawing.Point(249, -2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(76, 63);
            this.btnConnect.TabIndex = 183;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lbLed
            // 
            this.lbLed.BackColor = System.Drawing.Color.Red;
            this.lbLed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbLed.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbLed.Location = new System.Drawing.Point(411, 34);
            this.lbLed.Name = "lbLed";
            this.lbLed.Size = new System.Drawing.Size(158, 28);
            this.lbLed.TabIndex = 182;
            this.lbLed.Text = "OFF";
            this.lbLed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbconnected
            // 
            this.lbconnected.BackColor = System.Drawing.Color.Red;
            this.lbconnected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbconnected.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbconnected.Location = new System.Drawing.Point(85, 0);
            this.lbconnected.Name = "lbconnected";
            this.lbconnected.Size = new System.Drawing.Size(158, 61);
            this.lbconnected.TabIndex = 181;
            this.lbconnected.Text = "Disconnected";
            this.lbconnected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edtCmdPos
            // 
            this.edtCmdPos.Location = new System.Drawing.Point(655, 41);
            this.edtCmdPos.Name = "edtCmdPos";
            this.edtCmdPos.Size = new System.Drawing.Size(100, 21);
            this.edtCmdPos.TabIndex = 184;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.BackColor = System.Drawing.Color.White;
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(3, 83);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(1505, 577);
            this.pnlDisplay.TabIndex = 181;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 727);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 149);
            this.panel1.TabIndex = 182;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(369, 149);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Controls.Add(this.btnStop, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.btnReset, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(363, 143);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Crimson;
            this.btnStop.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStop.Location = new System.Drawing.Point(184, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(173, 127);
            this.btnStop.TabIndex = 179;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.LightSalmon;
            this.btnReset.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReset.Location = new System.Drawing.Point(3, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(172, 127);
            this.btnReset.TabIndex = 186;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pnlReustData
            // 
            this.pnlReustData.BackColor = System.Drawing.Color.White;
            this.pnlReustData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReustData.Location = new System.Drawing.Point(3, 3);
            this.pnlReustData.Name = "pnlReustData";
            this.pnlReustData.Size = new System.Drawing.Size(369, 718);
            this.pnlReustData.TabIndex = 177;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel9, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1904, 1041);
            this.tableLayoutPanel3.TabIndex = 177;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.pnlReustData, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(1526, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(375, 1035);
            this.tableLayoutPanel9.TabIndex = 177;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 882);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(369, 150);
            this.tableLayoutPanel6.TabIndex = 183;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.btnStart, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(363, 144);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightBlue;
            this.btnStart.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(351, 128);
            this.btnStart.TabIndex = 178;
            this.btnStart.Text = "S T A R T";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timerSensor
            // 
            this.timerSensor.Tick += new System.EventHandler(this.timerSensor_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "자동 수축률 측정기";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlConnectVIew.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Panel pnlConnectVIew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel pnlDisplay;
        public System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Panel pnlReustData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnlTotalData;
        private System.Windows.Forms.Panel pnlPcStatus;
        public System.Windows.Forms.Label lbconnected;
        public System.Windows.Forms.Label lbLed;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox chbLedonoff;
        private System.Windows.Forms.Timer timerSensor;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbxServo;
        public System.Windows.Forms.TextBox edtActPos;
        public System.Windows.Forms.TextBox edtCmdPos;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStop;
        public System.Windows.Forms.Label lbServo;
        private System.Windows.Forms.CheckBox chbServoonoff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

