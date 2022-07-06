using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;

namespace HMechUtility.Controls
{
    public partial class HMProgressBar : ProgressBar
    {
        #region Property
        private int _Fade = 150;
        public int Fade
        {
            get
            {
                return _Fade;
            }
            set
            {
                if (value < 0 || value > 255)
                {
                    object[] str = new object[] { value };
                    throw new ArgumentOutOfRangeException("value", string.Format(System.Globalization.CultureInfo.CurrentCulture, "A value of '{0}' is not valid for 'Fade'. 'Fade' must be between 0 and 255.", str));
                }

                _Fade = value;

                // Clean up previous brush
                if (_FadeBrush != null)
                {
                    _FadeBrush.Dispose();
                }

                _FadeBrush = new SolidBrush(Color.FromArgb(value, Color.White));

                Invalidate();
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        private SolidBrush _FadeBrush;
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }
        #endregion

        public HMProgressBar()
        {
            base.ForeColor = SystemColors.ControlText;
            _FadeBrush = new SolidBrush(Color.FromArgb(Fade, Color.White));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_FadeBrush != null)
                {
                    _FadeBrush.Dispose();
                    _FadeBrush = null;
                }
            }

            base.Dispose(disposing);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myParams = base.CreateParams;

                // Make the control use double buffering
                myParams.ExStyle |= NativeMethods.WS_EX_COMPOSITED;

