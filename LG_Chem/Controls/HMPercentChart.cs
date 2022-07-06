using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace HMechUtility.Controls
{
    public partial class HMPercentChart : UserControl
    {
        public DoubleBufferPanel DoubleBuffering = null;

        private Rectangle _DrawChartRect;
        private Rectangle _DrawChartRect2;
        private const int _radius = 70; //큰 원의 반지름
        private const int _radius2 = 40; //작은 원의 반지름
        
        private float _percent = 0;
        public float Percent
        {
            get { return _percent; }
            set { _percent = value; }
        }

        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private Font _fontType;
        public Font FontType
        {
            get { return _fontType; }
            set { _fontType = value; }
        }

        private SolidBrush _graphColor;
        public SolidBrush GraphColor
        {
            get { return _graphColor; }
            set { _graphColor = value; }
        }

        public HMPercentChart()
        {
            InitializeComponent();
        }

        public void UpdateUI(float percent)
        {
            if (_percent == percent)
                return;
            else
            {
                _percent = percent;

                if (DoubleBuffering != null)
                    DoubleBuffering.Invalidate();
            }
        }

        private void HMPercentChart_Load(object sender, EventArgs e)
        {
            AddControls();
        }

        private void AddControls()
        {
            DoubleBuffering = new DoubleBufferPanel();
            pnlPercentChart.Controls.Add(DoubleBuffering);
            DoubleBuffering.Dock = DockStyle.Fill;
            DoubleBuffering.Paint += DoubleBuffering_Paint;
            DoubleBuffering.Resize += DoubleBuffering_Resize;
            DoubleBuffering.SizeChanged += DoubleBuffering_Resize;
        }

        private void DoubleBuffering_Resize(object sender, EventArgs e)
        {
            if (DoubleBuffering != null)
            {
                SetDrawChartRect();
                DoubleBuffering.Invalidate();
            }
        }

        private void DoubleBuffering_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void Draw(Graphics g)
        {
            try
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.Clear(SystemColors.Control);

                SetDrawChartRect();

                DrawBaseLine(g);

                DrawGraph(g);
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void SetDrawChartRect()
        {
            _DrawChartRect = new Rectangle(pnlPercentChart.Width / 2 - _radius, pnlPercentChart.Height / 2 - _radius, _radius * 2, _radius * 2);
            _DrawChartRect2 = new Rectangle(pnlPercentChart.Width / 2 - _radius2, pnlPercentChart.Height / 2 - _radius2, _radius2 * 2, _radius2 * 2);
        }

        private void DrawBaseLine(Graphics g)
        {
            Pen pen = new Pen(SystemColors.ScrollBar, 2);
            SolidBrush brush = new SolidBrush(SystemColors.ScrollBar);
            
            // 영역 초기화
            g.FillRectangle(new SolidBrush(SystemColors.Window), new RectangleF(pnlPercentChart.Left, pnlPercentChart.Top, pnlPercentChart.Width, pnlPercentChart.Height));
            // Graph
            g.DrawArc(pen, _DrawChartRect, 180, 180);
            g.DrawArc(pen, _DrawChartRect2, 180, 180);
            g.FillPie(brush, _DrawChartRect, 180, 180);
            g.DrawLine(pen, new PointF(pnlPercentChart.Width / 2 - _radius, pnlPercentChart.Height / 2), new PointF(pnlPercentChart.Width / 2 - _radius2, pnlPercentChart.Height / 2));
            g.DrawLine(pen, new PointF(pnlPercentChart.Width / 2 + _radius, pnlPercentChart.Height / 2), new PointF(pnlPercentChart.Width / 2 + _radius2, pnlPercentChart.Height / 2));
        }

        private void DrawGraph(Graphics g)
        {
            GraphicsPath myGraphicsPath = new GraphicsPath();
            float angle = _percent * (float)180 / (float)100; //180도를 곱하고 100(%)으로 나눔

            //Percent에 따라 색상 변경
            if (_percent < 30)
                _graphColor = new SolidBrush(Color.MediumSeaGreen);
            else if(_percent < 60)
                _graphColor = new SolidBrush(Color.Orange);
            else
                _graphColor = new SolidBrush(Color.Red);

            // Percent만큼 Graph 색칠
            g.FillPie(_graphColor, _DrawChartRect, 180, angle);
            // 작은 Rect영역에 색 덧칠
            g.FillEllipse(new SolidBrush(SystemColors.Window), _DrawChartRect2);
            // Draw String
            DrawPercentString(g, _percent);
            DrawDriveString(g, _title);
        }

        public void SetFontStyle(int fontSize, FontStyle fontStyle)
        {
            _fontType = new Font("Microsoft Sans Serif", fontSize, fontStyle);
        }

        private void DrawPercentString(Graphics g, float percent)
        {
            SetFontStyle(10, FontStyle.Bold);
            string axisXString = percent.ToString("F2") + " %";
            float axisXTypeWidth = g.MeasureString(axisXString, _fontType).Width;
            float axisXTypeHeight = g.MeasureString(axisXString, _fontType).Height;
            PointF axisXTypePoint = new PointF((pnlPercentChart.Width / 2) - (axisXTypeWidth / 2), (pnlPercentChart.Height / 2) - axisXTypeHeight);
            g.DrawString(axisXString, _fontType, _graphColor, axisXTypePoint);
        }

        private void DrawDriveString(Graphics g, string driveType)
        {
            SetFontStyle(10, FontStyle.Bold);
            string DriveString = driveType + " Drive Usage";
            float DriveStringWidth = g.MeasureString(DriveString, _fontType).Width;
            float DriveStringHeight = g.MeasureString(DriveString, _fontType).Height;
            PointF DriveStringPoint = new PointF((pnlPercentChart.Width / 2) - (DriveStringWidth / 2), (pnlPercentChart.Height / 2) + (DriveStringHeight / 2));
            g.DrawString(DriveString, _fontType, Brushes.Black, DriveStringPoint);
        }
    }
}
