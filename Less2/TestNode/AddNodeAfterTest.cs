using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2.TestNode
{
    public class AddNodeAfterTest:NodeTest
    {
        public AddNodeAfterTest(string name) : base(name)
        {

        }
        static private int TryAddNodeAfter(int count, int index, int value)
        {
            DoubleLinkedList linkedList = new DoubleLinkedList();
            var dls = (ITwoWayLinkedList)linkedList;
            for (int i = 0; i < count; i++)
            {
                dls.AddNode(i);
            }
            var node = dls.FindNode(index);
            dls.AddNodeAfter(node, value);

            if (index == count - 1)
            {
                var isTail = linkedList.Tail == node.NextNode ? true : false;
                if (isTail)
                    return linkedList.Tail.Value;
                else
                    throw new AggregateException();
            }
            return node.NextNode.Value;
        }
        public override string Test()
        {
            try
            {
                actual = TryAddNodeAfter(Count, Index,Value);
                if (actual == Value)
                    return "Valid";
                else
                    return "Invalid";
            }
            catch (Exception ex)
            {
                if (ExpectedException != null)
                    return "Valid Ex";
                else
                    return "Invalid Ex";
            }
        }
    }
}
