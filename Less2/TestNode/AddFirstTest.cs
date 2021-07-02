using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2.TestNode
{
    public class AddFirstTest:NodeTest
    {
        public AddFirstTest(string name): base(name)
        {

        }
        static private int TryAddFirst(int count, int value)
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
        public override string Test()
        {
            try
            {
                actual = TryAddFirst(Count, Value);
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
