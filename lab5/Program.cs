using lab5;


var context = new MyDbContext();

context.Database.EnsureCreated();

var client = new Client()
{
    Name = "Jan Nowak"
};

context.Orders.Add(new Order()
{
    Price = 10m
});

context.Clients.Add(client);

//context.SaveChanges();