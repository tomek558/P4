using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    internal class AddIncome
    {
        public void Add(MyDbContext ctx)
        {
            Console.WriteLine("Dodawanie nowego wydatku.");
           
            Console.WriteLine("Podaj nazwe wydatku: ");
            string typeName = Console.ReadLine();
            Console.WriteLine("Podaj wartość wydatku: ");
            int typeValue = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wybierz domownika do którego chcesz przypisać wydatek: ");
            int typePersonId = Convert.ToInt32(Console.ReadLine());


            var addedIncome = new Income
            {
                Name = typeName,
                Value = typeValue,
                PersonId = Guid.NewGuid()
            };

            ctx.Incomes.Add(addedIncome);
            ctx.SaveChanges();
        }
    }
}
