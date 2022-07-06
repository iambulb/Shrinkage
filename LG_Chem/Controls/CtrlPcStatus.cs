using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LG_Chem
{
    public partial class CtrlPcStatus : Form
    {
        private Series m_series_hdd = null;
        private DriveInfo m_hddInfo = new DriveInfo("D");

        private static double m_totalMem = 32.0;

        public double m_dUsedDiskPercentage = 0;

        public CtrlPcStatus()
        {
            TopLevel = false;
            InitializeComponent();
        }

        private void FormStatus_Load(object sender, EventArgs e)
        {
            Initchart();
            timer1.Start();
        }

        private void Initchart()
        {
            double HddTotalSize = (m_hddInfo.TotalSize) / 1024 / 1024 / 1024;
            double HddFreeSize = (m_hddInfo.AvailableFreeSpace) / 1024 / 1024 / 1024;

            m_series_hdd = chartHDD.Series.Add("HDD");
            m_series_hdd.ChartType = SeriesChartType.Pie;

            m_series_hdd.Points.AddY(HddFreeSize);
            m_series_hdd.Points[0].Color = Color.Blue;
            m_series_hdd.Points[0].BorderColor = Color.Green;
            m_series_hdd.Points[0].BorderWidth = 3;
            m_series_hdd.Points[0].LegendText = "Free : " + HddFreeSize.ToString("F0") + "GB";

            m_series_hdd.Points.AddY(Convert.ToInt32(HddTotalSize - HddFreeSize));
            m_series_hdd.Points[1].Color = Color.Red;
            m_series_hdd.Points[1].BorderColor = Color.Green;
            m_series_hdd.Points[1].BorderWidth = 3;
            m_series_hdd.Points[1].LegendText = "used : " + (HddTotalSize - HddFreeSize).ToString("F0") + "GB";

            ui_bar_cpu.Visible = true;
            ui_bar_mem.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                double dHddTotalSize = (m_hddInfo.TotalSize) / 1024 / 1024 / 1024;
                double dHddFreeSize = (m_hddInfo.AvailableFreeSpace) / 1024 / 1024 / 1024;
                m_dUsedDiskPercentage = (dHddTotalSize - dHddFreeSize) / dHddTotalSize * 100;

                ui_lb_hddTotal.Text = "Total : " + dHddTotalSize.ToString("F0") + "GB";
                ui_lb_hddUsed.Text = "Used : " + m_dUsedDiskPercentage.ToString("F2") + "%";
                m_series_hdd.Points[0].SetValueY(dHddFreeSize);
                m_series_hdd.Points[1].SetValueY((Convert.ToInt32(dHddTotalSize - dHddFreeSize)));

                double dCpu = PCcpu.NextValue();
                double dUsedMem = (m_totalMem - PCmem.NextValue() / 1024);
                
                ui_bar_cpu.Value = Convert.ToInt32(dCpu);
                ui_bar_mem.Value = (int)((/*m_totalMem - */dUsedMem) / m_totalMem * 100);

                lblCPU.Text = "CPU: " + dCpu.ToString("F2") + "%";
                lblMem.Text = "MEM: " + ((/*m_totalMem -*/ dUsedMem) / m_totalMem * 100).ToString("F2") + "%";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
