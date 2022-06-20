using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

    void QSelect(SqlConnection connection)
    {
        var queryString = "SELECT * FROM Region";
        var command = new SqlCommand(queryString, connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"RegionID: {reader[0]} | RegionDescription: {reader[1]}");
        }
    }


    void QInsert(SqlConnection connection, int pId, string pRegionName)
    {
        var queryString = "INSERT INTO Region VALUES(@id, @regionName)";
        var command = new SqlCommand(queryString, connection);
        command.Parameters.AddWithValue("id", pId);
        command.Parameters.AddWithValue("regionName", pRegionName);
        var sqlOutput = command.ExecuteNonQuery();
        Console.WriteLine($"Affected rows: {sqlOutput}");
    }

        // SQL Init
        string connectionString = "Data Source = KRUSZALAK6A4C; Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        QSelect(connection);

        Console.WriteLine("Podaj ID: ");
        int pId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Podaj nazwe regionu do dodania: ");
        string pRegionName = Console.ReadLine();

        string[] forbiddenStuff = { "=", "@", "1", ";", "DROP", "*", "INSERT", "SELECT", "," };

        if (forbiddenStuff.Any(pRegionName.Contains))
        {
            Console.WriteLine("Zły format.");
        }
        else
        {
            QInsert(connection, pId, pRegionName);
            Console.WriteLine("\nSELECT:");
            QSelect(connection);
        }

