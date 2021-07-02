using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2.TestNode
{
    public class FindNodeTest:NodeTest
    {
        public FindNodeTest(string name) : base(name)
        {

        }
        static private int TryFindNodeTest(int count, int value)
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
        public override string Test()
        {
            try
            {
                actual = TryFindNodeTest(Count, Value);
                if (actual == ExpectedValue)
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
