using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCORE_25.Data;

namespace EFCORE_25.Repositories
{
    public interface IBookRepository
    {
        Book GetBookById(int id);
        IEnumerable<Book> GetAllBooks();
        void AddBook(Book book);
        void DeleteBook(int id);

        // Новые методы
        IEnumerable<Book> GetBooksByGenreAndPublicationYear(string genre, int startYear, int endYear);
        int GetBookCountByAuthor(int authorId);
        int GetBookCountByGenre(string genre);
        bool IsBookAvailable(string title, int authorId);
        bool IsBookBorrowedByUser(int bookId, int userId);
        int GetBorrowedBookCountByUser(int userId);
        Book GetLatestBook();
        IEnumerable<Book> GetAllBooksSortedByTitle();
        IEnumerable<Book> GetAllBooksSortedByPublicationYearDescending();
    }
}
