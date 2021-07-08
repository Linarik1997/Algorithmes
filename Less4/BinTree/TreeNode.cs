using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less4.BinTree
{
    public class TreeNode<T>:IComparable<T> where T : IComparable<T>
    {

        public TreeNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }
        public TreeNode<T> Parent { get; set; }

        //public int CompareTo(object other)
        //{
        //    if (other == null)
        //        return 1;
        //    var node = other as TreeNode<T>;
        //    return this.Value.CompareTo(node.Value);
        //}
        public static bool operator > (TreeNode<T> operand1, TreeNode<T> operand2)
        {
            return operand1.CompareTo(operand2) > 0;
        }
        public static bool operator >=(TreeNode<T> operand1, TreeNode<T> operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }
        public static bool operator <(TreeNode<T> operand1, TreeNode<T> operand2)
        {
            return operand1.CompareTo(operand2) < 0;
        }
        public static bool operator <=(TreeNode<T> operand1, TreeNode<T> operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode<T>;
            if (node == null)
                return false;
            return node.Value.Equals(Value);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(T other)
        {
            if (other == null)
                return 1;
            var node = other as TreeNode<T>;
            return this.Value.CompareTo(node.Value);
        }
    }
}
