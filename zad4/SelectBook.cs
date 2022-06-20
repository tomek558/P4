using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace zad4
{
    internal class SelectBook
    {
        public void Select(MyDbContext ctx)
        {
            Console.WriteLine("Podaj tytuł książki: ");
            Console.WriteLine("\n");

            var bookSearch = Console.ReadLine();
            if (bookSearch is null) return;
            var books = ctx.Books
                .Include(b => b.Author)
                .Where(b => b.Title.Contains(bookSearch)).ToList();
            foreach (var book in books)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Tytuł: {book.Title}");
                Console.WriteLine($"Autor: {book.Author.FirstName} {book.Author.Surname}");
                Console.WriteLine($"Rok wydania: {book.Year}");
            }
        }
    }
}