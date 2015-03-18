using System;
using RandomInteligence;
using RandomInteligence.Commands;

namespace Sandbox
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var world = new[,]
            {
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 1}
            };

            while (true)
            {
                var commandRandomizer = new CommandRandomizer(new Command[] { new CommandLeft(world), new CommandRight(world), new CommandUp(world), new CommandDown(world) });

                CommandMove cmd;
                long steps = 0;
                do
                {
                    cmd = (CommandMove)commandRandomizer.GetRandom();
                    cmd.Move();
                    steps++;
                } while (!cmd.Found());
                Console.WriteLine("Found way in {0} steps", steps);
            }
        }
    }

    internal abstract class CommandMove : Command
    {
        private readonly int[,] world;
        protected int x, y;
        protected int maxX;
        protected int maxY;

        public CommandMove(int[,] world)
        {
            this.world = world;
            maxX = world.GetLength(0) - 1;
            maxY = world.GetLength(1) - 1;
        }

        public abstract void Move();

        public bool Found()
        {
            return world[x, y] == 1;
        }
    }

    internal class CommandLeft : CommandMove
    {
        public CommandLeft(int[,] world)
            : base(world)
        {
        }

        public override void Move()
        {
            if (x > 1)
            {
                x--;
            }
        }
    }

    internal class CommandRight : CommandMove
    {
        public CommandRight(int[,] world)
            : base(world)
        {
        }

        public override void Move()
        {
            if (x < maxX)
            {
                x++;
            }
        }
    }

    internal class CommandUp : CommandMove
    {
        public CommandUp(int[,] world)
            : base(world)
        {
        }

        public override void Move()
        {
            if (y > 1)
            {
                y--;
            }
        }
    }

    internal class CommandDown : CommandMove
    {
        public CommandDown(int[,] world)
            : base(world)
        {
        }

        public override void Move()
        {
            if (y < maxY)
            {
                y++;
            }
        }
    }
}