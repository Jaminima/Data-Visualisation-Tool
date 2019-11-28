using ImitationLibrary;
using System;
using System.Drawing;

namespace DataVisulisation
{
    public static class LineGraph
    {
        public static void DrawLines(ref Bitmap Bmp, int[] yValues, Color LineColor, int Padding = 20, int Thickness = 2, string[] Labels = null, string xLabel = null, string yLabel = null, int FontSize = 1, int TextOffset = 20)
        {
            float xStep = (float)(Bmp.Width - (Padding*2)) / (yValues.Length - 1),
                yStep = (float)(Bmp.Height - (Padding*2)) / (Linq.Max(yValues, x => x)[0] - Linq.Min(yValues, x => x)[0]),
                yOffset = yStep * Linq.Min(yValues, x => x)[0];
            int Align = 1;

            if (Labels!=null && Labels.Length != yValues.Length) { throw new Exception("Labels and yValues length missmatch"); }
            for (int i = 0; i < yValues.Length - 1; i++)
            {
                Point P1 = BitMapHandling.PointRelativeToOrigin(Bmp, i * xStep + Padding, (yValues[i] * yStep) + Padding - yOffset),
                    P2 = BitMapHandling.PointRelativeToOrigin(Bmp, (i + 1) * xStep + Padding, (yValues[i + 1] * yStep) + Padding - yOffset);
                BitMapHandling.DrawLine(ref Bmp, P1, P2, LineColor, Thickness);
                if (Labels != null) { 
                    BitMapHandling.DrawText(ref Bmp, new Point(P1.X,P1.Y+TextOffset), Labels[i], Color.Black, FontSize, Align);
                    TextOffset = -TextOffset;
                    if (i == 0) { Align = 0; }
                    if (i == yValues.Length - 2) { BitMapHandling.DrawText(ref Bmp, new Point(P2.X, P2.Y+TextOffset), Labels[i+1], Color.Black, FontSize, -1); }
                }
            }
        }
    }
}