using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE_25.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public int AuthorId { get; set; } // Идентификатор автора
        public Author Author { get; set; } // Навигационное свойство для автора
        public int GenreId { get; set; } // Идентификатор жанра
        public Genre Genre { get; set; } // Навигационное свойство для жанра
    }
}
