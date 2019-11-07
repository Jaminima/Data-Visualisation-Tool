using ImitationLibrary;
using System;
using System.Drawing;

namespace DataVisulisation
{
    public static class LineGraph
    {
        public static void DrawLines(ref Bitmap Bmp, int[] yValues, Color LineColor, int Padding = 20, int Thickness = 2)
        {
            BitMapHandling.SetBackColor(ref Bmp, Color.Gray);
            int xStep = (int)Math.Round((double)(Bmp.Width - (Padding * 2)) / (yValues.Length - 1), 0),
                yStep = (int)Math.Round((double)(Bmp.Height - (Padding * 2)) / (Linq.Max(yValues, x => x)), 0);

            for (int i = 0; i < yValues.Length - 1; i++)
            {
                BitMapHandling.DrawLine(ref Bmp,
                    BitMapHandling.PointRelativeToOrigin(Bmp, i * xStep + Padding, yValues[i] * yStep),
                    BitMapHandling.PointRelativeToOrigin(Bmp, (i + 1) * xStep + Padding, yValues[i + 1] * yStep),
                    LineColor, Thickness);
            }
        }
    }
}