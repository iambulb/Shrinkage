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
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.Dimensioning;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Implementation;
using Cognex.VisionPro.Display;

namespace LG_Chem
{
    public partial class CtrlDisplay : UserControl
    {
        private CogDisplay LresultDisplay = null;
        private CogDisplay RresultDisplay = null;

        
        public CtrlDisplay()
        {
            InitializeComponent();
            //Machine.Instance()._cameraManager._cameraList[0].handler += UpdateImage;
            Addhandler();
        }
        public void Addhandler()
        {
            foreach (Device.Camera.CameraHik camera in Machine._cameraManager._cameraList)
            {
                camera.handler += UpdateImage;
            }
        }
        private void CtrlDisplay_Load(object sender, EventArgs e)
        {
            LresultDisplay = new CogDisplay();
            LresultDisplay.Dock = DockStyle.Fill;
            pbLimage.Controls.Add(LresultDisplay);

            RresultDisplay = new CogDisplay();
            RresultDisplay.Dock = DockStyle.Fill;
            pbRimage.Controls.Add(RresultDisplay);

        }
        public delegate void InvokeDisplayResultImageDele(Bitmap lImg, Bitmap rImg, CogRectangle LRect, CogRectangle RRect, CogLineSegment LDis, CogLineSegment RDis, CogGraphicLabel LLabel, CogGraphicLabel RLabel, CogGraphicLabel TotalLabel, double Total);
        public void DisplayResultImage(Bitmap Limg, Bitmap Rimg, CogRectangle LRect, CogRectangle RRect,CogLineSegment LDis, CogLineSegment RDis, CogGraphicLabel LLabel, CogGraphicLabel RLabel, CogGraphicLabel TotalLabel, double Total)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeDisplayResultImageDele callback = DisplayResultImage;
                    BeginInvoke(callback, Limg, Rimg, LRect, RRect, LDis, RDis, LLabel, RLabel, TotalLabel, Total);
                    return;
                }

                FormMain.Instance().lbTotal.Text = Total.ToString() + " mm";
                if (Limg == null || Rimg == null)
                    return;

                if (LresultDisplay.Image != null)
                {
                    LresultDisplay.Image = null;
                }

                if (RresultDisplay.Image != null)
                {
                    RresultDisplay.Image = null;
                }

                LresultDisplay.StaticGraphics.Clear();
                LresultDisplay.InteractiveGraphics.Clear();
                LresultDisplay.Image = new CogImage8Grey(Limg);

                LresultDisplay.StaticGraphics.Add(LDis, "");
                LresultDisplay.StaticGraphics.Add(LRect, "");
                LresultDisplay.StaticGraphics.Add(LLabel, "");
                LresultDisplay.StaticGraphics.Add(TotalLabel, "");
                LresultDisplay.Zoom = 0.133;
                //LresultDisplay.Update();
                //Bitmap i = LresultDisplay.Image.ToBitmap();
                //i.Save(Directory.GetCurrentDirectory() + "\\" + "image" + "\\" + "Test.bmp");

                RresultDisplay.StaticGraphics.Clear();
                RresultDisplay.InteractiveGraphics.Clear();
                RresultDisplay.Image = new CogImage8Grey(Rimg);

                RresultDisplay.StaticGraphics.Add(RDis, "");
                RresultDisplay.StaticGraphics.Add(RRect, "");
                RresultDisplay.StaticGraphics.Add(RLabel, "");
                RresultDisplay.Zoom = 0.133;

                //RresultDisplay.Update();
                //Limg.Dispose();
                //Rimg.Dispose();

                //IDisposable disposable = Limg;
                //disposable.Dispose();
                //disposable = Rimg;
                //disposable.Dispose();
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
            }
        }
        private delegate void DeleUpdateImage(int camNo, Bitmap bitmap);

        public void UpdateImage(int camNo, Bitmap bitmap)
        {
            if (this.InvokeRequired)
            {
                DeleUpdateImage updateImageDisplay = new DeleUpdateImage(UpdateImage);
                this.Invoke(updateImageDisplay, camNo, bitmap);
                return;
            }

            //ICogImage oldbmp = LresultDisplay.Image;
        
            if (camNo == 0)
            {
                LresultDisplay.StaticGraphics.Clear();
                LresultDisplay.InteractiveGraphics.Clear();
                LresultDisplay.Image = new CogImage8Grey(bitmap);
                LresultDisplay.Update();
                LresultDisplay.Zoom = 0.133;
            }
            else
            {
                RresultDisplay.StaticGraphics.Clear();
                RresultDisplay.InteractiveGraphics.Clear();
                RresultDisplay.Image = new CogImage8Grey(bitmap);
                RresultDisplay.Update();
                RresultDisplay.Zoom = 0.133;
            }
            //if (oldbmp != null)
            //{
            //    oldbmp.Dispose();
            //}
            //oldbmp = null;
        }
         private delegate void DeleLoadImage(Bitmap Lbitmap, Bitmap Rbitmap);
        public void LoadImage(Bitmap Lbitmap, Bitmap Rbitmap)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    DeleLoadImage LoadImageDisplay = new DeleLoadImage(LoadImage);
                    this.Invoke(LoadImageDisplay, Lbitmap, Rbitmap);
                    return;
                }

                //ICogImage oldbmp = LresultDisplay.Image;

                LresultDisplay.StaticGraphics.Clear();
                LresultDisplay.InteractiveGraphics.Clear();
                LresultDisplay.Image = new CogImage8Grey(Lbitmap);
                LresultDisplay.Update();
                LresultDisplay.Zoom = 0.133;

                RresultDisplay.StaticGraphics.Clear();
                RresultDisplay.InteractiveGraphics.Clear();
                RresultDisplay.Image = new CogImage8Grey(Rbitmap);
                RresultDisplay.Update();
                RresultDisplay.Zoom = 0.133;

                //if (oldbmp != null)
                //{
                //    oldbmp.Dispose();
                //}
                //oldbmp = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("이미지가 없습니다.");
            }


        }
    }
}
