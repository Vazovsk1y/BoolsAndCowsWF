using System.Drawing.Drawing2D;
using System.Drawing;

namespace BoolsAndCows.Components.Instruments
{
    internal static class RoundRectangleDrawer
    {
        public static GraphicsPath RoundRectangle(Rectangle rectangle, float roundSize)
        {
            GraphicsPath graphicsPath = new GraphicsPath();

            graphicsPath.AddArc(rectangle.X, rectangle.Y, roundSize, roundSize, 180, 90); // left up angle
            graphicsPath.AddArc(rectangle.X + rectangle.Width - roundSize, rectangle.Y, roundSize, roundSize, 270, 90); // right up angle

            graphicsPath.AddArc(rectangle.X + rectangle.Width - roundSize, rectangle.Y + rectangle.Height - roundSize, roundSize, roundSize, 0, 90); // right down angle
            graphicsPath.AddArc(rectangle.X, rectangle.Y + rectangle.Height - roundSize, roundSize, roundSize, 90, 90); // left down angle

            graphicsPath.CloseFigure();
            return graphicsPath;
        }
    }
}
