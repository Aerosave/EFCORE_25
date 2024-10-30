using EFCORE_25.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE_25.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly EFCORE_25.Data.AppContext _context;

        public GenreRepository(EFCORE_25.Data.AppContext context)
        {
            _context = context;
        }

        public Genre GetGenreById(int id)
        {
            return _context.Genres.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }

        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void DeleteGenre(int id)
        {
            var genre = GetGenreById(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
        }
    }
}
