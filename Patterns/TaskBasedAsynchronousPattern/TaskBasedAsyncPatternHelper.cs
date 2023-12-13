namespace AsyncProgramming.Patterns.TaskBasedAsynchronousPattern;

public static class TaskBasedAsyncPatternHelper
{
    public static async Task FetchAndPrintUser(int userId)
    {
        var tapUserProvider = new TapUserProvider();

        var user = await tapUserProvider.GetUserAsync(userId);

        if (user is not null) Console.WriteLine($"Id: {user.Id}\nName: {user.Name}");
    }
}