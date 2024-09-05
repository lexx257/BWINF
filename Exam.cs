namespace BWINF;
using System.Collections.Generic;
public class Exam
{
    private Dictionary<string, Task> Tasks { get; set; } = new();
    
    private Task GetOrCreateTask(string taskName)
    {
        if (Tasks.TryGetValue(taskName, out var value)) return value;
        value = new Task(taskName);
        Tasks[taskName] = value;
        return value;
    }


    public void AddDependency(string easierTask, string harderTask)
    {
        var task1 = GetOrCreateTask(easierTask);
        var task2 = GetOrCreateTask(harderTask);
        task1.HarderTasks.Add(task2);
    }
    public List<string> GetTaskOrder()
    {
        return GraphSort.TopologicalSort(Tasks.Values);
    }
}