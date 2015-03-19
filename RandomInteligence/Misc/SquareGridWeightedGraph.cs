using System.Collections.Generic;
using Cerberus;
using RandomInteligence.Data;

namespace RandomInteligence.Misc
{
    public class SquareGridWeightedGraph : IWeightedGraph<PointLocation>
    {
        private readonly int[,] square;
        private readonly int lastX;
        private readonly int lastY;

        public SquareGridWeightedGraph(int[,] square)
        {
            Guard.ArgumentIsNotNull(() => square);
            Guard.ArgumentMeetCondition(() => square.Rank == 2);
            this.square = square;
            lastX = square.GetLength(0) - 1;
            lastY = square.GetLength(0) - 1;
        }

        public int Cost(PointLocation location)
        {
            return square[location.X, location.X];
        }

        public IEnumerable<PointLocation> Neighbors(PointLocation location)
        {
            if (location.X < lastX)
            {
                yield return new PointLocation { X = location.X + 1, Y = location.Y };
            }

            if (location.X < lastX && location.Y < lastY)
            {
                yield return new PointLocation { X = location.X + 1, Y = location.Y + 1 };
            }

            if (location.Y < lastY)
            {
                yield return new PointLocation { X = location.X, Y = location.Y + 1 };
            }

            if (location.X > 0 && location.Y < lastY)
            {
                yield return new PointLocation { X = location.X - 1, Y = location.Y + 1 };
            }

            if (location.X > 0)
            {
                yield return new PointLocation { X = location.X - 1, Y = location.Y };
            }

            if (location.X > 0 && location.Y > 0)
            {
                yield return new PointLocation { X = location.X - 1, Y = location.Y - 1 };
            }

            if (location.Y > 0)
            {
                yield return new PointLocation { X = location.X, Y = location.Y - 1 };
            }

            if (location.X < lastX && location.Y > 0)
            {
                yield return new PointLocation { X = location.X + 1, Y = location.Y - 1 };
            }
        }
    }
}