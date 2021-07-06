using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Less3.DistanceCalculation
{
    public class PointClass
    {
        private float X { get; set; }
        private float Y { get; set; }
        public PointClass(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        public  static void PointClassDistance()
        {
            Random r = new Random();
            PointClass A = new PointClass(r.Next(0, 100) * 1_000_000, r.Next(0, 100) * 1_000_000);
            PointClass B = new PointClass(r.Next(0, 100) * 1_000_000, r.Next(0, 100) * 1_000_000);
            float x = A.X - B.X;
            float y = A.Y - B.Y;
            var result = MathF.Sqrt((x * x) + (y * y));
        }
    }
}
