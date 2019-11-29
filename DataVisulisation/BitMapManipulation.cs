using System.Drawing;

namespace DataVisulisation
{
    public static class BitMapManipulation
    {
        #region Methods

        public static void ApplyAA(ref Bitmap Bmp, float CenterMultiplyer = 1.1f)
        {
            Bitmap BMPOriginal = (Bitmap)Bmp.Clone();
            for (int x = 0, y = 0; y < Bmp.Height; x++)
            {
                if (!Color.FromArgb(0,0,0,0).Equals(Bmp.GetPixel(x,y)))
                { Bmp.SetPixel(x, y, BitMapAnalysis.PixelAverage(BMPOriginal, new Point(x, y), 1, CenterMultiplyer)); }
                if (x == Bmp.Width - 1) { x = -1; y++; }
            }
            BMPOriginal.Dispose();
        }

        #endregion Methods
    }
}