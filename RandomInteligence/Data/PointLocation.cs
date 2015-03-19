using System.Diagnostics;

namespace RandomInteligence.Data
{
    [DebuggerDisplay("{X},{Y}")]
    public struct PointLocation : ILocation
    {
        public int X;
        public int Y;

        public PointLocation(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", X, Y);
        }
    }
}