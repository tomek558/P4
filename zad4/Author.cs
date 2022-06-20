using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zad4
{
    [Table("Autor")]
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string FirstName { get; set; } 
        public virtual List<Book> Books { get; set; }
    }
}
