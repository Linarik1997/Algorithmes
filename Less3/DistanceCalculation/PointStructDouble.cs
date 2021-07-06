using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less3.DistanceCalculation
{
    public struct PointStructDouble
    {
        private double X { get; set; }
        private double Y { get; set; }
        private PointStructDouble(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public static void PointStructDoubleDistance()
        {
            Random r = new Random();
            PointStructDouble A = new PointStructDouble(r.Next(0, 100) * 1_000_000, r.Next(0, 100) * 1_000_000);
            PointStructDouble B = new PointStructDouble(r.Next(0, 100) * 1_000_000, r.Next(0, 100) * 1_000_000);
            double x = A.X - B.X;
            double y = A.Y - B.Y;
            var resut = Math.Sqrt((x * x) + (y * y));
        }
    }
}
