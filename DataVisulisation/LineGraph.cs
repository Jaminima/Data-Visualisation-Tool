using ImitationLibrary;
using System;
using System.Drawing;

namespace DataVisulisation
{
    public static class LineGraph
    {
        #region Methods

        private static void DrawDataPoint(ref Bitmap Bmp, Point P1, int V1, Point P2, int V2, string T1, string T2, string ValueStructure, Color LineColor, int Thickness, int Padding, int FontSize, int Align)
        {
            if (T1 != null)//If we have an point name
            {
                BitMapHandling.DrawLine(ref Bmp, new Point(P1.X, 0), BitMapHandling.PointRelativeToOrigin(Bmp, P1.X, Padding / 2), Color.Gray);//Draw a vertical grey line behind the point
                BitMapHandling.DrawText(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, P1.X, Padding / 2 + (6 * FontSize)), T1, Color.Black, FontSize, Align);//Write the name of the data point below the x axis
                BitMapHandling.DrawText(ref Bmp, new Point(P1.X, P1.Y - (6 * FontSize)), String.Format(ValueStructure, V1), Color.Black, FontSize, 0);//Write the value of the data point above the point
            }
            if (T2 != null)//If we have a point name
            {
                BitMapHandling.DrawLine(ref Bmp, new Point(P2.X, 0), BitMapHandling.PointRelativeToOrigin(Bmp, P2.X, Padding / 2), Color.Gray);//Draw a vertical grey line behind the point
                BitMapHandling.DrawText(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, P2.X, Padding / 2 + (6 * FontSize)), T2, Color.Black, FontSize, -1);//Write the name of the data point below the x axis
                BitMapHandling.DrawText(ref Bmp, new Point(P2.X, P2.Y - (6 * FontSize)), String.Format(ValueStructure, V2), Color.Black, FontSize, 0);//Write the value of the data point above the point
            }
            BitMapHandling.DrawLine(ref Bmp, P1, P2, LineColor, Thickness);//Draw The Data Points Line
        }

        public static void DrawLines(ref Bitmap Bmp, int[] yValues, Color LineColor, string ValueStructure = "{0}", int Padding = 20, int Thickness = 2, string[] Labels = null, string xLabel = null, string yLabel = null, int FontSize = 1)
        {
            if ((xLabel != null || yLabel != null) && Padding < 20) { Padding = 20; }//If we have axis labels, ensure we have enough space for them

            float xStep = (float)(Bmp.Width - (Padding * 2)) / (yValues.Length - 1),
                yStep = (float)(Bmp.Height - (Padding * 2)) / (Linq.Max(yValues, x => x)[0] - Linq.Min(yValues, x => x)[0]),
                yOffset = yStep * Linq.Min(yValues, x => x)[0];//Calculate how many pixels per unit on the x,y axes and how far to shift the grid down by
            string T1 = null, T2 = null;
            int Align = 1;//Indicates direction of text write

            //Draw the lines for the x and y axes
            BitMapHandling.DrawLine(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, Padding / 2, Padding / 2),
                    BitMapHandling.PointRelativeToOrigin(Bmp, Bmp.Width - (Padding / 2), Padding / 2), Color.Gray, 3);
            BitMapHandling.DrawLine(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, Padding / 2, Padding / 2),
                    BitMapHandling.PointRelativeToOrigin(Bmp, Padding / 2, Bmp.Height - Padding), Color.Gray, 3);

            if (xLabel != null)//Write the x axes label at intervals below the line
            {
                for (int x = 1; x < yValues.Length - 1; x += 5)
                {
                    BitMapHandling.DrawText(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, xStep * x + Padding, Padding / 2 - 5), xLabel, Color.Black, 2, 0);
                }
            }

            if (yLabel != null)//Write the y axes label above the y axes line 
            { BitMapHandling.DrawText(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, Padding / 2, Bmp.Height - (Padding / 2)), yLabel, Color.Black, 2, 1); }

            if (Labels != null && Labels.Length != yValues.Length) { throw new Exception("Labels and yValues length missmatch"); }//Throw an error if we dont have enough labels for the values

            for (int i = 0; i < yValues.Length - 1; i++)//For every point
            {
                Point P1 = BitMapHandling.PointRelativeToOrigin(Bmp, i * xStep + Padding, (yValues[i] * yStep) + Padding - yOffset),
                    P2 = BitMapHandling.PointRelativeToOrigin(Bmp, (i + 1) * xStep + Padding, (yValues[i + 1] * yStep) + Padding - yOffset);//Caclulate the Points for itself and the next point
                if (i != 0) { Align = 0; }//Change the text align to center
                if (Labels != null)//Set the names of the points
                {
                    T1 = Labels[i];
                    if (i == yValues.Length - 2) { T2 = Labels[i + 1]; }
                }
                DrawDataPoint(ref Bmp, P1, yValues[i], P2, yValues[i + 1], T1, T2, ValueStructure, LineColor, Thickness, Padding, FontSize, Align);//Draw the points and their details
            }
        }

        #endregion Methods
    }
}