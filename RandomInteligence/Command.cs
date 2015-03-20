using Cerberus;

namespace RandomInteligence.Commands
{
    public abstract class Command
    {
        private int priority = 1;

        public int Priority
        {
            get { return priority; }
            set
            {
                Guard.ArgumentMeetCondition(() => value > 0);
                priority = value;
            }
        }
    }
}