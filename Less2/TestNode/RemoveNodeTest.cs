using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2.TestNode
{
    public class RemoveNodeTest:NodeTest
    {
        public RemoveNodeTest(string name) : base(name)
        {

        }
        static private int TryRemoveNode(int count, int index)
        {
            DoubleLinkedList linkedList = new DoubleLinkedList();
            var dls = (ITwoWayLinkedList)linkedList;
            for (int i = 0; i < count; i++)
            {
                dls.AddNode(i);
            }
            if (index == 0)
            {
                var temp = linkedList.Head.NextNode;
                dls.RemoveNode(index);
                if (linkedList.Head == temp)
                    return -1;
                else throw new AggregateException();
            }
            if (index == dls.GetCount() - 1)
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
        public override string Test(NodeTest test)
        {
            try
            {
                actual = TryRemoveNode(test.Count, test.Index);
                if (actual == test.ExpectedIndex)
                    return "Valid";
                else
                    return "Invalid";
            }
            catch (Exception ex)
            {
                if (test.ExpectedException != null)
                    return "Valid Ex";
                else
                    return "Invalid Ex";
            }
        }
    }
}
