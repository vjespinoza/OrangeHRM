namespace OrangeHRM.Utils;

public abstract class Records
{
    public record UserData(
        string UserRole,
        string EmployeeNameInitial,
        string Status,
        string Username,
        string Password
    );

    public record LoginData(string Username, string Password);
}