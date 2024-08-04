using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibraryV2.Models
{
    public class BookSet
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Set Title")]
        public string? SetTitle { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
