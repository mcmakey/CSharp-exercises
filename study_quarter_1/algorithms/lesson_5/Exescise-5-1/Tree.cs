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
    }
}
