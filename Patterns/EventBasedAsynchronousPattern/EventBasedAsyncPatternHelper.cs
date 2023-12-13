namespace AsyncProgramming.Patterns.EventBasedAsynchronousPattern;

public static class EventBasedAsyncPatternHelper
{
    public static void FetchAndPrintUser(int userId)
    {
        var eapUserProvider = new EapUserProvider();

        eapUserProvider.GetUserCompleted += (sender, args) =>
        {
            var user = args.User;

            if (user is not null) Console.WriteLine($"Id: {user.Id}\nName: {user.Name}");
        };

        eapUserProvider.GetUserAsync(userId);
    }
}