using System;
using System.Collections.Generic;

public class TaskScheduler<TTask, TPriority> where TPriority : IComparable<TPriority>
{
    private SortedDictionary<TPriority, Queue<TTask>> taskQueue = new SortedDictionary<TPriority, Queue<TTask>>();
    public delegate void TaskExecution(TTask task);
    public void AddTask(TTask task, TPriority priority)
    {
        if (!taskQueue.ContainsKey(priority))
        {
            taskQueue[priority] = new Queue<TTask>();
        }
        taskQueue[priority].Enqueue(task);
    }
    public void ExecuteNext(TaskExecution execute)
    {
        if (taskQueue.Count == 0)
        {
            Console.WriteLine("Немає завдань для виконання.");
            return;
        }
        var highestPriority = taskQueue.Keys.Max();
        var task = taskQueue[highestPriority].Dequeue();
        if (taskQueue[highestPriority].Count == 0)
        {
            taskQueue.Remove(highestPriority);
        }
        execute(task);
    }
    public TTask GetFromPool(Func<TTask> initializer)
    {
        return initializer();
    }
    public void ReturnToPool(TTask task, Action<TTask> resetter)
    {
        resetter(task);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Данiїл Iванченко, КIб-1-23-4.0д");
        TaskScheduler<string, int> scheduler = new TaskScheduler<string, int>();
        Console.WriteLine("Введіть завдання (для завершення введення введіть 'exit'):");
        while (true)
        {
            Console.Write("Завдання: ");
            string task = Console.ReadLine();
            if (task.ToLower() == "exit")
                break;

            Console.Write("Пріоритет (число): ");
            if (int.TryParse(Console.ReadLine(), out int priority))
            {
                scheduler.AddTask(task, priority);
            }
            else
            {
                Console.WriteLine("Невірний формат пріоритету.");
            }
        }
        scheduler.ExecuteNext(task => Console.WriteLine($"Виконання завдання: {task}"));
    }
}
