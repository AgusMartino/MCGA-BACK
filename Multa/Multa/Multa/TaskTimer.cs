using System;
using System.Threading;

namespace Multa
{
    internal class TaskTimer
    {
        Action Action;
        int Delay_ms;
        int? Iterations = null;
        int Iterations_Count = 0;
        System.Timers.Timer timer = null;
        Thread taskForBeforeDelay = null;
        public TaskTimer(Action action, int delay_ms)
        {
            Action = action;
            Delay_ms = delay_ms;
        }
        public TaskTimer(Action action, int delay_ms, int iterations)
        {
            Action = action;
            Delay_ms = delay_ms;
            Iterations = iterations;
        }
        public void Start(bool start_after_delay = false)
        {
            Stop();

            if (Iterations != null)
                Iterations_Count = 0;

            if (!start_after_delay)
            {
                taskForBeforeDelay = new Thread(
                    new ThreadStart(delegate
                    {
                        Exec_Action(null, null);
                    }));
                taskForBeforeDelay.Start();
            }

            timer = new System.Timers.Timer();
            timer.Elapsed += Exec_Action;
            timer.Interval = Delay_ms;
            timer.Start();

            //timer = new System.Threading.Timer(e => Action.Invoke(),null,0,Delay_ms);
        }
        public void Stop()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Elapsed -= Exec_Action;
                timer.Dispose();
                timer = null;
            }
            if (taskForBeforeDelay != null)
            {
                taskForBeforeDelay.Abort();
                taskForBeforeDelay = null;
            }
        }
        [Obsolete("Método aún no desarrollado")]
        public void Wait(int delay_ms)
        {
            throw new NotImplementedException();
        }
        public void Change(Action action, int delay_ms, int? iterations = null)
        {
            Stop();
            this.Action = action;
            this.Delay_ms = delay_ms;
            this.Iterations = iterations;
        }
        void Exec_Action(object source, System.Timers.ElapsedEventArgs e)
        {
            if (Iterations == null || Iterations_Count < Iterations)
            {
                Iterations_Count++;
                Action.Invoke();
            }
            else
                this.Stop();
        }
    }
}
