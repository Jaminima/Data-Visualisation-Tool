using System.Drawing;

namespace DataVisulisation
{
    public static class BitMapManipulation
    {
        #region Methods

        public static void ApplyAA(ref Bitmap Bmp, float CenterMultiplyer = 1.1f)
        {
            Bitmap BMPOriginal = (Bitmap)Bmp.Clone();//Create a duplicate of the Bitmap
            for (int x = 0, y = 0; y < Bmp.Height; x++)//For every pixel
            {
                Bmp.SetPixel(x, y, BitMapAnalysis.PixelAverage(BMPOriginal, new Point(x, y), 1, CenterMultiplyer));//Set the pixel to the average of all ajacent ones
                if (x == Bmp.Width - 1) { x = -1; y++; }//When at the end of a row, move to the next
            }
            BMPOriginal.Dispose();//Clear the duplicate from memory
        }

        #endregion Methods
    }
}