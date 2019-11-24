using ImitationLibrary;
using System;
using System.Drawing;

namespace DataVisulisation
{
    public static class LineGraph
    {
        public static void DrawLines(ref Bitmap Bmp, int[] yValues, Color LineColor, int Padding = 20, int Thickness = 2, string[] Labels = null, string xLabel = null, string yLabel = null)
        {
            int xStep = (int)Math.Floor((double)(Bmp.Width - (Padding * 2)) / (yValues.Length - 1)),
                yStep = (int)Math.Floor((double)(Bmp.Height - (Padding * 2)) / (Linq.Max(yValues, x => x)[0])),
                Align = 1;

            if (Labels!=null && Labels.Length != yValues.Length) { throw new Exception("Labels and yValues length missmatch"); }
            for (int i = 0; i < yValues.Length - 1; i++)
            {
                Point P1 = BitMapHandling.PointRelativeToOrigin(Bmp, i * xStep + Padding, yValues[i] * yStep),
                    P2 = BitMapHandling.PointRelativeToOrigin(Bmp, (i + 1) * xStep + Padding, yValues[i + 1] * yStep);
                BitMapHandling.DrawLine(ref Bmp, P1, P2, LineColor, Thickness);
                if (Labels != null) { 
                    BitMapHandling.DrawText(ref Bmp, P1, Labels[i], Color.Black, 3, Align); 
                    if (i == 0) { Align = 0; }
                    if (i == yValues.Length - 2) { BitMapHandling.DrawText(ref Bmp, P2, Labels[i+1], Color.Black, 3, -1); }
                }
            }
        }
    }
}