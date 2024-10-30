using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE_25.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; }

        // Связь с книгами, которые пользователь взял на руки
        public List<Book> BorrowedBooks { get; set; } = new List<Book>(); // Инициализация списка
    }
}
