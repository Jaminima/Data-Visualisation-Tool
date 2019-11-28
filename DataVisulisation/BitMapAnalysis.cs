using System;
using System.Drawing;

namespace DataVisulisation
{
    public static class BitMapAnalysis
    {
        #region Methods

        public static Color PixelAverage(Bitmap Bmp, Point P, int AvgAreaRadius = 1, float CenterMultiplyer = 1f)
        {
            int[] PixelChannelTotals = new int[3];
            int AreaSize = 0;
            Color Pixel;
            for (int X = P.X - AvgAreaRadius, Y = P.Y - AvgAreaRadius; Y <= P.Y + AvgAreaRadius; X++)
            {
                if (X >= 0 && X < Bmp.Width && Y >= 0 && Y < Bmp.Height)
                {
                    Pixel = Bmp.GetPixel(X, Y);
                    if (X == P.X && Y == P.Y)
                    {
                        PixelChannelTotals[0] += (int)Math.Round(Pixel.R * CenterMultiplyer, 0);
                        PixelChannelTotals[1] += (int)Math.Round(Pixel.G * CenterMultiplyer, 0);
                        PixelChannelTotals[2] += (int)Math.Round(Pixel.B * CenterMultiplyer, 0);
                    }
                    else
                    {
                        PixelChannelTotals[0] += Pixel.R;
                        PixelChannelTotals[1] += Pixel.G;
                        PixelChannelTotals[2] += Pixel.B;
                    }
                    AreaSize++;
                }
                if (X >= P.X + AvgAreaRadius) { X = P.X - 1 - AvgAreaRadius; Y++; }
            }
            PixelChannelTotals[0] /= AreaSize;
            PixelChannelTotals[1] /= AreaSize;
            PixelChannelTotals[2] /= AreaSize;
            for (int i = 0; i < 3; i++) { if (PixelChannelTotals[i] > 255) { PixelChannelTotals[i] = 255; } }
            return Color.FromArgb(PixelChannelTotals[0], PixelChannelTotals[1], PixelChannelTotals[2]);
        }

        #endregion Methods
    }
}