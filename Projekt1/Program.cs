using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Projekt1;

var context = ContextFactory.Context;
var choice = 0;
do
{
    Console.Clear();
    Console.WriteLine("___________________________________________");
    Console.WriteLine("               Wydatki domowe              ");
    Console.WriteLine("___________________________________________");
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine("1. Wyświetl domowników.");
    Console.WriteLine("2. Wyświetl dochody.");
    Console.WriteLine("3. Wyświetl wydatki.");
    Console.WriteLine("4. Dodaj wydatek.");
    Console.WriteLine("5. Wyjście.");
    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            var selectPerson = new SelectPerson();
            selectPerson.Select(context);
            Console.ReadKey();
            break;
        case 2:
            var selectIncome = new SelectIncome();
            selectIncome.Select(context);
            Console.ReadKey();
            break;
        case 3:
            var selectOutcome = new SelectOutcome();
            selectOutcome.Select(context);
            Console.ReadKey();
            break;
        case 4:
            var selectPerson2 = new SelectPerson();
            selectPerson2.Select(context);

            var addOutcome = new AddOutcome();
            addOutcome.Add(context);
            Console.ReadKey();
            break;
    }
} while (choice != 5);

public static class ContextFactory
{
    private static readonly Lazy<MyDbContext> LazyContext = new(() =>
    {
        var ctx = new MyDbContext();
        ctx.Database.EnsureCreated();
        ctx.SeedData();
        return ctx;
    });

    public static MyDbContext Context => LazyContext.Value;
}
public static class DataInitializer
{
    public static void SeedData(this MyDbContext myDbContext)
    {

        var person1 = new Person
        {
            Id = Guid.Parse("32447eca-95eb-4022-8fdf-5eed22ef57a1"),
            Name = "Tomasz",
            LastName = "Kurowski",
        };
        var person2 = new Person
        {
            Id = Guid.Parse("a5f87b5a-acbb-4cdc-b88e-f72af3f12fab"),
            Name = "Piotr",
            LastName = "Kurowski"
        };
        var person3 = new Person
        {
            Id = Guid.Parse("80e5a56c-1e55-4893-a835-adb9a15db04c"),
            Name = "Anita",
            LastName = "Kurowska"
        };

        myDbContext.Person.Upsert(person1);
        myDbContext.Person.Upsert(person2);
        myDbContext.Person.Upsert(person3);


        var income1 = new Income
        {
            Id = Guid.Parse("6d6f3798-a64b-4d54-adc1-ef1b307c1617"),
            Name = "wynagrodzenie za maj",
            Value = 5800,
            PersonId = person1.Id,
        };
        var income2 = new Income
        {
            Id = Guid.Parse("7c955970-84d2-4613-9817-c55c918b318d"),
            Name = "wynagrodzenie za czerwiec",
            Value = 5800,
            PersonId = person1.Id
        };
        var outcome1 = new Outcome
        {
            Id = Guid.Parse("6a721f70-0834-4f2f-bb11-1055f7ca221a"),
            Name = "zakupy spożywcze",
            Value = 160,
            PersonId = person2.Id,
        };
        var outcome2 = new Outcome
        {
            Id = Guid.Parse("f6174591-2a44-437c-a66a-2cc7cce11817"),
            Name = "rachunek za prąd - maj",
            Value = 280,
            PersonId = person1.Id
        };

        myDbContext.Incomes.Upsert(income1);
        myDbContext.Incomes.Upsert(income2);
        myDbContext.Outcomes.Upsert(outcome1);
        myDbContext.Outcomes.Upsert(outcome2);

        myDbContext.SaveChanges();
    }

}