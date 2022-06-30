using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    internal class AddOutcome
    {
        public void Add(MyDbContext ctx)
        {
            Console.WriteLine("Dodawanie nowego wydatku.");
           
            Console.WriteLine("Podaj ID wydatku: ");
            int typeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj nazwe wydatku: ");
            string typeName = Console.ReadLine();
            Console.WriteLine("Podaj wartość wydatku: ");
            int typeValue = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wybierz domownika do którego chcesz przypisać wydatek: ");
            int typePersonId = Convert.ToInt32(Console.ReadLine());


            var addedOutcome = new Outcome
            {
                Id = typeId,
                Name = typeName,
                Value = typeValue,
                PersonId = typePersonId
            };

            ctx.Outcomes.Upsert(addedOutcome);
            ctx.SaveChanges();
        }
    }
}
