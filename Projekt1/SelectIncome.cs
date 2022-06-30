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
    internal class SelectIncome
    {
        public void Select(MyDbContext ctx)
        {
            Console.WriteLine("Lista przychodów:");


            var incomeSelect = ctx.Incomes
                .ToList();
            foreach (var income in incomeSelect)
            {
                Console.Write($"Id: {income.Id} | ");
                Console.Write($"Nazwa: {income.Name} | ");
                Console.Write($"Wartość: {income.Value} zł");
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}