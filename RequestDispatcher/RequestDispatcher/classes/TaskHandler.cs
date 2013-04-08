using System;
using System.Collections;

namespace RequestDispatcher
{
    public sealed class TaskHandler
    {
        private Queue queueHandlers = new Queue();

        public void newTask(Task task)
        {
            queueHandlers.Enqueue(task);
        }
    }
}
