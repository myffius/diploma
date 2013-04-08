using System;
using System.Collections;

namespace RequestDispatcher
{
    public class QueueDispatcher : Dispatcher
    {
        private int currentHandlerIndex = 0;

        public override void resolve(Task task)
        {
            TaskHandler handler = handlers.Item[currentHandlerIndex];
        }
    }
}
