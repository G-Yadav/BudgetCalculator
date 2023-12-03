using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace com.gaurav.domain.models 
{
    [Table("Publishers")]
    public class Publisher
    {
        [Key]
        [Column("Publisher_Id")]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Location { get; set; }
        public List<Book> Books { get; set; }
    }

}