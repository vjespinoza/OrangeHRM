namespace OrangeHRM.Utils;

public class Records
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