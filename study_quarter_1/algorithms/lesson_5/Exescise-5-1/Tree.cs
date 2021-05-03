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
    }
}
