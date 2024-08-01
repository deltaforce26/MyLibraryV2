using Microsoft.AspNetCore.Mvc.Rendering;
using MyLibraryV2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibraryV2.Models
{
    
    public class Book_LibraryViewModel
    {
        
        [NotMapped]
        public Book B { get; set; }
        [NotMapped]
        public Library L { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Libraries { get; set; }
    }
}

