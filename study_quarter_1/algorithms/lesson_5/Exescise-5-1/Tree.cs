using System;
using System.Collections.Generic;
using System.Text;

namespace Exescise_5_1
{
    class BynaryTree
    {
        private Node _root;

        public BynaryTree(int n)
        {
            fill(n);
        }

        // Заполнение дерева с n узлами со значениями от 1 до 9
        private Node fill (int n)
        {
            Node newNode = null;
            if (n == 0)
                return null;
            else
            {
                var nl = n / 2;
                var nr = n - nl - 1;
                newNode = new Node();

                if(_root == null)
                {
                    _root = newNode;
                }

                newNode.Data = new Random().Next(1, 9);
                newNode.Left = fill(nl);
                newNode.Right = fill(nr);
            }

            return newNode;
        }

        // Рекурсивный обход дерева
        private void PreOrderTravers(Node root)
        {
            if (root != null)
            {
                Console.Write($"{root.Data}");
                if (root.Left != null || root.Right != null)
                {
                    Console.Write("(");

                    if (root.Left != null)
                    {
                        PreOrderTravers(root.Left);
                    }
                    else
                    {
                        Console.Write("_");
                    }

                    Console.Write(",");

                    if (root.Right != null)
                    {
                        PreOrderTravers(root.Right);
                    }
                    else
                    {
                        Console.Write("_");
                    }

                    Console.Write(")");
                }
            }
        }

        // Отображение дерева
        public void Display()
        {
            PreOrderTravers(_root);
        }

        // Обход дерева в ширину
        public void BreadthFirstSearch()
        {
            Queue<Node> consideredNodes = new Queue<Node>();

            consideredNodes.Enqueue(_root);

            while (consideredNodes.Count != 0)
            {
                var currentNode = consideredNodes.Dequeue();
                Console.Write($"{currentNode.Data}, ");
                if (currentNode.Left != null)
                {
                    consideredNodes.Enqueue(currentNode.Left);
                }
                if (currentNode.Right != null)
                {
                    consideredNodes.Enqueue(currentNode.Right);
                }
            }
        }

        // Обход дерева в глубину
        public void DeepFirstSearch()
        {
            Stack<Node> consideredNodes = new Stack<Node>();

            consideredNodes.Push(_root);

            while (consideredNodes.Count != 0)
            {
                var currentNode = consideredNodes.Pop();
                Console.Write($"{currentNode.Data}, ");

                if (currentNode.Right != null)
                {
                    consideredNodes.Push(currentNode.Right);
                }
                if (currentNode.Left != null)
                {
                    consideredNodes.Push(currentNode.Left);
                }
            }
        }
    }
}
