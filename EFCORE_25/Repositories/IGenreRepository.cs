using EFCORE_25.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE_25.Repositories
{
    public interface IGenreRepository
    {
        Genre GetGenreById(int id);
        IEnumerable<Genre> GetAllGenres();
        void AddGenre(Genre genre);
        void DeleteGenre(int id);
    }
}