namespace OrangeHRM.Utils;

public class TestData
{
    public Records.UserData NewUser => new(
        "Admin",
        "a",
        "Enabled",
        $"vic_superuser_{Helpers.GetRandomFourDigits()}",
        "qwerty.123"
    );

    public Records.UserData ModifiedUser => NewUser with
    {
        UserRole = "ESS",
        Status = "Disabled",
        Password = "asdfgh_987"
    };

    public Records.LoginData ValidLogin => new(
        "Admin",
        "admin123"
    );
}