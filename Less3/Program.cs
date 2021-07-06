using System;
using Less3.DistanceCalculation;

namespace Less3
{
    class Program
    {
        static void Main(string[] args)
        {
            Action[] actions = new Action[]
            {
                PointClass.PointClassDistance,
                PointStructDouble.PointStructDoubleDistance,
                PointStructFloat.PointStructFloatDistance,
                PointStructFloat.PointStructFloatDistanceNoSqrt
            };
            foreach (var action in actions)
            {
                DistanceTester.RunPerOperation(action, 5);
            }
            foreach (var action in actions)
            {
                DistanceTester.RunFullTime(action, 1000000,5);
            }
        }
    }
}
