using System;
using RandomInteligence.Algorithms;
using RandomInteligence.Data;
using RandomInteligence.Misc;

namespace Sandbox
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var world = new[,]
            {
                {1, 0, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
            };

            var start = new PointLocation { X = 0, Y = 0 };
            var goal = new PointLocation { X = 9, Y = 9 };
            var equalityComparer = new PointLocationEqualityComparer();
            var search = new AStarSearch<PointLocation>(
                new SquareGridWeightedGraph(world),
                start,
                goal,
                new PointLocationHeuristic(),
                equalityComparer);

            search.Search();

            Console.Clear();
            //foreach (var location in search.costSoFar)
            //{
            //    Console.SetCursorPosition(location.Key.X * 3, location.Key.Y * 3);
            //    Console.Write(" " + location.Value);
            //}

            var l = search.costSoFar.ContainsKey(goal) ? goal : start;
            while (!equalityComparer.Equals(l, start))
            {
                Console.SetCursorPosition(l.X, l.Y);
                Console.Write("*");
                l = search.cameFrom[l];
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(start.X, start.Y);
            Console.Write("S");
            Console.SetCursorPosition(goal.X, goal.Y);
            Console.Write("X");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ReadLine();
        }
    }
}