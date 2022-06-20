using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zad4
{
    [Table("Książka")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
    
        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public virtual Author Author { get; set; }
    }
}
