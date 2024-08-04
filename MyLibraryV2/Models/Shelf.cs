using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibraryV2.Models
{
    public class Shelf
    {
        public int Id { get; set; }
        [Display(Name = "מספר מדף")]
        public int ShelfId { get; set; }

        [Display(Name = "גובה מדף")]
        public int Hight { get; set; }

        [Display(Name = "רוחב מדף")]
        public int Width { get; set; }
        [Display(Name = "מקום פנוי")]
        public int LeftSpace { get; set; }
        public int LibraryId { get; set; }

        public Library? Library { get; set; }

        public ICollection<Book> Books { get; set; }

        //[NotMapped]
        //public Double EmptySpace { get => Books != null ? Width - Books.Sum(b => b.Width) : Width; }
    }
}