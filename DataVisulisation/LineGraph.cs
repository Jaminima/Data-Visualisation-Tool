using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;

namespace DataVisulisation
{
    public static class LineGraph
    {
        public static Bitmap Create(int[] yValues, int Width = 800, int Height = 600, int Padding = 20)
        {
            Bitmap Bmp = BitMapHandling.CreateNew(Width, Height);
            BitMapHandling.SetBackColor(ref Bmp, Color.Gray);
            int xStep = (int)Math.Round((double)(Width - (Padding * 2))/(yValues.Length-1),0),
                yStep = (int)Math.Round((double)(Height- (Padding * 2))/(yValues.Max()),0);

            for (int i = 0; i < yValues.Length-1; i++)
            {
                BitMapHandling.DrawLine(ref Bmp,
                    BitMapHandling.PointRelativeToOrigin(Bmp, i * xStep + Padding, yValues[i]*yStep),
                    BitMapHandling.PointRelativeToOrigin(Bmp, (i + 1) * xStep + Padding, yValues[i + 1]*yStep),
                    Color.Red);
            }
            return Bmp;
        }
    }
}
