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
            BinaryTree<int> bt = new(100);
            bt.AddItem(50);
            bt.AddItem(20);
            bt.AddItem(70);
            bt.AddItem(150);
            bt.AddItem(200);
            bt.AddItem(10);
            bt.AddItem(170);
            bt.PrintTree(TreeNode<int>.TraversalOrder.inorder) ;


            return;
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
