using System;
using System.Threading;

class TaskScheduler
{
    private Timer timer;
    private int taskCounter;

    public TaskScheduler(int initialDelay, int interval)
    {
        timer = new Timer(ExecuteTask, null, initialDelay, interval);
        taskCounter = 0;
    }

    private void ExecuteTask(object state)
    {
        int result = PerformCalculation(3, 5);

        Console.WriteLine($" {taskCounter++}  {DateTime.Now}.  {result}");

        TaskExecuted?.Invoke(this, EventArgs.Empty);
    }
    private int PerformCalculation(EventHandler TaskExecuted)
    {
        return TaskExecuted;
    }
    public void StopScheduler()
    {
        timer.Change(Timeout.Infinite, Timeout.Infinite);
    }
    public event EventHandler TaskExecuted;
    static void More()
    {
        TaskScheduler taskScheduler = new TaskScheduler(1000, 2000);
        taskScheduler.TaskExecuted += TaskScheduler_TaskExecuted;
        Thread.Sleep(10000);
        taskScheduler.StopScheduler();
    }
    private static void TaskScheduler_TaskExecuted(object sender, EventArgs e)
    {
        Console.WriteLine("NICE!");
    }
}
