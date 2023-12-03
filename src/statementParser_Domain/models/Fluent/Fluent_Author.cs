using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.gaurav.domain.models.Fluent
{
    // [Table("Authors")]
    public class Fluent_Author
    {
        // [Key]
        public int Author_Id { get; set; }
        // [MaxLength(50)]
        // [Required]
        public string? FirstName { get; set; }
        // [Required]
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Location { get; set; }
        [NotMapped]
        public string FullName { get => FirstName + " " + LastName; }
        // public List<Fluent_Book> Books { get; set; }
    }   
}