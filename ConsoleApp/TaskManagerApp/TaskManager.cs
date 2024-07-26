using System.Collections.Generic;
using System.Linq;

public class TaskManager : ITaskManager
{
    private readonly IDataStorage _dataStorage;

    public TaskManager(IDataStorage dataStorage)
    {
        _dataStorage = dataStorage;
    }

    public void AddTask(Task task)
    {
        _dataStorage.SaveTask(task);
    }

    public void ModifyTask(int taskId, string newDescription, bool isCompleted)
    {
        var task = _dataStorage.LoadTasks().FirstOrDefault(t => t.Id == taskId);
        if (task != null)
        {
            task.Description = newDescription;
            task.IsCompleted = isCompleted;
            _dataStorage.UpdateTask(task);
        }
    }

    public void DeleteTask(int taskId)
    {
        _dataStorage.RemoveTask(taskId);
    }

    public List<Task> GetPendingTasks()
    {
        return _dataStorage.LoadTasks().Where(t => !t.IsCompleted).ToList();
    }

    public List<Task> GetCompletedTasks()
    {
        return _dataStorage.LoadTasks().Where(t => t.IsCompleted).ToList();
    }
}
