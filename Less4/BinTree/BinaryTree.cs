using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less4.BinTree
{
    public class BinaryTree<T>: ITree<T> where T:IComparable<T>
    {
        public TreeNode<T> RootNode { get; set; }
        private TreeNode<T> getFreeNode(T Value, TreeNode<T> parent)
        {
            TreeNode<T> tNode = new(Value);
            var current = parent;
            if (RootNode == null)
            {
                tNode.Parent = null;
                RootNode = tNode;
                return tNode;
            }
            if (Value == null || Value.Equals(RootNode.Value))
            {
                return null;
            }
            if (Value.CompareTo(current.Value) < 0)
            {
                return current.LeftChild;
            }
            else if (Value.CompareTo(current.Value) > 0)
            {
                return current.RightChild;
            }
            return parent;
        }
        public void AddItem(T Value)
        {
            TreeNode<T> tNode = new(Value); 
            if(RootNode == null)
            {
                tNode.Parent = null;
                RootNode = tNode;
                return;
            }
            if(Value == null || Value.Equals(RootNode.Value))
            {
                return;
            }
            if (tNode < RootNode)
            {

            }
            throw new NotImplementedException();
        }

        public TreeNode<T> GetNodeByValue(T Value)
        {
            throw new NotImplementedException();
        }

        public TreeNode<T> GetRoot()
        {
            throw new NotImplementedException();
        }

        public void PrintTree()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(T Value)
        {
            throw new NotImplementedException();
        }
    }
}
