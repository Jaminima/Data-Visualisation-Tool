using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;

namespace DataVisulisation
{
    public static class BitMapHandling
    {
        public static Bitmap CreateNew(int x = 800, int y = 600)
        {
            Bitmap Bmp = new Bitmap(x, y);
            return Bmp;
        }

        public static void SetBackColor(ref Bitmap Bmp, Color BackColor)
        {
            for (int x = 0, y = 0; y < Bmp.Height;)
            {
                SetPixel(ref Bmp, new Point(x, y), BackColor);
                x++;
                if (x == Bmp.Width) { x = 0; y++; }
            }
        }

        public static void DrawLine(ref Bitmap Bmp, Point P1, Point P2, Color LineColor, int Thickness = 1)
        {
            int xChange = Math.Abs(P1.X - P2.X), yChange = Math.Abs(P1.Y - P2.Y);
            int xDirection = Math.Sign(P2.X - P1.X), yDirection = Math.Sign(P1.Y - P2.Y);
            float Gradient = (float)yChange / xChange * yDirection;
            bool GradientIsVertical = Gradient % 2 <= 1;

            for (int x = P1.X; x != P2.X && GradientIsVertical; x += xDirection)
            {
                int y = P1.Y - (int)Math.Round(Math.Abs(x - P1.X) * Gradient, 0);
                for (int i = 0; i + y < Bmp.Height && i < Thickness; i++) SetPixel(ref Bmp, new Point(x, y + i), LineColor);
            }

            for (int y = P1.Y; y != P2.Y && !GradientIsVertical; y -= yDirection)
            {
                int x = P1.X + (int)Math.Round(Math.Abs(P1.Y - y) / Gradient, 0);
                for (int i = 0; i + x < Bmp.Width && i < Thickness; i++) { SetPixel(ref Bmp, new Point(x + i, y), LineColor); }
            }
        }

        public static void DrawEquation(ref Bitmap Bmp, Point P, int xSize, Color LineColor, string Equation = "x")
        {
            DataTable DT = new DataTable();
            int prevY = P.Y;
            for (int x = 0; x < xSize; x++)
            {
                int y = P.Y - (int)Math.Round(Convert.ToDouble(DT.Compute(Equation.Replace("x", x.ToString()), "")), 0), yDirection = Math.Sign(prevY - y);

                if (y >= 0 && y < Bmp.Height) { SetPixel(ref Bmp, new Point(x + P.X, y), LineColor); }
                for (int i = y + yDirection; i != prevY; i += yDirection)
                {
                    if (i >= 0 && i < Bmp.Height) { SetPixel(ref Bmp, new Point(x + P.X, i), LineColor); }
                }
                prevY = y;
            }
            DT.Dispose();
        }

        static Dictionary<char, bool[,]> LetterMaps = new Dictionary<char, bool[,]>
        {
            { 'A', new bool[,] {
                { false, false, true, false, false },
                { false, true, false, true, false },
                { false, true, true, true, false },
                { true, false, false, false, true },
                { true, false, false, false, true }
            } },
            { 'B', new bool[,]{
                { true, true, true, true, false },
                { true, false, false, false, true },
                { true, true, true, true, true },
                { true, false, false, false, true },
                { true, true, true, true, false }
            } }
        };

        public static void DrawText(ref Bitmap Bmp, Point P, string Text, Color color, int FontSize = 1)
        {
            int xOffset = 0;
            foreach (Char C in Text.ToUpper())
            {
                bool[,] LetterMap = LetterMaps[C];
                for (int x=0,y=0; x < 5 * FontSize && y < 5*FontSize;)
                {
                    if (LetterMap[y/FontSize, x/FontSize]) {
                        SetPixel(ref Bmp, new Point(P.X + x + xOffset, P.Y + y), color);
                    }
                    x++;
                    if (x == 5*FontSize) { x = 0; y++; }
                }
                xOffset += 6 * FontSize;
            }
        }

        private static void SetPixel(ref Bitmap Bmp, Point P, Color PixelColor)
        {
            try { Bmp.SetPixel(P.X, P.Y, PixelColor); }
            catch { throw new Exception("Point is out of bounds"); }
        }

        public static void MakePointReativeToOrign(ref Point P, Bitmap Bmp)
        {
            P.Y = Bmp.Height - 1 - P.Y;
        }

        public static Point PointRelativeToOrigin(Bitmap Bmp, int x, int y)
        {
            return new Point(x, Bmp.Height - 1 - y);
        }
    }
}