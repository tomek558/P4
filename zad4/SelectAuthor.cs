using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad4;
using Microsoft.EntityFrameworkCore;

namespace zad4
{
    internal class SelectAuthor
    {
        public void Select(MyDbContext ctx)
        {
            Console.WriteLine("Podaj nazwisko autora: ");
            Console.WriteLine("\n");

            var authorSearch = Console.ReadLine();
            if(authorSearch is null) return;
            var authorBooks = ctx.Authors
                .Include(n => n.Books).ThenInclude(b=>b.Author)
                .Where(a => a.Surname.Contains(authorSearch))
                .SelectMany(a => a.Books)
                .ToList();
            foreach (var book in authorBooks)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Tytuł: {book.Title}");
                Console.WriteLine($"Autor: {book.Author.FirstName} {book.Author.Surname}");
                Console.WriteLine($"Rok wydania: {book.Year}");
            }
        }
    }
}