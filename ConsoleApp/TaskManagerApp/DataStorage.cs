using System.Collections.Generic;
using System.Linq;

public class DataStorage : IDataStorage
{
    private List<Task> _tasks = new List<Task>();

    public void SaveTask(Task task)
    {
        _tasks.Add(task);
    }

    public void UpdateTask(Task task)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existingTask != null)
        {
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;
        }
    }

    public void RemoveTask(int taskId)
    {
        _tasks = _tasks.Where(t => t.Id != taskId).ToList();
    }

    public List<Task> LoadTasks()
    {
        return _tasks;
    }
}
