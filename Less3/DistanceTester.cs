using System;
using System.Diagnostics;
using System.Threading;

namespace Less3
{
    public class DistanceTester
    {
        private static void BubbleSort(long[] arr)
        {
            var count = arr.Length;
            for(int i = 0; i < count; i++)
            {
                for( int j = 0;j < count - 1;j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        var temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
        private static long Average(long[] arr)
        {
            long total = 0;
            foreach(var t in arr)
            {
                total += t;
            }
            return total/arr.Length;
        }
        static public void RunPerOperation(Action act, int count)
        {
            Stopwatch ft = new();
            Console.WriteLine($"Test: {act.Method.Name}");
            long[] results = new long[count];
            Random r = new Random();
            ft.Start();
            for (int i = 0; i < count; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var t = r.Next(100, 400);
                act();
                Thread.Sleep(t);
                sw.Stop();
                results[i] = sw.ElapsedMilliseconds;
                Console.WriteLine($"№ {i + 1} Time Elapsed: {sw.ElapsedMilliseconds} Sleep: {t}");
            }
            ft.Stop();
            BubbleSort(results);
            var median = count % 2 == 0 ? (results[results.Length / 2] + results[(results.Length / 2) + 1]) / 2 : results[results.Length / 2];
            Console.WriteLine($"Test: {act.Method.Name} FullTime: {ft.ElapsedMilliseconds} Average: {Average(results)} Median: {median}");
        }
        static public void RunFullTime(Action act, int count, int iterations)
        {
            long total = 0;
            long[] results = new long[iterations];
            for(int i = 0; i < iterations; i++)
            {
                Stopwatch ft = new();
                ft.Start();
                for (int j = 0; j< count; j++)
                {
                    act();
                }
                ft.Stop();
                total += ft.ElapsedMilliseconds;
                results[i] = ft.ElapsedMilliseconds;
            }
            BubbleSort(results);
            var median = count % 2 == 0 ? (results[results.Length / 2] + results[(results.Length / 2) + 1]) / 2 : results[results.Length / 2];
            Console.WriteLine($"Test: {act.Method.Name} FullTime: {total} Average: {Average(results)} Median: {median}");
        }
    }
}

