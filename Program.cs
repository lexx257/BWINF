namespace BWINF;

internal static class Program
{
    private static void Main(string[] args)
    {

        var exam = new Exam();

        // Adding task dependencies (B < D < F) (A < E < D < C < F)
        exam.AddDependency("B", "D");
        exam.AddDependency("D", "F");
        exam.AddDependency("A", "E");
        exam.AddDependency("E", "D");
        exam.AddDependency("D", "C");
        exam.AddDependency("C", "F");

        try
        {
            var sortedTasks = exam.GetTaskOrder();
            Console.WriteLine("Ordered tasks: " + string.Join(", ", sortedTasks));
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}