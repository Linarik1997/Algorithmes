using Less4.BinTree;
using Less4.Task1;
using System;
using System.Diagnostics;
using System.Linq;

namespace Less4
{
    class Program
    {
        public delegate bool Find(string line);
        public static string GenerateOneLine(int lineLength, char[] alphabet)
        {
            string line = string.Empty;
            var max = alphabet.Length;
            Random rnd = new Random();
            for (int i = 0; i < lineLength; i++)
            {
                char letter = alphabet[rnd.Next(0, max)];
                line += letter;
            }
            return line;
        }
        public static long Test(Find test, string toFind)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            test(toFind);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        static void Main(string[] args)
        {
            //Демонстрация дерева
            BinaryTree<int> bt = new(100);
            bt.AddItem(99);
            bt.AddItem(102);
            bt.AddItem(101);
            bt.AddItem(120);
            bt.AddItem(115);
            Console.WriteLine("Изначальное дерево");
            bt.PrintTree();
            bt.RemoveItem(102);
            Console.WriteLine("Удаление узла 102");
            bt.PrintTree();
            Console.WriteLine("Удаление узла 100");
            bt.RemoveItem(100);
            bt.PrintTree();
            Console.WriteLine($"Root.Value: {bt.GetRoot().Value}");
            var node = bt.GetNodeByValue(99);
            Console.WriteLine("GetNodeByValue(99).Value: {0}",node?.Value);

            //Сравнение массива и хэшсета
            char[] alhabet = Enumerable.Range('A', 'z' - 'A' + 1).Select(i => (char)i).Where(i => i < '[' ^ i > '`').ToArray();
            HashTest hashTest = new(alhabet);
            hashTest.FillHashSet(10, 1_000_000);

            string s = GenerateOneLine(10, alhabet);

            ArrayTest arrayTest = new ArrayTest(alhabet, 1_000_000);
            arrayTest.FillArray(10);

            Find AT = arrayTest.Array.Contains<string>;
            Find HST = hashTest.hashSet.Contains;
            Console.WriteLine($"Поиск в несортированном массиве строк:{Test(AT, s)} мс");
            Console.WriteLine($"Поиск в HashSet<String>:{Test(HST, s)} мс");
        }
    }
}
