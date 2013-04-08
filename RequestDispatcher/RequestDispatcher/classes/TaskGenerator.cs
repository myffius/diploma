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
            for (int i = 1; i <= _generator.Random(); i++)
            {
                tasks.Add(new RequestDispatcher.Task());
            }
            return tasks;
        }
    }
}
