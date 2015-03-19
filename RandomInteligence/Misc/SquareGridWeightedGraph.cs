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

        private readonly int[,] directions =
        {
            {1, 0},  // right
            {0, 1},  // down
            {-1, 0}, // left
            {0, -1}, // up

            //{1, -1}, // right up
            //{1, 1}, // right down
            //{-1, 1}, // left down
            //{-1, -1} // left up
        };

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
            return square[location.Y, location.X];
        }

        public IEnumerable<PointLocation> Neighbors(PointLocation location)
        {
            for (var i = 0; i < directions.GetLength(0); i++)
            {
                var point = new PointLocation(directions[i, 0] + location.X, directions[i, 1] + location.Y);

                if (point.X < 0 || point.X > lastX || point.Y < 0 || point.Y > lastY || Cost(point) <= 0)
                {
                    continue;
                }

                yield return point;
            }
        }
    }
}