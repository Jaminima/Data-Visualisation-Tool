using System;
using System.Data;
using System.Drawing;
using ImitationLibrary;

namespace DataVisulisation
{
    public static class BitMapHandling
    {
        #region Fields

        private static Tuple<char, bool[,]>[] LetterMaps = new Tuple<char, bool[,]>[] {
            new Tuple<char, bool[,]> ('A', new bool[,] {
                { false, false, true, false, false },
                { false, true, false, true, false },
                { false, true, true, true, false },
                { true, false, false, false, true },
                { true, false, false, false, true }
            }),
            new Tuple<char, bool[,]> ('B',new bool[,]{
                { true, true, true, true, false },
                { true, false, false, false, true },
                { true, true, true, true, true },
                { true, false, false, false, true },
                { true, true, true, true, false }
            }),
            new Tuple<char, bool[,]> ('C',new bool[,]{
                { false, true, true, true, true },
                { true, false, false, false, false },
                { true, false, false, false, false },
                { true, false, false, false, false },
                { false, true, true, true, true }
            }),
            new Tuple<char, bool[,]> ('D',new bool[,]{
                { true, true, true, true, false },
                { true, false, false, false, true },
                { true, false, false, false, true },
                { true, false, false, false, true },
                { true, true, true, true, false }
            }),
            new Tuple<char, bool[,]> ('E',new bool[,]{
                { true, true, true, true, true },
                { true, false, false, false, false },
                { true, true, true, true, true },
                { true, false, false, false, false },
                { true, true, true, true, true }
            }),
            new Tuple<char, bool[,]> ('F',new bool[,]{
                { true, true, true, true, true },
                { true, false, false, false, false },
                { true, true, true, true, true },
                { true, false, false, false, false },
                { true, false, false, false, false }
            }),
            new Tuple<char, bool[,]> ('G',new bool[,]{
                { true, true, true, true, true },
                { true, false, false, false, false },
                { true, false, true, true, true },
                { true, false, false, false, true },
                { true, true, true, true, true }
            }),
            new Tuple<char, bool[,]> ('H',new bool[,]{
                { true, false, false, false, true },
                { true, false, false, false, true },
                { true, true, true, true, true },
                { true, false, false, false, true },
                { true, false, false, false, true }
            }),
            new Tuple<char, bool[,]> ('I',new bool[,]{
                { true, true, true, true, true },
                { false, false, true, false, false },
                { false, false, true, false, false },
                { false, false, true, false, false },
                { true, true, true, true, true }
            }),
            new Tuple<char, bool[,]> ('J',new bool[,]{
                { true, true, true, true, true },
                { false, false, false, true, false },
                { false, false, false, true, false },
                { false, false, false, true, false },
                { true, true, true, false, false }
            }),
            new Tuple<char, bool[,]> ('K',new bool[,]{
                { true, false, false, false, true },
                { true, false, false, true, false },
                { true, true, true, false, false },
                { true, false, false, true, false },
                { true, false, false, false, true }
            }),
            new Tuple<char, bool[,]> ('L',new bool[,]{
                { true, false, false, false, false },
                { true, false, false, false, false },
                { true, false, false, false, false },
                { true, false, false, false, false },
                { true, true, true, true, true }
            }),
            new Tuple<char, bool[,]> ('M',new bool[,]{
                { true, false, false, false, true },
                { true, true, false, true, true },
                { true, false, true, false, true },
                { true, false, false, false, true },
                { true, false, false, false, true }
            }),
            new Tuple<char, bool[,]> ('N',new bool[,]{
                { true, false, false, false, true },
                { true, true, false, false, true },
                { true, false, true, false, true },
                { true, false, false, true, true },
                { true, false, false, false, true }
            }),
            new Tuple<char, bool[,]> ('O',new bool[,]{
                { false, true, true, true, false },
                { true, false, false, false, true },
                { true, false, false, false, true },
                { true, false, false, false, true },
                { false, true, true, true, false }
            }),
            new Tuple<char, bool[,]> ('P',new bool[,]{
                { false, true, true, true, false },
                { true, false, false, false, true },
                { true, true, true, true, false },
                { true, false, false, false, false },
                { true, false, false, false, false }
            }),
            new Tuple<char, bool[,]> ('Q',new bool[,]{
                { false, true, true, true, false },
                { true, false, false, false, true },
                { true, false, true, false, true },
                { true, false, false, true, false },
                { false, true, true, false, true }
            }),
            new Tuple<char, bool[,]> ('R',new bool[,]{
                { true, true, true, true, false },
                { true, false, false, false, true },
                { true, true, true, true, false },
                { true, false, false, false, true },
                { true, false, false, false, true }
            }),
            new Tuple<char, bool[,]> ('S',new bool[,]{
                { false, true, true, true, true },
                { true, false, false, false, false },
                { false, true, true, true, false },
                { false, false, false, false, true },
                { true, true, true, true, false }
            }),
            new Tuple<char, bool[,]> ('T',new bool[,]{
                { true, true, true, true, true },
                { false, false, true, false, false },
                { false, false, true, false, false },
                { false, false, true, false, false },
                { false, false, true, false, false }
            }),
            new Tuple<char, bool[,]> ('U',new bool[,]{
                { true, false, false, false, true },
                { true, false, false, false, true },
                { true, false, false, false, true },
                { true, false, false, false, true },
                { false, true, true, true, false }
            }),
            new Tuple<char, bool[,]> ('V',new bool[,]{
                { true, false, false, false, true },
                { true, false, false, false, true },
                { false, true, false, true, false },
                { false, true, false, true, false },
                { false, false, true, false, false }
            }),
            new Tuple<char, bool[,]> ('W',new bool[,]{
                { true, false, false, false, true },
                { true, false, false, false, true },
                { true, false, true, false, true },
                { true, false, true, false, true },
                { false, true, false, true, false }
            }),
            new Tuple<char, bool[,]> ('X',new bool[,]{
                { true, false, false, false, true },
                { false, true, false, true, false },
                { false, false, true, false, false },
                { false, true, false, true, false },
                { true, false, false, false, true }
            }),
            new Tuple<char, bool[,]> ('Y',new bool[,]{
                { true, false, false, false, true },
                { false, true, false, true, false },
                { false, false, true, false, false },
                { false, false, true, false, false },
                { false, false, true, false, false }
            }),
            new Tuple<char, bool[,]> ('Z',new bool[,]{
                { true, true, true, true, true },
                { false, false, false, true, false },
                { false, false, true, false, false },
                { false, true, false, false, false },
                { true, true, true, true, true }
            }),
            new Tuple<char, bool[,]> ('0',new bool[,]{
                { false, true, true, true, false },
                { true, false, false, true, true },
                { true, false, true, false, true },
                { true, true, false, false, true },
                { false, true, true, true, false }
            }),
            new Tuple<char, bool[,]> ('1',new bool[,]{
                { false, false, true, false, false },
                { false, true, true, false, false },
                { true, false, true, false, false },
                { false, false, true, false, false },
                { true, true, true, true, true }
            }),
            new Tuple<char, bool[,]> ('2',new bool[,]{
                { false, true, true, true, false },
                { true, false, false, false, true },
                { false, false, true, true, false },
                { false, true, false, false, false },
                { true, true, true, true, true }
            }),
            new Tuple<char, bool[,]> ('3',new bool[,]{
                { true, true, true, true, false },
                { false, false, false, false, true },
                { true, true, true, true, false },
                { false, false, false, false, true },
                { true, true, true, true, false }
            }),
            new Tuple<char, bool[,]> ('4',new bool[,]{
                { false, false, true, true, false },
                { false, true, false, true, false },
                { true, true, true, true, true },
                { false, false, false, true, false },
                { false, false, false, true, false }
            }),
            new Tuple<char, bool[,]> ('5',new bool[,]{
                { true, true, true, true, true },
                { true, false, false, false, false },
                { true, true, true, true, false },
                { false, false, false, false, true },
                { true, true, true, true, false }
            }),
            new Tuple<char, bool[,]> ('6',new bool[,]{
                { false, true, true, true, true },
                { true, false, false, false, false },
                { true, true, true, true, false },
                { true, false, false, false, true },
                { false, true, true, true, false }
            }),
            new Tuple<char, bool[,]> ('7',new bool[,]{
                { true, true, true, true, true },
                { false, false, false, false, true },
                { false, false, false, true, false },
                { false, false, true, false, false },
                { false, true, false, false, false }
            }),
            new Tuple<char, bool[,]> ('8',new bool[,]{
                { false, true, true, true, false },
                { true, false, false, false, true },
                { false, true, true, true, false },
                { true, false, false, false, true },
                { false, true, true, true, false }
            }),
            new Tuple<char, bool[,]> ('9',new bool[,]{
                { false, true, true, true, false },
                { true, false, false, false, true },
                { false, true, true, true, true },
                { false, false, false, false, true },
                { false, true, true, true, false }
            }),
            new Tuple<char, bool[,]> ('£',new bool[,]{
                { false, false, true, true, false },
                { false, true, false, false, true },
                { true, true, true, true, false },
                { false, true, false, false, false },
                { true, true, true, true, true }
            })
        };

