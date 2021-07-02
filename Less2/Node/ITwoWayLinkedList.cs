using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2
{
    public interface ITwoWayLinkedList
    {
        int GetCount();// возвращает количество элементов в списке
        void AddFirst(int value);//добавляет новый элемент списка в начало
        void AddNode(int value); // добавляет новый элемент списка в конец
        void AddNodeAfter(Node afterNode, int value); // добавляет новый элемент списка после определённого элемента

        void RemoveNode(int index); // удаляет элемент по порядковому номеру

        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
        string Display(); //отображение списка в порядке
        string ReverseDisplay();//отображение списка в обратном порядке
    }
}
