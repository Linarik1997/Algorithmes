using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less4.BinTree
{
    public interface ITree<T> where T: IComparable<T>
    {
        TreeNode<T> GetRoot(); //Получить корень
        void AddItem(T Value); //Добавить узел
        void RemoveItem(T Value); //Убрать Узел
        TreeNode<T> GetNodeByValue(T Value);//Получить узел дерева по значению
        void PrintTree(TreeNode<T>.TraversalOrder type);//Вывсти дерево в консоль
    }
}
