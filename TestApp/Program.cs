using DataVisulisation;
using System.Drawing;

namespace TestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Bitmap Bmp = BitMapHandling.CreateNew(800,600);
            //BitMapHandling.SetBackColor(ref Bmp, Color.Gray);
            //BitMapHandling.DrawLine(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, 10, 10), BitMapHandling.PointRelativeToOrigin(Bmp, 300, 500), Color.Green, 2);
            //BitMapHandling.DrawLine(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, 300, 500), BitMapHandling.PointRelativeToOrigin(Bmp, 500, 350), Color.Red, 2);
            //BitMapHandling.DrawEquation(ref Bmp, BitMapHandling.PointRelativeToOrigin(Bmp, 10, 10), 500, Color.Blue, "500.0/((x/50)+1)");

            LineGraph.DrawLines(ref Bmp, new int[] { 40, 20, 30, 5, 20, 1000 }, Color.Blue, 30, 2, new string[] { "Steve", "Bob", "Garry", "Remansi", "Neha", "Dave" });

            //string Alpha = "0123456789";
            //BitMapHandling.DrawText(ref Bmp, new Point(10, 0), Alpha, Color.Black, 1);
            //BitMapHandling.DrawText(ref Bmp, new Point(10, 8), Alpha, Color.Black, 2);
            //BitMapHandling.DrawText(ref Bmp, new Point(10, 20), Alpha, Color.Black, 3);
            //BitMapHandling.DrawText(ref Bmp, new Point(10, 40), Alpha, Color.Black, 4);
            //BitMapHandling.DrawText(ref Bmp, new Point(10, 70), Alpha, Color.Black, 5);

            //BitMapManipulation.ApplyAA(ref Bmp, 2f);
            Bmp.Save("./out.png");
        }
    }
}