using System;
using RandomInteligence.Data;

namespace RandomInteligence.Algorithms
{
    public class PointLocationHeuristic : IHeuristic<PointLocation>
    {
        public int Calculate(PointLocation a, PointLocation b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }
}