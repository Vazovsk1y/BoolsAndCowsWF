using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System;
using BoolsAndCows.Components.Animations;

namespace BoolsAndCows.Components
{
    public class ThemeSwitchGUI : Control
    {
        private Rectangle phoneRectangle;  // main rectangle
        int TogglePosX_ON;                 // right
        int TogglePosX_OFF;                // left
        Animation ToggleAnimation;
        private bool IsSwitched { get; set; } = false;
        private Color BackColorON { get; set; } = Color.Red;

        public ThemeSwitchGUI()
        {
            // for optimizing drawing
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw
                | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            Size = new Size(50, 20);
            BackColor = Color.White;
            Font = new Font("Verdana", 9f, FontStyle.Regular);
            phoneRectangle = new Rectangle(1, 1, Width - 3, Height - 3);
            TogglePosX_OFF = phoneRectangle.X;
            TogglePosX_ON = phoneRectangle.Width - phoneRectangle.Height;
            ToggleAnimation = new Animation();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ToggleAnimation.Value = IsSwitched ? TogglePosX_ON: TogglePosX_OFF;
            Animator.Start();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            phoneRectangle = new Rectangle(1, 1, Width - 3, Height - 3);
            TogglePosX_OFF = phoneRectangle.X;
            TogglePosX_ON = phoneRectangle.Width - phoneRectangle.Height;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Parent.BackColor);

            Pen pen = new Pen(Color.DarkGray, 3);
            Pen penToggle = new Pen(Color.DarkGray, 3);

            GraphicsPath rectanglePath = RoundRectangle(phoneRectangle, phoneRectangle.Height);

            Rectangle rectangleToggle = new Rectangle((int)ToggleAnimation.Value, phoneRectangle.Y, phoneRectangle.Height, phoneRectangle.Height);
            graphics.DrawPath(pen, rectanglePath);

            if (IsSwitched.Equals(true))
            {
                if (!Animator.IsWork)
                {
                    rectangleToggle.Location = new Point(TogglePosX_ON, phoneRectangle.Y);
                }
                graphics.FillPath(new SolidBrush(BackColorON), rectanglePath);
            }
            else
            {
                if (!Animator.IsWork)
                {
                    rectangleToggle.Location = new Point(TogglePosX_OFF, phoneRectangle.Y);
                }
                graphics.FillPath(new SolidBrush(BackColor), rectanglePath);
            }

            graphics.DrawEllipse(penToggle, rectangleToggle);
            graphics.FillEllipse(new SolidBrush(Color.White), rectangleToggle);

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            SwitchToggle();
        }

        // move toggle
        private void SwitchToggle()
        {
            if (IsSwitched)
            {
                ToggleAnimation = new Animation("Toggle_" + Handle, Invalidate, ToggleAnimation.Value, TogglePosX_OFF);
            }
            else
            {
                ToggleAnimation = new Animation("Toggle_" + Handle, Invalidate, ToggleAnimation.Value, TogglePosX_ON);
            }

            IsSwitched = !IsSwitched;
            ToggleAnimation.StepDivider = 6;          // animation speed
            Animator.Request(ToggleAnimation, true);
        }

        private GraphicsPath RoundRectangle(Rectangle rect, int RoundSize)
        {
            GraphicsPath graphicsPath = new GraphicsPath();

            graphicsPath.AddArc(rect.X, rect.Y, RoundSize, RoundSize, 180, 90); // left up angle
            graphicsPath.AddArc(rect.X + rect.Width - RoundSize, rect.Y, RoundSize,RoundSize, 270, 90); // right up angle

            graphicsPath.AddArc(rect.X + rect.Width - RoundSize, rect.Y + rect.Height - RoundSize, RoundSize, RoundSize, 0, 90); // right down angle
            graphicsPath.AddArc(rect.X, rect.Y + rect.Height - RoundSize, RoundSize, RoundSize, 90, 90); // left down angle

            graphicsPath.CloseFigure();
            return graphicsPath;
        } 
    }
}
