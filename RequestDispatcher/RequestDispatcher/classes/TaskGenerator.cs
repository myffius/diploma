using System;
using System.Collections.Generic;
using RequestDispatcher.RdMath;

namespace RequestDispatcher
{
    public sealed class TaskGenerator
    {
        private ProbabilityDensityFunction _generator;

        public TaskGenerator(ProbabilityDensityFunction distribution)
        {
            _generator = distribution;
        }

        public List<Task> generate()
        {
            List<Task> tasks = new List<Task>();
            double max = _generator.Random() * 10;
            for (int i = 1; i <= max; i++)
            {
                tasks.Add(new RequestDispatcher.Task());
            }
            return tasks;
        }
    }
}
