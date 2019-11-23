using ImitationLibrary;
using System;
using System.Drawing;

namespace DataVisulisation
{
    public static class LineGraph
    {
        public static void DrawLines(ref Bitmap Bmp, int[] yValues, Color LineColor, int Padding = 20, int Thickness = 2)
        {
            int xStep = (int)Math.Floor((double)(Bmp.Width - (Padding * 2)) / (yValues.Length - 1)),
                yStep = (int)Math.Floor((double)(Bmp.Height - (Padding * 2)) / (Linq.Max(yValues, x => x)[0]));

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