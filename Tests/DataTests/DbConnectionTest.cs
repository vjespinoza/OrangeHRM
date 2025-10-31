namespace OrangeHRM.Tests.DataTests;

public class DbConnectionTest : BaseDataTest
{
    [Fact]
    public void VerifyTableConnectionTest()
    {
        var schemaName = "db_hotel_test";
        var tableName = "hotel_reservations";
        var query = $@"SELECT * 
                   FROM INFORMATION_SCHEMA.TABLES 
                   WHERE TABLE_SCHEMA = '{schemaName}' 
                   AND TABLE_NAME = '{tableName}'";

        var result = DbHelper.ExecuteQuery(query);

        Assert.NotNull(result);
        Assert.True(result.Rows.Count > 0,
            $"Table '{tableName}' does not exist in schema '{schemaName}'");
    }
}