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
            for (int x = 0, y = 0; x < Bmp.Width && y < Bmp.Height;)
            {
                SetPixel(ref Bmp, x, y, BackColor);
                x++;
                if (x == Bmp.Width) { x = 0; y++; }
            }
        }

        public static void DrawLine(ref Bitmap Bmp, Point P1, Point P2, Color LineColor)
        {
            int xChange = Math.Abs(P1.X - P2.X), yChange = Math.Abs(P1.Y - P2.Y);
            float Gradient = (float)yChange/xChange;
            for (int x=P1.X; x < P2.X; x++)
            {
                SetPixel(ref Bmp, x, (int)Math.Round(x * Gradient,0), LineColor);
            }
        }

        static void SetPixel(ref Bitmap Bmp,int x, int y, Color PixelColor)
        {
            Bmp.SetPixel(x, Bmp.Height - 1 - y, PixelColor);
        }
    }
}
