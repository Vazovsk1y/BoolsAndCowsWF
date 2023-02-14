using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using BoolsAndCows.Components.Instruments;
using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace BoolsAndCows.Components
{
    public class Vazovsk1yButtonGUI : Button
    {
        #region --Fields--

        private const string vazovskiyOptions  = "Vazovskiy";
        private StringFormat StringFormat = new StringFormat();
        private Timer timer = new Timer();
        public bool IsMouseOnButton { get; set; } = false;
        public bool IsButtonPressed { get; set; } = false;

        #endregion

        #region --Properties--

        private Color buttonOutlineColor;
        [Browsable(true)]
        [Category(vazovskiyOptions)]
        [Description("Button outline color")]
        public Color ButtonOutlineColor
        {
            get => buttonOutlineColor;
            set
            {
                buttonOutlineColor = value;
                Invalidate();
            }
        }

        private float gradientAngle = 0f;
        [Browsable(true)]
        [Category(vazovskiyOptions)]
        [Description("Gradient angle")]
        public float GradientAngle
        {
            get => gradientAngle;
            set 
            { 
                gradientAngle = value; 
                Invalidate(); 
            }
        }

        private bool isAnimationEnable = false;
        [Browsable(true)]
        [Category(vazovskiyOptions)]
        [Description("Is gradient animation enable?")]
        public bool IsAnimationEnable
        {
            get => isAnimationEnable;
            set 
            {
                if (value)
                    timer.Start();
                else
                    timer.Stop();
                isAnimationEnable = value; 
                Refresh(); 
            }
        }

        private bool gradientEnable = false;
        [Browsable(true)]
        [Category(vazovskiyOptions)]
        [Description("Is gradient enable?")]
        public bool GradientEnable
        {
            get => gradientEnable;
            set
            {
                gradientEnable = value;
                Refresh();
            }
        }

        private Color firstGradientColor;
        [DisplayName("Gradient color #1")]
        [Browsable(true)]
        [Category(vazovskiyOptions)]
        [Description("Gradient color #1")]
        public Color FirstColor
        {
            get => firstGradientColor;
            set
            {
                firstGradientColor = value;
                Refresh();
            }
        }

        private Color secondColor;
        [DisplayName("Gradient color #2")]
        [Browsable(true)]
        [Category(vazovskiyOptions)]
        [Description("Gradient color #2")]
        public Color SecondColor
        {
            get => secondColor;
            set
            {
                secondColor = value;
                Refresh();
            }
        }

        private bool roundingEnable = false;
        [Browsable(true)]
        [Category(vazovskiyOptions)]
        [Description("Is rounding enable?")]
        public bool RoundingEnable
        {
            get => roundingEnable;
            set
            {
                roundingEnable = value;
                Refresh();
            }
        }

        private int roundingPercent = 1;
        [Browsable(true)]
        [DisplayName("Rounding [%]")]
        [Category(vazovskiyOptions)]
        [Description("The degree of rounding from 1 to 100")]
        public int Rounding
        {
            get => roundingPercent;
            set
            {
                if (value >= 1 && value <= 100)
                {
                    roundingPercent = value;
                    Invalidate();
                }
            }
        }

        #endregion

        #region --Constructors--

        public Vazovsk1yButtonGUI() 
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer 
                | ControlStyles.ResizeRedraw 
                | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            Size = new Size(100, 50);
            StringFormat.LineAlignment = StringAlignment.Center;
            StringFormat.Alignment = StringAlignment.Center;
            timer.Interval = 60;
            timer.Tick += (s, e) => { GradientAngle = GradientAngle % 360 + 1; };
        }

        #endregion

        #region --Events--

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Parent.BackColor);
            Rectangle rectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            DrawButton(graphics, rectangle);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            IsMouseOnButton = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            IsMouseOnButton = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            IsButtonPressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            IsButtonPressed = false;
            Invalidate();
        }

        #endregion

        #region --Methods--

        private void DrawButton(Graphics currentGraphics, Rectangle currentRectangle)
        {
            float roundingValue = 0.1f;
            GraphicsPath currentButtonPicture = RoundRectangleDrawer.RoundRectangle(currentRectangle, roundingValue); 

            if (RoundingEnable)
            {
                roundingValue = Height / 100f * roundingPercent;
                currentButtonPicture = RoundRectangleDrawer.RoundRectangle(currentRectangle, roundingValue);
            }

            if (GradientEnable)
            {
                currentGraphics.FillPath(new LinearGradientBrush(ClientRectangle, FirstColor, SecondColor, GradientAngle), currentButtonPicture);
            }
            else
            {
                currentGraphics.FillPath(new SolidBrush(BackColor), currentButtonPicture);
            }

            if (IsMouseOnButton)
            {
                // degree of white when you mouse down on button
                currentGraphics.DrawPath(new Pen(Color.FromArgb(60, Color.White)), currentButtonPicture);
                currentGraphics.FillPath(new SolidBrush(Color.FromArgb(60, Color.White)), currentButtonPicture);
            }
            if(IsButtonPressed)
            {
                // degree of black when you pushed the button
                currentGraphics.DrawPath(new Pen(Color.FromArgb(30, Color.Black)), currentButtonPicture);
                currentGraphics.FillPath(new SolidBrush(Color.FromArgb(30, Color.Black)), currentButtonPicture);
            }

            currentGraphics.DrawPath(new Pen(ButtonOutlineColor), currentButtonPicture);
            currentGraphics.DrawString(Text, Font, new SolidBrush(ForeColor), currentRectangle, StringFormat);
        }

        #endregion
    }
}
