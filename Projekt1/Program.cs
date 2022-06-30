using Projekt1;

var context = new MyDbContext();
context.Database.EnsureCreated();
SeedDatabase(context);

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


void SeedDatabase(MyDbContext myDbContext)
{
    var person1 = new Person
    {
        Id = 1,
        Name = "Tomasz",
        LastName = "Kurowski",
    };
    var person2 = new Person
    {
        Id = 2,
        Name = "Piotr",
        LastName = "Kurowski"
    };
    var person3 = new Person
    {
        Id = 3,
        Name = "Anita",
        LastName = "Kurowska"
    };

    myDbContext.Person.Upsert(person1);
    myDbContext.Person.Upsert(person2);
    myDbContext.Person.Upsert(person3);


    var income1 = new Income
    {
        Id = 1,
        Name = "wynagrodzenie za maj",
        Value = 5800,
        PersonId = 1
    };
    var income2 = new Income
    {
        Id = 2,
        Name = "wynagrodzenie za czerwiec",
        Value = 5800,
        PersonId = 1
    };
    var outcome1 = new Outcome
    {
        Id = 1,
        Name = "zakupy spożywcze",
        Value = 160,
        PersonId = 2
    };
    var outcome2 = new Outcome
    {
        Id = 2,
        Name = "rachunek za prąd - maj",
        Value = 280,
        PersonId = 1
    };
  
    myDbContext.Incomes.Upsert(income1);
    myDbContext.Incomes.Upsert(income2);
    myDbContext.Outcomes.Upsert(outcome1);
    myDbContext.Outcomes.Upsert(outcome2);

    myDbContext.SaveChanges();
}