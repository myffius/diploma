using System;
using System.Collections;

namespace RequestDispatcher
{
    abstract public class Dispatcher
    {
        protected ArrayList handlers;

        public void addHandler(TaskHandler handler)
        {
            
        }

        abstract public void resolve(Task task)
        { 
        }
    }
}
