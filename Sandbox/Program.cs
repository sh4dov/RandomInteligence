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
                {1, 1, 1, 1, 5, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {5, 1, 1, 1, 1, 1, 1, 1, 1, 1},
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
            foreach (var location in search.costSoFar)
            {
                Console.SetCursorPosition(location.Key.X * 3, location.Key.Y * 3);
                Console.Write(" " + location.Value);
            }

            var l = goal;
            do
            {
                Console.SetCursorPosition(l.X, l.Y);
                Console.Write("X");
                l = search.cameFrom[l];
            } while (!equalityComparer.Equals(l, start));

            Console.ReadLine();
        }
    }
}