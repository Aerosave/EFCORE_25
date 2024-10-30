using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCORE_25.Data;
using EFCORE_25.Repositories;
using Microsoft.EntityFrameworkCore;


namespace EFCORE_25.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly EFCORE_25.Data.AppContext _context;

        public BookRepository(EFCORE_25.Data.AppContext context)
        {
            _context = context;
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        // 1. Получение списка книг определенного жанра и вышедших между определенными годами.
        public IEnumerable<Book> GetBooksByGenreAndPublicationYear(string genre, int startYear, int endYear)
        {
            return _context.Books
                .Where(b => b.Genre.Name == genre && b.PublicationYear >= startYear && b.PublicationYear <= endYear)
                .ToList();
        }

        // 2. Получение количества книг определенного автора в библиотеке.
        public int GetBookCountByAuthor(int authorId)
        {
            return _context.Books.Count(b => b.AuthorId == authorId);
        }

        // 3. Получение количества книг определенного жанра в библиотеке.
        public int GetBookCountByGenre(string genre)
        {
            return _context.Books.Count(b => b.Genre.Name == genre);
        }

        // 4. Проверка, есть ли книга определенного автора и с определенным названием в библиотеке.
        public bool IsBookAvailable(string title, int authorId)
        {
            return _context.Books.Any(b => b.Title == title && b.AuthorId == authorId);
        }

        // 5. Проверка, есть ли определенная книга на руках у пользователя.
        public bool IsBookBorrowedByUser(int bookId, int userId)
        {
            var user = _context.Users.Include(u => u.BorrowedBooks)
                                      .FirstOrDefault(u => u.Id == userId);
            return user?.BorrowedBooks.Any(b => b.Id == bookId) ?? false;
        }

        // 6. Получение количества книг на руках у пользователя.
        public int GetBorrowedBookCountByUser(int userId)
        {
            var user = _context.Users.Include(u => u.BorrowedBooks)
                                      .FirstOrDefault(u => u.Id == userId);
            return user?.BorrowedBooks.Count() ?? 0;
        }

        // 7. Получение последней вышедшей книги.
        public Book GetLatestBook()
        {
            return _context.Books.OrderByDescending(b => b.PublicationYear).FirstOrDefault();
        }

        // 8. Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public IEnumerable<Book> GetAllBooksSortedByTitle()
        {
            return _context.Books.OrderBy(b => b.Title).ToList();
        }

        // 9. Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        public IEnumerable<Book> GetAllBooksSortedByPublicationYearDescending()
        {
            return _context.Books.OrderByDescending(b => b.PublicationYear).ToList();
        }
    }
}

