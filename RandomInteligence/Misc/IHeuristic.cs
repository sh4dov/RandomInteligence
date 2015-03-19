using RandomInteligence.Data;

namespace RandomInteligence.Algorithms
{
    public interface IHeuristic<in T> where T : ILocation
    {
        int Calculate(T a, T b);
    }
}