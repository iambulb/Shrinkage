namespace LG_Chem
{
    partial class CtrlTapDispaly
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpHistory = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnDateSearch = new System.Windows.Forms.Button();
            this.tpSetting = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.lblCamNo = new System.Windows.Forms.Label();
            this.cbxCamNo = new System.Windows.Forms.ComboBox();
            this.lblCamAddress = new System.Windows.Forms.Label();
            this.lbCamAddress = new System.Windows.Forms.Label();
            this.lblExposureTime = new System.Windows.Forms.Label();
            this.txtExposureTime = new System.Windows.Forms.TextBox();
            this.txtLightValue = new System.Windows.Forms.TextBox();
            this.lblLightValue = new System.Windows.Forms.Label();
            this.txtMiddleValue = new System.Windows.Forms.TextBox();
            this.chbxLiveMode = new System.Windows.Forms.CheckBox();
            this.lbSerialNumber = new System.Windows.Forms.Label();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.lbCamWidth = new System.Windows.Forms.Label();
            this.lbCamHeight = new System.Windows.Forms.Label();
            this.lblCamWidth = new System.Windows.Forms.Label();
            this.lblCamHeight = new System.Windows.Forms.Label();
            this.lbServoSpeed = new System.Windows.Forms.Label();
            this.txtServoSpeed = new System.Windows.Forms.TextBox();
            this.lblMiddleValue = new System.Windows.Forms.Label();
            this.btnGrab = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnJogLeft = new System.Windows.Forms.Button();
            this.btnJogRight = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnApplyCameraParameter = new System.Windows.Forms.Button();
            this.btnFolder = new System.Windows.Forms.Button();
            this.btnCalibration = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbMain = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbHistory = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbSetting = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.tpHistory.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.panel3.SuspendLayout();
            this.tpSetting.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(362, 680);
            this.tableLayoutPanel6.TabIndex = 178;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tabControl1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 105);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(356, 572);
            this.panel4.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tpMain);
            this.tabControl1.Controls.Add(this.tpHistory);
            this.tabControl1.Controls.Add(this.tpSetting);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(356, 572);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.dgvResult);
            this.tpMain.Location = new System.Drawing.Point(4, 5);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(348, 563);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "tabPage1";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResult.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.L,
            this.R,
            this.Distance,
            this.Date});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(3, 3);
            this.dgvResult.Name = "dgvResult";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(342, 557);
            this.dgvResult.TabIndex = 0;
            this.dgvResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellClick);
            // 
            // No
            // 
            this.No.FillWeight = 50F;
            this.No.HeaderText = "No";
            this.No.MinimumWidth = 50;
            this.No.Name = "No";
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // L
            // 
            this.L.HeaderText = "L (mm)";
            this.L.MinimumWidth = 100;
            this.L.Name = "L";
            this.L.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // R
            // 
            this.R.HeaderText = "R (mm)";
            this.R.MinimumWidth = 100;
            this.R.Name = "R";
            this.R.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Distance
            // 
            this.Distance.HeaderText = "Distance (mm)";
            this.Distance.MinimumWidth = 110;
            this.Distance.Name = "Distance";
            this.Distance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 110;
            this.Date.Name = "Date";
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpHistory
            // 
            this.tpHistory.Controls.Add(this.tableLayoutPanel7);
            this.tpHistory.Location = new System.Drawing.Point(4, 5);
            this.tpHistory.Name = "tpHistory";
            this.tpHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tpHistory.Size = new System.Drawing.Size(348, 563);
            this.tpHistory.TabIndex = 1;
            this.tpHistory.Text = "tabPage2";
            this.tpHistory.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.dgvHistory, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(342, 557);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Azure;
            this.dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(3, 43);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowTemplate.Height = 23;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(336, 511);
            this.dgvHistory.TabIndex = 2;
            this.dgvHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistory_CellClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dateTimePicker2);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.btnDateSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(336, 34);
            this.panel3.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(269, -1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 35);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "~";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(113, 6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(81, 21);
            this.dateTimePicker2.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(9, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(83, 21);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // btnDateSearch
            // 
            this.btnDateSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDateSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDateSearch.Location = new System.Drawing.Point(200, -2);
            this.btnDateSearch.Name = "btnDateSearch";
            this.btnDateSearch.Size = new System.Drawing.Size(69, 35);
            this.btnDateSearch.TabIndex = 12;
            this.btnDateSearch.Text = "Search";
            this.btnDateSearch.UseVisualStyleBackColor = false;
            this.btnDateSearch.Click += new System.EventHandler(this.btnDateSearch_Click);
            // 
            // tpSetting
            // 
            this.tpSetting.Controls.Add(this.panel1);
            this.tpSetting.Location = new System.Drawing.Point(4, 5);
            this.tpSetting.Name = "tpSetting";
            this.tpSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tpSetting.Size = new System.Drawing.Size(348, 563);
            this.tpSetting.TabIndex = 2;
            this.tpSetting.Text = "tabPage3";
            this.tpSetting.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 557);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtCount, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblCamNo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxCamNo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCamAddress, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbCamAddress, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblExposureTime, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtExposureTime, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtLightValue, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblLightValue, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtMiddleValue, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.chbxLiveMode, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.lbSerialNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSerialNumber, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbCamWidth, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbCamHeight, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCamWidth, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCamHeight, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbServoSpeed, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtServoSpeed, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblMiddleValue, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnGrab, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.btnApplyCameraParameter, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.btnFolder, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.btnCalibration, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(280, 280);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.771902F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.771902F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.771902F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.771902F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.771902F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.816705F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.816705F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.816705F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.816705F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.817735F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.019262F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.019262F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.017412F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(342, 557);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtCount
            // 
            this.txtCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.Location = new System.Drawing.Point(174, 325);
            this.txtCount.Multiline = true;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(164, 37);
            this.txtCount.TabIndex = 33;
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCamNo
            // 
            this.lblCamNo.AutoSize = true;
            this.lblCamNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCamNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamNo.Location = new System.Drawing.Point(4, 1);
            this.lblCamNo.Name = "lblCamNo";
            this.lblCamNo.Size = new System.Drawing.Size(163, 28);
            this.lblCamNo.TabIndex = 0;
            this.lblCamNo.Text = "Cam No";
            this.lblCamNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxCamNo
            // 
            this.cbxCamNo.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.cbxCamNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxCamNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCamNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCamNo.FormattingEnabled = true;
            this.cbxCamNo.Location = new System.Drawing.Point(174, 4);
            this.cbxCamNo.Name = "cbxCamNo";
            this.cbxCamNo.Size = new System.Drawing.Size(164, 26);
            this.cbxCamNo.TabIndex = 10;
            this.cbxCamNo.SelectedIndexChanged += new System.EventHandler(this.cbxCamNo_SelectedIndexChanged);
            // 
            // lblCamAddress
            // 
            this.lblCamAddress.AutoSize = true;
            this.lblCamAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCamAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamAddress.Location = new System.Drawing.Point(4, 59);
            this.lblCamAddress.Name = "lblCamAddress";
            this.lblCamAddress.Size = new System.Drawing.Size(163, 28);
            this.lblCamAddress.TabIndex = 1;
            this.lblCamAddress.Text = "Cam Address";
            this.lblCamAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCamAddress
            // 
            this.lbCamAddress.AutoSize = true;
            this.lbCamAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCamAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCamAddress.Location = new System.Drawing.Point(174, 59);
            this.lbCamAddress.Name = "lbCamAddress";
            this.lbCamAddress.Size = new System.Drawing.Size(164, 28);
            this.lbCamAddress.TabIndex = 15;
            this.lbCamAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExposureTime
            // 
            this.lblExposureTime.AutoSize = true;
            this.lblExposureTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExposureTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExposureTime.Location = new System.Drawing.Point(4, 190);
            this.lblExposureTime.Name = "lblExposureTime";
            this.lblExposureTime.Size = new System.Drawing.Size(163, 43);
            this.lblExposureTime.TabIndex = 3;
            this.lblExposureTime.Text = "Exposure Time";
            this.lblExposureTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtExposureTime
            // 
            this.txtExposureTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExposureTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExposureTime.Location = new System.Drawing.Point(174, 193);
            this.txtExposureTime.Multiline = true;
            this.txtExposureTime.Name = "txtExposureTime";
            this.txtExposureTime.Size = new System.Drawing.Size(164, 37);
            this.txtExposureTime.TabIndex = 9;
            this.txtExposureTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLightValue
            // 
            this.txtLightValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLightValue.Location = new System.Drawing.Point(174, 237);
            this.txtLightValue.Multiline = true;
            this.txtLightValue.Name = "txtLightValue";
            this.txtLightValue.Size = new System.Drawing.Size(164, 37);
            this.txtLightValue.TabIndex = 20;
            this.txtLightValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLightValue
            // 
            this.lblLightValue.AutoSize = true;
            this.lblLightValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLightValue.Location = new System.Drawing.Point(4, 234);
            this.lblLightValue.Name = "lblLightValue";
            this.lblLightValue.Size = new System.Drawing.Size(163, 43);
            this.lblLightValue.TabIndex = 19;
            this.lblLightValue.Text = "Light Value";
            this.lblLightValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMiddleValue
            // 
            this.txtMiddleValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMiddleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddleValue.Location = new System.Drawing.Point(174, 281);
            this.txtMiddleValue.Multiline = true;
            this.txtMiddleValue.Name = "txtMiddleValue";
            this.txtMiddleValue.Size = new System.Drawing.Size(164, 37);
            this.txtMiddleValue.TabIndex = 22;
            this.txtMiddleValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chbxLiveMode
            // 
            this.chbxLiveMode.AutoSize = true;
            this.chbxLiveMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbxLiveMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxLiveMode.Location = new System.Drawing.Point(4, 369);
            this.chbxLiveMode.Name = "chbxLiveMode";
            this.chbxLiveMode.Size = new System.Drawing.Size(163, 38);
            this.chbxLiveMode.TabIndex = 14;
            this.chbxLiveMode.Text = "LiveMode";
            this.chbxLiveMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbxLiveMode.UseVisualStyleBackColor = true;
            this.chbxLiveMode.CheckedChanged += new System.EventHandler(this.chbxLiveMode_CheckedChanged);
            // 
            // lbSerialNumber
            // 
            this.lbSerialNumber.AutoSize = true;
            this.lbSerialNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSerialNumber.Location = new System.Drawing.Point(174, 30);
            this.lbSerialNumber.Name = "lbSerialNumber";
            this.lbSerialNumber.Size = new System.Drawing.Size(164, 28);
            this.lbSerialNumber.TabIndex = 16;
            this.lbSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNumber.Location = new System.Drawing.Point(4, 30);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(163, 28);
            this.lblSerialNumber.TabIndex = 4;
            this.lblSerialNumber.Text = "Cam Serial";
            this.lblSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCamWidth
            // 
            this.lbCamWidth.AutoSize = true;
            this.lbCamWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCamWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCamWidth.Location = new System.Drawing.Point(174, 88);
            this.lbCamWidth.Name = "lbCamWidth";
            this.lbCamWidth.Size = new System.Drawing.Size(164, 28);
            this.lbCamWidth.TabIndex = 17;
            this.lbCamWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCamHeight
            // 
            this.lbCamHeight.AutoSize = true;
            this.lbCamHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCamHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCamHeight.Location = new System.Drawing.Point(174, 117);
            this.lbCamHeight.Name = "lbCamHeight";
            this.lbCamHeight.Size = new System.Drawing.Size(164, 28);
            this.lbCamHeight.TabIndex = 18;
            this.lbCamHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCamWidth
            // 
            this.lblCamWidth.AutoSize = true;
            this.lblCamWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCamWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamWidth.Location = new System.Drawing.Point(4, 88);
            this.lblCamWidth.Name = "lblCamWidth";
            this.lblCamWidth.Size = new System.Drawing.Size(163, 28);
            this.lblCamWidth.TabIndex = 6;
            this.lblCamWidth.Text = "Cam Width";
            this.lblCamWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCamHeight
            // 
            this.lblCamHeight.AutoSize = true;
            this.lblCamHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCamHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamHeight.Location = new System.Drawing.Point(4, 117);
            this.lblCamHeight.Name = "lblCamHeight";
            this.lblCamHeight.Size = new System.Drawing.Size(163, 28);
            this.lblCamHeight.TabIndex = 5;
            this.lblCamHeight.Text = "Cam Height";
            this.lblCamHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbServoSpeed
            // 
            this.lbServoSpeed.AutoSize = true;
            this.lbServoSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbServoSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServoSpeed.Location = new System.Drawing.Point(4, 146);
            this.lbServoSpeed.Name = "lbServoSpeed";
            this.lbServoSpeed.Size = new System.Drawing.Size(163, 43);
            this.lbServoSpeed.TabIndex = 26;
            this.lbServoSpeed.Text = "Servo Speed";
            this.lbServoSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtServoSpeed
            // 
            this.txtServoSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtServoSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServoSpeed.Location = new System.Drawing.Point(174, 149);
            this.txtServoSpeed.Multiline = true;
            this.txtServoSpeed.Name = "txtServoSpeed";
            this.txtServoSpeed.Size = new System.Drawing.Size(164, 37);
            this.txtServoSpeed.TabIndex = 27;
            this.txtServoSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMiddleValue
            // 
            this.lblMiddleValue.AutoSize = true;
            this.lblMiddleValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMiddleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleValue.Location = new System.Drawing.Point(4, 278);
            this.lblMiddleValue.Name = "lblMiddleValue";
            this.lblMiddleValue.Size = new System.Drawing.Size(163, 43);
            this.lblMiddleValue.TabIndex = 21;
            this.lblMiddleValue.Text = "Middle Distance(mm)";
            this.lblMiddleValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGrab
            // 
            this.btnGrab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrab.Location = new System.Drawing.Point(174, 369);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(163, 38);
            this.btnGrab.TabIndex = 25;
            this.btnGrab.Text = "Grab";
            this.btnGrab.UseVisualStyleBackColor = true;
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnJogLeft, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnJogRight, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(174, 414);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(164, 38);
            this.tableLayoutPanel3.TabIndex = 30;
            // 
            // btnJogLeft
            // 
            this.btnJogLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogLeft.Location = new System.Drawing.Point(3, 3);
            this.btnJogLeft.Name = "btnJogLeft";
            this.btnJogLeft.Size = new System.Drawing.Size(76, 32);
            this.btnJogLeft.TabIndex = 30;
            this.btnJogLeft.Text = "<";
            this.btnJogLeft.UseVisualStyleBackColor = true;
            this.btnJogLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogLeft_MouseDown);
            this.btnJogLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogLeft_MouseUp);
            // 
            // btnJogRight
            // 
            this.btnJogRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogRight.Location = new System.Drawing.Point(85, 3);
            this.btnJogRight.Name = "btnJogRight";
            this.btnJogRight.Size = new System.Drawing.Size(76, 32);
            this.btnJogRight.TabIndex = 29;
            this.btnJogRight.Text = ">";
            this.btnJogRight.UseVisualStyleBackColor = true;
            this.btnJogRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogRight_MouseDown);
            this.btnJogRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogRight_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 411);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 44);
            this.label3.TabIndex = 31;
            this.label3.Text = "Servo Jog";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnApplyCameraParameter
            // 
            this.btnApplyCameraParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApplyCameraParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyCameraParameter.Location = new System.Drawing.Point(174, 504);
            this.btnApplyCameraParameter.Name = "btnApplyCameraParameter";
            this.btnApplyCameraParameter.Size = new System.Drawing.Size(164, 49);
            this.btnApplyCameraParameter.TabIndex = 11;
            this.btnApplyCameraParameter.Text = "All Apply";
            this.btnApplyCameraParameter.UseVisualStyleBackColor = true;
            this.btnApplyCameraParameter.Click += new System.EventHandler(this.btnApplyCameraParameter_Click);
            // 
            // btnFolder
            // 
            this.btnFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolder.Location = new System.Drawing.Point(4, 504);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(163, 49);
            this.btnFolder.TabIndex = 28;
            this.btnFolder.Text = "Program Folder Open";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // btnCalibration
            // 
            this.btnCalibration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalibration.Location = new System.Drawing.Point(174, 459);
            this.btnCalibration.Name = "btnCalibration";
            this.btnCalibration.Size = new System.Drawing.Size(164, 38);
            this.btnCalibration.TabIndex = 24;
            this.btnCalibration.Text = "Search";
            this.btnCalibration.UseVisualStyleBackColor = true;
            this.btnCalibration.Click += new System.EventHandler(this.btnCalibration_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 44);
            this.label2.TabIndex = 23;
            this.label2.Text = "Calibration";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 43);
            this.label4.TabIndex = 32;
            this.label4.Text = "Count";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tableLayoutPanel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(356, 96);
            this.panel5.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel7, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(356, 96);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(112, 90);
            this.panel2.TabIndex = 0;
            // 
            // cbMain
            // 
            this.cbMain.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbMain.BackColor = System.Drawing.Color.LightBlue;
            this.cbMain.Checked = true;
            this.cbMain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMain.Location = new System.Drawing.Point(0, 0);
            this.cbMain.Name = "cbMain";
            this.cbMain.Size = new System.Drawing.Size(112, 90);
            this.cbMain.TabIndex = 3;
            this.cbMain.Text = "Main";
            this.cbMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbMain.UseVisualStyleBackColor = false;
            this.cbMain.Click += new System.EventHandler(this.cbMain_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbHistory);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(121, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(112, 90);
            this.panel6.TabIndex = 1;
            // 
            // cbHistory
            // 
            this.cbHistory.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbHistory.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cbHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbHistory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHistory.Location = new System.Drawing.Point(0, 0);
            this.cbHistory.Name = "cbHistory";
            this.cbHistory.Size = new System.Drawing.Size(112, 90);
            this.cbHistory.TabIndex = 4;
            this.cbHistory.Text = "History";
            this.cbHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbHistory.UseVisualStyleBackColor = false;
            this.cbHistory.Click += new System.EventHandler(this.cbHistory_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cbSetting);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(239, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(114, 90);
            this.panel7.TabIndex = 2;
            // 
            // cbSetting
            // 
            this.cbSetting.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbSetting.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cbSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSetting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSetting.Location = new System.Drawing.Point(0, 0);
            this.cbSetting.Name = "cbSetting";
            this.cbSetting.Size = new System.Drawing.Size(114, 90);
            this.cbSetting.TabIndex = 5;
            this.cbSetting.Text = "Setting";
            this.cbSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSetting.UseVisualStyleBackColor = false;
            this.cbSetting.Click += new System.EventHandler(this.cbSetting_CheckedChanged);
            // 
            // CtrlTapDispaly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel6);
            this.Name = "CtrlTapDispaly";
            this.Size = new System.Drawing.Size(362, 680);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.tpHistory.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tpSetting.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.TabPage tpHistory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDateSearch;
        private System.Windows.Forms.TabPage tpSetting;
        private System.Windows.Forms.CheckBox cbSetting;
        private System.Windows.Forms.CheckBox cbHistory;
        private System.Windows.Forms.CheckBox cbMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCamNo;
        private System.Windows.Forms.Label lblCamAddress;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblExposureTime;
        private System.Windows.Forms.Label lblCamWidth;
        private System.Windows.Forms.Label lblCamHeight;
        private System.Windows.Forms.TextBox txtExposureTime;
        private System.Windows.Forms.ComboBox cbxCamNo;
        private System.Windows.Forms.Button btnApplyCameraParameter;
        public System.Windows.Forms.CheckBox chbxLiveMode;
        private System.Windows.Forms.Label lbCamAddress;
        private System.Windows.Forms.Label lbSerialNumber;
        private System.Windows.Forms.Label lbCamWidth;
        private System.Windows.Forms.Label lbCamHeight;
        private System.Windows.Forms.Label lblLightValue;
        public System.Windows.Forms.TextBox txtLightValue;
        private System.Windows.Forms.Label lblMiddleValue;
        public System.Windows.Forms.TextBox txtMiddleValue;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn L;
        private System.Windows.Forms.DataGridViewTextBoxColumn R;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCalibration;
        public System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnGrab;
        private System.Windows.Forms.Label lbServoSpeed;
        private System.Windows.Forms.TextBox txtServoSpeed;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnJogLeft;
        private System.Windows.Forms.Button btnJogRight;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label4;
    }
}