        #endregion Fields

        #region Methods

        private static void SetPixel(ref Bitmap Bmp, Point P, Color PixelColor)
        {
            try { Bmp.SetPixel(P.X, P.Y, PixelColor); }
            catch { throw new Exception("Point is out of bounds"); }
        }

        public static Bitmap CreateNew(int x = 800, int y = 600)
        {
            Bitmap Bmp = new Bitmap(x, y);
            return Bmp;
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

        public static void DrawText(ref Bitmap Bmp, Point P, string Text, Color color, int FontSize = 1, int Align = 1)
        {
            int xOffset = 0;
            if (Align == -1) { xOffset = -Text.Length * 6 * FontSize; }
            else if (Align == 0) { xOffset = -Text.Length * 3 * FontSize; }
            foreach (Char C in Text.ToUpper())
            {
                if (Linq.Contains(LetterMaps, x => x.Item1 == C))
                {
                    bool[,] LetterMap = Linq.Where(LetterMaps, x => x.Item1 == C)[0].Item2;
                    for (int x = 0, y = 0; x < 5 * FontSize && y < 5 * FontSize;)
                    {
                        if (LetterMap[y / FontSize, x / FontSize])
                        {
                            SetPixel(ref Bmp, new Point(P.X + x + xOffset, P.Y + y), color);
                        }
                        x++;
                        if (x == 5 * FontSize) { x = 0; y++; }
                    }
                    xOffset += 6 * FontSize;
                }
                else if (C == ' ') { xOffset += 6 * FontSize; }
            }
        }

        public static void MakePointReativeToOrign(ref Point P, Bitmap Bmp)
        {
            P.Y = Bmp.Height - 1 - P.Y;
        }

        public static Point PointRelativeToOrigin(Bitmap Bmp, float x, float y)
        {
            return PointRelativeToOrigin(Bmp, (int)Math.Round(x, 0), (int)Math.Round(y, 0));
        }

        public static Point PointRelativeToOrigin(Bitmap Bmp, int x, int y)
        {
            return new Point(x, Bmp.Height - 1 - y);
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

        #endregion Methods
    }
}