using ImitationLibrary;
using System;
using System.Data;
using System.Drawing;

namespace DataVisulisation
{
    public static class BitMapHandling
    {
        #region Fields
        /*This horrific Array of chars and bool arrays immitates what i wanted to do using a dictionary (but wasnt allowed too)
         * In here we state what character we are defining, and a 5x5 black and white equivalent grid to define the look
         * These are used later on to write these characters to the screen*/
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
            }),
            new Tuple<char, bool[,]> ('/',new bool[,]{
                { false, false, false, false, true },
                { false, false, false, true, false },
                { false, false, true, false, false },
                { false, true, false, false, false },
                { true, false, false, false, false }
            }),
            new Tuple<char, bool[,]> ('!',new bool[,]{
                { false, false, true, false, false },
                { false, false, true, false, false },
                { false, false, true, false, false },
                { false, false, false, false, false },
                { false, false, true, false, false }
            }),
            new Tuple<char, bool[,]> ('?',new bool[,]{
                { false, false, true, true, false },
                { false, false, false, false, true },
                { false, false, true, true, false },
                { false, false, false, false, false },
                { false, false, true, false, false }
            })
        };

        #endregion Fields

        #region Methods

        private static void SetPixel(ref Bitmap Bmp, Point P, Color PixelColor)
        {
            try { Bmp.SetPixel(P.X, P.Y, PixelColor); }//Attempt to set the pixel, and throw a custom error if we cant
            catch { throw new Exception("Point is out of bounds"); }
        }

        public static Bitmap CreateNew(int x = 800, int y = 600)
        {
            Bitmap Bmp = new Bitmap(x, y);//Create a bitmap fitting the dimensions
            return Bmp;
        }

        public static void DrawEquation(ref Bitmap Bmp, Point P, int xSize, Color LineColor, string Equation = "x")
        {
            DataTable DT = new DataTable();//This is used in order to process the equation
            int prevY = P.Y;
            for (int x = 0; x < xSize; x++)//For every x position
            {
                //Calculate the y value by processing the equation
                int y = P.Y - (int)Math.Round(Convert.ToDouble(DT.Compute(Equation.Replace("x", x.ToString()), "")), 0),
                    yDirection = Math.Sign(prevY - y);//Check to see if the equation is increasing or decreasing

                if (y >= 0 && y < Bmp.Height) { SetPixel(ref Bmp, new Point(x + P.X, y), LineColor); }//Set the target pixel
                for (int i = y + yDirection; i != prevY; i += yDirection)//For every y co-ordinate between this pixel and the previous
                {
                    if (i >= 0 && i < Bmp.Height) { SetPixel(ref Bmp, new Point(x + P.X, i), LineColor); }//Set the pixel -- This ensures a continous line
                }
                prevY = y;
            }
            DT.Dispose();//Remove it from memory
        }

        public static void DrawLine(ref Bitmap Bmp, Point P1, Point P2, Color LineColor, int Thickness = 1)
        {
            int xChange = Math.Abs(P1.X - P2.X), yChange = Math.Abs(P1.Y - P2.Y);//Calculate how far we are going in each direction
            int xDirection = Math.Sign(P2.X - P1.X), yDirection = Math.Sign(P1.Y - P2.Y);//Determine if we are moving positevely or negativel
            float Gradient = (float)yChange / xChange * yDirection;//Calcultate the gradient of the line
            bool GradientIsVertical = Math.Abs(Gradient) > 1;//Determine if the line is more than 45 degrees from the x axis

            for (int x = P1.X; x != P2.X && !GradientIsVertical; x += xDirection)//If gradient is < 45 degrees, increment along the x axis
            {
                int y = P1.Y - (int)Math.Round(Math.Abs(x - P1.X) * Gradient, 0);//Calculate the y value
                for (int i = 0; i + y < Bmp.Height && i < Thickness; i++) SetPixel(ref Bmp, new Point(x, y + i), LineColor);//Color extra pixels around the new pixel
            }

            for (int y = P1.Y; y != P2.Y && GradientIsVertical; y -= yDirection)//If gradient is > 45 degrees, increment along the y axis
            {
                int x = P1.X - (int)Math.Round(Math.Abs(P1.Y - y) / Gradient, 0);//Calculate the x value
                for (int i = 0; i + x < Bmp.Width && i < Thickness; i++) { SetPixel(ref Bmp, new Point(x + i, y), LineColor); }//Color extra pixels around the new pixel
            }
        }

        public static void DrawText(ref Bitmap Bmp, Point P, string Text, Color color, int FontSize = 1, int Align = 1)
        {
            int xOffset = 0;//Stores how far we should be starting drawing from the Point
            if (Align == -1) { xOffset = -Text.Length * 6 * FontSize; }//Offset the text so the last character ends on the point
            else if (Align == 0) { xOffset = -Text.Length * 3 * FontSize; }//Offset the text so the middle of the text is on the point
            foreach (Char C in Text.ToUpper())//Process each characer, as a capital
            {
                if (Linq.Contains(LetterMaps, x => x.Item1 == C))//Check if the character exists in the Letter Maps
                {
                    bool[,] LetterMap = Linq.Where(LetterMaps, x => x.Item1 == C)[0].Item2;//Get the boolean grid for the character
                    for (int x = 0, y = 0; x < 5 * FontSize && y < 5 * FontSize;)//Set pixels in a 5 * Font size area
                    {
                        if (LetterMap[y / FontSize, x / FontSize])//If the place in the letter map is true, Set the pixel
                        {
                            SetPixel(ref Bmp, new Point(P.X + x + xOffset, P.Y + y), color);
                        }
                        x++;//Increment
                        if (x == 5 * FontSize) { x = 0; y++; }//Shift down a row if we are at the end
                    }
                    xOffset += 6 * FontSize;//Move the offest to leave a gap and so we dont write over the text
                }
                else if (C == ' ') { xOffset += 6 * FontSize; }//Leave an empty space in the text
            }
        }

        public static void MakePointReativeToOrign(ref Point P, Bitmap Bmp)
        {
            P.Y = Bmp.Height - 1 - P.Y;//Change the y value to be relative to the bottom not the top
        }

        public static Point PointRelativeToOrigin(Bitmap Bmp, float x, float y)
        {
            return PointRelativeToOrigin(Bmp, (int)Math.Round(x, 0), (int)Math.Round(y, 0));
        }

        public static Point PointRelativeToOrigin(Bitmap Bmp, int x, int y)
        {
            return new Point(x, Bmp.Height - 1 - y);//Create a point relative to the bottom of the screen
        }

        public static void SetBackColor(ref Bitmap Bmp, Color BackColor)
        {
            for (int x = 0, y = 0; y < Bmp.Height;)//Set the color of every pixel to the given
            {
                SetPixel(ref Bmp, new Point(x, y), BackColor);
                x++;
                if (x == Bmp.Width) { x = 0; y++; }//If we are at the end of the row, shift down
            }
        }

        #endregion Methods
    }
}