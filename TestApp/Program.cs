using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DataVisulisation;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap Bmp = BitMapHandling.CreateNew();
            BitMapHandling.SetBackColor(ref Bmp, Color.Gray);
            BitMapHandling.DrawLine(ref Bmp, new Point(10, 10), new Point(600, 400), Color.Red);
            Bmp.Save("./out.png");
        }
    }
}
