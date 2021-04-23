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
        // Верхний ограничитель
        private Node _top { get; }

        // ВНижний ограничитель
        private Node _low { get; }

        public LinkedList()
        {
            this._top = new Node();
            _top.NextNode = this._low;
            _top.PrevNode = null;

            this._low = new Node();
            _low.NextNode = null;
            _low.PrevNode = _top;

        }

        public int GetCount()
        {
            return 7;
        }

        public void AddNode(int value)
        {
            var node = _top;

            // нахождение последней ячейки
            while (node.NextNode != null)
            {
                node = node.NextNode;
            }

            // Создание новой ячейки
            var newNode = new Node { Value = value };

            // Ссылка на новою ячейку "сверху"
            node.NextNode = newNode;

            // Ссылка на новую ячейку с нижнего ограничителя
            _low.PrevNode = newNode;
            
            // Ссылки новой ячейки    
            newNode.NextNode = _low;
            newNode.PrevNode = node;
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
