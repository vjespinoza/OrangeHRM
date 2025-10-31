using System.Data;
using MySql.Data.MySqlClient;

namespace OrangeHRM.Utils;

public class DataBaseHelper : IDisposable
{
    private readonly MySqlConnection _connection;

    public DataBaseHelper(string connectionString)
    {
        _connection = new MySqlConnection(connectionString);
        _connection.Open();
    }

    public void Dispose()
    {
        _connection?.Dispose();
    }

    public DataTable ExecuteQuery(string query)
    {
        using var cmd = new MySqlCommand(query, _connection);
        using var adapter = new MySqlDataAdapter(cmd);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }
}