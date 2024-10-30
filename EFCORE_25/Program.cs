using System;
using EFCORE_25.Data;
using EFCORE_25.Repositories;

namespace EFCORE_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EFCORE_25.Data.AppContext())
            {
                var userRepository = new UserRepository(db);
                var bookRepository = new BookRepository(db);
                var authorRepository = new AuthorRepository(db);
                var genreRepository = new GenreRepository(db);

                // Пример добавления авторов
                var author1 = new Author { Name = "Л.Н. Толстой" };
                var author2 = new Author { Name = "Джордж Оруэлл" };
                authorRepository.AddAuthor(author1);
                authorRepository.AddAuthor(author2);

                // Пример добавления жанров
                var genre1 = new Genre { Name = "Роман" };
                var genre2 = new Genre { Name = "Антиутопия" };
                genreRepository.AddGenre(genre1);
                genreRepository.AddGenre(genre2);

                // Пример добавления книг с указанием авторов и жанров
                var book1 = new Book { Title = "Война и мир", PublicationYear = 1869, AuthorId = author1.Id, GenreId = genre1.Id };
                var book2 = new Book { Title = "1984", PublicationYear = 1949, AuthorId = author2.Id, GenreId = genre2.Id };
                bookRepository.AddBook(book1);
                bookRepository.AddBook(book2);

                // Пример получения всех книг
                var allBooks = bookRepository.GetAllBooks();
                foreach (var book in allBooks)
                {
                    Console.WriteLine($"Книга: {book.Title}, Автор: {book.Author.Name}, Жанр: {book.Genre.Name}");
                }

                // Пример добавления пользователя и получения книги на руки
                var user = new User { Name = "Алиса", Email = "alice@example.com", Role = "Пользователь" };
                userRepository.AddUser(user);
                user.BorrowedBooks.Add(book1); // Пользователь берет книгу на руки

                // Получение списка книг определенного жанра и года
                var booksInGenre = bookRepository.GetBooksByGenreAndPublicationYear("Роман", 1800, 1900);
                Console.WriteLine("Книги жанра 'Роман', изданные между 1800 и 1900 годами:");
                foreach (var book in booksInGenre)
                {
                    Console.WriteLine(book.Title);
                }

                // Получение количества книг определенного автора
                var authorBookCount = bookRepository.GetBookCountByAuthor(author1.Id);
                Console.WriteLine($"Количество книг автора {author1.Name}: {authorBookCount}");

                // Проверка наличия книги определенного автора и названия
                bool isBookAvailable = bookRepository.IsBookAvailable("1984", author2.Id);
                Console.WriteLine($"Есть ли книга '1984' автора {author2.Name} в библиотеке? {isBookAvailable}");

                // Получение количества книг на руках у пользователя
                int borrowedBookCount = bookRepository.GetBorrowedBookCountByUser(user.Id);
                Console.WriteLine($"Пользователь {user.Name} имеет {borrowedBookCount} книгу(и) на руках.");

                // Получение последней вышедшей книги
                var latestBook = bookRepository.GetLatestBook();
                Console.WriteLine($"Последняя вышедшая книга: {latestBook?.Title}");

                // Получение всех книг, отсортированных по названию
                var sortedBooks = bookRepository.GetAllBooksSortedByTitle();
                Console.WriteLine("Книги, отсортированные по названию:");
                foreach (var book in sortedBooks)
                {
                    Console.WriteLine(book.Title);
                }

                // Получение всех книг, отсортированных по году выхода
                var booksSortedByYear = bookRepository.GetAllBooksSortedByPublicationYearDescending();
                Console.WriteLine("Книги, отсортированные по году выхода (убывание):");
                foreach (var book in booksSortedByYear)
                {
                    Console.WriteLine($"{book.Title} ({book.PublicationYear})");
                }
            }
        }
    }
}