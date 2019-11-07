using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DataVisulisation
{
    public static class BitMapManipulation
    {
        public static void ApplyAA(ref Bitmap Bmp)
        {
            Bitmap BMPOriginal = (Bitmap)Bmp.Clone();
            for (int x = 0, y = 0; y < Bmp.Height; x++)
            {
                Bmp.SetPixel(x, y, BitMapAnalysis.PixelAverage(BMPOriginal, new Point(x, y), 1, 2f));
                if (x == Bmp.Width - 1) { x = -1; y++; }
            }
        }
    }
}
