using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less3.DistanceCalculation
{
    public struct PointStructFloat
    {
        private float X;
        private float Y;
        public PointStructFloat(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        public static void PointStructFloatDistance()
        {
            Random r = new Random();
            PointStructFloat A = new PointStructFloat(r.Next(0, 100) * 1_000_000, r.Next(0, 100) * 1_000_000);
            PointStructFloat B = new PointStructFloat(r.Next(0, 100) * 1_000_000, r.Next(0, 100) * 1_000_000);
            float x = A.X - B.X;
            float y = A.Y - B.Y;
            var result = MathF.Sqrt((x * x) + (y * y));
        }
        public static void PointStructFloatDistanceNoSqrt()
        {
            Random r = new Random();
            PointStructFloat A = new PointStructFloat(r.Next(0, 100) * 1_000_000, r.Next(0, 100) * 1_000_000);
            PointStructFloat B = new PointStructFloat(r.Next(0, 100) * 1_000_000, r.Next(0, 100) * 1_000_000);
            float x = A.X - B.X;
            float y = A.Y - B.Y;
            var result = (x * x) + (y * y);
        }
    }
}
