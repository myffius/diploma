using System;
using System.Collections;

namespace RequestDispatcher
{
    public class QueueDispatcher : Dispatcher
    {
        private int currentHandlerIndex = 0;

        public override void resolve(Task task)
        {
            TaskHandler handler = handlers[currentHandlerIndex];
            currentHandlerIndex++;
            if (currentHandlerIndex > handlers.Count - 1)
                currentHandlerIndex = 0;
        }
    }
}
