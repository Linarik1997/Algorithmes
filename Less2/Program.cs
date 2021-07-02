using System;
using System.Diagnostics;
using static Less2.TestNode.NodeTest;

namespace Less2
{
    class Program
    {
        #region TestCases
        static TestNode.NodeTest countTest = new TestNode.NodeTest()
        {
            TestName = "Count",
            TestType = TestNode.TestType.Count,
            ExpectedResult = "Valid",
            Count = 3,
            ExpectedException = null,
            Pops = 0
        };
        static TestNode.NodeTest countPopTest = new()
        {
            TestName = "PopsCount",
            TestType = TestNode.TestType.Count,
            ExpectedResult = "Valid",
            Count = 3,
            ExpectedException = null,
            Pops = 2
        };
        static TestNode.NodeTest addFirst = new()
        {
            TestName = "AddFirst",
            TestType = TestNode.TestType.AddFirst,
            ExpectedResult = "Valid",
            Count = 5,
            Value = 20,
            ExpectedValue = 20
        };
        static TestNode.NodeTest addFirstFalse = new()
        {
            TestName = "AddFirst",
            TestType = TestNode.TestType.AddFirst,
            ExpectedResult = "Invalid",
            Count = 5,
            Value = 20,
            ExpectedValue = 30
        };
        static TestNode.NodeTest findNode = new()
        {
            TestName = "FindNode",
            TestType = TestNode.TestType.FindNode,
            ExpectedResult = "Valid",
            Count = 5,
            Value = 4,
            ExpectedValue = 4
        };
        static TestNode.NodeTest notfindNode = new()
        {
            TestName = "NotfindNode",
            TestType = TestNode.TestType.FindNode,
            ExpectedResult = "Valid",
            Count = 5,
            Value = 10,
            ExpectedValue = -1
        };
        static TestNode.NodeTest addNodeAfter = new()
        {
            TestName = "AddNodeAfter",
            TestType = TestNode.TestType.AddNodeAfter,
            ExpectedResult = "Valid",
            Count = 10,
            Value = 20,
            Index = 5,
            ExpectedValue = 20,
        };
        static TestNode.NodeTest addNodeAfterLast = new()
        {
            TestName = "AddNodeAfterTail",
            TestType = TestNode.TestType.AddNodeAfter,
            ExpectedResult = "Valid",
            Count = 5,
            Value = 20,
            Index = 4,
            ExpectedValue = 20
        };
        static TestNode.NodeTest addNodeAfterException = new()
        {
            TestName = "AddNodeAfterException",
            TestType = TestNode.TestType.AddNodeAfter,
            ExpectedResult = "Valid Ex",
            Count = 10,
            Value = 30,
            Index = 15,
            ExpectedException = new ArgumentException(),
            ExpectedValue = 20
        };
        static TestNode.NodeTest removeNode = new()
        {
            TestName = "RemoveNode",
            TestType = TestNode.TestType.RemoveNode,
            ExpectedResult = "Valid",
            Count = 4,
            Index = 2,
            ExpectedIndex = -1
        };
        static TestNode.NodeTest removeNodeFalse = new()
        {
            TestName = "RemoveNodeFalse",
            TestType = TestNode.TestType.RemoveNode,
            ExpectedResult = "Invalid",
            Count = 10,
            Index = 8,
            ExpectedIndex = 9
        };
        static TestNode.NodeTest removeHead = new()
        {
            TestName = "RemoveHead",
            TestType = TestNode.TestType.RemoveNode,
            ExpectedResult = "Valid",
            Count = 5,
            Index = 0,
            ExpectedIndex = -1
        };
        static TestNode.NodeTest removeTail = new()
        {
            TestName = "RemoveTail",
            TestType = TestNode.TestType.RemoveNode,
            ExpectedResult = "Valid",
            Count = 5,
            Index = 4,
            ExpectedIndex = -1
        };
        static TestNode.NodeTest removeOne = new()
        {
            TestName = "RemoveOne",
            TestType = TestNode.TestType.RemoveNode,
            ExpectedResult = "Valid",
            Count = 1,
            Index = 0,
            ExpectedIndex = -1
        };
        static TestNode.NodeTest removeException = new()
        {
            TestName = "RemoveException",
            TestType = TestNode.TestType.RemoveNode,
            ExpectedResult = "Valid Ex",
            Count = 10,
            Index = 15,
            ExpectedIndex = 0,
            ExpectedException = new ArgumentOutOfRangeException()
        };
        #endregion

        static public TestNode.NodeTest[] cases = new[] { countTest, countPopTest, addFirst, addFirstFalse, 
            findNode, notfindNode ,addNodeAfter,addNodeAfterLast,addNodeAfterException, removeNode,removeHead,removeTail,removeOne,
        removeException,removeNodeFalse};


        static void Main(string[] args)
        {
            //Тесты
            foreach (var testCase in cases)
            {
                ShowResult(testCase);
            }
            //Демонстрация
            ITwoWayLinkedList doubleLinkedList = new DoubleLinkedList(); //Создание списка и заполнение
            for(int i =0; i < 20; i++)
            {
                doubleLinkedList.AddFirst(i);
            }
            //Отображение элементов и отдельно головы и хвоста
            Console.WriteLine(doubleLinkedList.Display()); 
            var dls = (DoubleLinkedList)doubleLinkedList;
            Console.WriteLine("Head:"+ dls.Head.Value.ToString());
            Console.WriteLine("Tail:" + dls.Tail.Value.ToString());
            
            doubleLinkedList.RemoveNode(16);//Удаляем 16ый элемент по индексу
            var node = doubleLinkedList.FindNode(0);//находим ноду со значением 0 (первая)
            doubleLinkedList.AddNodeAfter(node, 150); //После нее вставляем новую со значением 150

            //Отображение элементов и отдельно головы и хвоста
            Console.WriteLine(doubleLinkedList.Display());
            Console.WriteLine("Head:" + dls.Head.Value.ToString());
            Console.WriteLine("Tail:" + dls.Tail.Value.ToString());


            //Сортировка массива + бинарный поиск
            Console.WriteLine("Сортировка массива + бинарный поиск:");
            for (int t = 0; t < 10; t++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int[] rndArray = new int[10000];
                Random rnd = new Random();
                for (int i = 0; i < rndArray.Length; i++)
                {
                    rndArray[i] = rnd.Next(0, 10000);
                }
                var index = BinarySearch.ArrayBinarySearch(rndArray, rnd.Next(0, 10000));
                sw.Stop();
                Console.WriteLine($"Iteration:{t}; Time Ellapsed:{sw.ElapsedMilliseconds} ; Found Index:{index}");
            }
            //бинарный поиск в отсортированном массиве
            Console.WriteLine("бинарный поиск в отсортированном массиве:");
            for (int t = 0; t < 10; t++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int[] sortedArr = new int[10000];
                Random rnd = new Random();
                for (int i = 0; i < sortedArr.Length; i++)
                {
                    sortedArr[i] = i;
                }
                var index = BinarySearch.ArrayBinarySearch(sortedArr, rnd.Next(0, 10000));
                sw.Stop();
                Console.WriteLine($"Iteration:{t}; Time Ellapsed:{sw.ElapsedMilliseconds} ; Found Index:{index}");
            }
        }
    }
}

