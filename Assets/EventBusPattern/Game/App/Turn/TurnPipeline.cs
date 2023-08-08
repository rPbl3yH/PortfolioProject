using System;
using System.Collections.Generic;

namespace EventBusPattern
{
    public class TurnPipeline
    {
        public event Action OnFinished;

        private List<TurnTask> _tasks = new();

        private int _currentIndex = -1;
        
        public void Run()
        {
            _currentIndex = 0;
            RunNextTask();
        }

        private void RunNextTask()
        {
            if (_currentIndex >= _tasks.Count)
            {
                OnFinished?.Invoke();
                return;
            }

            _tasks[_currentIndex].Run(OnTaskFinished);
        }

        private void OnTaskFinished(TurnTask task)
        {
            _currentIndex++;
            RunNextTask();
        }
    }
}