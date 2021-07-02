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
    public abstract class NodeTest
    {
        #region fields
        internal string TestName { get; set; }
        internal string ExpectedResult { get; set; }
        internal int Count { get; set; }
        internal int Pops { get; set; }
        internal int Value { get; set; }
        internal int Index { get; set; }
        internal int ExpectedValue { get; set; }
        internal int ExpectedIndex { get; set; }
        internal int ExpectedCount
        {
            get { return Count - Pops; }
        }
        internal int actual { get; set; }
        public NodeTest(string name)
        {
            this.TestName = name;
        }
        public Exception ExpectedException { get; set; }
        #endregion
        #region Public Methods
        public abstract string Test();
        static public void ShowResult(NodeTest test)
        {
            Console.WriteLine("Test Name:" + test.TestName + new string(' ', 3) + "Expected Result: " + test.ExpectedResult + new string(' ', 3) + "Actual Result: " + test.Test());
        }
        #endregion
    }
}
