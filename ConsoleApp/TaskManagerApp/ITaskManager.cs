using System.Collections.Generic;

public interface ITaskManager
{
    void AddTask(Task task);
    void ModifyTask(int taskId, string newDescription, bool isCompleted);
    void DeleteTask(int taskId);
    List<Task> GetPendingTasks();
    List<Task> GetCompletedTasks();
}

public interface IDataStorage
{
    void SaveTask(Task task);
    void UpdateTask(Task task);
    void RemoveTask(int taskId);
    List<Task> LoadTasks();
}