                return myParams;
            }
        }

        protected override void WndProc(ref Message m)
        {
            int message = m.Msg;

            if (message == NativeMethods.WM_PAINT)
            {
                WmPaint(ref m);
                return;
            }

            if (message == NativeMethods.WM_PRINTCLIENT)
            {
                WmPrintClient(ref m);
                return;
            }

            base.WndProc(ref m);
        }

        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            builder.Append(GetType().FullName);
            builder.Append(", Minimum: ");
            builder.Append(Minimum.ToString(CultureInfo.CurrentCulture));
            builder.Append(", Maximum: ");
            builder.Append(Maximum.ToString(CultureInfo.CurrentCulture));
            builder.Append(", Value: ");
            builder.Append(Value.ToString(CultureInfo.CurrentCulture));

            return builder.ToString();
        }

        private void PaintPrivate(IntPtr device)
        {
            // Create a Graphics object for the device context
            using (Graphics graphics = Graphics.FromHdc(device))
            {
                Rectangle rect = ClientRectangle;

                if (_FadeBrush != null)
                {
                    // Paint a translucent white layer on top, to fade the colors a bit
                    graphics.FillRectangle(_FadeBrush, rect);
                }

                TextRenderer.DrawText(graphics, Text, Font, rect, ForeColor);
            }
        }

        private void WmPaint(ref Message m)
        {
            // Create a wrapper for the Handle
            HandleRef myHandle = new HandleRef(this, Handle);

            // Prepare the window for painting and retrieve a device context
            NativeMethods.PAINTSTRUCT pAINTSTRUCT = new NativeMethods.PAINTSTRUCT();
            IntPtr hDC = UnsafeNativeMethods.BeginPaint(myHandle, ref pAINTSTRUCT);

            try
            {
                // Apply hDC to message
                m.WParam = hDC;

                // Let Windows paint
                base.WndProc(ref m);

                // Custom painting
                PaintPrivate(hDC);
            }
            finally
            {
                // Release the device context that BeginPaint retrieved
                UnsafeNativeMethods.EndPaint(myHandle, ref pAINTSTRUCT);
            }
        }
        internal static class UnsafeNativeMethods
        {

            /* Prepares the specified window for painting and fills 
            a PAINTSTRUCT structure with information about the painting */
            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = false)]
            internal static extern IntPtr BeginPaint(HandleRef hWnd, [In][Out] ref NativeMethods.PAINTSTRUCT lpPaint);

            /* Marks the end of painting in the specified window. 
            This function is required for each call to the BeginPaint 
            function, but only after painting is complete. */
            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = false)]
            internal static extern bool EndPaint(HandleRef hWnd, ref NativeMethods.PAINTSTRUCT lpPaint);

        }

        internal static class SafeNativeMethods
        {

            /* Deletes a logical pen, brush, font, bitmap, region, or palette, 
            freeing all system resources associated with the object. After the 
            object has been deleted, the specified handle is no longer valid. */
            [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = false)]
            internal static extern bool DeleteObject(HandleRef hObject);

            /* Selects an object into the specified device context (DC). 
            The new object replaces the previous object of the same type. */
            [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = false)]
            internal static extern IntPtr SelectObject(HandleRef hDC, HandleRef hObject);

            /* Fills the specified buffer with the metrics for the currently selected font. */
            internal static int GetTextMetrics(HandleRef hDC, ref NativeMethods.TEXTMETRIC lptm)
            {
                if (Marshal.SystemDefaultCharSize != 1)
                {
                    // Handle Unicode
                    return SafeNativeMethods.GetTextMetricsW(hDC, out lptm);
                }

                // Handle ANSI; call GetTextMetricsA and translate to Unicode struct
                NativeMethods.TEXTMETRICA tEXTMETRICA = new NativeMethods.TEXTMETRICA();
                int result = SafeNativeMethods.GetTextMetricsA(hDC, out tEXTMETRICA);

                lptm.tmHeight = tEXTMETRICA.tmHeight;
                lptm.tmAscent = tEXTMETRICA.tmAscent;
                lptm.tmDescent = tEXTMETRICA.tmDescent;
                lptm.tmInternalLeading = tEXTMETRICA.tmInternalLeading;
                lptm.tmExternalLeading = tEXTMETRICA.tmExternalLeading;
                lptm.tmAveCharWidth = tEXTMETRICA.tmAveCharWidth;
                lptm.tmMaxCharWidth = tEXTMETRICA.tmMaxCharWidth;
                lptm.tmWeight = tEXTMETRICA.tmWeight;
                lptm.tmOverhang = tEXTMETRICA.tmOverhang;
                lptm.tmDigitizedAspectX = tEXTMETRICA.tmDigitizedAspectX;
                lptm.tmDigitizedAspectY = tEXTMETRICA.tmDigitizedAspectY;
                lptm.tmFirstChar = Convert.ToChar(tEXTMETRICA.tmFirstChar);
                lptm.tmLastChar = Convert.ToChar(tEXTMETRICA.tmLastChar);
                lptm.tmDefaultChar = Convert.ToChar(tEXTMETRICA.tmDefaultChar);
                lptm.tmBreakChar = Convert.ToChar(tEXTMETRICA.tmBreakChar);
                lptm.tmItalic = tEXTMETRICA.tmItalic;
                lptm.tmUnderlined = tEXTMETRICA.tmUnderlined;
                lptm.tmStruckOut = tEXTMETRICA.tmStruckOut;
                lptm.tmPitchAndFamily = tEXTMETRICA.tmPitchAndFamily;
                lptm.tmCharSet = tEXTMETRICA.tmCharSet;

                return result;
            }

            /* Fills the specified buffer with the metrics for the currently 
            selected font. This is the Ansi version of the function */
            [DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = false)]
            private static extern int GetTextMetricsA(HandleRef hDC, out NativeMethods.TEXTMETRICA lptm);

            /* Fills the specified buffer with the metrics for the currently 
            selected font. This is the Unicode version of the function.*/
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode, ExactSpelling = false)]
            private static extern int GetTextMetricsW(HandleRef hDC, out NativeMethods.TEXTMETRIC lptm);

        }
        private void WmPrintClient(ref Message m)
        {
            // Retrieve the device context
            IntPtr hDC = m.WParam;

            // Let Windows paint
            base.WndProc(ref m);

            // Custom painting
            PaintPrivate(hDC);
        }

        internal static class NativeMethods
        {


            #region Parameters

            /* Sent when the system makes a request to paint (a portion of) a window. */
            public const int WM_PAINT = 0xf;

            /* Sent to a window to request that it draw its client area in the 
            specified device context, most commonly in a printer device context. */
            public const int WM_PRINTCLIENT = 0x318;

            /* Paints all descendants of a window in bottom-to-top painting order using double-buffering. */
            public const int WS_EX_COMPOSITED = 0x2000000;

            #endregion


            #region Structures

            /* Contains information to be used to paint the client area of a window. */
            [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public struct PAINTSTRUCT
            {
                /* A handle to the display DC to use for painting. */
                public IntPtr hdc;

                /* Indicates whether the background should be erased. */
                public bool fErase;

                /* A RECT structure that specifies the upper left and lower right 
                corners of the rectangle in which the painting is requested, */
                public RECT rcPaint;

                /* Reserved; used internally by the system. */
                public bool fRestore;

                /* Reserved; used internally by the system. */
                public bool fIncUpdate;
            }

            /* Defines the coordinates of the upper-left and lower-right corners of a rectangle. */
            [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public struct RECT
            {
                /* The x-coordinate of the upper-left corner of the rectangle. */
                public int Left;

                /* The y-coordinate of the upper-left corner of the rectangle. */
                public int Top;

                /* The x-coordinate of the lower-right corner of the rectangle. */
                public int Right;

                /* The y-coordinate of the lower-right corner of the rectangle. */
                public int Bottom;
            }

            /*  Contains basic information about a physical font. This is the Unicode version of the structure. */
            [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
            public struct TEXTMETRIC
            {
                /* The height (ascent + descent) of characters. */
                public int tmHeight;

                /* The ascent (units above the base line) of characters. */
                public int tmAscent;

                /* The descent (units below the base line) of characters. */
                public int tmDescent;

                /* The amount of leading (space) inside the bounds set by the tmHeight member. */
                public int tmInternalLeading;

                /* The amount of extra leading (space) that the application adds between rows. */
                public int tmExternalLeading;

                /* The average width of characters in the font (generally defined as the width of the letter x). */
                public int tmAveCharWidth;

                /* The width of the widest character in the font. */
                public int tmMaxCharWidth;

                /* The weight of the font. */
                public int tmWeight;

                /* The extra width per string that may be added to some synthesized fonts. */
                public int tmOverhang;

                /* The horizontal aspect of the device for which the font was designed. */
                public int tmDigitizedAspectX;

                /* The vertical aspect of the device for which the font was designed. */
                public int tmDigitizedAspectY;

                /* The value of the first character defined in the font. */
                public char tmFirstChar;

                /* The value of the last character defined in the font. */
                public char tmLastChar;

                /* The value of the character to be substituted for characters not in the font. */
                public char tmDefaultChar;

                /* The value of the character that will be used to define word breaks for text justification. */
                public char tmBreakChar;

                /* Specifies an italic font if it is nonzero. */
                public byte tmItalic;

                /* Specifies an underlined font if it is nonzero. */
                public byte tmUnderlined;

                /* A strikeout font if it is nonzero. */
                public byte tmStruckOut;

                /* Specifies information about the pitch, the technology, and the family of a physical font. */
                public byte tmPitchAndFamily;

                /* The character set of the font. */
                public byte tmCharSet;
            }

            /* Contains basic information about a physical font. This is the ANSI version of the structure. */
            [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
            public struct TEXTMETRICA
            {
                /* The height (ascent + descent) of characters. */
                public int tmHeight;

                /* The ascent (units above the base line) of characters. */
                public int tmAscent;

                /* The descent (units below the base line) of characters. */
                public int tmDescent;

                /* The amount of leading (space) inside the bounds set by the tmHeight member. */
                public int tmInternalLeading;

                /* The amount of extra leading (space) that the application adds between rows. */
                public int tmExternalLeading;

                /* The average width of characters in the font (generally defined as the width of the letter x). */
                public int tmAveCharWidth;

                /* The width of the widest character in the font. */
                public int tmMaxCharWidth;

                /* The weight of the font. */
                public int tmWeight;

                /* The extra width per string that may be added to some synthesized fonts. */
                public int tmOverhang;

                /* The horizontal aspect of the device for which the font was designed. */
                public int tmDigitizedAspectX;

                /* The vertical aspect of the device for which the font was designed. */
                public int tmDigitizedAspectY;

                /* The value of the first character defined in the font. */
                public byte tmFirstChar;

                /* The value of the last character defined in the font. */
                public byte tmLastChar;

                /* The value of the character to be substituted for characters not in the font. */
                public byte tmDefaultChar;

                /* The value of the character that will be used to define word breaks for text justification. */
                public byte tmBreakChar;

                /* Specifies an italic font if it is nonzero. */
                public byte tmItalic;

                /* Specifies an underlined font if it is nonzero. */
                public byte tmUnderlined;

                /* A strikeout font if it is nonzero. */
                public byte tmStruckOut;

                /* Specifies information about the pitch, the technology, and the family of a physical font. */
                public byte tmPitchAndFamily;

                /* The character set of the font. */
                public byte tmCharSet;
            }
            #endregion
        }
    }
}