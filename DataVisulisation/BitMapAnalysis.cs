using System;
using System.Drawing;

namespace DataVisulisation
{
    public static class BitMapAnalysis
    {
        #region Methods

        public static Color PixelAverage(Bitmap Bmp, Point P, int AvgAreaRadius = 1, float CenterMultiplyer = 1f)
        {
            int[] PixelChannelTotals = new int[3];//Store the Total RGB values
            int AreaSize = 0;//Store the total number of pixels
            Color Pixel;
            for (int X = P.X - AvgAreaRadius, Y = P.Y - AvgAreaRadius; Y <= P.Y + AvgAreaRadius; X++)//For every pixel around the target pixel
            {
                if (X >= 0 && X < Bmp.Width && Y >= 0 && Y < Bmp.Height)//Ensure pixel is on the bitmap
                {
                    Pixel = Bmp.GetPixel(X, Y);//Get the Color value of the pixel
                    if (X == P.X && Y == P.Y)//If we are looking at the target pixel
                    {//Add the color values to the score, using a multiplyer to increase its weight
                        PixelChannelTotals[0] += (int)Math.Round(Pixel.R * CenterMultiplyer, 0);
                        PixelChannelTotals[1] += (int)Math.Round(Pixel.G * CenterMultiplyer, 0);
                        PixelChannelTotals[2] += (int)Math.Round(Pixel.B * CenterMultiplyer, 0);
                    }
                    else
                    {//Add the color values to the score
                        PixelChannelTotals[0] += Pixel.R;
                        PixelChannelTotals[1] += Pixel.G;
                        PixelChannelTotals[2] += Pixel.B;
                    }
                    AreaSize++;//Increment area size
                }
                if (X >= P.X + AvgAreaRadius) { X = P.X - 1 - AvgAreaRadius; Y++; }//If we are at the end of the row, move to the next
            }
            PixelChannelTotals[0] /= AreaSize;//Calculate the average
            PixelChannelTotals[1] /= AreaSize;
            PixelChannelTotals[2] /= AreaSize;
            for (int i = 0; i < 3; i++) { if (PixelChannelTotals[i] > 255) { PixelChannelTotals[i] = 255; } }//Ensure values are within bounds
            return Color.FromArgb(PixelChannelTotals[0], PixelChannelTotals[1], PixelChannelTotals[2]);//Return the average color
        }

        #endregion Methods
    }
}