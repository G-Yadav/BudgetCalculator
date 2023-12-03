using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.gaurav.domain.models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Column("Name")]
        [Required]
        public string? GenreName { get; set; }
    }
    
}