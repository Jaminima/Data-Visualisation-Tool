using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DataVisulisation
{
    public static class BitMapHandling
    {
        public static Bitmap CreateNew(int x=800, int y=600)
        {
            Bitmap Bmp = new Bitmap(x, y);
            return Bmp;
        }

        public static void SetBackColor(ref Bitmap Bmp, Color BackColor)
        {
            for (int x = 0, y = 0; y < Bmp.Height;)
            {
                SetPixel(ref Bmp, new Point(x, y), BackColor);
                x++;
                if (x == Bmp.Width) { x = 0; y++; }
            }
        }

        public static void DrawLine(ref Bitmap Bmp, Point P1, Point P2, Color LineColor, int Thiccness = 1)
        {
            int xChange = Math.Abs(P1.X - P2.X), yChange = Math.Abs(P1.Y - P2.Y);
            int xDirection = Math.Sign(P2.X - P1.X), yDirection = Math.Sign(P1.Y-P2.Y);
            float Gradient = (float)yChange / xChange * yDirection;
            bool GradientIsVertical = Gradient % 2 <= 1;
            for (int x = P1.X; x != P2.X; x += xDirection)
            {
                int y = P1.Y - (int)Math.Round((x - P1.X) * Gradient, 0);
                if (GradientIsVertical) {
                    for(int i = 0; i < Thiccness && x + i < Bmp.Width; i++) { SetPixel(ref Bmp, new Point(x + i, y), LineColor); } }
                else {
                    for (int i = 0; i < Thiccness && y + i < Bmp.Height; i++) { SetPixel(ref Bmp, new Point(x, y + i), LineColor); } }
            }
        }

        static void SetPixel(ref Bitmap Bmp, Point P, Color PixelColor)
        {
            try { Bmp.SetPixel(P.X, P.Y, PixelColor); }
            catch { throw new Exception("Point is out of bounds"); }
        }

        public static void MakePointReativeToOrign(ref Point P, Bitmap Bmp)
        {
            P.Y = Bmp.Height - 1 - P.Y;
        }

        public static Point PointRelativeToOrigin(Bitmap Bmp, int x, int y)
        {
            return new Point(x, Bmp.Height - 1 - y);
        }
    }
}
