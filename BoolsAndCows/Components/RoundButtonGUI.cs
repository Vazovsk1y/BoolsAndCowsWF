using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using BoolsAndCows.Components.Instruments;
using System.Runtime.CompilerServices;

namespace BoolsAndCows.Components
{
    public class RoundButtonGUI : Control
    {
        private float roundingDegree;
        private StringFormat StringFormat = new StringFormat();

        public RoundButtonGUI() 
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer 
                | ControlStyles.ResizeRedraw 
                | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            roundingDegree = 60;       // play with this value
            BackColor = Color.Tomato;
            ForeColor = Color.Black;
            Size = new Size(100, 50);
            StringFormat.LineAlignment = StringAlignment.Center;
            StringFormat.Alignment = StringAlignment.Center;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Parent.BackColor);

            Rectangle rectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath roundButton = RoundRectangleDrawer.RoundRectangle(rectangle, roundingDegree);

            graphics.DrawPath(new Pen(BackColor), roundButton);
            graphics.FillPath(new SolidBrush(BackColor), roundButton);
            graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rectangle, StringFormat);
        }
    }
}
