using com.gaurav.domain.models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace statementParser_WebApp.Models
{
    public class BookVM
    {
        public Book Book { get; set; }
        public List<SelectListItem> PublisherList { get; set; }
    }
}