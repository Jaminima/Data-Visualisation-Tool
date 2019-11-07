using DataVisulisation;
using System.Drawing;

namespace TestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //    Bitmap Bmp = BitMapHandling.CreateNew();
            //    BitMapHandling.SetBackColor(ref Bmp, Color.Gray);
            //    BitMapHandling.DrawLine(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, 10, 10), BitMapHandling.PointRelativeToOrigin(Bmp, 300, 500), Color.Green, 2);
            //    BitMapHandling.DrawLine(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, 300, 500), BitMapHandling.PointRelativeToOrigin(Bmp, 500, 350), Color.Red, 2);
            //    BitMapHandling.DrawEquation(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, 10, 10), 500, Color.Blue, "500.0/((x/50)+1)");
            //    BitMapManipulation.ApplyAA(ref Bmp);
            Bitmap Bmp = LineGraph.Create(new int[] { 40, 20, 30, 5, 20 });
            Bmp.Save("./out.png");
        }
    }
}