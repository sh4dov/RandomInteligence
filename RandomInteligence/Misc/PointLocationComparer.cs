using System.Collections.Generic;
using RandomInteligence.Data;

namespace RandomInteligence.Misc
{
    public class PointLocationEqualityComparer : IEqualityComparer<PointLocation>
    {
        public bool Equals(PointLocation x, PointLocation y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode(PointLocation obj)
        {
            unchecked
            {
                return (obj.X * 397) ^ obj.Y;
            }
        }
    }
}