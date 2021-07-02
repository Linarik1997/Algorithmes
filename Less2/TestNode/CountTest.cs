using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2.TestNode
{
    public class CountTest: NodeTest
    {
        public CountTest(string name): base(name)
        {

        }
        static private int TryLinkedListCount(int count, int pops)
        {
            DoubleLinkedList linkedList = new DoubleLinkedList();
            var dls = (ITwoWayLinkedList)linkedList;
            for (int i = 0; i < count; i++)
            {
                dls.AddNode(i);
            }
            for (int i = 0; i < pops; i++)
            {
                dls.RemoveNode(i);
            }
            return dls.GetCount();
        }
        public override string Test()
        {
            try
            {
                actual = TryLinkedListCount(Count, Pops);
                if (actual == ExpectedCount)
                    return "Valid";
                else
                    return "Invalid";
            }
            catch(Exception ex)
            {
                if (ExpectedException != null)
                    return "Valid Ex";
                else
                    return "Invalid Ex";
            }
        }
    }
}
