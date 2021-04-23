using System;
using System.Collections.Generic;
using System.Text;

namespace Exescise_2_1
{
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    class LinkedList : ILinkedList
    {
        public LinkedList()
        {
            
        }

        public int GetCount()
        {
            return 7;
        }

        public void AddNode(int value)
        {

        }

        public void AddNodeAfter(Node node, int value)
        {

        }

        public void RemoveNode(int index)
        {

        }

        public void RemoveNode(Node node)
        {

        }

        public Node FindNode(int searchValue)
        {
            return new Node();
        }
    }
}
