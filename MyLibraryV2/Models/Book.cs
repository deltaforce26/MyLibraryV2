using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibraryV2.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "שם הספר")]
        public string? BookName { get; set; }
        [Display(Name = "גובה ספר")]
        public int Hight { get; set; }
        [Display(Name = "רוחב ספר")]
        public int Width { get; set; }
        
        public string? Genre { get; set; }
        [Display(Name = "מספר מדף")]
        public int? ShelfNumber { get; set; }
        
        public int? ShelfId { get; set; } = null;

        public Shelf? Shelf { get; set; } = null;
    }
}
