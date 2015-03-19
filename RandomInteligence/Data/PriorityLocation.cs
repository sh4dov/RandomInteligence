using Cerberus;

namespace RandomInteligence.Data
{
    internal class PriorityItem<T>
    {
        public PriorityItem(T item, int priority)
        {
            Guard.ArgumentIsNotNull(() => item);
            Item = item;
            Priority = priority;
        }

        public T Item { get; set; }

        public int Priority { get; set; }
    }
}