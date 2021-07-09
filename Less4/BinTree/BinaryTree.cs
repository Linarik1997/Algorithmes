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
        public TreeNode<T> Minimum
        {
            get { return Min(RootNode); }
        }
        public TreeNode<T> Maximum
        {
            get { return Max(RootNode); }
        }
        private TreeNode<T> Min(TreeNode<T> root)
        {
            if (root.LeftChild == null)
                return root;
            return Min(root.LeftChild);
        }
        private TreeNode<T> Max (TreeNode<T> root)
        {
            if (root.RightChild == null)
                return root;
            return Max(root.RightChild);
        }
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
                else return;
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
        public void RemoveItem(T Value)
        {
            RemoveItem(RootNode, Value);
            return;
        }
        private TreeNode<T> RemoveItem(TreeNode<T> root, T Value)
        {
            if (root == null)
                return root;
            if (Value.CompareTo(root.Value) < 0)
                root.LeftChild = RemoveItem(root.LeftChild, Value);
            else if (Value.CompareTo(root.Value) > 0)
                root.RightChild = RemoveItem(root.RightChild, Value);
            else if(root.RightChild!=null && root.LeftChild != null)
            {
                root.Value = Min(root.RightChild).Value;
                root.RightChild = RemoveItem(root.RightChild, root.Value);
            }
            else
            {
                if (root.LeftChild != null)
                    root = root.LeftChild;
                else if (root.RightChild != null)
                    root = root.RightChild;
                else
                    root = null;
            }
            return root;
        }
        public void PrintTree()
        {
            RootNode.PrintTree("", NodePosition.Center, true, false);
        }
    }
}
