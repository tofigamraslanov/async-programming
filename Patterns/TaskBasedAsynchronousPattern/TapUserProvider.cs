using AsyncProgramming.Patterns.Shared;

namespace AsyncProgramming.Patterns.TaskBasedAsynchronousPattern;

public class TapUserProvider
{
    private readonly UserService _userService;

    public TapUserProvider() => _userService = new UserService();

    private User? GetUser(int userId) => _userService.GetUser(userId);

    public Task<User?> GetUserAsync(int userId) => Task.Run(() => GetUser(userId));
}