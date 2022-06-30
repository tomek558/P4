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
    internal class SelectOutcome
    {
        public void Select(MyDbContext ctx)
        {
            Console.WriteLine("Lista wydatków:");

            var outcomeSelect = ctx.Outcomes
                .ToList();
            foreach (var outcome in outcomeSelect)
            {
                Console.Write($"Id: {outcome.Id} | ");
                Console.Write($"Nazwa: {outcome.Name} | ");
                Console.Write($"Wartość: {outcome.Value}");
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}