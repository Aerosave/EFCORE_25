﻿using EFCORE_25.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE_25.Repositories
{
    public interface IAuthorRepository
    {
        Author GetAuthorById(int id);
        IEnumerable<Author> GetAllAuthors();
        void AddAuthor(Author author);
        void DeleteAuthor(int id);
    }
}