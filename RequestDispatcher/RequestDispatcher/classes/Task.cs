using System;

namespace RequestDispatcher
{
    public sealed class Task
    {
        private int _executionTime;
        private int _cpu;
        private int _memory;

        public void proccess()
        { 
            
        }
        
        public int getMemory
        {
            get { return _memory;}
        }

        public int CPU
        {
            get { return _cpu;}
        }

        public int Time
        {
            get { return _executionTime; }
        }
    }
}
