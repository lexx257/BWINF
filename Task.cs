namespace BWINF;

public class Task(string name)
{
    public string Name { get; set; } = name;
    public List<Task> HarderTasks { get; set; } = [];
}