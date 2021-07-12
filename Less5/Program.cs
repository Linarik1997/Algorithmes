using System;
using System.Collections.Generic;
using Less4.BinTree;

namespace Less5
{
    class Program
    {
        /// <summary>
        /// Статичский метод обходу в ширину в бинарном древе поиска с типом данных int, реализованном в Less4.BinTree
        /// </summary>
        /// <param name="bt">Ссылка на экземпляр бинарного древа поиска с типом данных int</param>
        /// <param name="searchValue">int значение поиска узла в бинарном древе поиска</param>
        /// <returns>Ссылку на узел в древе при обнаружении узла с searchValue, null при не обнаружении узла</returns>
        public static TreeNode<int> BFS(BinaryTree<int> bt, int searchValue)
        {
            //Создаем Очередь.
            //Добавляем в нее корень bt.
            Queue<TreeNode<int>> q = new Queue<TreeNode<int>>();
            var root = bt.GetRoot();
            q.Enqueue(root);
            Console.WriteLine($"Добавлен в очередь узел с Value:{root.Value}");
            //В цикле перебираем набор данных в очереди до тех пор пока в очереди больше 0 элементов.
            //Достаем из очереди элемент и присваиваем элемент переменной node.
            //Если node.Value == searchValue возвращаем node.
            //В противном случае добавляем в очередь node.LeftChild и node.RightChild если ссылка на них не null.
            while (q.Count>0)
            {
                var node = q.Dequeue();
                Console.WriteLine($"Вытащили из очередь узел с Value:{node.Value}");
                if (node.Value == searchValue)
                {
                    Console.WriteLine($"Найден искомый узел с Value:{node.Value}");
                    return node;
                }
                if (node.LeftChild != null)
                {
                    q.Enqueue(node.LeftChild);
                    Console.WriteLine($"Добавлен в очередь узел с Value:{node.LeftChild.Value}");
                }
                if (node.RightChild != null)
                {
                    q.Enqueue(node.RightChild);
                    Console.WriteLine($"Добавлен в очередь узел с Value:{node.RightChild.Value}");
                }

            }
            //Выход из цикла обозначает, что искомый элемент не был найден.
            //Тогла возвращаем null.
            Console.WriteLine($"Искомый узел с Value: {searchValue} не найден");
            return null;
        }
        /// <summary>
        /// Статичский метод обхода в глубину в бинарном древе поиска с типом данных int, реализованном в Less4.BinTree
        /// </summary>
        /// <param name="bt">Ссылка на экземпляр бинарного древа поиска с типом данных int</param>
        /// <param name="searchValue">int значение поиска узла в бинарном древе поиска</param>
        /// <returns>Ссылку на узел в древе при обнаружении узла с searchValue, null при не обнаружении узла</returns>
        public static TreeNode<int> DFS(BinaryTree<int> bt,int searchValue)
        {
            //Создаем Стек.
            //Добавляем в нее корень bt.
            Stack<TreeNode<int>> s = new Stack<TreeNode<int>>();
            var root = bt.GetRoot();
            s.Push(root);
            Console.WriteLine($"Добавлен в стэк узел с Value:{root.Value}");
            //В цикле перебираем набор данных в стэке до тех пор пока в стэке больше 0 элементов.
            //Достаем из стэка элемент и присваиваем элемент переменной node.
            //Если node.Value == searchValue возвращаем node.
            //В противном случае добавляем в стэк node.LeftChild и node.RightChild если ссылка на них не null.
            while (s.Count > 0)
            {
                var node = s.Pop();
                Console.WriteLine($"Вытащили из стэка узел с Value:{node.Value}");
                if (node.Value == searchValue)
                {
                    Console.WriteLine($"Найден искомый узел с Value:{node.Value}");
                    return node;
                }
                if (node.LeftChild != null)
                {
                    s.Push(node.LeftChild);
                    Console.WriteLine($"Добавлен в стэк узел с Value:{node.LeftChild.Value}");
                }
                if (node.RightChild != null)
                {
                    s.Push(node.RightChild);
                    Console.WriteLine($"Добавлен в стэк узел с Value:{node.RightChild.Value}");
                }
            }
            //Выход из цикла обозначает, что искомый элемент не был найден.
            //Тогла возвращаем null.
            Console.WriteLine($"Искомый узел с Value: {searchValue} не найден");
            return null;
        }

        static void Main(string[] args)
        {
            BinaryTree<int> bt = new(100);
            bt.AddItem(20);
            bt.AddItem(120);
            bt.AddItem(150);
            bt.AddItem(80);
            bt.PrintTree();
            DFS(bt, 60);
        }
    }
}
