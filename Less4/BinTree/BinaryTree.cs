using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less4.BinTree
{
    public class BinaryTree<T>: ITree<T> where T:IComparable<T>
    {
        public BinaryTree() { }
        public BinaryTree(T rootValue)
        {
            var root = new TreeNode<T>(rootValue, null);
            RootNode = root;
        }
        private TreeNode<T> RootNode { get; set; }
        private TreeNode<T> Search(TreeNode<T> Root, T Value)
        {
            if (Root == null || Value.Equals(Root.Value))
                return Root;
            if (Value.CompareTo(Root.Value) < 0)
                return Search(Root.LeftChild, Value);
            else return Search(Root.RightChild, Value);             
        }
        public void AddItem(T Value)
        {
            TreeNode<T> temp = null;
            if (RootNode == null)
            {
                TreeNode<T> root = new(Value, null);
                RootNode = root;
                return;
            }
            temp = RootNode;
            while (temp != null)
            {
                if (Value.CompareTo(temp.Value) > 0)
                {
                    if (temp.RightChild != null)
                    {
                        temp = temp.RightChild;
                        continue;
                    }
                    else
                    {
                        TreeNode<T> insert = new(Value, temp);
                        temp.RightChild = insert;
                        return;
                    }
                }
                else if (Value.CompareTo(temp.Value) < 0)
                {
                    if (temp.LeftChild != null)
                    {
                        temp = temp.LeftChild;
                        continue;
                    }
                    else
                    {
                        TreeNode<T> insert = new(Value, temp);
                        temp.LeftChild = insert;
                        return;
                    }
                }
                else throw new FormatException();
            }
        }

        public TreeNode<T> GetNodeByValue(T Value)
        {
            return Search(RootNode, Value);
        }

        public TreeNode<T> GetRoot()
        {
            return RootNode;
        }

        public void PrintTree(TreeNode<T>.TraversalOrder type, TreeNode<T> root, string indent = "")
        {
            if (root == null)
                return;
            switch (type)
            {

                case TreeNode<T>.TraversalOrder.inorder:
                    PrintTree(TreeNode<T>.TraversalOrder.preorder, root.RightChild, $"{indent}{new string(' ', 2)}");
                    Console.WriteLine($"{indent}{root.Value}");
                    PrintTree(TreeNode<T>.TraversalOrder.preorder, root.LeftChild, $"{indent}{new string(' ', 2)}");
                    return;
                case TreeNode<T>.TraversalOrder.preorder:
                    Console.WriteLine($"{indent}{root.Value}");
                    PrintTree(TreeNode<T>.TraversalOrder.preorder, root.LeftChild, $"{indent}{new string(' ', 2)}");
                    PrintTree(TreeNode<T>.TraversalOrder.preorder, root.RightChild, $"{indent}{new string(' ', 2)}");
                    break;
                case TreeNode<T>.TraversalOrder.postorder:
                    PrintTree(TreeNode<T>.TraversalOrder.preorder, root.LeftChild, $"{indent}{new string(' ', 2)}");
                    PrintTree(TreeNode<T>.TraversalOrder.preorder, root.RightChild, $"{indent}{new string(' ', 2)}");
                    Console.WriteLine($"{indent}{root.Value}");
                    return;
                default:
                    return;
            }
        }

        public void RemoveItem(T Value)
        {
            throw new NotImplementedException();
        }

        public void PrintTree(TreeNode<T>.TraversalOrder type)
        {
            PrintTree(type, RootNode,"");
        }
    }
}
