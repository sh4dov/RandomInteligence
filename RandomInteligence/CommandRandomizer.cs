using System;
using System.Collections.Generic;
using System.Linq;
using Cerberus;
using RandomInteligence.Commands;

namespace RandomInteligence
{
    public class CommandRandomizer
    {
        private readonly List<CommandInterval> commands;
        private readonly int maxInterval;
        private readonly Random random;

        public CommandRandomizer(Command[] commands, int? seed = null)
        {
            Guard.CollectionIsNotNullOrEmpty(() => commands);
            var interval = 0;
            this.commands = commands.Select(c =>
            {
                var start = interval;
                var end = interval + c.Priority - 1;
                interval = end + 1;
                return new CommandInterval(c, start, end);
            }).ToList();
            maxInterval = interval;
            random = seed.HasValue ? new Random(seed.Value) : new Random();
        }

        public Command GetRandom()
        {
            var interval = random.Next() % maxInterval;
            return commands.First(c => c.IsInInterval(interval)).Command;
        }

        private class CommandInterval
        {
            private readonly int end;
            private readonly int start;

            public CommandInterval(Command command, int start, int end)
            {
                this.start = start;
                this.end = end;
                Command = command;
            }

            public Command Command { get; set; }

            public bool IsInInterval(int value)
            {
                return start >= value && value <= end;
            }
        }
    }
}