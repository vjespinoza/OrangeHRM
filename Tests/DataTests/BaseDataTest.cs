using OrangeHRM.Utils;

namespace OrangeHRM.Tests.DataTests;

public class BaseDataTest
{
    private static readonly string ConnectionDb = "db_hotel_test";
    private static readonly string ConnectionUid = "root";
    private static readonly string ConnectionPwd = "Admin123";

    protected static readonly string ConnectionString =
        $"Server=localhost;Port=3306;Database={ConnectionDb};Uid={ConnectionUid};Pwd={ConnectionPwd};";

    protected readonly DataBaseHelper DbHelper = new(ConnectionString);
}