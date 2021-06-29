using System;

namespace ConsoleApp1
{
    class Program
    {
        public class TestCase
        {
            public int X { get; set; }
            public int ExpectedResult { get; set; }
            public string TestGoal { get; set; }
            public Exception ExpectedException { get; set; }

            static string TestFibIter(TestCase testCase)
            {
                try
                {
                    var actual = FibIter(testCase.X);
                    if (actual == testCase.ExpectedResult)
                    {
                        return "VALID";
                    }
                    else
                    {
                        return "INVALID";
                    }
                }
                catch (Exception ex)
                {
                    if (testCase.ExpectedException != null)
                    {
                        return "VALID";
                    }
                    else
                    {
                        return "INVALID";
                    }
                }
            }
            static string TestFibRec(TestCase testCase)
            {
                try
                {
                    var actual = FibRec(testCase.X);
                    if (actual == testCase.ExpectedResult)
                    {
                        return "VALID";
                    }
                    else
                    {
                        return "INVALID";
                    }
                }
                catch (Exception ex)
                {
                    if (testCase.ExpectedException != null)
                    {
                        return "VALID";
                    }
                    else
                    {
                        return "INVALID";
                    }
                }
            }
            public static void TestChain(TestCase[] tCases)
            {
                Console.WriteLine("TYPE" + new string(' ', 5) + "TEST GOAL" + new string(' ', 5) + "ACTUAL GOAL");
                foreach(var tCase in tCases)
                {
                    Console.WriteLine($"CYCLE" + new string(' ', 5) + tCase.TestGoal + new string(' ', 5) + TestFibIter(tCase));
                    Console.WriteLine($"RECUR" + new string(' ', 5) + tCase.TestGoal + new string(' ', 5) + TestFibRec(tCase));
                }
            }
        }

        /// <summary>
        /// Счетчик итераций для циклической и рекурсивной функций
        /// </summary>
        static long fRec = 0;
        static long fIter = 0;
        /// <summary>
        /// Тесты функции вычисления числа Фибоначчи
        /// </summary>
        static TestCase testFibTrue = new TestCase()
        {
            X = 10,
            ExpectedResult = 55,
            TestGoal = "VALID",
            ExpectedException = null
        };
        static TestCase testFibFalse = new TestCase()
        {
            X = 8,
            ExpectedResult = 20,
            TestGoal = "INVALID",
            ExpectedException = null
        };
        static TestCase testFibException = new TestCase()
        {
            X = -1,
            ExpectedResult = 0,
            TestGoal = "VALID",
            ExpectedException = new ArgumentException()
        };
        static TestCase[] cases = new TestCase[3] { testFibTrue, testFibFalse, testFibException };
        static void Task1()
        {
            Console.WriteLine("Введите число n");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out int n))
                throw new ArgumentException($"{input} не является целым числом");
            int i = 2;
            int d = 0;
            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                    i++;
                }
                else
                    i++;
            }
            if (d == 0)
            {
                Console.WriteLine($"{n} простое число");
            }
            else
            {
                Console.WriteLine($"{n} составное число");
            }
        }
        static int FibRec(int n)
        {
            if (n < 0)
                throw new ArgumentException($"{n} должен быть положительным числом");
            fRec++;
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            else
                return (FibRec(n - 1) + FibRec(n - 2));            
        }
        static int FibIter(int n)
        {
            if (n < 0)
                throw new ArgumentException($"{n} должен быть положительным числом");
            fIter++;
            int res = 0;
            int fib0 = 0;
            int fib1 = 1;
            for(int i = 1; i < n; i++)
            {
                res = fib0 + fib1;
                fib0 = fib1;
                fib1 = res;
                fIter++;
            }
            return res;
        }
        static void Main(string[] args)
        {
            Task1();
            Console.WriteLine($"10ый член последовательности Фибоначчи {FibRec(10)}: количество итераций через рекурсию {fRec}"); 
            Console.WriteLine($"10ый член последовательности Фибоначчи {FibIter(10)}: количество итераций через цикл {fIter}");
            TestCase.TestChain(cases);
        }
    }
}
