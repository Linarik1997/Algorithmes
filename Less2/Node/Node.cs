using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        #region Fields
        /// <summary>
        /// Значение Ноды
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// Ссылка на следующую ноду
        /// </summary>
        public Node NextNode { get; set; }
        /// <summary>
        /// Ссылка на предыдущую ноду
        /// </summary>
        public Node PrevNode { get; set; }

        #endregion
    }
    public class DoubleLinkedList: ITwoWayLinkedList
    {

        #region Fileds
        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Головной элемент
        /// </summary>
        public Node Head { get; set; }
        /// <summary>
        /// Хвостовой элемент
        /// </summary>
        public Node Tail { get; set; }
        #endregion

        #region Private Methdos
        private void RemoveFirst()
        {
            if (Head == null)
                throw new InvalidOperationException();
            if (Count == 0)
                throw new ArgumentOutOfRangeException();
            else
            {
                var temp = Head;
                if (Head.NextNode != null)
                {
                    Head.NextNode.PrevNode = null;
                }
                Head = Head.NextNode;
                Count--;
            }
        }
        private void RemoveLast()
        {
            if (Tail == null)
                throw new InvalidOperationException();
            if (Count == 0)
                throw new ArgumentOutOfRangeException();
            else
            {
                var temp = Tail;
                if (Tail.PrevNode != null)
                {
                    Tail.PrevNode.NextNode = null;
                }
                Tail = Tail.PrevNode;
                Count--;
            }
        }
        #endregion

        #region Interface Realisation
        void ITwoWayLinkedList.AddFirst(int value)
        {
            Node newNode = new Node(value);
            var temp = Head;
            newNode.NextNode = temp;
            Head = newNode;
            if (Count == 0)
                Tail = Head;
            else
                temp.PrevNode = newNode;
            Count++;
        }

        int ITwoWayLinkedList.GetCount()
        {
            return Count;
        }
        void ITwoWayLinkedList.AddNode(int value)
        {
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Tail.NextNode = newNode;
                newNode.PrevNode = Tail;
            }
            Count++;
            Tail = newNode;
        }
        void ITwoWayLinkedList.AddNodeAfter(Node afterNode, int value)
        {
            if(afterNode == null)
            {
                throw new ArgumentException();
            }
            Node newNode = new Node(value);
            if (Tail == afterNode)
            {
                Tail.NextNode = newNode;
                newNode.PrevNode = Tail;
                Tail = newNode;
            }
            else
            {
                //Связываем новую ноду со следующей нодой
                var nextTemp = afterNode.NextNode;
                afterNode.NextNode.PrevNode = newNode;
                newNode.NextNode = nextTemp;
                //Связываем новую ноду с предыдущей
                afterNode.NextNode = newNode;
                newNode.PrevNode = afterNode;               
            }
            Count++;
        }

        void ITwoWayLinkedList.RemoveNode(Node node)
        {
            if (Count == 0)
                throw new ArgumentOutOfRangeException();
            if(Count == 1)
            {
                node.NextNode = null;
                node.PrevNode = null;
                Head = null;
                Tail = null;
                Count--;
                return;
            }
            if(node == Head)
            {
                RemoveFirst();
                return;
            }
            if (node == Tail)
            {
                RemoveLast();
                return;
            }
            else
            {
                node.NextNode.PrevNode = node.PrevNode;
                node.PrevNode.NextNode = node.NextNode;
                Count--;
            }
        }
        void ITwoWayLinkedList.RemoveNode(int index)
        {
            if (index < 0 || index > Count-1)
                throw new ArgumentOutOfRangeException();
            if (index == 0)
            {
                RemoveFirst();
                return;
            }
            if (index == Count - 1)
            {
                RemoveLast();
                return;
            }
            else
            {
                int i = 0;
                var currentNode = Head;
                while (currentNode != null)
                {
                    if(i == index)
                    {
                        currentNode.NextNode.PrevNode = currentNode.PrevNode;
                        currentNode.PrevNode.NextNode = currentNode.NextNode;
                        Count--;
                    }
                    currentNode = currentNode.NextNode;
                    i++;
                }
            }                
        }
        Node ITwoWayLinkedList.FindNode(int searchValue)
        {
            var current = Head;
            while(current!= null)
            {
                if (current.Value == searchValue)
                    return current;
                current = current.NextNode;
            }
            return null;
        }
        string ITwoWayLinkedList.Display()
        {
            var current = Head;
            StringBuilder sb = new StringBuilder();
            while (current != null)
            {
                sb.Append(current.Value.ToString() + " ");
                current = current.NextNode;
            }
            return sb.ToString();
        }
        string ITwoWayLinkedList.ReverseDisplay()
        {
            var current = Tail;
            StringBuilder sb = new StringBuilder();
            while (current != null)
            {
                sb.Append(current.Value.ToString() + " ");
                current = current.PrevNode;
            }
            return sb.ToString();
        }
        #endregion
    }
}
