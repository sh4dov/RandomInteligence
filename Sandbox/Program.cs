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
            AStarTest();
        }

        private static void AStarTest()
        {
            // x > 0 - dificulty (moving throught 2 is two times more expensive than moving by 1 etc.)
            // x <= 0 - cannot pass (wall)
            var world = new[,]
            {
                {1, 3, 1, 1, 0, 1, 0, 1, 1, 1},
                {2, 1, 1, 1, 0, 1, 0, 1, 0, 1},
                {1, 1, 1, 1, 0, 1, 0, 1, 0, 1},
                {1, 1, 1, 1, 0, 1, 0, 1, 0, 1},
                {1, 1, 1, 1, 0, 1, 1, 1, 0, 1},
                {1, 1, 1, 1, 0, 1, 0, 1, 0, 1},
                {1, 1, 1, 1, 0, 1, 0, 1, 0, 1},
                {1, 1, 1, 1, 0, 1, 0, 1, 0, 1},
                {1, 1, 1, 1, 0, 1, 0, 1, 0, 1},
                {1, 1, 1, 1, 1, 1, 0, 1, 0, 1}
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

            var path = search.Search();

            Console.Clear();
            foreach (var l in path)
            {
                Console.SetCursorPosition(l.X, l.Y);
                Console.Write("*");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(start.X, start.Y);
            Console.Write("S");
            Console.SetCursorPosition(goal.X, goal.Y);
            Console.Write("X");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, world.GetLength(0) + 1);
            Console.WriteLine("Number of used points: {0}", path.Count);
        }
    }
}