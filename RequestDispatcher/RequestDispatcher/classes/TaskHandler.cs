using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

namespace RequestDispatcher
{
    public sealed class TaskHandler : IDisposable
    {
        private EventWaitHandle wh = new AutoResetEvent(false);
        private Thread worker;
        private object locker = new object();
        private Queue<RequestDispatcher.Task> tasks = new Queue<RequestDispatcher.Task>();

        private string identity;
        private int cpu;
        private int memory;

        public TaskHandler(string identity, int cpu, int memory)
        {
            this.identity = identity;
            this.cpu = cpu;
            this.memory = memory;

            worker = new Thread(proccess);
            worker.IsBackground = true;
            worker.Start();
        }

        public void EnqueueTask(RequestDispatcher.Task task)
        {
            lock (locker)
                tasks.Enqueue(task);

            wh.Set();
        }

        public void Dispose()
        {
            EnqueueTask(null);      // Сигнал Потребителю на завершение
            worker.Join();          // Ожидание завершения Потребителя
            wh.Close();             // Освобождение ресурсов
        }

        void proccess()
        { 
            while (true) 
            {
                RequestDispatcher.Task task = null;
                lock (locker)
                {
                    if (tasks.Count > 0) 
                    {
                        task = tasks.Dequeue();
                        if (task == null)
                            return;
                    }
                }

                if (task != null) 
                {
                    
                }
                else
                    wh.WaitOne();       // Больше задач нет, ждем сигнала...
            }
        }

        public int GetInfo()
        {
            return tasks.Count;
        }
    }
}
