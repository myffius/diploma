using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace RequestDispatcher
{
    abstract public class Dispatcher
    {
        protected List<TaskHandler> handlers = new List<TaskHandler>();
        protected List<Chart> charts = new List<Chart>();

        public void addHandler(TaskHandler handler, Chart ch)
        {
            handlers.Add(handler);
            charts.Add(ch);
        }

        public int getHandlerStatistic(int index)
        {
            return handlers[index].GetInfo();
        }

        abstract public void resolve(Task task);
    }
}
