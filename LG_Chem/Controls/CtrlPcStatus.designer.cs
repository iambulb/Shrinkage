namespace LG_Chem
{
    partial class CtrlPcStatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PCcpu = new System.Diagnostics.PerformanceCounter();
            this.PCmem = new System.Diagnostics.PerformanceCounter();
            this.PChdd = new System.Diagnostics.PerformanceCounter();
            this.chartHDD = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ui_bar_cpu = new System.Windows.Forms.ProgressBar();
            this.lblCPU = new System.Windows.Forms.Label();
            this.lblMem = new System.Windows.Forms.Label();
            this.ui_bar_mem = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ui_lb_hddUsed = new System.Windows.Forms.Label();
            this.ui_lb_hddTotal = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.PCcpu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCmem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PChdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHDD)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PCcpu
            // 
            this.PCcpu.CategoryName = "Processor";
            this.PCcpu.CounterName = "% Processor Time";
            this.PCcpu.InstanceName = "_Total";
            // 
            // PCmem
            // 
            this.PCmem.CategoryName = "Memory";
            this.PCmem.CounterName = "Available MBytes";
            // 
            // PChdd
            // 
            this.PChdd.CategoryName = "LogicalDisk";
            this.PChdd.CounterName = "Free Megabytes";
            this.PChdd.InstanceName = "D:";
            // 
            // chartHDD
            // 
            this.chartHDD.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea12.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea12.Name = "ChartArea1";
            this.chartHDD.ChartAreas.Add(chartArea12);
            this.chartHDD.Dock = System.Windows.Forms.DockStyle.Fill;
            legend12.BackColor = System.Drawing.Color.WhiteSmoke;
            legend12.Name = "Legend1";
            legend12.Title = "HDD";
            this.chartHDD.Legends.Add(legend12);
            this.chartHDD.Location = new System.Drawing.Point(0, 0);
            this.chartHDD.Name = "chartHDD";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.chartHDD.Series.Add(series12);
            this.chartHDD.Size = new System.Drawing.Size(395, 200);
            this.chartHDD.TabIndex = 0;
            this.chartHDD.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ui_bar_cpu
            // 
            this.ui_bar_cpu.Location = new System.Drawing.Point(242, 121);
            this.ui_bar_cpu.Name = "ui_bar_cpu";
            this.ui_bar_cpu.Size = new System.Drawing.Size(100, 20);
            this.ui_bar_cpu.TabIndex = 1;
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Location = new System.Drawing.Point(255, 107);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(90, 12);
            this.lblCPU.TabIndex = 2;
            this.lblCPU.Text = "CPU Usage(%)";
            // 
            // lblMem
            // 
            this.lblMem.AutoSize = true;
            this.lblMem.Location = new System.Drawing.Point(251, 148);
            this.lblMem.Name = "lblMem";
            this.lblMem.Size = new System.Drawing.Size(112, 12);
            this.lblMem.TabIndex = 3;
            this.lblMem.Text = "Memory Usage(%)";
            // 
            // ui_bar_mem
            // 
            this.ui_bar_mem.Location = new System.Drawing.Point(242, 161);
            this.ui_bar_mem.Name = "ui_bar_mem";
            this.ui_bar_mem.Size = new System.Drawing.Size(100, 20);
            this.ui_bar_mem.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.ui_bar_mem);
            this.panel1.Controls.Add(this.ui_bar_cpu);
            this.panel1.Controls.Add(this.lblMem);
            this.panel1.Controls.Add(this.ui_lb_hddUsed);
            this.panel1.Controls.Add(this.lblCPU);
            this.panel1.Controls.Add(this.ui_lb_hddTotal);
            this.panel1.Controls.Add(this.chartHDD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 200);
            this.panel1.TabIndex = 7;
            // 
            // ui_lb_hddUsed
            // 
            this.ui_lb_hddUsed.AutoSize = true;
            this.ui_lb_hddUsed.Location = new System.Drawing.Point(248, 78);
            this.ui_lb_hddUsed.Name = "ui_lb_hddUsed";
            this.ui_lb_hddUsed.Size = new System.Drawing.Size(78, 12);
            this.ui_lb_hddUsed.TabIndex = 8;
            this.ui_lb_hddUsed.Text = "UsedHDD(%)";
            // 
            // ui_lb_hddTotal
            // 
            this.ui_lb_hddTotal.AutoSize = true;
            this.ui_lb_hddTotal.Location = new System.Drawing.Point(246, 60);
            this.ui_lb_hddTotal.Name = "ui_lb_hddTotal";
            this.ui_lb_hddTotal.Size = new System.Drawing.Size(77, 12);
            this.ui_lb_hddTotal.TabIndex = 7;
            this.ui_lb_hddTotal.Text = "TotalHDD(%)";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.19753F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(402, 205);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // CtrlPcStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 205);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CtrlPcStatus";
            this.Text = "FromStatus";
            this.Load += new System.EventHandler(this.FormStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PCcpu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCmem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PChdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHDD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Diagnostics.PerformanceCounter PCcpu;
        private System.Diagnostics.PerformanceCounter PCmem;
        private System.Diagnostics.PerformanceCounter PChdd;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHDD;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar ui_bar_cpu;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Label lblMem;
        private System.Windows.Forms.ProgressBar ui_bar_mem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ui_lb_hddTotal;
        private System.Windows.Forms.Label ui_lb_hddUsed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}