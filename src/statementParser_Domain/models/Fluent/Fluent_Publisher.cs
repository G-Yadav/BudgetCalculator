using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace com.gaurav.domain.models.Fluent 
{
    // [Table("Publishers")]
    public class Fluent_Publisher
    {
        // [Key]
        // [Column("Publisher_Id")]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Location { get; set; }
        // public List<Fluent_Book> Books { get; set; }
    }

}