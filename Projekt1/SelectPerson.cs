
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt1;
using Microsoft.EntityFrameworkCore;

namespace Projekt1

{
    internal class SelectPerson
    {
        public void Select(MyDbContext ctx)
        {
            Console.WriteLine("Lista domowników:");


            var personSelect = ctx.Person
                .ToList();
            foreach (var person in personSelect)
            {
                Console.Write($"Id: {person.Id} | ");
                Console.Write($" Imię: {person.Name} ");
                Console.Write($"Nazwisko: {person.LastName}");
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}