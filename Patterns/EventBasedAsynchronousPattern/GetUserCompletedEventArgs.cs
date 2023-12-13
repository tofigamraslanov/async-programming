using System.ComponentModel;
using AsyncProgramming.Patterns.Shared;

namespace AsyncProgramming.Patterns.EventBasedAsynchronousPattern;

public class GetUserCompletedEventArgs : AsyncCompletedEventArgs
{
    private readonly User? _user;

    public User? User
    {
        get
        {
            RaiseExceptionIfNecessary();
            return _user;
        }
    }

    public GetUserCompletedEventArgs(Exception? error, bool cancelled, User? user)
        : base(error, cancelled, user)
    {
        _user = user;
    }
}