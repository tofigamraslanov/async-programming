using System.ComponentModel;
using AsyncProgramming.Patterns.Shared;

namespace AsyncProgramming.Patterns.EventBasedAsynchronousPattern;

public class EapUserProvider
{
    private readonly SendOrPostCallback _operationFinished;
    private readonly UserService _userService;

    public EapUserProvider()
    {
        _operationFinished = ProcessOperationFinished;
        _userService = new UserService();
    }

    public event EventHandler<GetUserCompletedEventArgs>? GetUserCompleted;

    public void GetUserAsync(int userId) => GetUserAsync(userId, null);

    private void ProcessOperationFinished(object? state)
    {
        var args = (GetUserCompletedEventArgs)state!;    

        GetUserCompleted?.Invoke(this, args);
    }

    private void GetUserAsync(int userId, object? userState)
    {
        AsyncOperation operation = AsyncOperationManager.CreateOperation(userState);
        
        ThreadPool.QueueUserWorkItem(_ =>
        {
            GetUserCompletedEventArgs args;
            
            try
            {
                var user = GetUser(userId);
                args = new GetUserCompletedEventArgs(null, false, user);
            }
            catch (Exception? e)
            {
                Console.WriteLine(e.Message);
                args = new GetUserCompletedEventArgs(e, false, null);
            }
            
            operation.PostOperationCompleted(_operationFinished, args);
        }, userState);
    }
    
    private User? GetUser(int userId) => _userService.GetUser(userId);
}