using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.gaurav.domain.models
{
    public class BookDetail
    {
        [Key]
        public int BookDetail_Id { get; set; }
        public int NumberOfChapter { get; set; }
        public int NumberOfPages { get; set; }
        public decimal Weight { get; set; }
        [ForeignKey("Book")]
        public int Book_Id { get; set; }
        public Book Book { get; set; }
    }
}