using System;
using System.Data.SQLite;
using System.IO;

public class DatabaseManager
{
    private static readonly string BaseDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data"));
    private static readonly string DatabaseFileName = "register.db";
    private static readonly string DatabaseFilePath = Path.GetFullPath(Path.Combine(BaseDirectory, DatabaseFileName));
    private static readonly string ConnectionString = $"Data Source={DatabaseFilePath};Mode=ReadWriteCreate;";


    // 建立数据库
    public void CreateDatabase()
    {
        // 确保目录存在
        string directory = Path.GetDirectoryName(DatabaseFilePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // 如果数据库文件不存在，则创建它
        if (!File.Exists(DatabaseFilePath))
        {
            SQLiteConnection.CreateFile(DatabaseFilePath);
        }
    }

    // 建表
    public void CreateTable()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string sql = "CREATE TABLE IF NOT EXISTS Customers (Id INTEGER PRIMARY KEY, Name TEXT, Age INTEGER)";
            using (var cmd = new SQLiteCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    // 插入
    public void InsertData()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string sql = "INSERT INTO Customers (Name, Age) VALUES ('John Doe', 30)";
            using (var cmd = new SQLiteCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    // 查询
    public void QueryData()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string sql = "SELECT * FROM Customers";
            using (var cmd = new SQLiteCommand(sql, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        String str = $"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}";
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
                    }
                }
            }
        }
    }
}