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
            BitMapHandling.DrawLine(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, 10, 10), BitMapHandling.PointRelativeToOrigin(Bmp, 300, 500), Color.Black, 2);
            BitMapHandling.DrawLine(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, 300, 500), BitMapHandling.PointRelativeToOrigin(Bmp, 500, 350), Color.Black, 2);
            BitMapManipulation.ApplyAA(ref Bmp);
            Bmp.Save("./out.png");
        }
    }
}
