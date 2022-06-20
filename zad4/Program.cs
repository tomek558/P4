using zad4;

var context = new MyDbContext();
context.Database.EnsureCreated();
SeedDatabase(context);

var choice = 0;
do
{
    Console.Clear();
    Console.WriteLine("___________________________________________");
    Console.WriteLine("             Książki i autorzy             ");
    Console.WriteLine("___________________________________________");
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine("1. Znajdź książkę.");
    Console.WriteLine("2. Znajdź autora.");
    Console.WriteLine("3. Wyjście.");
    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            var selectBook = new SelectBook();
            selectBook.Select(context);
            Console.ReadKey();
            break;
        case 2:
            var selectAuthor = new SelectAuthor();
            selectAuthor.Select(context);
            Console.ReadKey();
            break;
    }
} while (choice != 3);


void SeedDatabase(MyDbContext myDbContext)
{
    var author = new Author
    {
        Id = 1,
        Surname = "Sienkiewicz",
        FirstName = "Henryk",
    };
    var author2 = new Author
    {
        Id = 2,
        Surname = "Sapkowski",
        FirstName = "Andrzej"
    };
    var author3 = new Author
    {
        Id = 3,
        Surname = "Burczymucha",
        FirstName = "Stefan"
    };
    var author4 = new Author
    {
        Id = 4,
        Surname = "Boncek",
        FirstName = "Marian"
    };
    var author5 = new Author
    {
        Id = 5,
        Surname = "Padło",
        FirstName = "Krzysztof"
    };

    myDbContext.Authors.Upsert(author);
    myDbContext.Authors.Upsert(author2);
    myDbContext.Authors.Upsert(author3);
    myDbContext.Authors.Upsert(author4);
    myDbContext.Authors.Upsert(author5);

    var book = new Book
    {
        Id = 1,
        Title = "Quo Vadis",
        Year = 2020,
        AuthorId = 1
    };
    var book1 = new Book
    {
        Id = 2,
        Title = "W pustyni i w puszczy",
        Year = 1980,
        AuthorId = 1
    };
    var book2 = new Book
    {
        Id = 3,
        Title = "Latarnik",
        Year = 1950,
        AuthorId = 1
    };
    var book3 = new Book
    {
        Id = 4,
        Title = "Krew elfów",
        Year = 1990,
        AuthorId = 2
    };
    var book4 = new Book
    {
        Id = 5,
        Title = "Pani jeziora",
        Year = 1992,
        AuthorId = 2
    };
    var book5 = new Book
    {
        Id = 6,
        Title = "Czas pogardy",
        Year = 1994,
        AuthorId = 2
    };
    var book6 = new Book
    {
        Id = 7,
        Title = "Chrzest ognia",
        Year = 1998,
        AuthorId = 2
    };
    var book7 = new Book
    {
        Id = 8,
        Title = "Wieża jaskółki",
        Year = 1994,
        AuthorId = 2
    };
    var book8 = new Book
    {
        Id = 9,
        Title = "O dwóch takich co ukradli księżyc",
        Year = 2002,
        AuthorId = 3
    };
    var book9 = new Book
    {
        Id = 10,
        Title = "Syf w państwie",
        Year = 2002,
        AuthorId = 3
    };
    var book10 = new Book
    {
        Id = 11,
        Title = "Poprawka z Baz Danych",
        Year = 2002,
        AuthorId = 3
    };
    var book11 = new Book
    {
        Id = 12,
        Title = "Zimne piwko",
        Year = 2002,
        AuthorId = 3
    };
    var book12 = new Book
    {
        Id = 13,
        Title = "Lambada",
        Year = 2002,
        AuthorId = 4
    };
    var book13 = new Book
    {
        Id = 14,
        Title = "Krzywy kij",
        Year = 2010,
        AuthorId = 4
    };
    var book14 = new Book
    {
        Id = 15,
        Title = "Słońce świeci",
        Year = 2015,
        AuthorId = 4
    };
    var book15 = new Book
    {
        Id = 16,
        Title = "Ptaków śpiew",
        Year = 2017,
        AuthorId = 4
    };
    var book16 = new Book
    {
        Id = 17,
        Title = "Makbuk",
        Year = 2011,
        AuthorId = 5
    };
    var book17 = new Book
    {
        Id = 18,
        Title = "Stolik",
        Year = 2012,
        AuthorId = 5
    };
    var book18 = new Book
    {
        Id = 19,
        Title = "Krzesło",
        Year = 2012,
        AuthorId = 5
    };
    var book19 = new Book
    {
        Id = 20,
        Title = "Szafa",
        Year = 2009,
        AuthorId = 5
    };
    var book20 = new Book
    {
        Id = 21,
        Title = "Telewizorek",
        Year = 2005,
        AuthorId = 5
    };
    myDbContext.Books.Upsert(book);
    myDbContext.Books.Upsert(book1);
    myDbContext.Books.Upsert(book2);
    myDbContext.Books.Upsert(book3);
    myDbContext.Books.Upsert(book4);
    myDbContext.Books.Upsert(book5);
    myDbContext.Books.Upsert(book6);
    myDbContext.Books.Upsert(book7);
    myDbContext.Books.Upsert(book8);
    myDbContext.Books.Upsert(book9);
    myDbContext.Books.Upsert(book10);
    myDbContext.Books.Upsert(book11);
    myDbContext.Books.Upsert(book12);
    myDbContext.Books.Upsert(book13);
    myDbContext.Books.Upsert(book14);
    myDbContext.Books.Upsert(book15);
    myDbContext.Books.Upsert(book16);
    myDbContext.Books.Upsert(book17);
    myDbContext.Books.Upsert(book18);
    myDbContext.Books.Upsert(book19);
    myDbContext.Books.Upsert(book20);

    myDbContext.SaveChanges();
}