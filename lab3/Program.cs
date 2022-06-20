using System.Data.SqlClient;
using Dapper;

string connectionString = "Data Source = KRUSZALAK6A4C; Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
using var connection = new SqlConnection(connectionString);

/*var newRegion = new Region()
{
    RegionID = 8,
    RegionDescription = "Rajcza"
};


//var insertResult = connection.Execute("INSERT INTO Region(RegionID, RegionDescription) VALUES (@RegionId, @RegionDescription)", newRegion);
var regions = connection.Query<Region>("SELECT * FROM Region");

foreach (var item in regions)
{
    Console.WriteLine($"{item.RegionID}: {item.RegionDescription}");
}*/

/*var joinResult = connection.Query<Product, Category, Product>(
        "SELECT * FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID",
        (product, category) =>
        {
            product.Category = category;
            return product;
        }, 
        splitOn: "CategoryID");

foreach (var item in joinResult)
{
    Console.WriteLine($"{item.ProductName}: {item.Category.CategoryName}");
}*/
var joinResult = connection.Query<Territories, Region, Territories>(
        "SELECT * FROM Territories t JOIN Region r ON r.RegionID = t.RegionID " +
        "WHERE t.TerritoryDescription LIKE CONCAT (@letter, '%');",
        (territories, region) =>
        {
            territories.Region = region;
            return territories;
        },
        new { letter = "B" },
        splitOn: "RegionID") ;

foreach (var item in joinResult)
{
    Console.WriteLine($"{item.TerritoryDescription}: {item.Region.RegionDescription}");
}