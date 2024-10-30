using EFCORE_25.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE_25.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly EFCORE_25.Data.AppContext _context;

        public AuthorRepository(EFCORE_25.Data.AppContext context)
        {
            _context = context;
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var author = GetAuthorById(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
