namespace OrangeHRM.Utils;

public abstract class TestData
{
    public static readonly Records.UserData AdminUser = new(
        "Admin",
        "a",
        "Enabled",
        "vic_superuser",
        "qwerty.123"
    );

    public static readonly Records.LoginData ValidLogin = new(
        "Admin",
        "admin123"
    );
}