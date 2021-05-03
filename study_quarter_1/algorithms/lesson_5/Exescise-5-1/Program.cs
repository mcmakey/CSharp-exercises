// Алгоритмы. Урок 1. Задание 1
// Реализуйте DFS и BFS для дерева с выводом каждого шага в консоль

using System;

namespace Exescise_5_1
{
    class Program
    {
        const int NUMBER_NODES = 7;
        static void Main(string[] args)
        {
            BynaryTree tree = new BynaryTree(NUMBER_NODES);

            // Отображение дерева
            tree.Display();

            Console.WriteLine();

            // Обход дерева в ширину
            tree.BreadthFirstSearch();

            Console.WriteLine();

            // Обход дерева в глубину
            tree.DeepFirstSearch();
        }
    }
}
