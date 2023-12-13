namespace AsyncProgramming.Patterns.Shared;

public class UserService
{
    private readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "Tofig" },
        new User { Id = 2, Name = "Asim" }
    };

    public User? GetUser(int userId) => _users.FirstOrDefault(x => x.Id == userId);
}   