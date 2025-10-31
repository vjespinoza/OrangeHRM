namespace OrangeHRM.Tests.DataTests;

public class DbConnectionTest : BaseDataTest
{
    [Fact]
    public void VerifyTableConnectionTest()
    {
        var query = "SELECT * FROM db_hotel_test.hotel_reservations LIMIT 10";
        var resul = DbHelper.ExecuteQuery(query);

        Assert.NotNull(resul);
    }
}