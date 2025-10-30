namespace OrangeHRM.Utils;

public abstract class TestData
{
    public static readonly Records.UserData NewUser = new(
        "Admin",
        "a",
        "Enabled",
        $"vic_superuser_{Helpers.GetRandomFourDigits()}",
        "qwerty.123"
    );

    public static Records.UserData ModifiedUser = NewUser with
    {
        UserRole = "ESS",
        Status = "Disabled",
        Password = "asdfgh_987"
    };

    public static readonly Records.LoginData ValidLogin = new(
        "Admin",
        "admin123"
    );
}