namespace OrangeHRM.Tests.DataTests;

public class UserManagementDataTest : BaseDataTest
{
    [Theory]
    [InlineData("test_user_01")]
    public void VerifyUserAddedToDatabase(string username)
    {
        var query = $"SELECT * FROM users WHERE username = '{username}'";
        var result = DbHelper.ExecuteQuery(query);

        Assert.True(result.Rows.Count > 0, $"User '{username}' should exist in the database after creation.");
    }

    [Theory]
    [InlineData("test_user_01", "Admin")]
    public void VerifyUserEditedInDatabase(string username, string expectedRole)
    {
        var query = $"SELECT user_role FROM users WHERE username = '{username}'";
        var result = DbHelper.ExecuteQuery(query);

        Assert.True(result.Rows.Count > 0, $"User '{username}' not found.");
        var actualRole = result.Rows[0]["user_role"].ToString();

        Assert.Equal(expectedRole, actualRole);
    }

    [Theory]
    [InlineData("test_user_01")]
    public void VerifyUserDeletedFromDatabase(string username)
    {
        var query = $"SELECT * FROM users WHERE username = '{username}'";
        var result = DbHelper.ExecuteQuery(query);

        Assert.True(result.Rows.Count == 0, $"User '{username}' should have been deleted from the database.");
    }
}