using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt1
{
    public class Outcome
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Value { get; set; }

        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }

    }
}
