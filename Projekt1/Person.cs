using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt1
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; } 
        public virtual List<Income> Incomes { get; set; }
        public virtual List<Outcome> Outcomes { get; set; }
    }
}
