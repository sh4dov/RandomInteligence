using System.Collections.Generic;

namespace RandomInteligence.Data
{
    internal class PriorityComparer<T> : IComparer<PriorityItem<T>>
    {
        public int Compare(PriorityItem<T> x, PriorityItem<T> y)
        {
            return x.Priority.CompareTo(y.Priority);
        }
    }
}