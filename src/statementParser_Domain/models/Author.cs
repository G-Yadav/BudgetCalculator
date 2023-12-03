using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.gaurav.domain.models
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        public int Author_Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Location { get; set; }
        [NotMapped]
        public string FullName { get => $"{FirstName} {LastName}"; }
        public List<Book> Books { get; set; }
    }   
}