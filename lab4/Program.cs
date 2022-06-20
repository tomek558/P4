using Microsoft.EntityFrameworkCore;
using lab4;

var context = new MyDbContext();
context.Database.EnsureCreated();
context.Database.Migrate();

using var transaction = context.Database.BeginTransaction();



context.Clients.Add(new Client()
{
    Name = "Jan Kowalski",
    Adress = "Szeroka, Bielsko-Biała",
    Balance = 0
});

context.SaveChanges();

// wycofanie tranzakcji:
transaction.Rollback();
//transaction.Commit();



//var result = context.Clients.ToList();
var result = context.Clients
    .Where(client => client.Balance == 0)
    .ToArray();

foreach (var client in result)
{
    Console.WriteLine(client.Name);
}