using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less4.BinTree
{
    public enum NodePosition
    {
        Left,
        Right,
        Center
    }
    public class TreeNode<T>:IComparable<T> where T : IComparable<T>
    {

        public TreeNode(T value)
        {
            Value = value;
        }
        public TreeNode(T value, TreeNode<T> parent)
        {
            Value = value;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
        public T Value{ get; set; }
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }
        public TreeNode<T> Parent { get; set; }
        public void PrintTree(string indent, NodePosition nodePosition, bool last, bool empty)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "| ";
            }
            var stringValue = empty ? "-" : Value.ToString();
            PrintValue(stringValue, nodePosition);

            if (!empty && (this.LeftChild!=null || this.RightChild != null))
            {
                if (this.LeftChild != null)
                    this.LeftChild.PrintTree(indent, NodePosition.Left, false, false);
                else PrintTree(indent, NodePosition.Left, false, true);
                if (this.RightChild != null)
                    this.RightChild.PrintTree(indent, NodePosition.Right, true, false);
                else PrintTree(indent, NodePosition.Right, true, true);
            }

        }
        private void PrintLeftValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("L:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void PrintRightValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void PrintValue(string value, NodePosition nodePostion)
        {
            switch (nodePostion)
            {
                case NodePosition.Left:
                    PrintLeftValue(value);
                    break;
                case NodePosition.Right:
                    PrintRightValue(value);
                    break;
                case NodePosition.Center:
                    Console.WriteLine(value);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public int CompareTo(object other)
        {
            if (other == null)
                return 1;
            var node = other as TreeNode<T>;
            return this.Value.CompareTo(node.Value);
        }
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
            return this.Value.CompareTo(other);
        }
    }
}
