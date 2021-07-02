using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2.TestNode
{
    public enum TestType
    {
        Count,
        AddFirst,
        FindNode,
        AddNodeAfter,
        RemoveNode
    }
    public class NodeTest
    {
        #region fields
        public string TestName { get; set; }
        public TestType TestType { get; set; }
        public string ExpectedResult { get; set; }
        public int Count { get; set; }
        public int Pops { get; set; }
        public int Value { get; set; }
        public int Index { get; set; }
        public int ExpectedValue { get; set; }
        public int ExpectedIndex { get; set; }
        public int ExpectedCount
        {
            get { return Count - Pops; }
        }
        public Exception ExpectedException { get; set; }
        #endregion
        #region private Methods
        static private int linkedListCount(int count, int pops)
        {
            DoubleLinkedList linkedList = new DoubleLinkedList();
            var dls = (ITwoWayLinkedList)linkedList;
            for(int i = 0; i < count; i++)
            {
                dls.AddNode(i);
            }
            for(int i =0; i < pops; i++)
            {
                dls.RemoveNode(i);
            }
            return dls.GetCount();
        }
        static private int AddFirstTest(int count, int value)
        {
            DoubleLinkedList linkedList = new DoubleLinkedList();
            var dls = (ITwoWayLinkedList)linkedList;
            for (int i = 0; i < count; i++)
            {
                dls.AddNode(i);
            }
            dls.AddFirst(value);
            return linkedList.Head.Value;
        }
        static private int FindNodeTest(int count, int value)
        {
            DoubleLinkedList linkedList = new DoubleLinkedList();
            var dls = (ITwoWayLinkedList)linkedList;
            for (int i = 0; i < count; i++)
            {
                dls.AddNode(i);
            }
            var node = dls.FindNode(value);
            if (node != null)
                return node.Value;
            else return -1;
        }
        static private int AddNodeAfterTest(int count, int index,int value)
        {
            DoubleLinkedList linkedList = new DoubleLinkedList();
            var dls = (ITwoWayLinkedList)linkedList;
            for (int i = 0; i < count; i++)
            {
                dls.AddNode(i);
            }
            var node = dls.FindNode(index);
            dls.AddNodeAfter(node, value);

            if(index == count - 1)
            {
                var isTail = linkedList.Tail == node.NextNode ? true : false;
                if (isTail)
                    return linkedList.Tail.Value;
                else
                    throw new AggregateException();
            }
            return node.NextNode.Value;
        }
        static private int RemoveNodeTest(int count, int index)
        {
            DoubleLinkedList linkedList = new DoubleLinkedList();
            var dls = (ITwoWayLinkedList)linkedList;
            for (int i = 0; i < count; i++)
            {
                dls.AddNode(i);
            }
            if(index == 0)
            {
                var temp = linkedList.Head.NextNode;
                dls.RemoveNode(index);
                if (linkedList.Head == temp)
                    return -1;
                else throw new AggregateException();
            }
            if(index == dls.GetCount() - 1)
            {
                var temp = linkedList.Tail.PrevNode;
                dls.RemoveNode(index);
                if (linkedList.Tail == temp)
                    return -1;
                else throw new AggregateException();
            }
            dls.RemoveNode(index);
            var check = dls.FindNode(index);
            if (check == null)
                return -1;
            else 
                return check.Value;
        }
        #endregion
        #region Public Methods
        static public string Test(NodeTest test)
        {
            try
            {

                switch (test.TestType)
                {
                    case TestType.Count:
                        var actual = linkedListCount(test.Count, test.Pops);
                        if (actual == test.ExpectedCount)
                            return "Valid";
                        else
                            return "Invalid";
                    case TestType.AddFirst:
                        actual = AddFirstTest(test.Count, test.Value);
                        if (actual == test.ExpectedValue)
                            return "Valid";
                        else
                            return "Invalid";
                    case TestType.FindNode:
                        actual = FindNodeTest(test.Count, test.Value);
                        if (actual == test.ExpectedValue)
                            return "Valid";
                        else
                            return "Invalid";
                    case TestType.AddNodeAfter:
                        actual = AddNodeAfterTest(test.Count, test.Index, test.Value);
                        if (actual == test.Value)
                            return "Valid";
                        else
                            return "Invalid";
                    case TestType.RemoveNode:
                        actual = RemoveNodeTest(test.Count, test.Index);
                        if (actual == test.ExpectedIndex)
                            return "Valid";
                        else
                            return "Invalid";
                    default:
                        return "Test Type not defined";
                }

            }
            catch (Exception ex)
            {
                if (test.ExpectedException != null)
                    return "Valid Ex";
                else
                    return "Invalid Ex";
            }
        }

        //OLD
        //static public string TestCount(NodeTest test)
        //{
        //    try
        //    {
        //        var actual = linkedListCount(test.Count, test.Pops);
        //        if (actual == test.ExpectedCount)
        //            return "Valid";
        //        else
        //            return "Invalid";
        //    }
        //    catch(Exception ex)
        //    {
        //        if(test.ExpectedException!=null) 
        //            return "Valid";
        //        else
        //            return "Invalid";
        //    }
        //}
        //static public string TestAddFirst(NodeTest test)
        //{
        //    try
        //    {
        //        var actual = AddFirstTest(test.Count, test.Value);
        //        if (actual == test.ExpectedValue)
        //            return "Valid";
        //        else
        //            return "Invalid";
        //    }
        //    catch (Exception ex)
        //    {
        //        if (test.ExpectedException != null)
        //            return "Valid";
        //        else
        //            return "Invalid";
        //    }
        //}
        //static public string TestFindNode(NodeTest test)
        //{
        //    try
        //    {
        //        var actual = FindNodeTest(test.Count, test.Value);
        //        if (actual == test.ExpectedValue)
        //            return "Valid";
        //        else
        //            return "Invalid";
        //    }
        //    catch (Exception ex)
        //    {
        //        if (test.ExpectedException != null)
        //            return "Valid";
        //        else
        //            return "Invalid";
        //    }
        //}
        //static public string TestAddNodeAfter(NodeTest test)
        //{
        //    try
        //    {
        //        var actual = AddNodeAfterTest(test.Count, test.Index,test.Value);
        //        if (actual == test.Value)
        //            return "Valid";
        //        else
        //            return "Invalid";
        //    }
        //    catch (Exception ex)
        //    {
        //        if (test.ExpectedException != null)
        //            return "Valid";
        //        else
        //            return "Invalid";
        //    }
        //}
        //static public string TestRemoveNode(NodeTest test)
        //{
        //    try
        //    {
        //        var actual = RemoveNodeTest(test.Count, test.Index);
        //        if (actual == test.ExpectedIndex)
        //            return "Valid";
        //        else
        //            return "Invalid";
        //    }
        //    catch (Exception ex)
        //    {
        //        if (test.ExpectedException != null)
        //            return "Valid";
        //        else
        //            return "Invalid";
        //    }
        //}
        static public void ShowResult(NodeTest test)
        {
            Console.WriteLine("Test Name:" + test.TestName + new string(' ', 3) + "Expected Result: " + test.ExpectedResult + new string(' ', 3) + "Actual Result: " + Test(test));
        }
        #endregion
    }
}
