using System.ComponentModel.DataAnnotations;

namespace MyLibraryV2.Models
{
    public class Library
    {
        public int Id { get; set; }
        [Display(Name = "Library Name")]
        public string? LibraryName { get; set; }

        public ICollection<Shelf>? Shelves { get; set; }
    }
}