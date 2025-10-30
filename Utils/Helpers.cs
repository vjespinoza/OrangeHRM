namespace OrangeHRM.Utils;

public class Helpers
{
    public static string GetRandomFourDigits()
    {
        var random = new Random();
        var number = random.Next(0, 10000); // 0 to 9999
        return number.ToString("D4"); // Format with leading zeros
    }
}