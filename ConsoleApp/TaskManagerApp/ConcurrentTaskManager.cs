using System;
using System.Threading;

public class ConcurrentTaskManager
{
    private readonly ITaskManager _taskManager;

    public ConcurrentTaskManager(ITaskManager taskManager)
    {
        _taskManager = taskManager;
    }

    public void AddTaskConcurrently(Task task)
    {
        Thread thread = new Thread(() => _taskManager.AddTask(task));
        thread.Start();
    }

    public void ModifyTaskConcurrently(int taskId, string newDescription, bool isCompleted)
    {
        Thread thread = new Thread(() => _taskManager.ModifyTask(taskId, newDescription, isCompleted));
        thread.Start();
    }

    public void DeleteTaskConcurrently(int taskId)
    {
        Thread thread = new Thread(() => _taskManager.DeleteTask(taskId));
        thread.Start();
    }
}
