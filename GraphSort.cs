namespace BWINF;

public static class GraphSort
{
    public static List<string> TopologicalSort(IEnumerable<Task> tasks)
    {
        var sortedTasks = new List<string>();
        var visited = new HashSet<Task>();
        var visiting = new HashSet<Task>();

        if (tasks.Where(task => !visited.Contains(task)).Any(task => !Dfs(task, visited, visiting, sortedTasks)))
        {
            throw new InvalidOperationException("Conflict detected in task dependencies.");
        }

        sortedTasks.Reverse();
        return sortedTasks;
    }

    private static bool Dfs(Task task, HashSet<Task> visited, HashSet<Task> visiting, List<string> sortedTasks)
    {
        if (visiting.Contains(task))
        {
            return false;
        }

        if (visited.Contains(task)) return true;
        visiting.Add(task);
        if (task.HarderTasks.Any(harderTask => !Dfs(harderTask, visited, visiting, sortedTasks)))
        {
            return false;
        }
        visiting.Remove(task);
        visited.Add(task);
        sortedTasks.Add(task.Name);

        return true;
    }
}