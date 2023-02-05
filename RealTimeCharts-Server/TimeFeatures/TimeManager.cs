﻿namespace RealTimeCharts_Server.TimeFeatures
{
    public class TimeManager
    {
        private Timer _timer { get; set; }
        private AutoResetEvent _autoResetEvent { get; set; }
        private Action _action { get; set; }

        public  DateTime TimerStarted { get; set; }

        public TimeManager(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 1000, 2000);
            TimerStarted = DateTime.Now;
        }

        public void Execute(object stateInfo)
        {
            _action();
            if((DateTime.Now - TimerStarted).Seconds > 60)
            {
                _timer.Dispose();
            }
        }
    }
}
