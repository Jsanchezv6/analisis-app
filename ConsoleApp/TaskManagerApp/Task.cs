public class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public Task(int id, string description, bool isCompleted)
    {
        Id = id;
        Description = description;
        IsCompleted = isCompleted;
    }
}
