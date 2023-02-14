using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BoolsAndCows.Components
{
    public class ClearGUI : Control
    {

        private StringFormat StringFormat = new StringFormat();

        public ClearGUI() 
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw 
                | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
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

            graphics.DrawRectangle(new Pen(BackColor), rectangle);
            graphics.FillRectangle(new SolidBrush(BackColor), rectangle);
            graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rectangle, StringFormat);
        }
    }
}
