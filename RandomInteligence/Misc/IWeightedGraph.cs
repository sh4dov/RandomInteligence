using System.Collections.Generic;
using RandomInteligence.Data;

namespace RandomInteligence.Misc
{
    public interface IWeightedGraph<T> where T : ILocation
    {
        int Cost(T location);

        IEnumerable<T> Neighbors(T location);
    }
}