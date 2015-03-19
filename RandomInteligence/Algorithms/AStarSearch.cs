using System.Collections.Generic;
using System.Linq;
using C5;
using Cerberus;
using RandomInteligence.Data;
using RandomInteligence.Misc;

namespace RandomInteligence.Algorithms
{
    public class AStarSearch<T> where T : ILocation
    {
        private readonly IWeightedGraph<T> graph;
        private readonly T start;
        private readonly T goal;
        private readonly IHeuristic<T> heuristic;
        private readonly IEqualityComparer<T> comparer;
        public readonly Dictionary<T, T> cameFrom = new Dictionary<T, T>();
        public readonly Dictionary<T, int> costSoFar = new Dictionary<T, int>();

        public AStarSearch(IWeightedGraph<T> graph, T start, T goal, IHeuristic<T> heuristic, IEqualityComparer<T> comparer = null)
        {
            Guard.ArgumentIsNotNull(() => graph);
            Guard.ArgumentIsNotNull(() => start);
            Guard.ArgumentIsNotNull(() => goal);
            Guard.ArgumentIsNotNull(() => heuristic);
            Guard.ArgumentIsNotNull(() => comparer);
            this.graph = graph;
            this.start = start;
            this.goal = goal;
            this.heuristic = heuristic;
            this.comparer = comparer ?? System.Collections.Generic.EqualityComparer<T>.Default;
        }

        public void Search()
        {
            var frontier = new IntervalHeap<PriorityItem<T>>(new PriorityComparer<T>());
            frontier.Add(new PriorityItem<T>(start, 0));

            cameFrom.Add(start, start);
            costSoFar.Add(start, 0);

            while (frontier.Any())
            {
                var current = frontier.DeleteMin();
                if (comparer.Equals(current.Item, goal))
                {
                    break;
                }

                foreach (var next in graph.Neighbors(current.Item))
                {
                    var newCost = costSoFar[current.Item] + graph.Cost(next);
                    if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                    {
                        costSoFar[next] = newCost;
                        var priority = newCost + heuristic.Calculate(next, goal);
                        frontier.Add(new PriorityItem<T>(next, priority));
                        cameFrom[next] = current.Item;
                    }
                }
            }
        }
    }
}