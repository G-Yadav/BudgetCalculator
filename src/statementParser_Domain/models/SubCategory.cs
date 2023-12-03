using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.gaurav.domain.models
{
    [Table("SubCategories")]
    public class SubCategory
    {
        [Column("SubCategory_Id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}